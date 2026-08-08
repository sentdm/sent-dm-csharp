using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Body section of a message template with channel-specific content
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateBody, TemplateBodyFromRaw>))]
public sealed record class TemplateBody : JsonModel
{
    /// <summary>
    /// Content that will be used for all channels (SMS and WhatsApp) unless channel-specific
    /// content is provided
    /// </summary>
    public TemplateBodyContent? MultiChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("multiChannel");
        }
        init { this._rawData.Set("multiChannel", value); }
    }

    /// <summary>
    /// RCS-specific content that overrides multi-channel content for RCS messages
    /// </summary>
    public TemplateBodyContent? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("rcs");
        }
        init { this._rawData.Set("rcs", value); }
    }

    /// <summary>
    /// SMS-specific content that overrides multi-channel content for SMS messages
    /// </summary>
    public TemplateBodyContent? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("sms");
        }
        init { this._rawData.Set("sms", value); }
    }

    /// <summary>
    /// WhatsApp-specific content that overrides multi-channel content for WhatsApp messages
    /// </summary>
    public TemplateBodyContent? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateBodyContent>("whatsapp");
        }
        init { this._rawData.Set("whatsapp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MultiChannel?.Validate();
        this.Rcs?.Validate();
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public TemplateBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateBody(TemplateBody templateBody)
        : base(templateBody) { }
#pragma warning restore CS8618

    public TemplateBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateBodyFromRaw.FromRawUnchecked"/>
    public static TemplateBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateBodyFromRaw : IFromRawJson<TemplateBody>
{
    /// <inheritdoc/>
    public TemplateBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateBody.FromRawUnchecked(rawData);
}
