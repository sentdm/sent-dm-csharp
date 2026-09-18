using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a contact.opt_in, contact.opt_out or contact.help event. Delivered when
/// a contact signals a consent change or asks for help.              These events
/// state the signal outright, so you do not have to recognise keywords in the text
/// of a message.received event. They also cover cases that produce no inbound message
/// at all, such as a network handling an opt-out on your behalf.              Fields
/// are ordered identity → resulting state → provenance → join key. Nothing here
/// restates the envelope: which of the three signals occurred is the envelope's
/// event, and when it was emitted is its timestamp. Retries carry the same X-Webhook-Event-ID
/// header, which is what to deduplicate on.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactEventPayload, ContactEventPayloadFromRaw>))]
public sealed record class ContactEventPayload : JsonModel
{
    /// <summary>
    /// Whether the contact is opted out after this signal — the state to write to
    /// your own record. Same meaning as opt_out on the contact resource. On contact.help
    /// this reports the contact's existing state, which help does not change.
    ///           Two signals from the same contact can arrive out of order, because
    /// each one is queued on its own rather than against the contact. Compare the
    /// envelope's timestamp before you overwrite a newer state with an older one.
    /// That timestamp is second-precision, so treat two signals stamped in the same
    /// second as unordered and read the contact resource to settle them.
    /// </summary>
    public required bool OptOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("opt_out");
        }
        init { this._rawData.Set("opt_out", value); }
    }

    /// <summary>
    /// How the signal reached us. INBOUND_KEYWORD means the contact sent a message
    /// whose text matched one of the keywords; PROVIDER_SIGNAL means the network
    /// reported it. A provider signal usually carries no message_id or text, so read
    /// both for null rather than inferring them from this field.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The account the contact belongs to. Present so one endpoint can serve several accounts.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The channel the signal arrived on, for example sms or whatsapp.
    /// </summary>
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

    /// <summary>
    /// The contact who raised the signal. Always populated, including for contact.help
    /// from a number you have not messaged before — the contact is created if it
    /// does not exist yet, so this identifier is always resolvable against the contacts API.
    /// </summary>
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

    /// <summary>
    /// The inbound message that carried the signal, matching message_id on the corresponding
    /// message.received event so the two can be joined.              Sent as null
    /// when the signal did not arrive as a message — for example when a network
    /// processed an opt-out on your behalf — and also when the message belongs to
    /// a different account than this event, which can happen on a shared WhatsApp
    /// number. The field is always present, so read it and check for null rather
    /// than checking whether the key exists.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init { this._rawData.Set("message_id", value); }
    }

    /// <summary>
    /// The contact's number in E.164 format. Same value as phone_number on the contact resource.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// The text the contact sent, for example STOP or UNSUBSCRIBE. Sent as null when
    /// the signal did not arrive as text. The field is always present, so read it
    /// and check for null rather than checking whether the key exists.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OptOut;
        _ = this.Source;
        _ = this.AccountID;
        _ = this.Channel;
        _ = this.ContactID;
        _ = this.MessageID;
        _ = this.PhoneNumber;
        _ = this.Text;
    }

    public ContactEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactEventPayload(ContactEventPayload contactEventPayload)
        : base(contactEventPayload) { }
#pragma warning restore CS8618

    public ContactEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactEventPayloadFromRaw.FromRawUnchecked"/>
    public static ContactEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactEventPayloadFromRaw : IFromRawJson<ContactEventPayload>
{
    /// <inheritdoc/>
    public ContactEventPayload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactEventPayload.FromRawUnchecked(rawData);
}
