using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Voice.Catalogue;

[JsonConverter(typeof(JsonModelConverter<VoiceCatalogueVoice, VoiceCatalogueVoiceFromRaw>))]
public sealed record class VoiceCatalogueVoice : JsonModel
{
    /// <summary>
    /// Whether this is the voice used when an agent names none.
    /// </summary>
    public bool? Default
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("default");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("default", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The language the voice speaks.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// The value to send as speech.voice.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Default;
        _ = this.Description;
        _ = this.Language;
        _ = this.Name;
    }

    public VoiceCatalogueVoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCatalogueVoice(VoiceCatalogueVoice voiceCatalogueVoice)
        : base(voiceCatalogueVoice) { }
#pragma warning restore CS8618

    public VoiceCatalogueVoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCatalogueVoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCatalogueVoiceFromRaw.FromRawUnchecked"/>
    public static VoiceCatalogueVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceCatalogueVoiceFromRaw : IFromRawJson<VoiceCatalogueVoice>
{
    /// <inheritdoc/>
    public VoiceCatalogueVoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceCatalogueVoice.FromRawUnchecked(rawData);
}
