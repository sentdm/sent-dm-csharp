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
[JsonConverter(typeof(JsonModelConverter<TemplateButton, TemplateButtonFromRaw>))]
public sealed record class TemplateButton : JsonModel
{
    /// <summary>
    /// Properties specific to the button type
    /// </summary>
    public required TemplateButtonProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateButtonProps>("props");
        }
        init { this._rawData.Set("props", value); }
    }

    /// <summary>
    /// The type of button (e.g., QUICK_REPLY, URL, PHONE_NUMBER, VOICE_CALL, COPY_CODE)
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Props.Validate();
        _ = this.Type;
        _ = this.ID;
    }

    public TemplateButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateButton(TemplateButton templateButton)
        : base(templateButton) { }
#pragma warning restore CS8618

    public TemplateButton(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateButton(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateButtonFromRaw.FromRawUnchecked"/>
    public static TemplateButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateButtonFromRaw : IFromRawJson<TemplateButton>
{
    /// <inheritdoc/>
    public TemplateButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateButton.FromRawUnchecked(rawData);
}
