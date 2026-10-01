using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// The verdict of a test question sent to your callback URL
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceCallbackTest, VoiceCallbackTestFromRaw>))]
public sealed record class VoiceCallbackTest : JsonModel
{
    /// <summary>
    /// Your answer as Sent read it, with numbers in E.164 and a missing caller id
    /// filled in. Set only when the outcome is ok.
    /// </summary>
    public JsonElement? Answer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("answer");
        }
        init { this._rawData.Set("answer", value); }
    }

    /// <summary>
    /// The call id the test question carried. It does not exist anywhere else and
    /// cannot be looked up.
    /// </summary>
    public string? CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("call_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("call_id", value);
        }
    }

    /// <summary>
    /// Why the test did not end with ok
    /// </summary>
    public VoiceCallbackTestErrorInfo? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceCallbackTestErrorInfo>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// What happened: ok, timeout, connection_failed, http_error or invalid_answer
    /// </summary>
    public string? Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("outcome");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outcome", value);
        }
    }

    /// <summary>
    /// The test question exactly as it was sent
    /// </summary>
    public VoiceCallbackTestRequestInfo? Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceCallbackTestRequestInfo>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// What your endpoint answered
    /// </summary>
    public VoiceCallbackTestResponseInfo? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceCallbackTestResponseInfo>("response");
        }
        init { this._rawData.Set("response", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Answer;
        _ = this.CallID;
        this.Error?.Validate();
        _ = this.Outcome;
        this.Request?.Validate();
        this.Response?.Validate();
    }

    public VoiceCallbackTest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCallbackTest(VoiceCallbackTest voiceCallbackTest)
        : base(voiceCallbackTest) { }
#pragma warning restore CS8618

    public VoiceCallbackTest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCallbackTest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCallbackTestFromRaw.FromRawUnchecked"/>
    public static VoiceCallbackTest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCallbackTestFromRaw : IFromRawJson<VoiceCallbackTest>
{
    /// <inheritdoc/>
    public VoiceCallbackTest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceCallbackTest.FromRawUnchecked(rawData);
}
