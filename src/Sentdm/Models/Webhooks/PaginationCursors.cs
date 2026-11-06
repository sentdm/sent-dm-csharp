using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Cursor-based pagination. Never populated — see Cursors.
/// </summary>
[Obsolete("deprecated")]
[JsonConverter(typeof(JsonModelConverter<PaginationCursors, PaginationCursorsFromRaw>))]
public sealed record class PaginationCursors : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page.
    /// </summary>
    public string? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Cursor to fetch the previous page.
    /// </summary>
    public string? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public PaginationCursors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationCursors(PaginationCursors paginationCursors)
        : base(paginationCursors) { }
#pragma warning restore CS8618

    public PaginationCursors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationCursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationCursorsFromRaw.FromRawUnchecked"/>
    public static PaginationCursors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationCursorsFromRaw : IFromRawJson<PaginationCursors>
{
    /// <inheritdoc/>
    public PaginationCursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginationCursors.FromRawUnchecked(rawData);
}
