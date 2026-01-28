using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Organizations.Users;

[JsonConverter(typeof(JsonModelConverter<UserListResponse, UserListResponseFromRaw>))]
public sealed record class UserListResponse : JsonModel
{
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

    public IReadOnlyList<CustomerUser>? Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomerUser>>("users");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerUser>?>(
                "users",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.PageSize;
        _ = this.TotalCount;
        foreach (var item in this.Users ?? [])
        {
            item.Validate();
        }
    }

    public UserListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListResponse(UserListResponse userListResponse)
        : base(userListResponse) { }
#pragma warning restore CS8618

    public UserListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListResponseFromRaw.FromRawUnchecked"/>
    public static UserListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListResponseFromRaw : IFromRawJson<UserListResponse>
{
    /// <inheritdoc/>
    public UserListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserListResponse.FromRawUnchecked(rawData);
}
