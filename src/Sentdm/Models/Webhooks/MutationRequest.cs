using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<MutationRequest, MutationRequestFromRaw>))]
public sealed record class MutationRequest : JsonModel
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

    public MutationRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MutationRequest(MutationRequest mutationRequest)
        : base(mutationRequest) { }
#pragma warning restore CS8618

    public MutationRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MutationRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MutationRequestFromRaw.FromRawUnchecked"/>
    public static MutationRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MutationRequestFromRaw : IFromRawJson<MutationRequest>
{
    /// <inheritdoc/>
    public MutationRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MutationRequest.FromRawUnchecked(rawData);
}
