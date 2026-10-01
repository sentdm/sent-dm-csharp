using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Calls;

/// <summary>
/// Paginated list of calls
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallsList, CallsListFromRaw>))]
public sealed record class CallsList : JsonModel
{
    /// <summary>
    /// The calls on this page, most recent first
    /// </summary>
    public IReadOnlyList<Call>? Calls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Call>>("calls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Call>?>(
                "calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Calls ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public CallsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallsList(CallsList callsList)
        : base(callsList) { }
#pragma warning restore CS8618

    public CallsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallsListFromRaw.FromRawUnchecked"/>
    public static CallsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallsListFromRaw : IFromRawJson<CallsList>
{
    /// <inheritdoc/>
    public CallsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallsList.FromRawUnchecked(rawData);
}
