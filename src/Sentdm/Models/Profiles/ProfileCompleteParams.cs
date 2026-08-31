using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
/// removed in a future release. It still behaves exactly as before, so nothing needs
/// to change today — but new integrations should use `/v3/sender-profiles`, which
/// models a profile's markets, compliance, brand, campaigns and billing explicitly.
///
/// <para>Final step in the profile compliance workflow. Validates all prerequisites
/// (KYC, brand, campaigns, required documents), connects the profile to the SMS and
/// WhatsApp channels, and marks it onboarded. Prerequisites are always validated
/// first: if any fail the call returns 400 naming every unmet one, and nothing is
/// started. If they pass and the profile is already onboarded, the call returns
/// 200 and does nothing. Otherwise it returns 202 and calls the provided webhook
/// URL when background processing finishes.</para>
///
/// <para>Callable with the organization's API key or the profile's own key. The
/// key's user must be an admin or owner of the profile, or of the organization it
/// belongs to.</para>
///
/// <para>Prerequisites (all but the last are checked before the already-onboarded
/// short-circuit, matching the previous contract; the last is checked after it, so
/// a profile that is already onboarded is never rejected by it): - Profile must
/// have a name, short name, and description (short name max 50 characters, description
/// max 5000) - webHookUrl must be supplied on the request - A KYC form submission
/// is required - A brand is required, either on the profile or inherited from the
/// parent organization - TCR applications must have at least one campaign, own or
/// inherited - Destination countries marked as main must have their required compliance
/// documents uploaded - TCR applications must state whether they inherit the organization's
/// TCR brand and campaign</para>
///
/// <para>Outcome: - Once the prerequisites pass and background processing succeeds,
/// the profile's conversionFlowStatus becomes ONBOARDED and its public status reads
/// `approved` - A profile with no WhatsApp channel, or one still awaiting TCR registration
/// or country documents, is onboarded like any other. Those are answered by the brand
/// and campaign records, not by a status on the profile - If background processing
/// fails, the profile keeps the status it already had and the webhook reports the reason</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class ProfileCompleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProfileID { get; init; }

    /// <summary>
    /// Webhook URL to call when profile completion finishes (success or failure)
    /// </summary>
    public required string WebHookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("webHookUrl");
        }
        init { this._rawBodyData.Set("webHookUrl", value); }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
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

    public ProfileCompleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCompleteParams(ProfileCompleteParams profileCompleteParams)
        : base(profileCompleteParams)
    {
        this.ProfileID = profileCompleteParams.ProfileID;

        this._rawBodyData = new(profileCompleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProfileCompleteParams(
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
    ProfileCompleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProfileCompleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
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

    public virtual bool Equals(ProfileCompleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/profiles/{0}/complete", this.ProfileID)
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
