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
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonContractsPocOsTemplateBody,
        SentDmServicesCommonContractsPocOsTemplateBodyFromRaw
    >)
)]
public sealed record class SentDmServicesCommonContractsPocOsTemplateBody : JsonModel
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
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public SentDmServicesCommonContractsPocOsTemplateBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonContractsPocOsTemplateBody(
        SentDmServicesCommonContractsPocOsTemplateBody sentDmServicesCommonContractsPocOsTemplateBody
    )
        : base(sentDmServicesCommonContractsPocOsTemplateBody) { }
#pragma warning restore CS8618

    public SentDmServicesCommonContractsPocOsTemplateBody(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonContractsPocOsTemplateBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonContractsPocOsTemplateBodyFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonContractsPocOsTemplateBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonContractsPocOsTemplateBodyFromRaw
    : IFromRawJson<SentDmServicesCommonContractsPocOsTemplateBody>
{
    /// <inheritdoc/>
    public SentDmServicesCommonContractsPocOsTemplateBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonContractsPocOsTemplateBody.FromRawUnchecked(rawData);
}
