using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Messages;

/// <summary>
/// Message response for v3 API — same shape as v2 with snake_case JSON conventions.
///              The shape of a message that was sent immediately: it never has a
/// scheduled_at key. A message that is or was held for a later instant is a ScheduledMessageResponse,
/// and the endpoint decides which of the two to answer with. From always returns
/// this type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CancelledMessage, CancelledMessageFromRaw>))]
public sealed record class CancelledMessage : JsonModel
{
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

    public double? ActiveContactPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("active_contact_price");
        }
        init { this._rawData.Set("active_contact_price", value); }
    }

    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customer_id", value);
        }
    }

    public string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public IReadOnlyList<MessageStatusEvent>? Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageStatusEvent>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageStatusEvent>?>(
                "events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Structured message body format for database storage. Preserves channel-specific
    /// components (header, header media, body, footer, buttons, MMS subject and media).
    ///              Persisted as the messageBody jsonb column on Messages. Every
    /// write path goes through MessageUtils.MessageBodyJsonOptions, which writes
    /// nulls, so the envelope shape is stable regardless of channel or status. Anything
    /// that rebuilds this object field by field — the four IMessageBodyStrategy
    /// implementations and MessageUtils.BuildSegmentBody — has to carry every member,
    /// or that member is silently dropped on whichever path forgot it.
    /// </summary>
    public MessageBody? MessageBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageBody>("message_body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_body", value);
        }
    }

    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public string? PhoneInternational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_international");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_international", value);
        }
    }

    public double? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// A human-readable sentence for reason_code, for example "Insufficient balance".
    /// Omitted whenever reason_code is.
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
    /// Why the message is at its current status, as a stable platform code such
    /// as DELIVERY_007, BUSINESS_003 or DELIVERY_003. Present when the current status
    /// is FAILED, FILTERED or BLOCKED and the lifecycle was loaded; omitted otherwise.
    /// Switch on this rather than on reason: the code is stable, the wording may
    /// be improved. It is the platform's classification of the outcome, never a
    /// carrier or vendor code.
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

    public string? RegionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

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

    public string? TemplateCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_category");
        }
        init { this._rawData.Set("template_category", value); }
    }

    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_name");
        }
        init { this._rawData.Set("template_name", value); }
    }

    /// <summary>
    /// The send time that was called off, in UTC — the scheduled_at the message
    /// was being             held for, whether you set it or the recipient's quiet
    /// hours moved it there. Omitted only for a held             message that carried
    /// no recorded instant.
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

    public static implicit operator Message(CancelledMessage cancelledMessage) =>
        new()
        {
            ID = cancelledMessage.ID,
            ActiveContactPrice = cancelledMessage.ActiveContactPrice,
            Channel = cancelledMessage.Channel,
            ContactID = cancelledMessage.ContactID,
            CreatedAt = cancelledMessage.CreatedAt,
            CustomerID = cancelledMessage.CustomerID,
            Direction = cancelledMessage.Direction,
            Events = cancelledMessage.Events,
            MessageBody = cancelledMessage.MessageBody,
            Phone = cancelledMessage.Phone,
            PhoneInternational = cancelledMessage.PhoneInternational,
            Price = cancelledMessage.Price,
            Reason = cancelledMessage.Reason,
            ReasonCode = cancelledMessage.ReasonCode,
            RegionCode = cancelledMessage.RegionCode,
            Status = cancelledMessage.Status,
            TemplateCategory = cancelledMessage.TemplateCategory,
            TemplateID = cancelledMessage.TemplateID,
            TemplateName = cancelledMessage.TemplateName,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActiveContactPrice;
        _ = this.Channel;
        _ = this.ContactID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.Direction;
        foreach (var item in this.Events ?? [])
        {
            item.Validate();
        }
        this.MessageBody?.Validate();
        _ = this.Phone;
        _ = this.PhoneInternational;
        _ = this.Price;
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.RegionCode;
        _ = this.Status;
        _ = this.TemplateCategory;
        _ = this.TemplateID;
        _ = this.TemplateName;
        _ = this.ScheduledAt;
    }

    public CancelledMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CancelledMessage(CancelledMessage cancelledMessage)
        : base(cancelledMessage) { }
#pragma warning restore CS8618

    public CancelledMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CancelledMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CancelledMessageFromRaw.FromRawUnchecked"/>
    public static CancelledMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CancelledMessageFromRaw : IFromRawJson<CancelledMessage>
{
    /// <inheritdoc/>
    public CancelledMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CancelledMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The cancelled message, in the shape GET /v3/messages/{id} reports it: a cancellation
/// answers with the message it acted on rather than a bespoke acknowledgement, so
/// a client can hand the body to the same reader it already has. status is read off
/// the row the claim just wrote, not asserted by the endpoint.              It carries
/// scheduled_at for the same reason ScheduledMessageResponse does, and with the same
/// meaning — the instant the message was being held for. A cancelled message was
/// necessarily held, so the key is present on every real cancellation, and the two
/// endpoints agree on what they report about the same message. It is a property
/// here rather than inheritance because ScheduledMessageResponse is sealed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties,
        SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponsePropertiesFromRaw
    >)
)]
public sealed record class SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties
    : JsonModel
{
    /// <summary>
    /// The send time that was called off, in UTC — the scheduled_at the message
    /// was being             held for, whether you set it or the recipient's quiet
    /// hours moved it there. Omitted only for a held             message that carried
    /// no recorded instant.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScheduledAt;
    }

    public SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties(
        SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties sentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties
    )
        : base(
            sentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties
        ) { }
#pragma warning restore CS8618

    public SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponsePropertiesFromRaw.FromRawUnchecked"/>
    public static SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponsePropertiesFromRaw
    : IFromRawJson<SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties>
{
    /// <inheritdoc/>
    public SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SentDmServicesEndpointsCustomerApIv3MessagesResponsesCancelMessageV3ResponseProperties.FromRawUnchecked(
            rawData
        );
}
