using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// A freshly rotated callback signing secret
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceSecret, VoiceSecretFromRaw>))]
public sealed record class VoiceSecret : JsonModel
{
    /// <summary>
    /// The new whsec_ secret. The previous one stopped signing the moment this was
    /// returned, so update your backend before the next call reaches it. Shown once.
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

    public VoiceSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSecret(VoiceSecret voiceSecret)
        : base(voiceSecret) { }
#pragma warning restore CS8618

    public VoiceSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSecretFromRaw.FromRawUnchecked"/>
    public static VoiceSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceSecretFromRaw : IFromRawJson<VoiceSecret>
{
    /// <inheritdoc/>
    public VoiceSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceSecret.FromRawUnchecked(rawData);
}
