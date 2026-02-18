using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using Webhooks = SentDm.Models.Webhooks;

namespace SentDm.Models.Users;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserListResponse, UserListResponseFromRaw>))]
public sealed record class UserListResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public Webhooks::ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public Webhooks::ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
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

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// List of users in the organization
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
        foreach (var item in this.Users ?? [])
        {
            item.Validate();
        }
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
