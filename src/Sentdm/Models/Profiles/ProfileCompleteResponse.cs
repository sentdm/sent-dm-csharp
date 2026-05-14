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
[JsonConverter(typeof(JsonModelConverter<ProfileCompleteResponse, ProfileCompleteResponseFromRaw>))]
public sealed record class ProfileCompleteResponse : JsonModel
{
    /// <summary>
    /// Response when a profile is already in the completed state and no further action
    /// is taken.
    /// </summary>
    public ProfileCompleteResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileCompleteResponseData>("data");
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

    public ProfileCompleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCompleteResponse(ProfileCompleteResponse profileCompleteResponse)
        : base(profileCompleteResponse) { }
#pragma warning restore CS8618

    public ProfileCompleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileCompleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileCompleteResponseFromRaw.FromRawUnchecked"/>
    public static ProfileCompleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileCompleteResponseFromRaw : IFromRawJson<ProfileCompleteResponse>
{
    /// <inheritdoc/>
    public ProfileCompleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileCompleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response when a profile is already in the completed state and no further action
/// is taken.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileCompleteResponseData, ProfileCompleteResponseDataFromRaw>)
)]
public sealed record class ProfileCompleteResponseData : JsonModel
{
    /// <summary>
    /// Human-readable message describing the result.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Current process status of the profile (e.g., "completed", "submitted", "in_progress").
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Status;
    }

    public ProfileCompleteResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCompleteResponseData(ProfileCompleteResponseData profileCompleteResponseData)
        : base(profileCompleteResponseData) { }
#pragma warning restore CS8618

    public ProfileCompleteResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileCompleteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileCompleteResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileCompleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileCompleteResponseDataFromRaw : IFromRawJson<ProfileCompleteResponseData>
{
    /// <inheritdoc/>
    public ProfileCompleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileCompleteResponseData.FromRawUnchecked(rawData);
}
