using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// **Deprecated.** This endpoint is replaced by `/v3/sender-profiles` and will be
/// removed in a future release. It still behaves exactly as before, so nothing needs
/// to change today — but new integrations should use `/v3/sender-profiles`, which
/// models a profile's markets, compliance, brand, campaigns and billing explicitly.
///
/// <para>Updates a profile's configuration and settings. Requires admin role in
/// the organization. Only provided fields will be updated (partial update).</para>
///
/// <para>## Brand Management</para>
///
/// <para>Include the optional `brand` field to create or update the brand associated
/// with this profile. The brand holds KYC and TCR compliance data (legal business
/// info, contact details, messaging vertical). Once a brand has been submitted to
/// TCR it cannot be modified. Setting `inherit_tcr_brand: true` and providing `brand`
/// in the same request is not allowed.</para>
///
/// <para>## Payment Details</para>
///
/// <para>When `billing_model` is `"profile"` or `"profile_and_organization"` you
/// may include a `payment_details` object containing the card number, expiry (MM/YY),
/// CVC, and billing ZIP code. Payment details are **never stored** on our servers
/// and are forwarded directly to the payment processor. Providing `payment_details`
/// when `billing_model` is `"organization"` is not allowed.</para>
///
/// <para>## Deprecated fields</para>
///
/// <para>`sending_phone_number_profile_id` and `sending_whatsapp_number_profile_id`
/// are **accepted and ignored**. Sender borrowing is gone: a profile cannot send
/// from another profile's number, because two profiles behind one sender makes an
/// inbound reply and a delivery receipt ambiguous about whose they are.</para>
///
/// <para>Sending either **changes nothing and still returns `200`** — they are kept
/// on the contract so an existing integration keeps working. Reads carry both keys
/// too and always answer `null`, which is how you can confirm the value did not take.</para>
///
/// <para>Give the profile a sender of its own instead — `POST /v3/channels/sms`
/// or `POST /v3/channels/whatsapp`, sent with the `x-profile-id` header naming it.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class ProfileUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProfileID { get; init; }

    /// <summary>
    /// Deprecated. Accepted and ignored. Contact and template sharing between sender
    /// profiles is gone — a profile sees only what it owns, and the organization
    /// still sees all of its profiles' contacts and templates through read-time widening.
    /// The four columns behind these flags were dropped by M260720120000.
    ///        Retired the same way as SendingPhoneNumberProfileId, and for the same
    /// reason: the properties stay bound so an SDK that assigns them keeps compiling,
    /// and a 400 would break a working integration over a capability that is gone
    /// regardless. Every profile reports all four as false, so a caller that checks
    /// its own write can see it did not take.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? AllowContactSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_contact_sharing");
        }
        init { this._rawBodyData.Set("allow_contact_sharing", value); }
    }

    /// <summary>
    /// Whether number changes are allowed during onboarding (optional)
    /// </summary>
    public bool? AllowNumberChangeDuringOnboarding
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "allow_number_change_during_onboarding"
            );
        }
        init { this._rawBodyData.Set("allow_number_change_during_onboarding", value); }
    }

    [Obsolete("deprecated")]
    public bool? AllowTemplateSharing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_template_sharing");
        }
        init { this._rawBodyData.Set("allow_template_sharing", value); }
    }

    /// <summary>
    /// Billing contact information for a profile. Required when billing_model is
    /// "profile" or "profile_and_organization".
    /// </summary>
    public BillingContactInfo? BillingContact
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingContactInfo>("billing_contact");
        }
        init { this._rawBodyData.Set("billing_contact", value); }
    }

    /// <summary>
    /// Billing model: profile, organization, or profile_and_organization (optional).
    /// - "organization": the organization's billing details are used; no profile-level
    /// billing info needed. - "profile": the profile is billed independently; billing_contact
    /// is required. - "profile_and_organization": the profile is billed first with
    /// the organization as fallback; billing_contact is required.
    /// </summary>
    public string? BillingModel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billing_model");
        }
        init { this._rawBodyData.Set("billing_model", value); }
    }

    /// <summary>
    /// Brand and KYC data grouped into contact, business, and compliance sections
    /// </summary>
    public BrandsBrandData? Brand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BrandsBrandData>("brand");
        }
        init { this._rawBodyData.Set("brand", value); }
    }

    /// <summary>
    /// Profile description (optional)
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Profile icon URL (optional)
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("icon");
        }
        init { this._rawBodyData.Set("icon", value); }
    }

    [Obsolete("deprecated")]
    public bool? InheritContacts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_contacts");
        }
        init { this._rawBodyData.Set("inherit_contacts", value); }
    }

    /// <summary>
    /// Whether this profile inherits TCR brand from organization (optional)
    /// </summary>
    public bool? InheritTcrBrand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_tcr_brand");
        }
        init { this._rawBodyData.Set("inherit_tcr_brand", value); }
    }

    /// <summary>
    /// Whether this profile inherits TCR campaign from organization (optional)
    /// </summary>
    public bool? InheritTcrCampaign
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_tcr_campaign");
        }
        init { this._rawBodyData.Set("inherit_tcr_campaign", value); }
    }

    [Obsolete("deprecated")]
    public bool? InheritTemplates
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("inherit_templates");
        }
        init { this._rawBodyData.Set("inherit_templates", value); }
    }

    /// <summary>
    /// Profile name (optional)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Payment card details for this profile (optional). Accepted when billing_model
    /// is "profile" or "profile_and_organization". Not persisted on our servers —
    /// forwarded to the payment processor.
    /// </summary>
    public PaymentDetails? PaymentDetails
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PaymentDetails>("payment_details");
        }
        init { this._rawBodyData.Set("payment_details", value); }
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
    /// Direct phone number for SMS sending (optional)
    /// </summary>
    public string? SendingPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_phone_number");
        }
        init { this._rawBodyData.Set("sending_phone_number", value); }
    }

    /// <summary>
    /// Deprecated. Accepted and ignored. Sender borrowing is gone: a profile cannot
    /// send from another profile's SMS number. Supplying this changes nothing and
    /// the request still succeeds.              Bound rather than dropped so the
    /// property survives on the wire and in a generated client — an SDK that assigns
    /// it keeps compiling, which is the compatibility this exists for. It is deliberately
    /// not refused: a 400 here would break an integration that is otherwise working,
    /// and the capability it asks for is gone either way.              The trade-off,
    /// stated plainly. A caller asking for borrowing is told it succeeded when nothing
    /// happened. What makes that survivable is the read: sending_phone_number_profile_id
    /// comes back null on every profile, so a caller that checks its own write can
    /// see it did not take. Every request that carries one is logged, so we can tell
    /// when nobody is sending it any more and the field can go for real.
    ///       Give the profile a sender of its own instead: POST /v3/channels/sms
    /// with the x-profile-id header naming it.
    /// </summary>
    [Obsolete("deprecated")]
    public string? SendingPhoneNumberProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_phone_number_profile_id");
        }
        init { this._rawBodyData.Set("sending_phone_number_profile_id", value); }
    }

    [Obsolete("deprecated")]
    public string? SendingWhatsappNumberProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sending_whatsapp_number_profile_id");
        }
        init { this._rawBodyData.Set("sending_whatsapp_number_profile_id", value); }
    }

    /// <summary>
    /// Profile short name/abbreviation (optional). Must be 3–11 characters, contain
    /// only letters, numbers, and spaces, and include at least one letter. Example:
    /// "SALES", "Mkt 2", "Support1".
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("short_name");
        }
        init { this._rawBodyData.Set("short_name", value); }
    }

    /// <summary>
    /// Direct phone number for WhatsApp sending (optional)
    /// </summary>
    public string? WhatsappPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("whatsapp_phone_number");
        }
        init { this._rawBodyData.Set("whatsapp_phone_number", value); }
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

    public ProfileUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateParams(ProfileUpdateParams profileUpdateParams)
        : base(profileUpdateParams)
    {
        this.ProfileID = profileUpdateParams.ProfileID;

        this._rawBodyData = new(profileUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProfileUpdateParams(
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
    ProfileUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProfileUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
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

    public virtual bool Equals(ProfileUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/profiles/{0}", this.ProfileID)
        )
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
