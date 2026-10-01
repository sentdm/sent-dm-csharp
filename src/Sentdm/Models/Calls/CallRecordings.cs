using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Calls;

/// <summary>
/// The recordings of a call, each as a short-lived download link
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallRecordings, CallRecordingsFromRaw>))]
public sealed record class CallRecordings : JsonModel
{
    /// <summary>
    /// Every recording of the call, oldest first. Empty until the first call.recording_ready
    /// webhook has been sent, and for a call that was never recorded
    /// </summary>
    public IReadOnlyList<CallRecording>? Recordings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallRecording>>("recordings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CallRecording>?>(
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

    public CallRecordings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordings(CallRecordings callRecordings)
        : base(callRecordings) { }
#pragma warning restore CS8618

    public CallRecordings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingsFromRaw.FromRawUnchecked"/>
    public static CallRecordings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallRecordingsFromRaw : IFromRawJson<CallRecordings>
{
    /// <inheritdoc/>
    public CallRecordings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallRecordings.FromRawUnchecked(rawData);
}
