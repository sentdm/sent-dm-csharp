using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Users;

/// <summary>
/// The users in the organization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsersList, UsersListFromRaw>))]
public sealed record class UsersList : JsonModel
{
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

    /// <summary>
    /// The users on this page.
    /// </summary>
    public IReadOnlyList<UserResponse>? Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UserResponse>>("users");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UserResponse>?>(
                "users",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.Users ?? [])
        {
            item.Validate();
        }
    }

    public UsersList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsersList(UsersList usersList)
        : base(usersList) { }
#pragma warning restore CS8618

    public UsersList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsersList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsersListFromRaw.FromRawUnchecked"/>
    public static UsersList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsersListFromRaw : IFromRawJson<UsersList>
{
    /// <inheritdoc/>
    public UsersList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsersList.FromRawUnchecked(rawData);
}
