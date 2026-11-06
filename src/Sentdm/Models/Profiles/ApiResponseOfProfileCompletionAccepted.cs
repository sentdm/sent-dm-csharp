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
        ApiResponseOfProfileCompletionAccepted,
        ApiResponseOfProfileCompletionAcceptedFromRaw
    >)
)]
public sealed record class ApiResponseOfProfileCompletionAccepted : JsonModel
{
    /// <summary>
    /// Response acknowledging that profile completion has been accepted and started
    /// in the background. The provided webhook URL will be called when processing finishes.
    /// </summary>
    public ProfileCompletionAccepted? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileCompletionAccepted>("data");
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

    public ApiResponseOfProfileCompletionAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfProfileCompletionAccepted(
        ApiResponseOfProfileCompletionAccepted apiResponseOfProfileCompletionAccepted
    )
        : base(apiResponseOfProfileCompletionAccepted) { }
#pragma warning restore CS8618

    public ApiResponseOfProfileCompletionAccepted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfProfileCompletionAccepted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfProfileCompletionAcceptedFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfProfileCompletionAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfProfileCompletionAcceptedFromRaw
    : IFromRawJson<ApiResponseOfProfileCompletionAccepted>
{
    /// <inheritdoc/>
    public ApiResponseOfProfileCompletionAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfProfileCompletionAccepted.FromRawUnchecked(rawData);
}
