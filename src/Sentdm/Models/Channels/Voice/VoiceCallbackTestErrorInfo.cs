using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// Why the test did not end with ok
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VoiceCallbackTestErrorInfo, VoiceCallbackTestErrorInfoFromRaw>)
)]
public sealed record class VoiceCallbackTestErrorInfo : JsonModel
{
    /// <summary>
    /// What to fix
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Dotted path of the answer field at fault, such as action.action, when one
    /// field is to blame
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// Machine-readable reason, such as timeout, http_error, malformed_json, missing_action
    /// or unknown_action
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Path;
        _ = this.Reason;
    }

    public VoiceCallbackTestErrorInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCallbackTestErrorInfo(VoiceCallbackTestErrorInfo voiceCallbackTestErrorInfo)
        : base(voiceCallbackTestErrorInfo) { }
#pragma warning restore CS8618

    public VoiceCallbackTestErrorInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCallbackTestErrorInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCallbackTestErrorInfoFromRaw.FromRawUnchecked"/>
    public static VoiceCallbackTestErrorInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCallbackTestErrorInfoFromRaw : IFromRawJson<VoiceCallbackTestErrorInfo>
{
    /// <inheritdoc/>
    public VoiceCallbackTestErrorInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceCallbackTestErrorInfo.FromRawUnchecked(rawData);
}
