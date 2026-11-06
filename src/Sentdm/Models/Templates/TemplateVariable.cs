using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateVariable, TemplateVariableFromRaw>))]
public sealed record class TemplateVariable : JsonModel
{
    /// <summary>
    /// The variable's name, and the key callers use for it in a send request's parameters
    /// object. Must start with a letter and hold only letters, digits and underscores.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required TemplateVariableProps Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateVariableProps>("props");
        }
        init { this._rawData.Set("props", value); }
    }

    /// <summary>
    /// One of variable, link or media. Decides which Props fields are required.
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
    /// The variable's index, and the number its {{index:variable}} placeholder refers
    /// to.              Omitting it is only safe for a section holding a single
    /// variable. The field is a non-nullable int, so every variable that leaves
    /// it out defaults to 0, and a section with two such variables is refused by
    /// the unique-id rule ("variables must have unique IDs"). Number them from 0
    /// in the order they appear.
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
        _ = this.Name;
        this.Props.Validate();
        _ = this.Type;
        _ = this.ID;
    }

    public TemplateVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateVariable(TemplateVariable templateVariable)
        : base(templateVariable) { }
#pragma warning restore CS8618

    public TemplateVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateVariableFromRaw.FromRawUnchecked"/>
    public static TemplateVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateVariableFromRaw : IFromRawJson<TemplateVariable>
{
    /// <inheritdoc/>
    public TemplateVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateVariable.FromRawUnchecked(rawData);
}
