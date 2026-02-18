using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Pagination metadata for list responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginationMeta, PaginationMetaFromRaw>))]
public sealed record class PaginationMeta : JsonModel
{
    /// <summary>
    /// Cursor-based pagination (optional)
    /// </summary>
    public Cursors? Cursors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursors>("cursors");
        }
        init { this._rawData.Set("cursors", value); }
    }

    /// <summary>
    /// Whether there are more pages after this one
    /// </summary>
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    /// <summary>
    /// Current page number (1-indexed)
    /// </summary>
    public int? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Number of items per page
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    public int? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_count", value);
        }
    }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public int? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_pages", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.HasMore;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public PaginationMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationMeta(PaginationMeta paginationMeta)
        : base(paginationMeta) { }
#pragma warning restore CS8618

    public PaginationMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationMetaFromRaw.FromRawUnchecked"/>
    public static PaginationMeta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationMetaFromRaw : IFromRawJson<PaginationMeta>
{
    /// <inheritdoc/>
    public PaginationMeta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginationMeta.FromRawUnchecked(rawData);
}

/// <summary>
/// Cursor-based pagination (optional)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cursors, CursorsFromRaw>))]
public sealed record class Cursors : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page
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
    /// Cursor to fetch the previous page
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

    public Cursors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cursors(Cursors cursors)
        : base(cursors) { }
#pragma warning restore CS8618

    public Cursors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CursorsFromRaw.FromRawUnchecked"/>
    public static Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CursorsFromRaw : IFromRawJson<Cursors>
{
    /// <inheritdoc/>
    public Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cursors.FromRawUnchecked(rawData);
}
