using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Exceptions;

namespace Sentdm.Models.Channels.Rcs;

/// <summary>
/// Asks for an RCS agent and records the order form the carriers vet it against.
/// Always `202`: an agent is approved by the carriers, not by this call, and nothing
/// here can make that happen sooner.
///
/// <para>## What it asks for</para>
///
/// <para>The RCS Agent Order Form — the same one our team fills in on your behalf
/// today, so nothing has to be collected from you twice. **All fields are required**
/// and must be submitted together so the carrier review has everything it needs.
/// The only exception is `opt_in_screenshot_url`.</para>
///
/// <para>**Agent identity:** `display_name`, `description`, `agent_use_case` (must
/// be one of the accepted use cases; the error names the set), `brand_color` (six-digit
/// hex, `#RRGGBB`).</para>
///
/// <para>**Brand identity:** `brand_name` — the brand this agent presents. Not taken
/// from `compliance.brand`: a business may present a different brand on RCS than
/// the one its 10DLC registration is filed against, and the carriers vet this one.
/// `privacy_policy_url`, `terms_and_conditions_url`, `website_url`, `logo_url`, and
/// `banner_url` must be absolute `http(s)` URLs that the carriers can fetch without
/// authentication. The form specifies 224×224 px and 50 KB for the logo and 1440×448
/// px and 200 KB for the banner; these cannot be checked without the image bytes.</para>
///
/// <para>**Contact details:** `brand_phone_number`, `customer_support_phone_number`,
/// `brand_email`, `customer_support_email`, `contact_name_and_title`.</para>
///
/// <para>**Company:** `company_ein`, `entity_type`, `official_address` (street, city,
/// state, postal_code, country), `brief_company_description`.</para>
///
/// <para>**Consent and messages:** `opt_in_process_description`, `start_message`,
/// `help_message`, `stop_message`, `sample_messages` (at least one example message).</para>
///
/// <para>**Optional:** `opt_in_screenshot_url` (validated as an http(s) URL if supplied).</para>
///
/// <para>Anything supplied is checked against accepted values rather than passed
/// through: a value the provider rejects would otherwise surface days later, to
/// somebody who cannot fix it without asking you.</para>
///
/// <para>**A customer has one agent.** Asking again while you have one is `409`.</para>
///
/// <para>## What comes back, and what does not</para>
///
/// <para>Returns **the agent** — the form as stored, plus `id` and `status`. Not
/// your other channels, which this call cannot have changed.</para>
///
/// <para>`status` is `PROVISIONING` until the agent is handed to the carriers and
/// approved. **`GET /v3/channels` reports `rcs: null` until then** — a channel row
/// is what routing reads to decide you are sendable, and writing one for an unapproved
/// agent would claim a channel that cannot carry traffic.</para>
///
/// <para>Send `x-profile-id` with an organization key to ask for one of your profiles' agents.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RcCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Which kind of traffic the agent carries. One of the accepted use cases; the
    /// error names the set.
    /// </summary>
    public ApiEnum<string, AgentUseCase>? AgentUseCase
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AgentUseCase>>(
                "agent_use_case"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("agent_use_case", value);
        }
    }

    public string? BannerUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("banner_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("banner_url", value);
        }
    }

    /// <summary>
    /// Primary brand colour, as #RRGGBB. Three-digit shorthand is refused: the value
    /// is submitted verbatim, so two spellings of one colour is only a way for the
    /// stored value to disagree with the form.
    /// </summary>
    public string? BrandColor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("brand_color", value);
        }
    }

    public string? BrandEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("brand_email", value);
        }
    }

    /// <summary>
    /// The brand this agent presents over RCS.              Not taken from your compliance.brand:
    /// a business may present a different brand on RCS than the one its 10DLC registration
    /// is filed against, and the carriers vet this one.
    /// </summary>
    public string? BrandName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("brand_name", value);
        }
    }

    /// <summary>
    /// The brand's own number. Also becomes the agent's canonical sending number
    /// for routing, which is why it is normalised to E.164 rather than stored as sent.
    /// </summary>
    public string? BrandPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("brand_phone_number", value);
        }
    }

    public string? BriefCompanyDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brief_company_description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("brief_company_description", value);
        }
    }

    public string? CompanyEin
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_ein");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_ein", value);
        }
    }

    public string? ContactNameAndTitle
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contact_name_and_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contact_name_and_title", value);
        }
    }

    public string? CustomerSupportEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_support_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("customer_support_email", value);
        }
    }

    public string? CustomerSupportPhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_support_phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("customer_support_phone_number", value);
        }
    }

    /// <summary>
    /// What the agent is for, shown to recipients. Capped by the carriers, not by us.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The name the agent shows in the messaging client.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("display_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("display_name", value);
        }
    }

    public string? EntityType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("entity_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entity_type", value);
        }
    }

    public string? HelpMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("help_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("help_message", value);
        }
    }

    /// <summary>
    /// Publicly reachable logo. It has to be fetchable without authentication at
    /// review time, so a URL behind a login passes this call and fails the review.
    /// </summary>
    public string? LogoUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("logo_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("logo_url", value);
        }
    }

    /// <summary>
    /// The registered address of the company behind the agent.
    /// </summary>
    public RcsAddress? OfficialAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<RcsAddress>("official_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("official_address", value);
        }
    }

    /// <summary>
    /// How recipients opt in, in prose. The carriers read this one.
    /// </summary>
    public string? OptInProcessDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_in_process_description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opt_in_process_description", value);
        }
    }

    /// <summary>
    /// A screenshot of the opt-in, as a publicly fetchable URL.
    /// </summary>
    public string? OptInScreenshotUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opt_in_screenshot_url");
        }
        init { this._rawBodyData.Set("opt_in_screenshot_url", value); }
    }

    /// <summary>
    /// Required by US carriers. Must be an absolute http(s) URL they can fetch.
    /// </summary>
    public string? PrivacyPolicyUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("privacy_policy_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("privacy_policy_url", value);
        }
    }

    /// <summary>
    /// Examples of what the agent will send, for the review.
    /// </summary>
    public IReadOnlyList<string>? SampleMessages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("sample_messages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "sample_messages",
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

    public string? StartMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("start_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("start_message", value);
        }
    }

    public string? StopMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("stop_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stop_message", value);
        }
    }

    public string? TermsAndConditionsUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("terms_and_conditions_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("terms_and_conditions_url", value);
        }
    }

    /// <summary>
    /// The brand's own site.
    /// </summary>
    public string? WebsiteUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("website_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("website_url", value);
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

    public RcCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcCreateParams(RcCreateParams rcCreateParams)
        : base(rcCreateParams)
    {
        this._rawBodyData = new(rcCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RcCreateParams(
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
    RcCreateParams(
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
    public static RcCreateParams FromRawUnchecked(
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

    public virtual bool Equals(RcCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/channels/rcs")
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

/// <summary>
/// Which kind of traffic the agent carries. One of the accepted use cases; the error
/// names the set.
/// </summary>
[JsonConverter(typeof(AgentUseCaseConverter))]
public enum AgentUseCase
{
    Verification,
    Notifications,
    Marketing,
    MultiUse,
}

sealed class AgentUseCaseConverter : JsonConverter<AgentUseCase>
{
    public override AgentUseCase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VERIFICATION" => AgentUseCase.Verification,
            "NOTIFICATIONS" => AgentUseCase.Notifications,
            "MARKETING" => AgentUseCase.Marketing,
            "MULTI_USE" => AgentUseCase.MultiUse,
            _ => (AgentUseCase)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentUseCase value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentUseCase.Verification => "VERIFICATION",
                AgentUseCase.Notifications => "NOTIFICATIONS",
                AgentUseCase.Marketing => "MARKETING",
                AgentUseCase.MultiUse => "MULTI_USE",
                _ => throw new SentInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
