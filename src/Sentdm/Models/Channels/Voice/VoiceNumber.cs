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
[JsonConverter(typeof(JsonModelConverter<VoiceNumber, VoiceNumberFromRaw>))]
public sealed record class VoiceNumber : JsonModel
{
    /// <summary>
    /// The voice agent calls to this number go to, such as agent_9f2ab000-0000-4000-8000-000000000001.
    /// It wins over callback_url for calls to the number; calls your app places from
    /// the number still follow your app. Null when no agent answers the number.
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init { this._rawData.Set("agent_id", value); }
    }

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
    /// Who answers calls to this number: agent, the voice agent in agent_id; agent_pending,
    /// that agent once the number has finished moving to it, with calls possibly
    /// unanswered until then; callback, your callback_url; or none, in which case
    /// calls to it are declined.
    /// </summary>
    public string? RoutesTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("routes_to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("routes_to", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        _ = this.CallbackUrl;
        _ = this.CreatedAt;
        _ = this.DefaultForAppCalls;
        _ = this.Number;
        _ = this.RoutesTo;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public VoiceNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceNumber(VoiceNumber voiceNumber)
        : base(voiceNumber) { }
#pragma warning restore CS8618

    public VoiceNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceNumberFromRaw.FromRawUnchecked"/>
    public static VoiceNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceNumberFromRaw : IFromRawJson<VoiceNumber>
{
    /// <inheritdoc/>
    public VoiceNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceNumber.FromRawUnchecked(rawData);
}
