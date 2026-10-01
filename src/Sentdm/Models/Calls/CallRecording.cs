using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls;

/// <summary>
/// A short-lived link to a call recording
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallRecording, CallRecordingFromRaw>))]
public sealed record class CallRecording : JsonModel
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

    public CallRecording() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecording(CallRecording callRecording)
        : base(callRecording) { }
#pragma warning restore CS8618

    public CallRecording(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecording(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingFromRaw.FromRawUnchecked"/>
    public static CallRecording FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallRecordingFromRaw : IFromRawJson<CallRecording>
{
    /// <inheritdoc/>
    public CallRecording FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallRecording.FromRawUnchecked(rawData);
}
