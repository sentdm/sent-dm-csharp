using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Calls;
using Sentdm.Models.Calls.Participants;

namespace Sentdm.Services.Calls;

/// <summary>
/// Phone calls from the numbers you hold, driven by your own callback URL.
///
/// <para>`POST /v3/channels/voice` enables a number for calls, with the callback
/// URL Sent asks what to do with each call on it, and `POST /v3/channels/voice/tokens`
/// mints a short-lived token that lets a user of your app place and receive calls
/// as that number. When a call arrives or a caller presses a key, a signed question
/// is POSTed to the callback URL and the answer decides the call; `POST /v3/channels/voice/{number}/test`
/// checks the URL answers the way we need before a real call reaches it, and `POST
/// /v3/channels/voice/{number}/rotate-secret` replaces the signing secret. The call
/// events themselves (`call.completed` and the rest) arrive through your webhooks.</para>
///
/// <para>Every call is a record under `/v3/calls`: read it, list its recordings
/// once one is ready, hang it up, start or stop recording, and add, mute or remove
/// conference participants while it is live. A leg to a phone number runs for at
/// most what your balance affords at the destination's rate.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IParticipantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IParticipantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParticipantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Mutes or unmutes one participant of the conference room a live call is in, named
    /// by the participant's own call id from the participants list: send muted true to
    /// silence them, muted false to let them be heard again. Muting a participant who
    /// is already muted succeeds, as does unmuting one who is not. A participant who is
    /// not in this call's room answers 404. A call that has ended answers 409, as does
    /// a call that is not in a conference.
    /// </summary>
    Task Update(ParticipantUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ParticipantUpdateParams, CancellationToken)"/>
    Task Update(
        string participantID,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists who is in the conference room one of your live calls is in: each
    /// participant's own call id, who they are, whether the room mutes them, and how
    /// long they have been connected. The call itself is one of the participants. Use a
    /// participant's id to mute or remove them; it is also a call id, so GET
    /// /v3/calls/{id} accepts it. A call that has ended answers 409, as does a call
    /// that is not in a conference.
    /// </summary>
    Task<ApiResponseOfListOfCallParticipant> List(
        ParticipantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ParticipantListParams, CancellationToken)"/>
    Task<ApiResponseOfListOfCallParticipant> List(
        string id,
        ParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Dials one of your app users or a phone number into a call that is in a
    /// conference room, and answers with the participant's own call record. The
    /// participant is a call of their own: it has its own id, can be looked up and hung
    /// up, and is billed and reported through call.completed and call.failed like any
    /// other call. Every participant needs a positive balance. A phone participant is
    /// called from caller_id, which must be one of your numbers, or from the call's
    /// owning number when omitted, and needs a destination you may call. Only a call
    /// your answer connected to a conference can take participants: a call connected to
    /// a user or a number answers 409.
    /// </summary>
    Task<ApiResponseOfCall> Add(
        ParticipantAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ParticipantAddParams, CancellationToken)"/>
    Task<ApiResponseOfCall> Add(
        string id,
        ParticipantAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes one participant from the conference room a live call is in, named by the
    /// participant's own call id from the participants list. Their leg ends and is
    /// reported through call.completed like any other call; everyone else stays
    /// connected. A participant who is not in this call's room answers 404. A call that
    /// has ended answers 409, as does a call that is not in a conference.
    /// </summary>
    Task Remove(ParticipantRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(ParticipantRemoveParams, CancellationToken)"/>
    Task Remove(
        string participantID,
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes every participant from the conference room a live call is in, the call
    /// itself included. Every leg ends and is reported through call.completed like any
    /// other call. A room that is already empty answers 204 as well. A call that has
    /// ended answers 409, as does a call that is not in a conference.
    /// </summary>
    Task RemoveAll(
        ParticipantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveAll(ParticipantRemoveAllParams, CancellationToken)"/>
    Task RemoveAll(
        string id,
        ParticipantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IParticipantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IParticipantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParticipantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v3/calls/{id}/participants/{participantId}</c>, but is otherwise the
    /// same as <see cref="IParticipantService.Update(ParticipantUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ParticipantUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string participantID,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls/{id}/participants</c>, but is otherwise the
    /// same as <see cref="IParticipantService.List(ParticipantListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfListOfCallParticipant>> List(
        ParticipantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ParticipantListParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfListOfCallParticipant>> List(
        string id,
        ParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/calls/{id}/participants</c>, but is otherwise the
    /// same as <see cref="IParticipantService.Add(ParticipantAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfCall>> Add(
        ParticipantAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ParticipantAddParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfCall>> Add(
        string id,
        ParticipantAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/calls/{id}/participants/{participantId}</c>, but is otherwise the
    /// same as <see cref="IParticipantService.Remove(ParticipantRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ParticipantRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string participantID,
        ParticipantRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v3/calls/{id}/participants</c>, but is otherwise the
    /// same as <see cref="IParticipantService.RemoveAll(ParticipantRemoveAllParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RemoveAll(
        ParticipantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveAll(ParticipantRemoveAllParams, CancellationToken)"/>
    Task<HttpResponse> RemoveAll(
        string id,
        ParticipantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
