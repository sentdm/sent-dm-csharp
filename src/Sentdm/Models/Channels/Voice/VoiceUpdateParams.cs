using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// Changes one of your voice numbers and answers with the number as stored, the
/// same shape `GET` on this path returns, so what comes back can be sent back.
///
/// <para>## What it changes</para>
///
/// <para>| Body | Effect | | --- | --- | | `"status": "ACTIVE"` | turns calls on
/// again for a number you turned off; the callback URL and the secret it had are
/// kept | | `"status": "INACTIVE"` | turns calls off; the callback URL and the secret
/// stay on the number | | `"default_for_app_calls": true` | makes this the line app-originated
/// calls are placed from when a voice token names no number | | `"callback_url":
/// "https://example.com/voice"` | replaces where Sent asks what to do with each call
/// on the number; the signing secret and the status are kept | | `"agent_id": "agent_…"`
/// | one of your voice agents answers calls to the number, within about an hour
/// of the change (the provider applies the move on its own clock, and `routes_to`
/// reads `agent` as soon as it has recorded it); it wins over `callback_url` for
/// calls to the number, and calls your app places from it still follow your app.
/// `routes_to` reads `agent_pending` while the number is still being moved to the
/// agent | | `"agent_id": null` | unbinds the agent, so `callback_url` answers calls
/// to the number again | | key omitted | left exactly as it is |</para>
///
/// <para>`status` is matched ignoring case. Any combination is accepted: `status:
/// "ACTIVE"` with `default_for_app_calls: true` turns a number on as the new default,
/// and a `callback_url` sent with either status is written too. `agent_id` is applied
/// first, so a refusal to move the number to or from the agent leaves everything
/// as it was, and the `409` and `400` refusals below are decided before anything
/// is written, so they leave everything as it was too. A body that names none of
/// them is refused.</para>
///
/// <para>A number can be on without a callback URL: calls placed from your app then
/// connect straight to the number or user they dial, and calls to the number are declined.</para>
///
/// <para>## What it will refuse</para>
///
/// <para>**`default_for_app_calls: false` is `400`.** An account with active voice
/// numbers always has exactly one default, so the default moves by giving it to another number.</para>
///
/// <para>**Turning the default line off is `409`** while other active voice numbers
/// remain. Move the default to another number first. Turning off your last voice
/// number is allowed; that turns phone calls off.</para>
///
/// <para>**Making an inactive number the default is `400`.** Send `status: "ACTIVE"`
/// in the same call.</para>
///
/// <para>**A number you never turned voice on for is `404`**, and so is an `agent_id`
/// that is not one of your agents. Add the number with `POST /v3/channels/voice`.</para>
///
/// <para>**`502` means the number could not be moved to or from the agent**, or
/// an `agent_id` was sent while numbers cannot be bound to agents; nothing was written.</para>
///
/// <para>The number is the E.164 value in the path with the plus sign URL-encoded (`%2B`).</para>
///
/// <para>With `sandbox: true` nothing is written: the request is validated against
/// the stored number and the number is reported with `200` as it would read after
/// the change.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? Number { get; init; }

    /// <summary>
    /// One of your voice agents, such as agent_9f2ab000-0000-4000-8000-000000000001,
    /// to answer calls to the number, or null to unbind it so the callback URL answers
    /// them again. The agent wins over callback_url for calls to the number; calls
    /// your app places from it still follow your app.
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("agent_id");
        }
        init { this._rawBodyData.Set("agent_id", value); }
    }

    /// <summary>
    /// A new callback URL for the number, active or not: an absolute HTTP or HTTPS
    /// URL on a public host, where Sent asks what to do with each call. The signing
    /// secret is kept.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callback_url");
        }
        init { this._rawBodyData.Set("callback_url", value); }
    }

    /// <summary>
    /// true makes this the line app-originated calls are placed from when a voice
    /// token names no number. false is refused: an account with active voice numbers
    /// always has exactly one default, so the default moves by giving it to another number.
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
    /// ACTIVE turns calls on for the number again, INACTIVE turns them off. Matched
    /// ignoring case. Turning the default line off is refused while other active
    /// voice numbers remain.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawBodyData.Set("status", value); }
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

    public VoiceUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceUpdateParams(VoiceUpdateParams voiceUpdateParams)
        : base(voiceUpdateParams)
    {
        this.Number = voiceUpdateParams.Number;

        this._rawBodyData = new(voiceUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VoiceUpdateParams(
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
    VoiceUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string number
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Number = number;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoiceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string number
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            number
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Number"] = JsonSerializer.SerializeToElement(this.Number),
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

    public virtual bool Equals(VoiceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Number?.Equals(other.Number) ?? other.Number == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/channels/voice/{0}", this.Number)
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
/// ACTIVE turns calls on for the number again, INACTIVE turns them off. Matched ignoring
/// case. Turning the default line off is refused while other active voice numbers remain.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// Turns calls on for the number again. The callback URL and the signing secret
    /// it had are kept; send `callback_url` in the same call to replace the URL.
    /// </summary>
    Active,

    /// <summary>
    /// Turns calls off for the number. Refused while the number is the default line
    /// for app calls and other active voice numbers remain; move the default first.
    /// The callback URL and the secret stay on the number.
    /// </summary>
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => Status.Active,
            "INACTIVE" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "ACTIVE",
                Status.Inactive => "INACTIVE",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
