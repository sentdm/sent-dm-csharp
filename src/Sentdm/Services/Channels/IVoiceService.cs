using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Services.Channels;

/// <summary>
/// The senders you send from, one per channel.
///
/// <para>**SMS is a list of markets**, each keyed by `(country, number_type)` —
/// a customer can hold `us/10dlc` and `gb/alphanumeric` at once, so a market is addressed
/// by the pair rather than by country alone. **WhatsApp and RCS are single**: a
/// customer has one business account and one agent. **Voice is per number**: each
/// number you hold can carry phone calls on its own (`POST /v3/channels/voice`),
/// each with the callback URL Sent asks what to do with its calls, one of them is
/// the default line for calls placed from your app, and voice tokens are minted
/// under `POST /v3/channels/voice/tokens`. Read your voice numbers with `GET /v3/channels/voice`
/// and change one with `PATCH /v3/channels/voice/{number}`.</para>
///
/// <para>## Compliance lives on the market</para>
///
/// <para>Adding a market records everything that market registers with, in its `compliance`
/// object. Only **US `TEN_DLC`** registers with a regime — The Campaign Registry
/// — and it is the only market whose compliance carries `brand` and `campaign`. Everywhere
/// else compliance is documents, and many markets ask for none at all.</para>
///
/// <para>`GET` and `PATCH` on a market return and accept the same shape, so what
/// comes back can be sent back: an omitted key is left alone, and a key reported
/// in `requirements` is the path into the body that clears it.</para>
///
/// <para>Call `GET /v3/compliance/requirements` first — it answers what a market
/// demands before you hold it, with a body you can fill in and post.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Adds voice to one of the numbers you hold, or gives you a new one. Send `number`
    /// for a number that is already yours (see `GET /v3/channels`); leave it out to be
    /// given a new US number, optionally in a particular `area_code`. Sending both is
    /// refused. Nothing registers, so the number can carry calls as soon as this
    /// returns.
    ///
    /// <para>What happens on a call is decided by your `callback_url`: when a call
    /// arrives on the number, or a caller presses a key on a menu, Sent POSTs a signed
    /// question there and follows the answer. The response carries the
    /// `callback_secret` the questions are signed with, the one time it is shown
    /// without rotating; verify a question the way you verify a webhook. `POST
    /// /v3/channels/voice/{number}/test` sends a test question and reports the verdict.</para>
    ///
    /// <para>Your first voice number becomes the line app-originated calls are placed
    /// from when a voice token names no number; send `default_for_app_calls: true` to
    /// give that role to another number. A number you turned off earlier is turned back
    /// on, and the same number with a different `callback_url` has its URL replaced and
    /// keeps its secret.</para>
    ///
    /// <para>Read the number's settings with `GET /v3/channels/voice` and change them
    /// with `PATCH /v3/channels/voice/{number}`.</para>
    ///
    /// <para>With `sandbox: true` the request is validated and a simulated number
    /// reported with `202`; nothing is written and no number is bought.</para>
    /// </summary>
    Task<ApiResponseOfVoiceNumberCreated> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reads one of your voice numbers, active or inactive: its status, whether it is
    /// the default line for calls placed from your app, and its callback URL. The
    /// signing secret is not on this read.
    ///
    /// <para>The same shape `GET /v3/channels/voice` lists, and the same shape `PATCH`
    /// on this path accepts and returns, so what comes back can be sent back.</para>
    ///
    /// <para>The number is the E.164 value in the path with the plus sign URL-encoded
    /// (`%2B`).</para>
    /// </summary>
    Task<ApiResponseOfVoiceNumber> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceNumber> Retrieve(
        string number,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes one of your voice numbers and answers with the number as stored, the
    /// same shape `GET` on this path returns, so what comes back can be sent back.
    ///
    /// <para>## What it changes</para>
    ///
    /// <para>| Body | Effect | | --- | --- | | `"status": "ACTIVE"` | turns calls on
    /// again for a number you turned off; the callback URL and the secret it had are
    /// kept | | `"status": "INACTIVE"` | turns calls off; the callback URL and the
    /// secret stay on the number | | `"default_for_app_calls": true` | makes this the
    /// line app-originated calls are placed from when a voice token names no number | |
    /// `"callback_url": "https://example.com/voice"` | replaces where Sent asks what to
    /// do with each call on the number; the signing secret is kept, and a number that
    /// was waiting for its first URL is turned on | | key omitted | left exactly as it
    /// is |</para>
    ///
    /// <para>`status` is matched ignoring case. Any combination is accepted: `status:
    /// "ACTIVE"` with `default_for_app_calls: true` turns a number on as the new
    /// default, and a `callback_url` sent with either status is written too. A body
    /// that names none of the three is refused.</para>
    ///
    /// <para>## What it will refuse</para>
    ///
    /// <para>**`default_for_app_calls: false` is `400`.** An account with active voice
    /// numbers always has exactly one default, so the default moves by giving it to
    /// another number.</para>
    ///
    /// <para>**Turning the default line off is `409`** while other active voice numbers
    /// remain. Move the default to another number first. Turning off your last voice
    /// number is allowed; that turns phone calls off.</para>
    ///
    /// <para>**Making an inactive number the default is `400`.** Send `status:
    /// "ACTIVE"` in the same call.</para>
    ///
    /// <para>A number added without a `callback_url` is `INACTIVE` for that one reason,
    /// so sending it a `callback_url` turns it on by itself, and it becomes your
    /// default line if you have no other active voice number. A number you turned off
    /// while it had a URL stays off.</para>
    ///
    /// <para>**A number you never turned voice on for is `404`.** Add it with `POST
    /// /v3/channels/voice`.</para>
    ///
    /// <para>The number is the E.164 value in the path with the plus sign URL-encoded
    /// (`%2B`).</para>
    ///
    /// <para>With `sandbox: true` nothing is written: the request is validated against
    /// the stored number and the number is reported with `200` as it would read after
    /// the change.</para>
    /// </summary>
    Task<ApiResponseOfVoiceNumber> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VoiceUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceNumber> Update(
        string number,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Every number you turned phone calls on for, active or inactive, oldest first.
    /// Each entry carries the number's status, whether it is the default line for calls
    /// placed from your app, and its callback URL. The signing secret is never on a
    /// read; it is shown when voice is turned on and by `POST
    /// /v3/channels/voice/{number}/rotate-secret`.
    ///
    /// <para>The same entries `GET /v3/channels` reports under `voice`, and the same
    /// shape `GET /v3/channels/voice/{number}` returns for one of them. Change a number
    /// with `PATCH /v3/channels/voice/{number}`.</para>
    /// </summary>
    Task<ApiResponseOfListOfVoiceNumber> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mints a short-lived token for one of your app users. Call this from your backend
    /// and return the token to your app, which passes it to the voice client SDK to
    /// register. The identity is bound to the given number, or to your default app-call
    /// number when omitted, and calls placed by that identity are routed through the
    /// bound number. Minting again re-binds the identity, so an identity can move
    /// between numbers.
    /// </summary>
    Task<ApiResponseOfVoiceToken> CreateToken(
        VoiceCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a new signing secret for the questions Sent sends to this number's
    /// callback URL and returns it. The previous secret stops signing immediately, so
    /// update your backend before the next call reaches it. The number is the E.164
    /// value in the path with the plus sign URL-encoded (`%2B`).
    ///
    /// <para>With `sandbox: true` a secret is generated and returned with `202`, and
    /// nothing is written.</para>
    /// </summary>
    Task<ApiResponseOfVoiceSecret> RotateSecret(
        VoiceRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(VoiceRotateSecretParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceSecret> RotateSecret(
        string number,
        VoiceRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a synthetic call.request question, flagged "test": true, to the number's
    /// callback URL, signed with that number's real secret, and reports what came back.
    /// Use it to build and debug your callback endpoint without placing calls: no call
    /// is placed, nothing is billed, and nothing is stored. One attempt with the same
    /// deadline as a live call, no retry. The outcome is ok when your endpoint answered
    /// 2xx with a valid answer; otherwise it is timeout, connection_failed, http_error
    /// or invalid_answer, with the reason and, for an invalid answer, the field at
    /// fault. The number is the E.164 value in the path with the plus sign URL-encoded
    /// (`%2B`).
    ///
    /// <para>With `sandbox: true` nothing is sent: the verdict comes back ok with `202`
    /// and no request or response in it.</para>
    /// </summary>
    Task<ApiResponseOfVoiceCallbackTest> Test(
        VoiceTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(VoiceTestParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceCallbackTest> Test(
        string number,
        VoiceTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/voice</c>, but is otherwise the
    /// same as <see cref="IVoiceService.Create(VoiceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceNumberCreated>> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/voice/{number}</c>, but is otherwise the
    /// same as <see cref="IVoiceService.Retrieve(VoiceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceNumber>> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceNumber>> Retrieve(
        string number,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/channels/voice/{number}</c>, but is otherwise the
    /// same as <see cref="IVoiceService.Update(VoiceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceNumber>> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VoiceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceNumber>> Update(
        string number,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/channels/voice</c>, but is otherwise the
    /// same as <see cref="IVoiceService.List(VoiceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfListOfVoiceNumber>> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/voice/tokens</c>, but is otherwise the
    /// same as <see cref="IVoiceService.CreateToken(VoiceCreateTokenParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceToken>> CreateToken(
        VoiceCreateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/voice/{number}/rotate-secret</c>, but is otherwise the
    /// same as <see cref="IVoiceService.RotateSecret(VoiceRotateSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceSecret>> RotateSecret(
        VoiceRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(VoiceRotateSecretParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceSecret>> RotateSecret(
        string number,
        VoiceRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/channels/voice/{number}/test</c>, but is otherwise the
    /// same as <see cref="IVoiceService.Test(VoiceTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceCallbackTest>> Test(
        VoiceTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(VoiceTestParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceCallbackTest>> Test(
        string number,
        VoiceTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
