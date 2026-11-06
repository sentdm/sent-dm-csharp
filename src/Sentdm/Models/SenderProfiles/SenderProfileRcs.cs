using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Asks for an RCS agent of the profile's own, optionally with the full order form
/// inline.              Two modes, distinguished by whether any field is populated:
/// "rcs": {} — intent only. Records that the profile wants its own agent; the order
/// form is submitted separately through POST /v3/channels/rcs once the fields are
/// ready. "rcs": { ...fields... } — full form. All required fields must be present;
/// the agent is created alongside the profile in one call. Omitting opt_in_screenshot_url
/// is allowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfileRcs, SenderProfileRcsFromRaw>))]
public sealed record class SenderProfileRcs : JsonModel
{
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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

    public string? BannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("banner_url");
        }
        init { this._rawData.Set("banner_url", value); }
    }

    public string? BillingCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_category");
        }
        init { this._rawData.Set("billing_category", value); }
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

    public string? HostingRegion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hosting_region");
        }
        init { this._rawData.Set("hosting_region", value); }
    }

    public string? LogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logo_url");
        }
        init { this._rawData.Set("logo_url", value); }
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
    /// Optional — uploaded separately and its URL may not be known at submission time.
    /// </summary>
    public string? OptInScreenshotUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opt_in_screenshot_url");
        }
        init { this._rawData.Set("opt_in_screenshot_url", value); }
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
        _ = this.Description;
        _ = this.AgentUseCase;
        _ = this.BannerUrl;
        _ = this.BillingCategory;
        _ = this.BrandColor;
        _ = this.BrandEmail;
        _ = this.BrandName;
        _ = this.BrandPhoneNumber;
        _ = this.BriefCompanyDescription;
        _ = this.CompanyEin;
        _ = this.ContactNameAndTitle;
        _ = this.CustomerSupportEmail;
        _ = this.CustomerSupportPhoneNumber;
        _ = this.DisplayName;
        _ = this.EntityType;
        _ = this.HelpMessage;
        _ = this.HostingRegion;
        _ = this.LogoUrl;
        this.OfficialAddress?.Validate();
        _ = this.OptInProcessDescription;
        _ = this.OptInScreenshotUrl;
        _ = this.PrivacyPolicyUrl;
        _ = this.SampleMessages;
        _ = this.StartMessage;
        _ = this.StopMessage;
        _ = this.TermsAndConditionsUrl;
        _ = this.WebsiteUrl;
    }

    public SenderProfileRcs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileRcs(SenderProfileRcs senderProfileRcs)
        : base(senderProfileRcs) { }
#pragma warning restore CS8618

    public SenderProfileRcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileRcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileRcsFromRaw.FromRawUnchecked"/>
    public static SenderProfileRcs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SenderProfileRcs(string description)
        : this()
    {
        this.Description = description;
    }
}

class SenderProfileRcsFromRaw : IFromRawJson<SenderProfileRcs>
{
    /// <inheritdoc/>
    public SenderProfileRcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderProfileRcs.FromRawUnchecked(rawData);
}
