using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileListResponse, ProfileListResponseFromRaw>))]
public sealed record class ProfileListResponse : JsonModel
{
    /// <summary>
    /// The profiles in the organization.
    /// </summary>
    public ProfileListResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ProfileListResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ProfileListResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileListResponseMeta>("meta");
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

    public ProfileListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponse(ProfileListResponse profileListResponse)
        : base(profileListResponse) { }
#pragma warning restore CS8618

    public ProfileListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseFromRaw.FromRawUnchecked"/>
    public static ProfileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseFromRaw : IFromRawJson<ProfileListResponse>
{
    /// <inheritdoc/>
    public ProfileListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The profiles in the organization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileListResponseData, ProfileListResponseDataFromRaw>))]
public sealed record class ProfileListResponseData : JsonModel
{
    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public Pagination? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pagination>("pagination");
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

    /// <summary>
    /// The profiles on this page.
    /// </summary>
    public IReadOnlyList<Profile>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Profile>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Profile>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
    }

    public ProfileListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseData(ProfileListResponseData profileListResponseData)
        : base(profileListResponseData) { }
#pragma warning restore CS8618

    public ProfileListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseDataFromRaw : IFromRawJson<ProfileListResponseData>
{
    /// <inheritdoc/>
    public ProfileListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata for list responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor-based pagination. Never populated — see Cursors.
    /// </summary>
    [Obsolete("deprecated")]
    public Cursors? Cursors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursors>("cursors");
        }
        init { this._rawData.Set("cursors", value); }
    }

    /// <summary>
    /// Whether there are more pages after this one
    /// </summary>
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    /// <summary>
    /// Current page number (1-indexed)
    /// </summary>
    public int? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Number of items per page
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    public int? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_count", value);
        }
    }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public int? TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_pages", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.HasMore;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}

/// <summary>
/// Cursor-based pagination. Never populated — see Cursors.
/// </summary>
[Obsolete("deprecated")]
[JsonConverter(typeof(JsonModelConverter<Cursors, CursorsFromRaw>))]
public sealed record class Cursors : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page.
    /// </summary>
    public string? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Cursor to fetch the previous page.
    /// </summary>
    public string? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public Cursors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cursors(Cursors cursors)
        : base(cursors) { }
#pragma warning restore CS8618

    public Cursors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CursorsFromRaw.FromRawUnchecked"/>
    public static Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CursorsFromRaw : IFromRawJson<Cursors>
{
    /// <inheritdoc/>
    public Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cursors.FromRawUnchecked(rawData);
}

/// <summary>
/// Detailed profile response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Profile, ProfileFromRaw>))]
public sealed record class Profile : JsonModel
{
    /// <summary>
    /// Profile unique identifier
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
    /// Always false. A profile no longer shares contacts with sibling profiles —
    /// it sees only what it owns. Retained so existing v3 clients reading allow_contact_sharing
    /// keep deserializing; it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowContactSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init { this._rawData.Set("allow_contact_sharing", value); }
    }

    /// <summary>
    /// Whether number changes are allowed during onboarding
    /// </summary>
    public bool? AllowNumberChangeDuringOnboarding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_number_change_during_onboarding");
        }
        init { this._rawData.Set("allow_number_change_during_onboarding", value); }
    }

    /// <summary>
    /// Always false. A profile no longer shares templates with sibling profiles.
    /// Retained so existing v3 clients reading allow_template_sharing keep deserializing;
    /// it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init { this._rawData.Set("allow_template_sharing", value); }
    }

    /// <summary>
    /// Billing contact info returned in profile responses
    /// </summary>
    public ProfileBillingContact? BillingContact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBillingContact>("billing_contact");
        }
        init { this._rawData.Set("billing_contact", value); }
    }

    /// <summary>
    /// Billing model: profile, organization, or profile_and_organization
    /// </summary>
    public string? BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billing_model", value);
        }
    }

    /// <summary>
    /// Brand response with nested contact, business, and compliance sections — mirrors
    /// the request structure.
    /// </summary>
    public ProfileBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <summary>
    /// When the profile was created
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
    /// Profile description
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
    /// Profile email (inherited from organization)
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
    /// Profile icon URL
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
    /// Always false. A profile no longer inherits its organization's contacts. Retained
    /// so existing v3 clients reading inherit_contacts keep deserializing; it carries
    /// no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? InheritContacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_contacts");
        }
        init { this._rawData.Set("inherit_contacts", value); }
    }

    /// <summary>
    /// Whether this profile inherits TCR brand from the organization
    /// </summary>
    public bool? InheritTcrBrand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_tcr_brand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_tcr_brand", value);
        }
    }

    /// <summary>
    /// Whether this profile inherits TCR campaign from the organization
    /// </summary>
    public bool? InheritTcrCampaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_tcr_campaign");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit_tcr_campaign", value);
        }
    }

    /// <summary>
    /// Always false. A profile no longer inherits its organization's templates.
    /// Retained so existing v3 clients reading inherit_templates keep deserializing;
    /// it carries no information.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? InheritTemplates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit_templates");
        }
        init { this._rawData.Set("inherit_templates", value); }
    }

    /// <summary>
    /// Profile name
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
    /// Parent organization ID
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
    /// Direct SMS phone number
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
    /// Deprecated. Always null. Sender borrowing is gone: a profile no longer points
    /// at another profile for its SMS sender, and every profile owns the sender it
    /// sends from.              Kept on the wire, and never populated, because those
    /// are two different promises. Removing the key changes the response's shape
    /// — a generated client loses the property and stops compiling on the next regenerate,
    /// for a value that is now null for every profile in existence. Keeping it null
    /// costs a key and breaks nobody, and null is the honest answer rather than a
    /// placeholder: there is no borrowing left to report.              Nothing could
    /// populate it. Migration 260813161500 dropped the column and copied each borrower
    /// its own channel-provider row; its Down() says outright that the borrower-to-lender
    /// pairing is not recoverable. The only surviving trace is a notes string on
    /// the copied row.
    /// </summary>
    [Obsolete("deprecated")]
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawData.Set("sending_phone_number_profile_id", value); }
    }

    [Obsolete("deprecated")]
    public string? SendingWhatsappNumberProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sending_whatsapp_number_profile_id");
        }
        init { this._rawData.Set("sending_whatsapp_number_profile_id", value); }
    }

    /// <summary>
    /// Profile short name/abbreviation. 3–11 characters: letters, numbers, and spaces
    /// only, with at least one letter.
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
    /// Profile setup status: incomplete, pending_review, approved, rejected
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
    /// When the profile was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// WhatsApp Business Account ID associated with this profile. Present whether
    /// the WABA is inherited from the organization or configured directly.
    /// </summary>
    public string? WabaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("waba_id");
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <summary>
    /// Direct WhatsApp phone number
    /// </summary>
    public string? WhatsappPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("whatsapp_phone_number");
        }
        init { this._rawData.Set("whatsapp_phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AllowContactSharing;
        _ = this.AllowNumberChangeDuringOnboarding;
        _ = this.AllowTemplateSharing;
        this.BillingContact?.Validate();
        _ = this.BillingModel;
        this.Brand?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Email;
        _ = this.Icon;
        _ = this.InheritContacts;
        _ = this.InheritTcrBrand;
        _ = this.InheritTcrCampaign;
        _ = this.InheritTemplates;
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.SendingPhoneNumber;
        _ = this.SendingPhoneNumberProfileID;
        _ = this.SendingWhatsappNumberProfileID;
        _ = this.ShortName;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.WabaID;
        _ = this.WhatsappPhoneNumber;
    }

    public Profile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Profile(Profile profile)
        : base(profile) { }
#pragma warning restore CS8618

    public Profile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Profile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileFromRaw.FromRawUnchecked"/>
    public static Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileFromRaw : IFromRawJson<Profile>
{
    /// <inheritdoc/>
    public Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Profile.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing contact info returned in profile responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBillingContact, ProfileBillingContactFromRaw>))]
public sealed record class ProfileBillingContact : JsonModel
{
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
    }

    public ProfileBillingContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBillingContact(ProfileBillingContact profileBillingContact)
        : base(profileBillingContact) { }
#pragma warning restore CS8618

    public ProfileBillingContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBillingContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBillingContactFromRaw.FromRawUnchecked"/>
    public static ProfileBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBillingContactFromRaw : IFromRawJson<ProfileBillingContact>
{
    /// <inheritdoc/>
    public ProfileBillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBillingContact.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand response with nested contact, business, and compliance sections — mirrors
/// the request structure.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrand, ProfileBrandFromRaw>))]
public sealed record class ProfileBrand : JsonModel
{
    /// <summary>
    /// Unique identifier for the brand
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
    /// Business details and address information
    /// </summary>
    public ProfileBrandBusiness? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandBusiness>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// Compliance and TCR-related information
    /// </summary>
    public ProfileBrandCompliance? Compliance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandCompliance>("compliance");
        }
        init { this._rawData.Set("compliance", value); }
    }

    /// <summary>
    /// Contact information for the brand
    /// </summary>
    public ProfileBrandContact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileBrandContact>("contact");
        }
        init { this._rawData.Set("contact", value); }
    }

    /// <summary>
    /// When the brand was created
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
    /// Deprecated and scheduled for removal. Identifies the Campaign Service Provider
    /// that registered the brand, which is Sent, so the value is the same for every
    /// brand and every account. Nothing on your side can act on it and there is
    /// no replacement. Stop reading it.
    /// </summary>
    [Obsolete("deprecated")]
    public string? CspID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("csp_id");
        }
        init { this._rawData.Set("csp_id", value); }
    }

    public ApiEnum<string, ProfileBrandIdentityStatus>? IdentityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProfileBrandIdentityStatus>>(
                "identity_status"
            );
        }
        init { this._rawData.Set("identity_status", value); }
    }

    /// <summary>
    /// Whether this brand is inherited from the parent organization
    /// </summary>
    public bool? IsInherited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_inherited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_inherited", value);
        }
    }

    public ApiEnum<string, ProfileBrandStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProfileBrandStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the brand was submitted to TCR
    /// </summary>
    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submitted_at");
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <summary>
    /// Whether this brand has been submitted to TCR
    /// </summary>
    public bool? SubmittedToTcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("submitted_to_tcr");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("submitted_to_tcr", value);
        }
    }

    /// <summary>
    /// TCR brand ID (populated after TCR submission)
    /// </summary>
    public string? TcrBrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tcr_brand_id");
        }
        init { this._rawData.Set("tcr_brand_id", value); }
    }

    /// <summary>
    /// Universal EIN from TCR
    /// </summary>
    public string? UniversalEin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universal_ein");
        }
        init { this._rawData.Set("universal_ein", value); }
    }

    /// <summary>
    /// When the brand was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Business?.Validate();
        this.Compliance?.Validate();
        this.Contact?.Validate();
        _ = this.CreatedAt;
        _ = this.CspID;
        this.IdentityStatus?.Validate();
        _ = this.IsInherited;
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.SubmittedToTcr;
        _ = this.TcrBrandID;
        _ = this.UniversalEin;
        _ = this.UpdatedAt;
    }

    public ProfileBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrand(ProfileBrand profileBrand)
        : base(profileBrand) { }
#pragma warning restore CS8618

    public ProfileBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandFromRaw.FromRawUnchecked"/>
    public static ProfileBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandFromRaw : IFromRawJson<ProfileBrand>
{
    /// <inheritdoc/>
    public ProfileBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Business details and address information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrandBusiness, ProfileBrandBusinessFromRaw>))]
public sealed record class ProfileBrandBusiness : JsonModel
{
    /// <summary>
    /// City
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Country code (e.g., US, CA)
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Country where the business is registered
    /// </summary>
    public string? CountryOfRegistration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_of_registration");
        }
        init { this._rawData.Set("country_of_registration", value); }
    }

    /// <summary>
    /// Business entity type
    /// </summary>
    public string? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_type");
        }
        init { this._rawData.Set("entity_type", value); }
    }

    /// <summary>
    /// Legal business name
    /// </summary>
    public string? LegalName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_name");
        }
        init { this._rawData.Set("legal_name", value); }
    }

    /// <summary>
    /// Postal/ZIP code
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// State/province code
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Street address
    /// </summary>
    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    /// <summary>
    /// Tax ID/EIN number
    /// </summary>
    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <summary>
    /// Type of tax ID (e.g., us_ein, ca_bn)
    /// </summary>
    public string? TaxIDType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id_type");
        }
        init { this._rawData.Set("tax_id_type", value); }
    }

    /// <summary>
    /// Business website URL
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.CountryOfRegistration;
        _ = this.EntityType;
        _ = this.LegalName;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Street;
        _ = this.TaxID;
        _ = this.TaxIDType;
        _ = this.Url;
    }

    public ProfileBrandBusiness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandBusiness(ProfileBrandBusiness profileBrandBusiness)
        : base(profileBrandBusiness) { }
#pragma warning restore CS8618

    public ProfileBrandBusiness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandBusiness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandBusinessFromRaw.FromRawUnchecked"/>
    public static ProfileBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandBusinessFromRaw : IFromRawJson<ProfileBrandBusiness>
{
    /// <inheritdoc/>
    public ProfileBrandBusiness FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBrandBusiness.FromRawUnchecked(rawData);
}

/// <summary>
/// Compliance and TCR-related information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrandCompliance, ProfileBrandComplianceFromRaw>))]
public sealed record class ProfileBrandCompliance : JsonModel
{
    public ApiEnum<string, TcrBrandRelationship>? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrBrandRelationship>>(
                "brand_relationship"
            );
        }
        init { this._rawData.Set("brand_relationship", value); }
    }

    /// <summary>
    /// List of destination countries for messaging
    /// </summary>
    public IReadOnlyList<DestinationCountry>? DestinationCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DestinationCountry>>(
                "destination_countries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DestinationCountry>?>(
                "destination_countries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether this is a TCR (Campaign Registry) application
    /// </summary>
    public bool? IsTcrApplication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_tcr_application");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_tcr_application", value);
        }
    }

    /// <summary>
    /// Additional notes about the business or use case
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    /// <summary>
    /// Phone number prefix for messaging (e.g., "+1")
    /// </summary>
    public string? PhoneNumberPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_prefix");
        }
        init { this._rawData.Set("phone_number_prefix", value); }
    }

    /// <summary>
    /// Always null. The brand's free-text primary use case is no longer stored:
    /// it reached neither TCR nor any decision, and its column is dropped with no
    /// backfill, because the values were prose and the typed equivalent is the campaign's
    /// MessagingUseCaseUS.              Retained so existing v3 clients reading
    /// primary_use_case keep deserializing. Unlike the profile sharing flags, which
    /// can answer false truthfully, there is no value to report here — the field
    /// is present and empty rather than present and wrong.
    /// </summary>
    [Obsolete("deprecated")]
    public string? PrimaryUseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_use_case");
        }
        init { this._rawData.Set("primary_use_case", value); }
    }

    public ApiEnum<string, TcrVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TcrVertical>>("vertical");
        }
        init { this._rawData.Set("vertical", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BrandRelationship?.Validate();
        foreach (var item in this.DestinationCountries ?? [])
        {
            item.Validate();
        }
        _ = this.IsTcrApplication;
        _ = this.Notes;
        _ = this.PhoneNumberPrefix;
        _ = this.PrimaryUseCase;
        this.Vertical?.Validate();
    }

    public ProfileBrandCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandCompliance(ProfileBrandCompliance profileBrandCompliance)
        : base(profileBrandCompliance) { }
#pragma warning restore CS8618

    public ProfileBrandCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandComplianceFromRaw.FromRawUnchecked"/>
    public static ProfileBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandComplianceFromRaw : IFromRawJson<ProfileBrandCompliance>
{
    /// <inheritdoc/>
    public ProfileBrandCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileBrandCompliance.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for the brand
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileBrandContact, ProfileBrandContactFromRaw>))]
public sealed record class ProfileBrandContact : JsonModel
{
    /// <summary>
    /// Business/brand name
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("business_name");
        }
        init { this._rawData.Set("business_name", value); }
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
    /// Primary contact name
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
    /// Contact phone number in E.164 format
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// Contact phone country code (e.g., "1" for US)
    /// </summary>
    public string? PhoneCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_country_code");
        }
        init { this._rawData.Set("phone_country_code", value); }
    }

    /// <summary>
    /// Contact's role in the business
    /// </summary>
    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessName;
        _ = this.Email;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PhoneCountryCode;
        _ = this.Role;
    }

    public ProfileBrandContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileBrandContact(ProfileBrandContact profileBrandContact)
        : base(profileBrandContact) { }
#pragma warning restore CS8618

    public ProfileBrandContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileBrandContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileBrandContactFromRaw.FromRawUnchecked"/>
    public static ProfileBrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileBrandContactFromRaw : IFromRawJson<ProfileBrandContact>
{
    /// <inheritdoc/>
    public ProfileBrandContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileBrandContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileBrandIdentityStatusConverter))]
public enum ProfileBrandIdentityStatus
{
    SelfDeclared,
    Unverified,
    Verified,
    VettedVerified,
}

sealed class ProfileBrandIdentityStatusConverter : JsonConverter<ProfileBrandIdentityStatus>
{
    public override ProfileBrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SELF_DECLARED" => ProfileBrandIdentityStatus.SelfDeclared,
            "UNVERIFIED" => ProfileBrandIdentityStatus.Unverified,
            "VERIFIED" => ProfileBrandIdentityStatus.Verified,
            "VETTED_VERIFIED" => ProfileBrandIdentityStatus.VettedVerified,
            _ => (ProfileBrandIdentityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandIdentityStatus.SelfDeclared => "SELF_DECLARED",
                ProfileBrandIdentityStatus.Unverified => "UNVERIFIED",
                ProfileBrandIdentityStatus.Verified => "VERIFIED",
                ProfileBrandIdentityStatus.VettedVerified => "VETTED_VERIFIED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileBrandStatusConverter))]
public enum ProfileBrandStatus
{
    Active,
    Inactive,
    Suspended,
}

sealed class ProfileBrandStatusConverter : JsonConverter<ProfileBrandStatus>
{
    public override ProfileBrandStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => ProfileBrandStatus.Active,
            "INACTIVE" => ProfileBrandStatus.Inactive,
            "SUSPENDED" => ProfileBrandStatus.Suspended,
            _ => (ProfileBrandStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileBrandStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileBrandStatus.Active => "ACTIVE",
                ProfileBrandStatus.Inactive => "INACTIVE",
                ProfileBrandStatus.Suspended => "SUSPENDED",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileListResponseError, ProfileListResponseErrorFromRaw>)
)]
public sealed record class ProfileListResponseError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
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
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public ProfileListResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseError(ProfileListResponseError profileListResponseError)
        : base(profileListResponseError) { }
#pragma warning restore CS8618

    public ProfileListResponseError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseErrorFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseErrorFromRaw : IFromRawJson<ProfileListResponseError>
{
    /// <inheritdoc/>
    public ProfileListResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileListResponseMeta, ProfileListResponseMetaFromRaw>))]
public sealed record class ProfileListResponseMeta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
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

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public ProfileListResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponseMeta(ProfileListResponseMeta profileListResponseMeta)
        : base(profileListResponseMeta) { }
#pragma warning restore CS8618

    public ProfileListResponseMeta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseMetaFromRaw.FromRawUnchecked"/>
    public static ProfileListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileListResponseMetaFromRaw : IFromRawJson<ProfileListResponseMeta>
{
    /// <inheritdoc/>
    public ProfileListResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileListResponseMeta.FromRawUnchecked(rawData);
}
