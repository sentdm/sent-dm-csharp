using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Compliance;

/// <summary>
/// Everything a market expects of a sender, for one channel, country and sender type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComplianceRequirements, ComplianceRequirementsFromRaw>))]
public sealed record class ComplianceRequirements : JsonModel
{
    /// <summary>
    /// Channel the requirements apply to — sms, whatsapp or rcs.              Echoed
    /// so the document says which channel it describes. It always described one:
    /// setup's last step is a specific channel path, and every type is an SMS sender
    /// type — but a caller reading the payload had to infer that from the path to
    /// know it.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country the requirements apply to.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// Whether this market demands anything before a sender can be registered. When
    /// false, the compliance array may be omitted entirely and the profile is ready
    /// once provisioned.
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
    /// Values to supply in compliance. Empty when the market demands nothing. Values
    /// Sent supplies on your behalf are never listed, and neither are ones it derives
    /// from what you send.
    /// </summary>
    public IReadOnlyList<ComplianceRequirement>? Requirements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ComplianceRequirement>>(
                "requirements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ComplianceRequirement>?>(
                "requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pattern the sender's own value must match, where the market dictates one
    /// — alphanumeric sender ids and short codes. Null when the value is carrier-assigned.
    /// </summary>
    public string? SenderIDPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender_id_pattern");
        }
        init { this._rawData.Set("sender_id_pattern", value); }
    }

    /// <summary>
    /// The calls that set this market up, in the order they have to be made, each
    /// carrying a body that can be sent as it stands.              This is the answer
    /// to "what do I actually do". Requirements describes each value the market
    /// wants; this assembles those descriptions into the requests that supply them,
    /// so a caller — or an agent acting for one — copies a body out and sends it
    /// rather than building one from a table.              The last step is always
    /// the channel itself, and it is where the regime's own values are supplied.
    /// The one before it, where there is one, is the brand a registering market
    /// files against — so it is a step of its own and the channel call refuses until
    /// it exists. A market that registers with nobody has one step.
    /// </summary>
    public IReadOnlyList<ComplianceSetupStep>? Setup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ComplianceSetupStep>>("setup");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ComplianceSetupStep>?>(
                "setup",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sender type the requirements apply to.              Non-nullable while sms
    /// is the only channel answered here, because it is the only channel whose senders
    /// have a type — the day another one is answered, this becomes nullable along
    /// with it. Not nullable in advance: nothing can emit null today, and publishing
    /// a shape the API never sends is the same mistake as publishing a field it does
    /// not have.
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
        _ = this.Channel;
        _ = this.Country;
        _ = this.Required;
        foreach (var item in this.Requirements ?? [])
        {
            item.Validate();
        }
        _ = this.SenderIDPattern;
        foreach (var item in this.Setup ?? [])
        {
            item.Validate();
        }
        _ = this.Type;
    }

    public ComplianceRequirements() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceRequirements(ComplianceRequirements complianceRequirements)
        : base(complianceRequirements) { }
#pragma warning restore CS8618

    public ComplianceRequirements(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceRequirements(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceRequirementsFromRaw.FromRawUnchecked"/>
    public static ComplianceRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceRequirementsFromRaw : IFromRawJson<ComplianceRequirements>
{
    /// <inheritdoc/>
    public ComplianceRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceRequirements.FromRawUnchecked(rawData);
}
