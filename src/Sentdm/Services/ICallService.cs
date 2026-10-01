using System;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Calls;
using Sentdm.Services.Calls;

namespace Sentdm.Services;

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
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IParticipantService Participants { get; }

    /// <summary>
    /// Retrieves one of your calls by id: the parties, the owning number, the current
    /// status with its failure reason, duration, price, recording availability, and a
    /// timeline of when the call entered each status.
    /// </summary>
    Task<ApiResponseOfCall> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<ApiResponseOfCall> Retrieve(
        string id,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of your calls, most recent first. Filter by
    /// direction, status, the owning number, and the time the call started (from and to
    /// are inclusive). Use the call webhooks for real-time updates; this list is for
    /// looking calls up afterwards.
    /// </summary>
    Task<CallListPage> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Ends one of your live calls. The call then ends the way any other call does: its
    /// status moves to completed and call.completed is sent once the disconnect is
    /// reported. A call that has already ended answers 409, and so does a call with no
    /// phone leg, such as one between two app users.
    /// </summary>
    Task Hangup(CallHangupParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Hangup(CallHangupParams, CancellationToken)"/>
    Task Hangup(
        string id,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns pre-signed links to the recordings of one of your calls, each valid
    /// until its url_expires_at. A recording appears once the call was recorded, by a
    /// connect answer with record set, a startRecording instruction or the recordings
    /// command, and the call.recording_ready webhook has been sent; until then, and for
    /// a call that was never recorded, the list is empty. A call recorded more than
    /// once lists every recording, oldest first, each under the recording_id its
    /// call.recording_ready webhook carried.
    /// </summary>
    Task<ApiResponseOfCallRecordings> ListRecordings(
        CallListRecordingsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRecordings(CallListRecordingsParams, CancellationToken)"/>
    Task<ApiResponseOfCallRecordings> ListRecordings(
        string id,
        CallListRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts or stops recording one of your live calls. Use start to begin recording
    /// mid-call, or stop to end a recording, whether it was started here or by a
    /// connect answer with record set. A call that has already ended answers 409, and
    /// so does a call with no phone leg, such as one between two app users, which can't
    /// be recorded.
    /// </summary>
    Task Record(CallRecordParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Record(CallRecordParams, CancellationToken)"/>
    Task Record(
        string id,
        CallRecordParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IParticipantServiceWithRawResponse Participants { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls/{id}</c>, but is otherwise the
    /// same as <see cref="ICallService.Retrieve(CallRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfCall>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfCall>> Retrieve(
        string id,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls</c>, but is otherwise the
    /// same as <see cref="ICallService.List(CallListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallListPage>> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/calls/{id}/hangup</c>, but is otherwise the
    /// same as <see cref="ICallService.Hangup(CallHangupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hangup(CallHangupParams, CancellationToken)"/>
    Task<HttpResponse> Hangup(
        string id,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v3/calls/{id}/recordings</c>, but is otherwise the
    /// same as <see cref="ICallService.ListRecordings(CallListRecordingsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiResponseOfCallRecordings>> ListRecordings(
        CallListRecordingsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRecordings(CallListRecordingsParams, CancellationToken)"/>
    Task<HttpResponse<ApiResponseOfCallRecordings>> ListRecordings(
        string id,
        CallListRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v3/calls/{id}/recordings</c>, but is otherwise the
    /// same as <see cref="ICallService.Record(CallRecordParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Record(
        CallRecordParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Record(CallRecordParams, CancellationToken)"/>
    Task<HttpResponse> Record(
        string id,
        CallRecordParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
