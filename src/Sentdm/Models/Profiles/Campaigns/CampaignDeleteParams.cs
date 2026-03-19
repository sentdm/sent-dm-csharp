using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles.Campaigns;

/// <summary>
/// Deletes a campaign by ID from the brand of the specified profile. The profile
/// must belong to the authenticated organization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CampaignDeleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ProfileID { get; init; }

    public string? CampaignID { get; init; }

    /// <summary>
    /// Request to delete a campaign from a brand
    /// </summary>
    public required global::Sentdm.Models.Profiles.Campaigns.Body Body
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<global::Sentdm.Models.Profiles.Campaigns.Body>(
                "body"
            );
        }
        init { this._rawBodyData.Set("body", value); }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public CampaignDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignDeleteParams(CampaignDeleteParams campaignDeleteParams)
        : base(campaignDeleteParams)
    {
        this.ProfileID = campaignDeleteParams.ProfileID;
        this.CampaignID = campaignDeleteParams.CampaignID;

        this._rawBodyData = new(campaignDeleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CampaignDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID,
        string campaignID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
        this.CampaignID = campaignID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CampaignDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID,
        string campaignID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID,
            campaignID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
                    ["CampaignID"] = JsonSerializer.SerializeToElement(this.CampaignID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CampaignDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ProfileID.Equals(other.ProfileID)
            && (this.CampaignID?.Equals(other.CampaignID) ?? other.CampaignID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/profiles/{0}/campaigns/{1}", this.ProfileID, this.CampaignID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Request to delete a campaign from a brand
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Sentdm.Models.Profiles.Campaigns.Body,
        global::Sentdm.Models.Profiles.Campaigns.BodyFromRaw
    >)
)]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sandbox", value);
        }
    }

    public static implicit operator MutationRequest(
        global::Sentdm.Models.Profiles.Campaigns.Body body
    ) => new() { Sandbox = body.Sandbox };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Sandbox;
    }

    public Body() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body(global::Sentdm.Models.Profiles.Campaigns.Body body)
        : base(body) { }
#pragma warning restore CS8618

    public Body(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Body(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Sentdm.Models.Profiles.Campaigns.BodyFromRaw.FromRawUnchecked"/>
    public static global::Sentdm.Models.Profiles.Campaigns.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyFromRaw : IFromRawJson<global::Sentdm.Models.Profiles.Campaigns.Body>
{
    /// <inheritdoc/>
    public global::Sentdm.Models.Profiles.Campaigns.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Sentdm.Models.Profiles.Campaigns.Body.FromRawUnchecked(rawData);
}
