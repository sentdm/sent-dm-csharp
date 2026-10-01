using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// One number the profile carries phone calls on.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceNumberCreated, VoiceNumberCreatedFromRaw>))]
public sealed record class VoiceNumberCreated : JsonModel
{
    /// <summary>
    /// Where Sent asks what to do with each call on this number: a signed question
    /// is POSTed here when a call arrives or a caller presses a key, and the answer
    /// decides the call. The signing secret is not on this read; it is shown when
    /// voice is turned on and by the rotate endpoint.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url");
        }
        init { this._rawData.Set("callback_url", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Whether this is the line app-originated calls are placed from when a voice
    /// token names no number. Exactly one active voice number carries it while the
    /// profile has any.
    /// </summary>
    public bool? DefaultForAppCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("default_for_app_calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("default_for_app_calls", value);
        }
    }

    /// <summary>
    /// The number, in E.164.
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <summary>
    /// ACTIVE while the number carries calls, INACTIVE once it was turned off. Nothing
    /// provisions: a number the customer holds can carry calls the moment voice is
    /// turned on for it.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// The whsec_ secret every question to callback_url is signed with. Shown here
    /// and by POST /v3/channels/voice/{number}/rotate-secret, nowhere else: store
    /// it now. Verify a question exactly as you verify a webhook, with X-Webhook-ID,
    /// X-Webhook-Timestamp and the body.
    /// </summary>
    public string? CallbackSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_secret", value);
        }
    }

    public static implicit operator VoiceNumber(VoiceNumberCreated voiceNumberCreated) =>
        new()
        {
            CallbackUrl = voiceNumberCreated.CallbackUrl,
            CreatedAt = voiceNumberCreated.CreatedAt,
            DefaultForAppCalls = voiceNumberCreated.DefaultForAppCalls,
            Number = voiceNumberCreated.Number,
            Status = voiceNumberCreated.Status,
            UpdatedAt = voiceNumberCreated.UpdatedAt,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallbackUrl;
        _ = this.CreatedAt;
        _ = this.DefaultForAppCalls;
        _ = this.Number;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.CallbackSecret;
    }

    public VoiceNumberCreated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceNumberCreated(VoiceNumberCreated voiceNumberCreated)
        : base(voiceNumberCreated) { }
#pragma warning restore CS8618

    public VoiceNumberCreated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceNumberCreated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceNumberCreatedFromRaw.FromRawUnchecked"/>
    public static VoiceNumberCreated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceNumberCreatedFromRaw : IFromRawJson<VoiceNumberCreated>
{
    /// <inheritdoc/>
    public VoiceNumberCreated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceNumberCreated.FromRawUnchecked(rawData);
}

/// <summary>
/// A voice number as it was just turned on: the same facts GET /v3/channels reports,
/// plus the one it never shows, the signing secret.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties,
        SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponsePropertiesFromRaw
    >)
)]
public sealed record class SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
    : JsonModel
{
    /// <summary>
    /// The whsec_ secret every question to callback_url is signed with. Shown here
    /// and by POST /v3/channels/voice/{number}/rotate-secret, nowhere else: store
    /// it now. Verify a question exactly as you verify a webhook, with X-Webhook-ID,
    /// X-Webhook-Timestamp and the body.
    /// </summary>
    public string? CallbackSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_secret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallbackSecret;
    }

    public SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties(
        SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties sentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
    )
        : base(
            sentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
        ) { }
#pragma warning restore CS8618

    public SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponsePropertiesFromRaw.FromRawUnchecked"/>
    public static SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponsePropertiesFromRaw
    : IFromRawJson<SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties>
{
    /// <inheritdoc/>
    public SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties.FromRawUnchecked(
            rawData
        );
}
