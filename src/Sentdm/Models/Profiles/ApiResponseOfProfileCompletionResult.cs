using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfProfileCompletionResult,
        ApiResponseOfProfileCompletionResultFromRaw
    >)
)]
public sealed record class ApiResponseOfProfileCompletionResult : JsonModel
{
    /// <summary>
    /// Response when a profile is already in the completed state and no further action
    /// is taken.
    /// </summary>
    public ProfileCompletionResult? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileCompletionResult>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
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

    public ApiResponseOfProfileCompletionResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfProfileCompletionResult(
        ApiResponseOfProfileCompletionResult apiResponseOfProfileCompletionResult
    )
        : base(apiResponseOfProfileCompletionResult) { }
#pragma warning restore CS8618

    public ApiResponseOfProfileCompletionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfProfileCompletionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfProfileCompletionResultFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfProfileCompletionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfProfileCompletionResultFromRaw
    : IFromRawJson<ApiResponseOfProfileCompletionResult>
{
    /// <inheritdoc/>
    public ApiResponseOfProfileCompletionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfProfileCompletionResult.FromRawUnchecked(rawData);
}
