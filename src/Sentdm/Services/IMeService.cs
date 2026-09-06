using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Me;

namespace Sentdm.Services;

/// <summary>
/// Who the current key is.
///
/// <para>`GET /v3/me` answers with the account the key authenticates as, which is
/// the quickest way to tell a live key from a test one, an organization key from
/// a sender profile's, and to confirm `x-profile-id` resolved to the profile you meant.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the account associated with the provided API key. The response includes
    /// account identity, contact information, messaging channel configuration, and —
    /// depending on the account type — either a list of child profiles or the profile's
    /// own settings.
    ///
    /// <para>**Account types:** - `organization` — Has child profiles. The `profiles`
    /// array is populated. - `user` — Standalone account with no profiles. - `profile`
    /// — Child of an organization. Includes `organization_id`, `short_name`, `status`,
    /// and `settings`.</para>
    ///
    /// <para>**Channels:** The `channels` object always includes `sms`, `whatsapp`, and
    /// `rcs`. Each channel has a `configured` boolean. Configured channels expose
    /// additional details such as `phone_number`.</para>
    ///
    /// <para>**Sending number:** `sending_phone_number` is the account's US SMS sender.
    /// It is intentionally the same value as `channels.sms.phone_number` — the two are
    /// kept in step, and it is published under both names because
    /// `sending_phone_number` is what this value is called on `GET /v3/profiles`. Read
    /// either. One difference: `sending_phone_number` is always present, including as
    /// `null`, while `channels.sms.phone_number` is omitted when there is no sender.</para>
    ///
    /// <para>`sending_phone_number_profile_id` names the account that holds that number
    /// in inventory — normally this account, and a different one where a number is
    /// shared. Both are `null` when the account has no US SMS sender.</para>
    /// </summary>
    Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/me</c>, but is otherwise the
    /// same as <see cref="IMeService.Retrieve(MeRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MeRetrieveResponse>> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
