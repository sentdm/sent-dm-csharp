using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApiResponseOfSenderProfile, ApiResponseOfSenderProfileFromRaw>)
)]
public sealed record class ApiResponseOfSenderProfile : JsonModel
{
    /// <summary>
    /// A sender profile as the API reports it — the same document the create call
    /// accepts, plus the read-only facts it cannot: each market's status and what
    /// it still owes.              No status at the profile, brand or campaign level.
    /// Brand and campaign are identity, and identity has no lifecycle. What has one
    /// is the registration of a sender in a market, and the approval of a channel
    /// — so status lives there, where it says which specific thing is blocked rather
    /// than flattening several answers into one.
    /// </summary>
    public SenderProfile? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SenderProfile>("data");
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

    public ApiResponseOfSenderProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfSenderProfile(ApiResponseOfSenderProfile apiResponseOfSenderProfile)
        : base(apiResponseOfSenderProfile) { }
#pragma warning restore CS8618

    public ApiResponseOfSenderProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfSenderProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfSenderProfileFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfSenderProfileFromRaw : IFromRawJson<ApiResponseOfSenderProfile>
{
    /// <inheritdoc/>
    public ApiResponseOfSenderProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfSenderProfile.FromRawUnchecked(rawData);
}
