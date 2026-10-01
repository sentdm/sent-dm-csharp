using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// Adds voice to one of the numbers you hold, or gives you a new one. Send `number`
/// for a number that is already yours (see `GET /v3/channels`); leave it out to be
/// given a new US number, optionally in a particular `area_code`. Sending both is
/// refused. Nothing registers, so the number can carry calls as soon as this returns.
///
/// <para>What happens on a call is decided by your `callback_url`: when a call arrives
/// on the number, or a caller presses a key on a menu, Sent POSTs a signed question
/// there and follows the answer. The response carries the `callback_secret` the
/// questions are signed with, the one time it is shown without rotating; verify a
/// question the way you verify a webhook. `POST /v3/channels/voice/{number}/test`
/// sends a test question and reports the verdict.</para>
///
/// <para>Your first voice number becomes the line app-originated calls are placed
/// from when a voice token names no number; send `default_for_app_calls: true` to
/// give that role to another number. A number you turned off earlier is turned back
/// on, and the same number with a different `callback_url` has its URL replaced and
/// keeps its secret.</para>
///
/// <para>Read the number's settings with `GET /v3/channels/voice` and change them
/// with `PATCH /v3/channels/voice/{number}`.</para>
///
/// <para>With `sandbox: true` the request is validated and a simulated number reported
/// with `202`; nothing is written and no number is bought.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Where Sent asks what to do with each call on this number: an absolute HTTP
    /// or HTTPS URL on a public host. A signed question is POSTed here when a call
    /// arrives or a caller presses a key, and the answer decides the call. Every
    /// question is signed with the callback_secret the response returns, the same
    /// way your webhooks are signed. Turning the number on again with a different
    /// URL replaces it and keeps the secret.
    /// </summary>
    public required string CallbackUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("callback_url");
        }
        init { this._rawBodyData.Set("callback_url", value); }
    }

    /// <summary>
    /// The US area code a new number should be in, as 212. Only for a request that
    /// leaves number out — sending both says two different things about which number
    /// to use, and is refused. Omit it too and the number comes from anywhere in
    /// the country.
    /// </summary>
    public string? AreaCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("area_code");
        }
        init { this._rawBodyData.Set("area_code", value); }
    }

    /// <summary>
    /// Make this the line app-originated calls are placed from when a voice token
    /// names no number. Omit it and your first voice number takes that role; a later
    /// one leaves it where it is.
    /// </summary>
    public bool? DefaultForAppCalls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("default_for_app_calls");
        }
        init { this._rawBodyData.Set("default_for_app_calls", value); }
    }

    /// <summary>
    /// One of your phone numbers, in E.164 format. Leave the field out entirely to
    /// be given a new one instead; sending it empty is a refused request rather
    /// than a request for a new number.
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("number");
        }
        init { this._rawBodyData.Set("number", value); }
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

    public VoiceCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCreateParams(VoiceCreateParams voiceCreateParams)
        : base(voiceCreateParams)
    {
        this._rawBodyData = new(voiceCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VoiceCreateParams(
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
    VoiceCreateParams(
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
    public static VoiceCreateParams FromRawUnchecked(
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

    public virtual bool Equals(VoiceCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/voice")
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
