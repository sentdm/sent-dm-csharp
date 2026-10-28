using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Voices;

/// <summary>
/// The voices and languages a text-session agent may name in its speech settings:
/// what GET /v3/voice/voices and the admin GET /voice/voices answer, in one shape.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceCatalogue, VoiceCatalogueFromRaw>))]
public sealed record class VoiceCatalogue : JsonModel
{
    /// <summary>
    /// BCP 47 tags accepted as speech.language.
    /// </summary>
    public IReadOnlyList<string>? Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("languages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "languages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<VoiceCatalogueVoice>? Voices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceCatalogueVoice>>("voices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceCatalogueVoice>?>(
                "voices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Languages;
        foreach (var item in this.Voices ?? [])
        {
            item.Validate();
        }
    }

    public VoiceCatalogue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCatalogue(VoiceCatalogue voiceCatalogue)
        : base(voiceCatalogue) { }
#pragma warning restore CS8618

    public VoiceCatalogue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCatalogue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCatalogueFromRaw.FromRawUnchecked"/>
    public static VoiceCatalogue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCatalogueFromRaw : IFromRawJson<VoiceCatalogue>
{
    /// <inheritdoc/>
    public VoiceCatalogue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceCatalogue.FromRawUnchecked(rawData);
}
