using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// One attachment on an MMS template body.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateMediaItem, TemplateMediaItemFromRaw>))]
public sealed record class TemplateMediaItem : JsonModel
{
    /// <summary>
    /// One of MmsMediaTypes. Advisory: the carrier reads the Content-Type off the
    ///             fetched object, not this field. It exists so an authoring UI
    /// can render the right preview and so a             reviewer can see what was intended.
    /// </summary>
    public string? MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    /// <summary>
    /// Publicly fetchable https URL. The carrier's MMSC fetches this at send time,
    /// so it has to             stay reachable and unauthenticated for the life of
    /// the send — including retries and a DLQ             replay — which is why a
    /// presigned URL is not a valid value here.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaType;
        _ = this.Url;
    }

    public TemplateMediaItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateMediaItem(TemplateMediaItem templateMediaItem)
        : base(templateMediaItem) { }
#pragma warning restore CS8618

    public TemplateMediaItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateMediaItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateMediaItemFromRaw.FromRawUnchecked"/>
    public static TemplateMediaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateMediaItemFromRaw : IFromRawJson<TemplateMediaItem>
{
    /// <inheritdoc/>
    public TemplateMediaItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateMediaItem.FromRawUnchecked(rawData);
}
