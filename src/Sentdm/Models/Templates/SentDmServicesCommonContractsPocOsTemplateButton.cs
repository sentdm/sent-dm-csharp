using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Interactive button in a message template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonContractsPocOsTemplateButton,
        SentDmServicesCommonContractsPocOsTemplateButtonFromRaw
    >)
)]
public sealed record class SentDmServicesCommonContractsPocOsTemplateButton : JsonModel
{
    /// <summary>
    /// The unique identifier of the button (1-based index)
    /// </summary>
    public int? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Properties specific to the button type
    /// </summary>
    public SentDmServicesCommonContractsPocOsTemplateButtonProps? Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SentDmServicesCommonContractsPocOsTemplateButtonProps>(
                "props"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("props", value);
        }
    }

    /// <summary>
    /// The type of button (e.g., QUICK_REPLY, URL, PHONE_NUMBER, VOICE_CALL, COPY_CODE)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Props?.Validate();
        _ = this.Type;
    }

    public SentDmServicesCommonContractsPocOsTemplateButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonContractsPocOsTemplateButton(
        SentDmServicesCommonContractsPocOsTemplateButton sentDmServicesCommonContractsPocOsTemplateButton
    )
        : base(sentDmServicesCommonContractsPocOsTemplateButton) { }
#pragma warning restore CS8618

    public SentDmServicesCommonContractsPocOsTemplateButton(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonContractsPocOsTemplateButton(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonContractsPocOsTemplateButtonFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonContractsPocOsTemplateButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonContractsPocOsTemplateButtonFromRaw
    : IFromRawJson<SentDmServicesCommonContractsPocOsTemplateButton>
{
    /// <inheritdoc/>
    public SentDmServicesCommonContractsPocOsTemplateButton FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonContractsPocOsTemplateButton.FromRawUnchecked(rawData);
}
