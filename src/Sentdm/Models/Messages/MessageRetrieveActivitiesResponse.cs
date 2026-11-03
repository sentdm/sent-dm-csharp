using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Messages;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveActivitiesResponse,
        MessageRetrieveActivitiesResponseFromRaw
    >)
)]
public sealed record class MessageRetrieveActivitiesResponse : JsonModel
{
    /// <summary>
    /// Response for GET /messages/{id}/activities
    /// </summary>
    public MessageRetrieveActivitiesResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageRetrieveActivitiesResponseData>("data");
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

    public MessageRetrieveActivitiesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveActivitiesResponse(
        MessageRetrieveActivitiesResponse messageRetrieveActivitiesResponse
    )
        : base(messageRetrieveActivitiesResponse) { }
#pragma warning restore CS8618

    public MessageRetrieveActivitiesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveActivitiesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveActivitiesResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveActivitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveActivitiesResponseFromRaw : IFromRawJson<MessageRetrieveActivitiesResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveActivitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveActivitiesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response for GET /messages/{id}/activities
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageRetrieveActivitiesResponseData,
        MessageRetrieveActivitiesResponseDataFromRaw
    >)
)]
public sealed record class MessageRetrieveActivitiesResponseData : JsonModel
{
    /// <summary>
    /// List of activity events ordered by most recent first
    /// </summary>
    public IReadOnlyList<Activity>? Activities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Activity>>("activities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Activity>?>(
                "activities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The message ID these activities belong to
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_id", value);
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Activities ?? [])
        {
            item.Validate();
        }
        _ = this.MessageID;
        this.Pagination?.Validate();
    }

    public MessageRetrieveActivitiesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveActivitiesResponseData(
        MessageRetrieveActivitiesResponseData messageRetrieveActivitiesResponseData
    )
        : base(messageRetrieveActivitiesResponseData) { }
#pragma warning restore CS8618

    public MessageRetrieveActivitiesResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveActivitiesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveActivitiesResponseDataFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveActivitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveActivitiesResponseDataFromRaw
    : IFromRawJson<MessageRetrieveActivitiesResponseData>
{
    /// <inheritdoc/>
    public MessageRetrieveActivitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveActivitiesResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// A single message activity event for v3 API.              The activity list mixes
/// statuses, so unlike a message it is one shape rather than two: a SCHEDULED entry
/// carries scheduled_at, and every other entry has no such key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Activity, ActivityFromRaw>))]
public sealed record class Activity : JsonModel
{
    /// <summary>
    /// Active contact markup applied on top of the channel cost, formatted to 4 decimal places.
    /// </summary>
    public string? ActiveContactPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("active_contact_price");
        }
        init { this._rawData.Set("active_contact_price", value); }
    }

    /// <summary>
    /// Human-readable description of the activity
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Sender phone number for this activity (the customer's sending number for outbound,
    /// the external sender for inbound). Null when not reported by the provider.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Channel cost for this activity (e.g., SMS/WhatsApp provider cost), formatted
    /// to 4 decimal places.
    /// </summary>
    public string? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// A human-readable sentence for reason_code, for example "The recipient is
    /// not registered on this channel" Omitted whenever reason_code is.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Why the message reached this status, as a stable platform code such as DELIVERY_007
    /// or BUSINESS_003. Present on FAILED, FILTERED and BLOCKED activities; omitted
    /// on every status that needs no explanation. Switch on this rather than on reason:
    /// the code is stable, the wording may be improved. Same wire name and vocabulary
    /// as on the message and the webhook.
    /// </summary>
    public string? ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
    }

    /// <summary>
    /// SCHEDULED and CANCELLED activities only, in UTC: on a SCHEDULED entry, when
    /// the held message will be released for delivery; on a CANCELLED entry, the
    /// instant that was called off. Same wire name as on the send response, the message
    /// and the webhook. Omitted on every other activity. A message that quiet hours
    /// moved at release has two SCHEDULED entries, each carrying the instant as it
    /// stood at that moment.
    /// </summary>
    public DateTimeOffset? ScheduledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("scheduled_at");
        }
        init { this._rawData.Set("scheduled_at", value); }
    }

    /// <summary>
    /// Activity status. Outbound: QUEUED, PROCESSED, ROUTED, SCHEDULED, SENT, DELIVERED,
    /// READ, FAILED. Inbound (from contact): RECEIVED (terminal).
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
    /// When this activity occurred
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
        _ = this.ActiveContactPrice;
        _ = this.Description;
        _ = this.From;
        _ = this.Price;
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.ScheduledAt;
        _ = this.Status;
        _ = this.Timestamp;
    }

    public Activity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Activity(Activity activity)
        : base(activity) { }
#pragma warning restore CS8618

    public Activity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Activity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityFromRaw.FromRawUnchecked"/>
    public static Activity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityFromRaw : IFromRawJson<Activity>
{
    /// <inheritdoc/>
    public Activity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Activity.FromRawUnchecked(rawData);
}
