using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Agents;

/// <summary>
/// A freshly rotated signing secret.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceAgentSecret, VoiceAgentSecretFromRaw>))]
public sealed record class VoiceAgentSecret : JsonModel
{
    /// <summary>
    /// The new whsec_ secret. The previous one stopped signing the moment this was
    /// returned. Shown once.
    /// </summary>
    public string? SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signing_secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signing_secret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SigningSecret;
    }

    public VoiceAgentSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceAgentSecret(VoiceAgentSecret voiceAgentSecret)
        : base(voiceAgentSecret) { }
#pragma warning restore CS8618

    public VoiceAgentSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceAgentSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceAgentSecretFromRaw.FromRawUnchecked"/>
    public static VoiceAgentSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceAgentSecretFromRaw : IFromRawJson<VoiceAgentSecret>
{
    /// <inheritdoc/>
    public VoiceAgentSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceAgentSecret.FromRawUnchecked(rawData);
}
