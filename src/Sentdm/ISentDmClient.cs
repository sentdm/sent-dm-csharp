using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Services;

namespace Sentdm;

/// <summary>
/// A client for interacting with the Sent Dm REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISentDmClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Customer API key for authentication
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Customer sender ID (GUID) identifying the customer account
    /// </summary>
    string SenderID { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISentDmClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISentDmClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITemplateService Templates { get; }

    IContactService Contacts { get; }

    IMessageService Messages { get; }

    INumberLookupService NumberLookup { get; }

    IOrganizationService Organizations { get; }
}

/// <summary>
/// A view of <see cref="ISentDmClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ISentDmClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Customer API key for authentication
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Customer sender ID (GUID) identifying the customer account
    /// </summary>
    string SenderID { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISentDmClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITemplateServiceWithRawResponse Templates { get; }

    IContactServiceWithRawResponse Contacts { get; }

    IMessageServiceWithRawResponse Messages { get; }

    INumberLookupServiceWithRawResponse NumberLookup { get; }

    IOrganizationServiceWithRawResponse Organizations { get; }

    /// <summary>
    /// Sends a request to the Sent Dm REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
