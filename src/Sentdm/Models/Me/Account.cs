using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// Account response for GET /v3/me endpoint. Returns organization (with profiles),
/// user (standalone), or profile (child of an organization) data depending on the
/// API key type. Always includes messaging channel configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Account, AccountFromRaw>))]
public sealed record class Account : JsonModel
{
    /// <summary>
    /// Customer ID (organization, account, or profile)
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
    /// Messaging channel configuration. All three channels are always present. Each
    /// channel has a "configured" flag; configured channels expose additional details.
    /// </summary>
    public AccountChannels? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountChannels>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// When the account was created
    /// </summary>
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

    /// <summary>
    /// Account description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Contact email address
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Whether this account may mark a template for automatic creation on its sender
    /// profiles. Granted by Sent per account and off by default, so it is what a
    /// template-create form reads to decide whether to offer the option at all —
    /// marking a template without it does nothing.              Top-level rather
    /// than inside settings, which is written for type: "profile" only and so would
    /// never carry it to the account type that can act on it.              This
    /// is the capability, not the stored flag: a profile reports false whatever
    /// its own row holds. A sender profile owns no sender profiles, so a template
    /// it marked would have nothing to be created on and the fan-out would never
    /// read the flag. The admin GET /customers/{id} reports the stored value instead,
    /// because that is the one an operator granted.
    /// </summary>
    public bool? EnableTemplateAutoCreationForSp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable_template_auto_creation_for_sp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enable_template_auto_creation_for_sp", value);
        }
    }

    /// <summary>
    /// Account icon URL
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    /// <summary>
    /// Account name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Organization ID (only for profile type — the parent organization)
    /// </summary>
    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// List of profiles (populated for organization type, empty for user and profile types)
    /// </summary>
    public IReadOnlyList<AccountProfile>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AccountProfile>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AccountProfile>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The SMS sender this account sends from in the United States, in E.164 form.
    /// Null when the account has no US SMS sender.              The same value as
    /// channels.sms.phone_number, published under both names on purpose: sending_phone_number
    /// is what this value is already called on GET /v3/profiles, so the same key
    /// answers the same question whichever of the two endpoints you ask. Neither
    /// name is preferred over the other and neither is deprecated.              The
    /// same value, not the same presence: this key is always written, including
    /// as null, whereas channels.sms.phone_number is left out entirely when there
    /// is no sender.
    /// </summary>
    public string? SendingPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_phone_number");
        }
        init { this._rawData.Set("sending_phone_number", value); }
    }

    /// <summary>
    /// The account that holds sending_phone_number in number inventory: normally
    /// this account itself, and a different account when the number is held elsewhere.
    /// Null when there is no US sender, or when the sender is not a number drawn
    /// from inventory — an alphanumeric sender ID or a short code.
    /// </summary>
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawData.Set("sending_phone_number_profile_id", value); }
    }

    /// <summary>
    /// Profile configuration settings
    /// </summary>
    public ProfileSettings? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileSettings>("settings");
        }
        init { this._rawData.Set("settings", value); }
    }

    /// <summary>
    /// Short name / abbreviation (only for profile type)
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("short_name");
        }
        init { this._rawData.Set("short_name", value); }
    }

    /// <summary>
    /// Profile status (only for profile type): incomplete, pending_review, approved, etc.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Account type: "organization" (has profiles), "user" (no profiles), or "profile"
    /// (child of an organization)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channels?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Email;
        _ = this.EnableTemplateAutoCreationForSp;
        _ = this.Icon;
        _ = this.Name;
        _ = this.OrganizationID;
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
        _ = this.SendingPhoneNumber;
        _ = this.SendingPhoneNumberProfileID;
        this.Settings?.Validate();
        _ = this.ShortName;
        _ = this.Status;
        _ = this.Type;
    }

    public Account() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Account(Account account)
        : base(account) { }
#pragma warning restore CS8618

    public Account(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Account(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountFromRaw.FromRawUnchecked"/>
    public static Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountFromRaw : IFromRawJson<Account>
{
    /// <inheritdoc/>
    public Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Account.FromRawUnchecked(rawData);
}
