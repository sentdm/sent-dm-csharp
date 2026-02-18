using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using SentDm.Models.Webhooks;

namespace SentDm.Models.Brands.Campaigns;

/// <summary>
/// Deletes a campaign by ID within a specific brand. The brand must belong to the
/// authenticated customer.
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

    public required string BrandID { get; init; }

    public string? CampaignID { get; init; }

    /// <summary>
    /// Request to delete a campaign from a brand
    /// </summary>
    public required global::SentDm.Models.Brands.Campaigns.Body Body
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<global::SentDm.Models.Brands.Campaigns.Body>(
                "body"
            );
        }
        init { this._rawBodyData.Set("body", value); }
    }

    public CampaignDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignDeleteParams(CampaignDeleteParams campaignDeleteParams)
        : base(campaignDeleteParams)
    {
        this.BrandID = campaignDeleteParams.BrandID;
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
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CampaignDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BrandID"] = JsonSerializer.SerializeToElement(this.BrandID),
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
        return this.BrandID.Equals(other.BrandID)
            && (this.CampaignID?.Equals(other.CampaignID) ?? other.CampaignID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/brands/{0}/campaigns/{1}", this.BrandID, this.CampaignID)
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
        global::SentDm.Models.Brands.Campaigns.Body,
        global::SentDm.Models.Brands.Campaigns.BodyFromRaw
    >)
)]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Test mode flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? TestMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("test_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("test_mode", value);
        }
    }

    public static implicit operator MutationRequest(
        global::SentDm.Models.Brands.Campaigns.Body body
    ) => new() { TestMode = body.TestMode };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TestMode;
    }

    public Body() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body(global::SentDm.Models.Brands.Campaigns.Body body)
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

    /// <inheritdoc cref="global::SentDm.Models.Brands.Campaigns.BodyFromRaw.FromRawUnchecked"/>
    public static global::SentDm.Models.Brands.Campaigns.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyFromRaw : IFromRawJson<global::SentDm.Models.Brands.Campaigns.Body>
{
    /// <inheritdoc/>
    public global::SentDm.Models.Brands.Campaigns.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::SentDm.Models.Brands.Campaigns.Body.FromRawUnchecked(rawData);
}
