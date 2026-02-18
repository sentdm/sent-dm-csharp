using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using SentDm.Models.Webhooks;

namespace SentDm.Models.Users;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfUser, ApiResponseOfUserFromRaw>))]
public sealed record class ApiResponseOfUser : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public UserResponse? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserResponse>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
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

    public ApiResponseOfUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfUser(ApiResponseOfUser apiResponseOfUser)
        : base(apiResponseOfUser) { }
#pragma warning restore CS8618

    public ApiResponseOfUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfUserFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfUserFromRaw : IFromRawJson<ApiResponseOfUser>
{
    /// <inheritdoc/>
    public ApiResponseOfUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiResponseOfUser.FromRawUnchecked(rawData);
}
