using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

[JsonConverter(typeof(JsonModelConverter<ContactListResponse, ContactListResponseFromRaw>))]
public sealed record class ContactListResponse : JsonModel
{
    public IReadOnlyList<ContactListItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ContactListItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ContactListItem>?>(
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

    public ContactListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactListResponse(ContactListResponse contactListResponse)
        : base(contactListResponse) { }
#pragma warning restore CS8618

    public ContactListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactListResponseFromRaw.FromRawUnchecked"/>
    public static ContactListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactListResponseFromRaw : IFromRawJson<ContactListResponse>
{
    /// <inheritdoc/>
    public ContactListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactListResponse.FromRawUnchecked(rawData);
}
