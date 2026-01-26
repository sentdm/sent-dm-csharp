using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateListResponse, TemplateListResponseFromRaw>))]
public sealed record class TemplateListResponse : JsonModel
{
    public IReadOnlyList<TemplateResponse>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TemplateResponse>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TemplateResponse>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public int? PageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("pageSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageSize", value);
        }
    }

    public int? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("totalCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCount", value);
        }
    }

    public int? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("totalPages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalPages", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Page;
        _ = this.PageSize;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public TemplateListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateListResponse(TemplateListResponse templateListResponse)
        : base(templateListResponse) { }
#pragma warning restore CS8618

    public TemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateListResponseFromRaw.FromRawUnchecked"/>
    public static TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateListResponseFromRaw : IFromRawJson<TemplateListResponse>
{
    /// <inheritdoc/>
    public TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateListResponse.FromRawUnchecked(rawData);
}
