using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Compliance;

/// <summary>
/// One value a market expects in a channel call's compliance map.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComplianceRequirement, ComplianceRequirementFromRaw>))]
public sealed record class ComplianceRequirement : JsonModel
{
    /// <summary>
    /// Refinement of type where the market demands a specific shape, e.g. e164,
    /// url, email, iso3166_alpha2, csv_keywords.
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <summary>
    /// Shape of each entry, when this requirement is a list of objects rather than
    /// of scalars.              The compliance value stays null in the setup body
    /// like every other blank — a body that carries a half-filled object is one the
    /// endpoint refuses, which would break the promise that the published body can
    /// be sent as it stands. So the shape is described here instead, and each entry
    /// the caller composes has these keys.
    /// </summary>
    public IReadOnlyList<ComplianceRequirement>? ItemFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ComplianceRequirement>>(
                "item_fields"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ComplianceRequirement>?>(
                "item_fields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Key to use in the compliance map.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// Human label, suitable for a form field.
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Most entries this value accepts, where the market caps it.
    /// </summary>
    public int? MaxItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_items");
        }
        init { this._rawData.Set("max_items", value); }
    }

    /// <summary>
    /// Shortest acceptable value, where the market sets one. TCR refuses a consent
    /// narrative under 40 characters, and finding that out at submission time is
    /// the round trip this exists to save.
    /// </summary>
    public int? MinLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("min_length");
        }
        init { this._rawData.Set("min_length", value); }
    }

    /// <summary>
    /// Why the market asks for this.
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    /// <summary>
    /// Accepted values, when the type is an enum or a constrained array.
    /// </summary>
    public IReadOnlyList<string>? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the market always demands this value.
    /// </summary>
    public bool? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("required", value);
        }
    }

    /// <summary>
    /// Condition that makes this value required, when it is only required in some
    /// cases — e.g. brand.entity_type == PUBLIC_PROFIT. Evaluate it against your
    /// own payload to know whether to collect the field.
    /// </summary>
    public string? RequiredWhen
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("required_when");
        }
        init { this._rawData.Set("required_when", value); }
    }

    /// <summary>
    /// Value type: string, number, boolean, date, enum, object, array or document.
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
        _ = this.Format;
        foreach (var item in this.ItemFields ?? [])
        {
            item.Validate();
        }
        _ = this.Key;
        _ = this.Label;
        _ = this.MaxItems;
        _ = this.MinLength;
        _ = this.Notes;
        _ = this.Options;
        _ = this.Required;
        _ = this.RequiredWhen;
        _ = this.Type;
    }

    public ComplianceRequirement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceRequirement(ComplianceRequirement complianceRequirement)
        : base(complianceRequirement) { }
#pragma warning restore CS8618

    public ComplianceRequirement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceRequirement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceRequirementFromRaw.FromRawUnchecked"/>
    public static ComplianceRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceRequirementFromRaw : IFromRawJson<ComplianceRequirement>
{
    /// <inheritdoc/>
    public ComplianceRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceRequirement.FromRawUnchecked(rawData);
}
