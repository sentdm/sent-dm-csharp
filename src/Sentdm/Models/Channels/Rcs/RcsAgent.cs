using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Rcs;

/// <summary>
/// An RCS agent as its owner sees it: the order form back, plus where the submission
/// stands.              Not RcsSenderResponse. That one is the admin projection and
/// carries the pipeline we track about a customer's request — internalStatus, statusReason,
/// isLaunched — and the S3 keys behind the assets. None of that is the customer's
/// to read: an internal status is a note to ourselves, and an S3 key is a storage
/// detail that would become a contract the moment it was published.
/// What is here is what the caller sent, in the names it sent them under, plus the
/// three things only we can answer: the record's id, its status, and the number
/// it sends from. So a read after a write shows the form as stored rather than as echoed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RcsAgent, RcsAgentFromRaw>))]
public sealed record class RcsAgent : JsonModel
{
    /// <summary>
    /// The agent record. Stable across the whole approval, and what support will
    /// ask for.              Nullable and omitted when absent: a sender profile
    /// with RCS intent records the channel but has no agent until the order form
    /// is submitted, so no id exists to report. A zero GUID is not a valid id and
    /// is worse than the field being absent.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public string? AgentUseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_use_case");
        }
        init { this._rawData.Set("agent_use_case", value); }
    }

    public string? BrandColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_color");
        }
        init { this._rawData.Set("brand_color", value); }
    }

    public string? BrandEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_email");
        }
        init { this._rawData.Set("brand_email", value); }
    }

    public string? BrandName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_name");
        }
        init { this._rawData.Set("brand_name", value); }
    }

    public string? BrandPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_phone_number");
        }
        init { this._rawData.Set("brand_phone_number", value); }
    }

    public string? BriefCompanyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brief_company_description");
        }
        init { this._rawData.Set("brief_company_description", value); }
    }

    public string? CompanyEin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_ein");
        }
        init { this._rawData.Set("company_ein", value); }
    }

    public string? ContactNameAndTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_name_and_title");
        }
        init { this._rawData.Set("contact_name_and_title", value); }
    }

    /// <summary>
    /// Omitted when no real agent record exists — the intent-only path has no creation timestamp.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public string? CustomerSupportEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_support_email");
        }
        init { this._rawData.Set("customer_support_email", value); }
    }

    public string? CustomerSupportPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_support_phone_number");
        }
        init { this._rawData.Set("customer_support_phone_number", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    public string? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_type");
        }
        init { this._rawData.Set("entity_type", value); }
    }

    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("help_message");
        }
        init { this._rawData.Set("help_message", value); }
    }

    /// <summary>
    /// The registered address of the company behind the agent.
    /// </summary>
    public RcsAddress? OfficialAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsAddress>("official_address");
        }
        init { this._rawData.Set("official_address", value); }
    }

    public string? OptInProcessDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_in_process_description");
        }
        init { this._rawData.Set("opt_in_process_description", value); }
    }

    /// <summary>
    /// The number the agent sends from, derived from brand_phone_number.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? PrivacyPolicyUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privacy_policy_url");
        }
        init { this._rawData.Set("privacy_policy_url", value); }
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
    /// Why the agent is not ACTIVE, as a stable code: an ErrorCodes CHANNEL_xxx value
    /// such as CHANNEL_001 (something you owe) or CHANNEL_009 (under review). Switch
    /// on this rather than on reason. Omitted while ACTIVE. Read-only; when nothing
    /// more specific is known it is the generic reason for the status.
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

    public IReadOnlyList<string>? SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sample_messages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "sample_messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? StartMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("start_message");
        }
        init { this._rawData.Set("start_message", value); }
    }

    /// <summary>
    /// Where the agent stands, in terms of who is holding it up — PROVISIONING,
    /// ACTION_NEEDED, PENDING_REVIEW or ACTIVE.              Resolved from both of
    /// the provider's axes rather than reported raw: an agent whose resubmission
    /// we have asked for reads ACTION_NEEDED however its carrier status still reads,
    /// and an agent not yet handed over reads PROVISIONING rather than pending a
    /// review nobody has started.
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

    public string? StopMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stop_message");
        }
        init { this._rawData.Set("stop_message", value); }
    }

    public string? TermsAndConditionsUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("terms_and_conditions_url");
        }
        init { this._rawData.Set("terms_and_conditions_url", value); }
    }

    public string? WebsiteUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website_url");
        }
        init { this._rawData.Set("website_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentUseCase;
        _ = this.BrandColor;
        _ = this.BrandEmail;
        _ = this.BrandName;
        _ = this.BrandPhoneNumber;
        _ = this.BriefCompanyDescription;
        _ = this.CompanyEin;
        _ = this.ContactNameAndTitle;
        _ = this.CreatedAt;
        _ = this.CustomerSupportEmail;
        _ = this.CustomerSupportPhoneNumber;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.EntityType;
        _ = this.HelpMessage;
        this.OfficialAddress?.Validate();
        _ = this.OptInProcessDescription;
        _ = this.PhoneNumber;
        _ = this.PrivacyPolicyUrl;
        _ = this.Reason;
        _ = this.ReasonCode;
        _ = this.SampleMessages;
        _ = this.StartMessage;
        this.Status?.Validate();
        _ = this.StopMessage;
        _ = this.TermsAndConditionsUrl;
        _ = this.WebsiteUrl;
    }

    public RcsAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsAgent(RcsAgent rcsAgent)
        : base(rcsAgent) { }
#pragma warning restore CS8618

    public RcsAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsAgentFromRaw.FromRawUnchecked"/>
    public static RcsAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RcsAgentFromRaw : IFromRawJson<RcsAgent>
{
    /// <inheritdoc/>
    public RcsAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RcsAgent.FromRawUnchecked(rawData);
}

/// <summary>
/// Where the agent stands, in terms of who is holding it up — PROVISIONING, ACTION_NEEDED,
/// PENDING_REVIEW or ACTIVE.              Resolved from both of the provider's axes
/// rather than reported raw: an agent whose resubmission we have asked for reads
/// ACTION_NEEDED however its carrier status still reads, and an agent not yet handed
/// over reads PROVISIONING rather than pending a review nobody has started.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Provisioning,
    ActionNeeded,
    PendingReview,
    Active,
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
