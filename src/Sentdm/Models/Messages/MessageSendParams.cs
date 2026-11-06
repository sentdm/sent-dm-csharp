using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Models.Messages;

/// <summary>
/// Sends a message to one or more recipients using a template. Supports multi-channel
/// broadcast — when multiple channels are specified (e.g. ["sms", "whatsapp"]), a
/// separate message is created for each (recipient, channel) pair. To choose which
/// of your own numbers a send goes out from, use 'channels': {"sms": [{"from": ["+12125550000",
/// "+14155550000"]}]}. Each channel holds a list of entries, each with 'from' and
/// optionally 'country' and 'strategy'; 'country' and 'strategy' are stored but
/// not acted on yet, so every entry's numbers apply to every recipient on that channel.
/// Every number listed must be an active sender on your account. Like the other account-level
/// preconditions below, that is checked per message rather than when the request
/// is received: the request is still accepted with 202, and each affected message
/// is reported as BLOCKED with error code BUSINESS_029 on GET /messages/{id} and
/// the message.blocked webhook. Each channel's numbers restrict which numbers that
/// channel may use; it does not choose channels — 'channel' does, and the two can
/// be combined. With 'channel' left at auto-detect, a recipient best served by a
/// channel you listed no numbers for still goes out on it. Where several of the
/// listed numbers could serve a recipient, routing prefers the one whose area code
/// matches theirs. Keys: sms, whatsapp, rcs, mms. Returns immediately with per-recipient
/// message IDs for async tracking via webhooks or the GET /messages/{id} endpoint.
/// Sends gated before any delivery attempt do not reject the request — an account-level
/// precondition such as insufficient balance, a template not approved for sending,
/// or free-form content with no open conversation with the contact. The send is
/// accepted with 202 and the affected messages are reported as BLOCKED on GET /messages/{id}
/// and the message.blocked webhook. To send later, set scheduled_at (ISO-8601 with
/// an explicit UTC offset; a value without one is rejected) between 1 minute and
/// 30 days ahead: the response is a ScheduledSendMessageResponse (the same fields
/// plus scheduled_at; status is still QUEUED), each message then moves to SCHEDULED,
/// is held and released at that time (within a few minutes), and a message.scheduled
/// webhook fires once it is held. Balance and template approval are evaluated at
/// release, not at acceptance. Quiet hours are not checked when the request is accepted:
/// if the time falls inside a legally protected quiet-hours window for a recipient,
/// that message is moved to the next allowed time at release and a second message.scheduled
/// webhook reports the new scheduled_at. An account may hold at most 1,000,000 scheduled
/// messages at once: a message scheduled past that is reported as BLOCKED (LIMIT_001)
/// instead of being held.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Channels to broadcast on, e.g. ["whatsapp", "sms"]. Each channel produces
    /// a separate message per recipient. "sent" = auto-detect. Defaults to ["sent"]
    /// (auto-detect) if omitted.
    /// </summary>
    public IReadOnlyList<string>? Channel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("channel");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "channel",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Which of your own numbers to send from, keyed by channel, each channel holding
    /// a list of entries: {"sms": [{"country": "US", "from": ["+12125550000", "+14155550000"]},
    /// {"from": ["+447700800001"]}]}. Any real channel may be a key; sent, which
    /// is auto-detect rather than a channel, is rejected. country and strategy are
    /// accepted and stored but not acted on yet: every entry's numbers apply to
    /// every recipient on that channel.              This does not choose channels
    /// — Channel does, and the two combine: "channel": ["sms"] with an sms list sends
    /// on SMS from those numbers. Each list only narrows which of its own channel's
    /// routes may win, so with Channel left at auto-detect a recipient best served
    /// by a channel with no list still goes out on it. Routing itself is unchanged:
    /// the same rules are scored and ranked the same way, with routes pinned to
    /// numbers you did not list removed from the running.              Each channel's
    /// list is independent: an sms list does not restrict MMS. To choose the numbers
    /// a message may go out from as MMS, name them under mms. MMS sends from your
    /// SMS numbers, so an mms list may name any of your active SMS numbers whose
    /// market carries MMS — the ones listed under mms in your channels.
    ///      Every number must be an active sender on your account. The request itself
    /// is still accepted (202) if one is not — like every other send-time rule, that
    /// is decided per message, so each affected message is recorded BLOCKED with
    /// error code BUSINESS_029 and reported on GET /v3/messages and the status webhook.
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<MessageChannelOptions>>? Channels
    {
        get
        {
            this._rawBodyData.Freeze();
            var value = this._rawBodyData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<MessageChannelOptions>>
            >("channels");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<MessageChannelOptions>)entry.Value
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, ImmutableArray<MessageChannelOptions>>?>(
                "channels",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// Attachments for this send, as publicly fetchable https URLs. Used by the
    /// MMS channel and ignored by every other one.              Supplying these
    /// replaces the media on the template's mms body rather than adding to it, so
    /// a template can hold a default creative while a caller still sends something
    /// recipient-specific.              Their presence is also what makes a message
    /// eligible for MMS on an auto-detect send: a message with nothing attached
    /// is delivered as SMS, because an MMS with no media is a more expensive text
    /// message. For the same reason a send that names mms in channel with nothing
    /// attached, here or on the template, is refused with a 400.              The
    /// recipient's carrier fetches each URL after the send is accepted, so it must
    /// stay publicly reachable — a link that expires, or one behind auth, arrives
    /// as a failed message.
    /// </summary>
    public IReadOnlyList<string>? MediaUrls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("media_urls");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "media_urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sandbox flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("sandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sandbox", value);
        }
    }

    /// <summary>
    /// Optional future send time as an ISO-8601 timestamp with an explicit UTC offset,
    /// e.g. 2026-10-01T09:00:00+02:00 or 2026-10-01T07:00:00Z. A value without an
    /// offset is rejected (400) rather than read in the server's zone. The offset
    /// only fixes the instant: it is stored and echoed in UTC as scheduled_at. Omit
    /// to send now. Must be at least one minute ahead and at most 30 days ahead.
    /// Accepted messages report SCHEDULED and are released for delivery at this time.
    /// Quiet hours, balance and template approval are evaluated at release, not at
    /// acceptance: a message whose time falls inside a recipient's protected quiet-hours
    /// window is moved to the next allowed time and a second message.scheduled webhook
    /// reports the new scheduled_at.
    /// </summary>
    public DateTimeOffset? ScheduledAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("scheduled_at");
        }
        init { this._rawBodyData.Set("scheduled_at", value); }
    }

    /// <summary>
    /// Subject line for this send, overriding the template's. MMS only; ignored on
    /// every other channel. Most handsets render it above the body, some ignore
    /// it entirely.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("subject");
        }
        init { this._rawBodyData.Set("subject", value); }
    }

    /// <summary>
    /// SDK-style template reference: resolve by ID or by name, with optional parameters.
    /// </summary>
    public TemplateRef? Template
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TemplateRef>("template");
        }
        init { this._rawBodyData.Set("template", value); }
    }

    /// <summary>
    /// Plain-text (free-form) message body. Provide either Template or this.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// List of recipient phone numbers in E.164 format (multi-recipient fan-out)
    /// </summary>
    public IReadOnlyList<string>? To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-profile-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-profile-id", value);
        }
    }

    public MessageSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendParams(MessageSendParams messageSendParams)
        : base(messageSendParams)
    {
        this._rawBodyData = new(messageSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MessageSendParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MessageSendParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MessageSendParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/messages")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
