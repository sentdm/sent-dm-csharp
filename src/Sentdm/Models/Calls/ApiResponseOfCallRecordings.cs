using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Calls;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApiResponseOfCallRecordings, ApiResponseOfCallRecordingsFromRaw>)
)]
public sealed record class ApiResponseOfCallRecordings : JsonModel
{
    /// <summary>
    /// The recordings of a call, each as a short-lived download link
    /// </summary>
    public ApiResponseOfCallRecordingsData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiResponseOfCallRecordingsData>("data");
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

    public ApiResponseOfCallRecordings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfCallRecordings(ApiResponseOfCallRecordings apiResponseOfCallRecordings)
        : base(apiResponseOfCallRecordings) { }
#pragma warning restore CS8618

    public ApiResponseOfCallRecordings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfCallRecordings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfCallRecordingsFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfCallRecordings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfCallRecordingsFromRaw : IFromRawJson<ApiResponseOfCallRecordings>
{
    /// <inheritdoc/>
    public ApiResponseOfCallRecordings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfCallRecordings.FromRawUnchecked(rawData);
}

/// <summary>
/// The recordings of a call, each as a short-lived download link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfCallRecordingsData,
        ApiResponseOfCallRecordingsDataFromRaw
    >)
)]
public sealed record class ApiResponseOfCallRecordingsData : JsonModel
{
    /// <summary>
    /// Every recording of the call, oldest first. Empty until the first call.recording_ready
    /// webhook has been sent, and for a call that was never recorded
    /// </summary>
    public IReadOnlyList<Recording>? Recordings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Recording>>("recordings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Recording>?>(
                "recordings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Recordings ?? [])
        {
            item.Validate();
        }
    }

    public ApiResponseOfCallRecordingsData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfCallRecordingsData(
        ApiResponseOfCallRecordingsData apiResponseOfCallRecordingsData
    )
        : base(apiResponseOfCallRecordingsData) { }
#pragma warning restore CS8618

    public ApiResponseOfCallRecordingsData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfCallRecordingsData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfCallRecordingsDataFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfCallRecordingsData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfCallRecordingsDataFromRaw : IFromRawJson<ApiResponseOfCallRecordingsData>
{
    /// <inheritdoc/>
    public ApiResponseOfCallRecordingsData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfCallRecordingsData.FromRawUnchecked(rawData);
}

/// <summary>
/// A short-lived link to a call recording
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Recording, RecordingFromRaw>))]
public sealed record class Recording : JsonModel
{
    /// <summary>
    /// A pre-signed link that downloads the recording as an MP3 file. Anyone holding
    /// it can download the recording until it expires
    /// </summary>
    public string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("download_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("download_url", value);
        }
    }

    /// <summary>
    /// The recording's id, the one the call.recording_ready webhook announced it under
    /// </summary>
    public string? RecordingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recording_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recording_id", value);
        }
    }

    /// <summary>
    /// When the link stops working (UTC). Request the recordings again for a fresh link
    /// </summary>
    public DateTimeOffset? UrlExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("url_expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url_expires_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        _ = this.RecordingID;
        _ = this.UrlExpiresAt;
    }

    public Recording() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recording(Recording recording)
        : base(recording) { }
#pragma warning restore CS8618

    public Recording(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recording(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecordingFromRaw.FromRawUnchecked"/>
    public static Recording FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecordingFromRaw : IFromRawJson<Recording>
{
    /// <inheritdoc/>
    public Recording FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recording.FromRawUnchecked(rawData);
}
