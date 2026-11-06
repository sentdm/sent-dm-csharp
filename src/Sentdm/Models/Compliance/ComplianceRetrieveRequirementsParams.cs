using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.Compliance;

/// <summary>
/// **Call this first.** It returns what a channel, country and sender type demand
/// before you can send there — and `setup[]`, the calls that satisfy those demands,
/// in order, each with a body you can copy and send as it stands. You never have
/// to track forty countries' rules yourself.
///
/// <para>## Channel</para>
///
/// <para>`channel` is `sms`, `whatsapp` or `rcs`, and **defaults to `sms`** — so
/// a caller that omits it gets exactly what this endpoint has always returned.</para>
///
/// <para>`sms` is the only one answered today; the other two are `501` until their
/// requirements are declared. They are refused rather than answered with an empty
/// requirement set, because empty would say the channel demands nothing, and both
/// demand plenty — WhatsApp a business verification and a display name review, RCS
/// a carrier approval. Saying "not yet" is the true answer and the same one `POST
/// /v3/sender-profiles` gives for `channels.whatsapp`.</para>
///
/// <para>`type` is an SMS sender type, and SMS is the only channel whose senders
/// have one.</para>
///
/// <para>Requirements vary enormously. US `TEN_DLC` registers a brand and a campaign
/// with The Campaign Registry and asks for a substantial set of values. An alphanumeric
/// sender in one country pre-registers with supporting documents; in another it
/// needs nothing at all. This is the authoritative answer for whichever market you
/// are asking about, and it is the same declaration used to validate the calls themselves
/// — so it can never drift from what is actually enforced.</para>
///
/// <para>## `setup[]` — what to do</para>
///
/// <para>**One step.** `POST /v3/channels/sms` adds the market and records everything
/// it registers with — the identity in `compliance.brand`, the programme in `compliance.campaign`.
/// There were three, in a load-bearing order, while the identity and the campaign
/// were resources of their own; they are members of this call's body now, so there
/// is nothing to sequence.</para>
///
/// <para>Correct any of it afterwards with `PATCH /v3/channels/sms/{country}/{type}`,
/// which takes the same `compliance` object one key at a time.</para>
///
/// <para>Each step's `body` has every key that market wants already present, with
/// the values left **blank**. Blank rather than filled with placeholders, because
/// the body is meant to be sent: a null value counts as not supplied, so posting
/// a step verbatim comes back naming every blank you left. `attachments[]` lists
/// files to send as multipart on the channel call, each under the field name given
/// — a file cannot be a JSON value, so documents are never listed in `compliance[]`.</para>
///
/// <para>Every step is a call for whoever holds the key. To set a **sender profile**
/// up instead, send the same requests with the `x-profile-id` header naming it; there
/// is no separate path.</para>
///
/// <para>## `requirements[]` — what each value means</para>
///
/// <para>Each entry names a key for the `compliance` array, its value type, and whether
/// it is required. `required_when` marks values needed only in certain cases — evaluate
/// it against your own payload, e.g. `brand.entity_type == PUBLIC_PROFIT`. `options`
/// lists accepted values where the market constrains them, and `label` is suitable
/// for rendering a form field.</para>
///
/// <para>Values Sent supplies on your behalf are never listed: correlation ids, environment
/// flags, carrier elections, and booleans derivable from what you already send.</para>
///
/// <para>## When nothing is required</para>
///
/// <para>`required` is `false` and `requirements` is empty, and the single `setup`
/// step carries no `compliance` array at all. A `sender_id_pattern` may still be
/// present — many markets constrain the sender string without registering anything.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ComplianceRetrieveRequirementsParams : ParamsBase
{
    /// <summary>
    /// Channel the sender is for: sms, whatsapp or rcs. Defaults to sms, which is
    /// the only one answered today — the other two are 501 until their requirements
    /// are declared.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("channel");
        }
        init { this._rawQueryData.Set("channel", value); }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code, e.g. US, XK, IN
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("country");
        }
        init { this._rawQueryData.Set("country", value); }
    }

    /// <summary>
    /// Sender type: LOCAL, MOBILE, TEN_DLC, TOLL_FREE, SHORT_CODE, ALPHANUMERIC.
    /// 10DLC is accepted as a synonym of TEN_DLC, the same as on POST /v3/sender-profiles.
    /// Applies to channel=sms, the only channel whose senders have a type.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("type");
        }
        init { this._rawQueryData.Set("type", value); }
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

    public ComplianceRetrieveRequirementsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceRetrieveRequirementsParams(
        ComplianceRetrieveRequirementsParams complianceRetrieveRequirementsParams
    )
        : base(complianceRetrieveRequirementsParams) { }
#pragma warning restore CS8618

    public ComplianceRetrieveRequirementsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceRetrieveRequirementsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ComplianceRetrieveRequirementsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ComplianceRetrieveRequirementsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v3/compliance/requirements"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
