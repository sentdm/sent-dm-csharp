using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Whatsapp;

/// <summary>
/// The profile's WhatsApp account. Its status is Meta's verification state.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappChannel, WhatsappChannelFromRaw>))]
public sealed record class WhatsappChannel : JsonModel
{
    /// <summary>
    /// Derived from the organization's shared-account listing, like SolutionId.
    /// </summary>
    public string? OwnerBusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("owner_business_id");
        }
        init { this._rawData.Set("owner_business_id", value); }
    }

    /// <summary>
    /// The Meta phone-number id the profile sends from, or null when the account
    /// is connected but no number has been named yet — which is what a provisioning
    /// status means here.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_id");
        }
        init { this._rawData.Set("phone_number_id", value); }
    }

    /// <summary>
    /// A sentence for reason_code, saying what to do where it is yours. Omitted while ACTIVE.
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
    /// Why the account is not ACTIVE, as a stable code: an ErrorCodes CHANNEL_xxx
    /// value such as CHANNEL_001 (something you owe) or CHANNEL_009 (under review).
    /// Switch on this rather than on reason. Omitted while ACTIVE. Read-only; when
    /// nothing more specific is known it is the generic reason for the status.
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
    /// Derived, not echoed. The request no longer accepts this — it is read off
    /// the organization's shared-account listing at connect time and reported back
    /// so a caller can see which partnership the account actually arrived through.
    /// </summary>
    public string? SolutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("solution_id");
        }
        init { this._rawData.Set("solution_id", value); }
    }

    /// <summary>
    /// Read-only. Never carries a token — the row holds that and it is not returned.
    /// ACTION_NEEDED when no account is connected or the account has no phone number:
    /// both are yours to do.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? WabaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("waba_id");
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OwnerBusinessID;
        _ = this.PhoneNumberID;
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.SolutionID;
        this.Status?.Validate();
        _ = this.WabaID;
    }

    public WhatsappChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappChannel(WhatsappChannel whatsappChannel)
        : base(whatsappChannel) { }
#pragma warning restore CS8618

    public WhatsappChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappChannelFromRaw.FromRawUnchecked"/>
    public static WhatsappChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappChannelFromRaw : IFromRawJson<WhatsappChannel>
{
    /// <inheritdoc/>
    public WhatsappChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WhatsappChannel.FromRawUnchecked(rawData);
}

/// <summary>
/// Read-only. Never carries a token — the row holds that and it is not returned.
/// ACTION_NEEDED when no account is connected or the account has no phone number:
/// both are yours to do.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// We are working on it and there is nothing for you to do — a number is being
    /// procured, or a registration is being assembled. Minutes to hours.
    /// </summary>
    Provisioning,

    /// <summary>
    /// **Waiting on you.** Something the market asks for has not been supplied,
    /// a regulator rejected what was, or we have asked you to correct and resubmit
    /// your identity data. Nothing progresses until you act. For an SMS market,
    /// `GET /v3/channels/sms/{country}/{type}` names what it wants and `PATCH` on
    /// the same path supplies it — compliance values, documents and numbers alike.
    /// </summary>
    ActionNeeded,

    /// <summary>
    /// With a regulator or carrier — filed, or assembled and queued for us to file
    /// — and their answer is what moves it, to `ACTIVE` or back to `ACTION_NEEDED`.
    /// Nothing on your side changes it. Days for SMS, weeks for RCS.
    /// </summary>
    PendingReview,

    /// <summary>
    /// Can carry traffic now. A channel a sender profile runs on its organization's
    /// reads `ACTIVE` too — it sends, which is what the field is about.
    /// </summary>
    Active,

    /// <summary>
    /// **It had a working sender and no longer does** — the number was released,
    /// or the campaign it carried lapsed. Distinct from `PROVISIONING`, which means
    /// it has never sent yet: the same absence of a sender, opposite news. Sends
    /// will fail until it returns to `ACTIVE`.
    /// </summary>
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => Status.Provisioning,
            "ACTION_NEEDED" => Status.ActionNeeded,
            "PENDING_REVIEW" => Status.PendingReview,
            "ACTIVE" => Status.Active,
            "INACTIVE" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Provisioning => "PROVISIONING",
                Status.ActionNeeded => "ACTION_NEEDED",
                Status.PendingReview => "PENDING_REVIEW",
                Status.Active => "ACTIVE",
                Status.Inactive => "INACTIVE",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
