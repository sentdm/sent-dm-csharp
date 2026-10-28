using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Voice.Tokens;

namespace Sentdm.Services.Voice;

/// <summary>
/// Phone calls from the numbers you hold, driven by your own callback URL.
///
/// <para>`POST /v3/channels/voice` enables a number for calls, with the callback
/// URL Sent asks what to do with each call on it, and `POST /v3/voice/tokens` mints
/// a short-lived token that lets a user of your app place and receive calls as that
/// number. When a call arrives or a caller presses a key, a signed question is POSTed
/// to the callback URL and the answer decides the call; `POST /v3/channels/voice/{number}/test`
/// checks the URL answers the way we need before a real call reaches it, and `POST
/// /v3/channels/voice/{number}/rotate-secret` replaces the signing secret. The call
/// events themselves (`call.completed` and the rest) arrive through your webhooks.</para>
///
/// <para>Every call is a record under `/v3/voice/calls`: read it, list its recordings
/// once one is ready, hang it up, start or stop recording, and add, mute or remove
/// conference participants while it is live. A leg to a phone number runs for at
/// most what your balance affords at the destination's rate.</para>
///
/// <para>**Voice agents.** `POST /v3/voice/agents` creates an agent that answers
/// calls through the Sent Voice Gateway: `session_type` says whether Sent carries
/// the call as text (speech recognised and spoken for the agent) or as audio, `websocket_url`
/// is where the gateway dials the agent for each call (leave it out and the agent
/// dials in with your API key), and `tools`, `transfer_targets`, `fallback` and
/// `limits` say what it may do on a call. The agent's `signing_secret` is shown
/// on create and on `POST /v3/voice/agents/{id}/rotate-secret` only. Voices and languages
/// for text sessions come from `GET /v3/voice/voices`. A number takes calls to an
/// agent once it is bound to it on `/v3/channels/voice`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITokenServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Mints a short-lived token for one of your app users. Call this from your backend
    /// and return the token to your app, which passes it to the voice client SDK to
    /// register. The identity is bound to the given number, or to your default app-call
    /// number when omitted, and calls placed by that identity are routed through the
    /// bound number. Minting again re-binds the identity, so an identity can move
    /// between numbers.
    /// </summary>
    Task<ApiResponseOfVoiceToken> Create(
        TokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITokenService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITokenServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/voice/tokens</c>, but is otherwise the
    /// same as <see cref="ITokenService.Create(TokenCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceToken>> Create(
        TokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
