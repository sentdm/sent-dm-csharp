using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Complete definition of a message template including header, body, footer, and buttons
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateDefinition, TemplateDefinitionFromRaw>))]
public sealed record class TemplateDefinition : JsonModel
{
    /// <summary>
    /// Required template body with content for different channels (multi-channel,
    /// SMS-specific, or WhatsApp-specific)
    /// </summary>
    public required SentDmServicesCommonContractsPocOsTemplateBody Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SentDmServicesCommonContractsPocOsTemplateBody>(
                "body"
            );
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Configuration specific to AUTHENTICATION category templates (optional)
    /// </summary>
    public SentDmServicesCommonContractsPocOsAuthenticationConfig? AuthenticationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesCommonContractsPocOsAuthenticationConfig>(
                "authenticationConfig"
            );
        }
        init { this._rawData.Set("authenticationConfig", value); }
    }

    /// <summary>
    /// Optional list of interactive buttons (e.g., quick replies, URLs, phone numbers)
    /// </summary>
    public IReadOnlyList<SentDmServicesCommonContractsPocOsTemplateButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SentDmServicesCommonContractsPocOsTemplateButton>
            >("buttons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SentDmServicesCommonContractsPocOsTemplateButton>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The version of the template definition format
    /// </summary>
    public string? DefinitionVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("definitionVersion");
        }
        init { this._rawData.Set("definitionVersion", value); }
    }

    /// <summary>
    /// Optional template footer with optional variables
    /// </summary>
    public SentDmServicesCommonContractsPocOsTemplateFooter? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesCommonContractsPocOsTemplateFooter>(
                "footer"
            );
        }
        init { this._rawData.Set("footer", value); }
    }

    /// <summary>
    /// Optional template header with optional variables
    /// </summary>
    public SentDmServicesCommonContractsPocOsTemplateHeader? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesCommonContractsPocOsTemplateHeader>(
                "header"
            );
        }
        init { this._rawData.Set("header", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Body.Validate();
        this.AuthenticationConfig?.Validate();
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        _ = this.DefinitionVersion;
        this.Footer?.Validate();
        this.Header?.Validate();
    }

    public TemplateDefinition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateDefinition(TemplateDefinition templateDefinition)
        : base(templateDefinition) { }
#pragma warning restore CS8618

    public TemplateDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateDefinitionFromRaw.FromRawUnchecked"/>
    public static TemplateDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateDefinition(SentDmServicesCommonContractsPocOsTemplateBody body)
        : this()
    {
        this.Body = body;
    }
}

class TemplateDefinitionFromRaw : IFromRawJson<TemplateDefinition>
{
    /// <inheritdoc/>
    public TemplateDefinition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateDefinition.FromRawUnchecked(rawData);
}
