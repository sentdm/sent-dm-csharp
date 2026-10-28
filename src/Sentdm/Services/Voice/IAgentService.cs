using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

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
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an agent that answers phone calls through the Sent Voice Gateway.
    /// `session_type` says whether Sent carries the call as text (the caller's speech
    /// recognised for the agent, the agent's text spoken) or as audio. With
    /// `websocket_url` the gateway dials your agent for each call and signs the
    /// handshake with the `signing_secret` this response returns; without it, your
    /// agent dials in with your API key and this agent's `id`.
    ///
    /// <para>`tools`, `transfer_targets`, `fallback` and `limits` say what the agent
    /// may do on a call. Voices and languages for text sessions come from `GET
    /// /v3/voice/voices`. Calls reach the agent once a number is bound to it on
    /// `/v3/channels/voice`.</para>
    ///
    /// <para>`signing_secret` is shown here and on `POST
    /// /v3/voice/agents/{id}/rotate-secret` only; store it now. With `sandbox: true`
    /// the request is validated and the agent reported with `202`; nothing is written.</para>
    /// </summary>
    Task<ApiResponseOfVoiceAgent> Create(
        AgentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The agent as stored, without its signing secret.
    /// </summary>
    Task<ApiResponseOfVoiceAgent> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceAgent> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes the fields you name and answers with the agent as stored, the same shape
    /// `GET` returns.
    ///
    /// <para>A key left out is left alone. A key sent as `null` clears an optional
    /// field (`websocket_url` makes the agent dial in, `greeting` and `fallback` go,
    /// `speech`, `audio`, `tools`, `limits` and `transcripts` return to their
    /// defaults). A key sent with a value replaces that field whole: send the whole
    /// `limits` object, not one of its keys. Changing `session_type` drops `speech`,
    /// `audio` and `greeting` unless the body sends them, since the other type cannot
    /// carry them. The result is checked like a new agent, and a body that changes
    /// nothing is `400`.</para>
    ///
    /// <para>With `sandbox: true` nothing is written: the request is validated against
    /// the stored agent and the agent is reported with `200` as it would read after the
    /// change.</para>
    /// </summary>
    Task<ApiResponseOfVoiceAgent> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceAgent> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Your voice agents, newest first. `page` and `page_size` (1 to 100, default 20)
    /// page the list. Signing secrets are never listed.
    /// </summary>
    Task<AgentListPage> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes the agent. Calls it already took keep their `agent_id`.
    ///
    /// <para>An agent that one of your voice numbers routes to, or that another of your
    /// agents lists in `transfer_targets`, is not deleted: the answer is `409` with a
    /// message naming those numbers and agents. Unbind the numbers (`PATCH
    /// /v3/channels/voice/{number}` with `"agent_id": null`), take the agent out of the
    /// others' `transfer_targets` or delete them, and try again.</para>
    ///
    /// <para>With `sandbox: true` nothing is written: the agent is looked up and the
    /// answer is the one a real delete would give.</para>
    /// </summary>
    Task Delete(AgentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a new `signing_secret` for the agent and returns it. The previous
    /// secret stops signing immediately, so update your agent before the next call
    /// reaches it.
    ///
    /// <para>With `sandbox: true` a secret is generated and returned with `202`, and
    /// nothing is written.</para>
    /// </summary>
    Task<ApiResponseOfVoiceAgentSecret> RotateSecret(
        AgentRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(AgentRotateSecretParams, CancellationToken)"/>
    Task<ApiResponseOfVoiceAgentSecret> RotateSecret(
        string id,
        AgentRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/voice/agents</c>, but is otherwise the
    /// same as <see cref="IAgentService.Create(AgentCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceAgent>> Create(
        AgentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/voice/agents/{id}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceAgent>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceAgent>> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/voice/agents/{id}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceAgent>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceAgent>> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/voice/agents</c>, but is otherwise the
    /// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentListPage>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/voice/agents/{id}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Delete(AgentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/voice/agents/{id}/rotate-secret</c>, but is otherwise the
    /// same as <see cref="IAgentService.RotateSecret(AgentRotateSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfVoiceAgentSecret>> RotateSecret(
        AgentRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(AgentRotateSecretParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfVoiceAgentSecret>> RotateSecret(
        string id,
        AgentRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
