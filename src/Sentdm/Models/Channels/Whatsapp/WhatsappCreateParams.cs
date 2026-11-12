using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Whatsapp;

/// <summary>
/// Connects a WhatsApp Business Account shared with us through a Multi-Partner Solution
/// to the calling sender profile. Send `x-profile-id` for the profile the account
/// belongs to.
///
/// <para>**Two fields, because everything else is derived.** `waba_id` says which
/// of your organization's shared accounts this is — you hold one per client, and
/// nothing else can say which. `phone_number_id` names the account's number, which
/// is what assigns it to the profile as the number it sends from.</para>
///
/// <para>The solution the account arrived through, the client business portfolio
/// that owns it, the access token and its expiry are all resolved from your organization.
/// They are not accepted here: the first two are Meta's answer about provenance,
/// and the token is minted per client business and rotates roughly every sixty days,
/// so a value you sent would be stale before it was useful.</para>
///
/// <para>`phone_number_id` is optional. Omit it to connect the account now and settle
/// the number later — the channel reads as `ACTION_NEEDED` with `reason_code` `CHANNEL_007`,
/// and the profile's WhatsApp messages fail until a number is named. They do not
/// fall back to your organization's account. Call this endpoint again with `phone_number_id`
/// to name one.</para>
///
/// <para>The same resolution runs behind `channels.whatsapp` on `POST /v3/sender-profiles`,
/// so connecting at create and connecting afterwards fill the same fields.</para>
///
/// <para>Returns **the account**, not every channel you have — adding one cannot
/// change a market or an RCS agent, and `GET /v3/channels` is the whole picture.
/// Giving an account up is not self-service: ask support, because deregistering a
/// number lands in your own Meta business.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WhatsappCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Meta phone-number id of the number on WabaId, which assigns it to this
    /// profile as the number it sends from. It is not checked against the account
    /// here, so name the account's number; it is refused if another profile already
    /// uses it.              Optional: omit it to connect the account and settle
    /// the number later. Nothing picks one on your behalf.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phone_number_id");
        }
        init { this._rawBodyData.Set("phone_number_id", value); }
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

    /// <summary>
    /// WhatsApp Business Account id — one of the accounts shared into your organization.
    /// Required: the organization holds one per client, and nothing but the caller
    /// says which is meant here.
    /// </summary>
    public string? WabaID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("waba_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("waba_id", value);
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

    public WhatsappCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappCreateParams(WhatsappCreateParams whatsappCreateParams)
        : base(whatsappCreateParams)
    {
        this._rawBodyData = new(whatsappCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WhatsappCreateParams(
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
    WhatsappCreateParams(
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WhatsappCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WhatsappCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/whatsapp")
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
