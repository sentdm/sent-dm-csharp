using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Models.Calls.Participants;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfListOfCallParticipant,
        ApiResponseOfListOfCallParticipantFromRaw
    >)
)]
public sealed record class ApiResponseOfListOfCallParticipant : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public IReadOnlyList<Data>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public Webhooks::ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ApiResponseOfListOfCallParticipant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfListOfCallParticipant(
        ApiResponseOfListOfCallParticipant apiResponseOfListOfCallParticipant
    )
        : base(apiResponseOfListOfCallParticipant) { }
#pragma warning restore CS8618

    public ApiResponseOfListOfCallParticipant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfListOfCallParticipant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfListOfCallParticipantFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfListOfCallParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfListOfCallParticipantFromRaw : IFromRawJson<ApiResponseOfListOfCallParticipant>
{
    /// <inheritdoc/>
    public ApiResponseOfListOfCallParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfListOfCallParticipant.FromRawUnchecked(rawData);
}

/// <summary>
/// A participant of a conference call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The participant's own call id: what the mute and remove endpoints take, and
    /// what GET /v3/voice/calls/{id} accepts
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// How long the participant has been connected to the room, in seconds
    /// </summary>
    public int? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_seconds", value);
        }
    }

    /// <summary>
    /// user for one of your app users, number for a phone number, anonymous for
    /// a caller who withheld their number
    /// </summary>
    public string? Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kind");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    /// <summary>
    /// True while the room mutes this participant
    /// </summary>
    public bool? Muted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("muted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("muted", value);
        }
    }

    /// <summary>
    /// The app user's identity or the phone number in E.164 format. Null when the
    /// kind is anonymous
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DurationSeconds;
        _ = this.Kind;
        _ = this.Muted;
        _ = this.Value;
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
