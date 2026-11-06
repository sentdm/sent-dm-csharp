using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Services;

/// <summary>
/// What a market demands, before you have it.
///
/// <para>Requirements vary enormously and change without notice. US `TEN_DLC` registers
/// a brand and a campaign with The Campaign Registry and asks a substantial set
/// of questions; an alphanumeric sender pre-registers with documents in one country
/// and needs nothing in another.</para>
///
/// <para>This is the authoritative answer for whichever market you ask about, and
/// it is generated from the same declaration that validates the calls themselves
/// — so it cannot drift from what is actually enforced. The response includes the
/// request body to send, with every key that market wants already present and blank.</para>
///
/// <para>What you supplied, as opposed to what is asked of you, is reported on the
/// market under **Channels**.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IComplianceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IComplianceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComplianceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Call this first.** It returns what a channel, country and sender type demand
    /// before you can send there — and `setup[]`, the calls that satisfy those demands,
    /// in order, each with a body you can copy and send as it stands. You never have to
    /// track forty countries' rules yourself.
    ///
    /// <para>## Channel</para>
    ///
    /// <para>`channel` is `sms`, `whatsapp` or `rcs`, and **defaults to `sms`** — so a
    /// caller that omits it gets exactly what this endpoint has always returned.</para>
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
    /// <para>Requirements vary enormously. US `TEN_DLC` registers a brand and a
    /// campaign with The Campaign Registry and asks for a substantial set of values. An
    /// alphanumeric sender in one country pre-registers with supporting documents; in
    /// another it needs nothing at all. This is the authoritative answer for whichever
    /// market you are asking about, and it is the same declaration used to validate the
    /// calls themselves — so it can never drift from what is actually enforced.</para>
    ///
    /// <para>## `setup[]` — what to do</para>
    ///
    /// <para>**One step.** `POST /v3/channels/sms` adds the market and records
    /// everything it registers with — the identity in `compliance.brand`, the programme
    /// in `compliance.campaign`. There were three, in a load-bearing order, while the
    /// identity and the campaign were resources of their own; they are members of this
    /// call's body now, so there is nothing to sequence.</para>
    ///
    /// <para>Correct any of it afterwards with `PATCH
    /// /v3/channels/sms/{country}/{type}`, which takes the same `compliance` object one
    /// key at a time.</para>
    ///
    /// <para>Each step's `body` has every key that market wants already present, with
    /// the values left **blank**. Blank rather than filled with placeholders, because
    /// the body is meant to be sent: a null value counts as not supplied, so posting a
    /// step verbatim comes back naming every blank you left. `attachments[]` lists
    /// files to send as multipart on the channel call, each under the field name given
    /// — a file cannot be a JSON value, so documents are never listed in
    /// `compliance[]`.</para>
    ///
    /// <para>Every step is a call for whoever holds the key. To set a **sender
    /// profile** up instead, send the same requests with the `x-profile-id` header
    /// naming it; there is no separate path.</para>
    ///
    /// <para>## `requirements[]` — what each value means</para>
    ///
    /// <para>Each entry names a key for the `compliance` array, its value type, and
    /// whether it is required. `required_when` marks values needed only in certain
    /// cases — evaluate it against your own payload, e.g. `brand.entity_type ==
    /// PUBLIC_PROFIT`. `options` lists accepted values where the market constrains
    /// them, and `label` is suitable for rendering a form field.</para>
    ///
    /// <para>Values Sent supplies on your behalf are never listed: correlation ids,
    /// environment flags, carrier elections, and booleans derivable from what you
    /// already send.</para>
    ///
    /// <para>## When nothing is required</para>
    ///
    /// <para>`required` is `false` and `requirements` is empty, and the single `setup`
    /// step carries no `compliance` array at all. A `sender_id_pattern` may still be
    /// present — many markets constrain the sender string without registering anything.</para>
    /// </summary>
    Task<ApiResponseOfComplianceRequirements> RetrieveRequirements(
        ComplianceRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IComplianceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IComplianceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComplianceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/compliance/requirements</c>, but is otherwise the
    /// same as <see cref="IComplianceService.RetrieveRequirements(ComplianceRetrieveRequirementsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfComplianceRequirements>> RetrieveRequirements(
        ComplianceRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
