using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls;

/// <summary>
/// When a call entered a status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallTimelineEntry, CallTimelineEntryFromRaw>))]
public sealed record class CallTimelineEntry : JsonModel
{
    /// <summary>
    /// initiated, ringing, answered, completed, failed, no_answer or rejected
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

    /// <summary>
    /// When the call entered this status (UTC)
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
    }

    public CallTimelineEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallTimelineEntry(CallTimelineEntry callTimelineEntry)
        : base(callTimelineEntry) { }
#pragma warning restore CS8618

    public CallTimelineEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallTimelineEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallTimelineEntryFromRaw.FromRawUnchecked"/>
    public static CallTimelineEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallTimelineEntryFromRaw : IFromRawJson<CallTimelineEntry>
{
    /// <inheritdoc/>
    public CallTimelineEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallTimelineEntry.FromRawUnchecked(rawData);
}
