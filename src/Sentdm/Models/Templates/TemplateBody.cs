using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Body section of a message template.              A body picks one of two authoring
/// strategies, and mixing them is refused (TemplateDefinitionValidator.HaveValidChannelConfiguration):
/// a shared multiChannel body on its own, or an explicit sms + whatsapp pair, both
/// present.              multiChannel together with sms or whatsapp is rejected,
/// and so is sms or whatsapp on its own — every template is expected to be deliverable
/// on every channel. rcs is the one true override: it may accompany either strategy
/// to vary the copy, but cannot stand alone.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateBody, TemplateBodyFromRaw>))]
public sealed record class TemplateBody : JsonModel
{
    /// <summary>
    /// The shared body, used for every channel. One half of the choice described above.
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
    /// RCS-specific copy that overrides the chosen strategy for RCS only. The one
    /// true override: optional on top of either strategy, but it cannot be the only
    /// body present. Its length cap is the higher one described on Template.
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
    /// The SMS body. It does not override multiChannel, it replaces it.
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
    /// The WhatsApp body. It does not override multiChannel, it replaces it.
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
