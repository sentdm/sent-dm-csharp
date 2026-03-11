using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<MutationRequestBase, MutationRequestBaseFromRaw>))]
public sealed record class MutationRequestBase : JsonModel
{
    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sandbox", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Sandbox;
    }

    public MutationRequestBase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MutationRequestBase(MutationRequestBase mutationRequestBase)
        : base(mutationRequestBase) { }
#pragma warning restore CS8618

    public MutationRequestBase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MutationRequestBase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MutationRequestBaseFromRaw.FromRawUnchecked"/>
    public static MutationRequestBase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MutationRequestBaseFromRaw : IFromRawJson<MutationRequestBase>
{
    /// <inheritdoc/>
    public MutationRequestBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MutationRequestBase.FromRawUnchecked(rawData);
}
