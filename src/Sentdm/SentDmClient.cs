using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Services;

namespace Sentdm;

/// <inheritdoc/>
public sealed class SentDmClient : ISentDmClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string SenderID
    {
        get { return this._options.SenderID; }
        init { this._options.SenderID = value; }
    }

    readonly Lazy<ISentDmClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISentDmClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public ISentDmClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SentDmClient(modifier(this._options));
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    readonly Lazy<IContactService> _contacts;
    public IContactService Contacts
    {
        get { return _contacts.Value; }
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<INumberLookupService> _numberLookup;
    public INumberLookupService NumberLookup
    {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<IOrganizationService> _organizations;
    public IOrganizationService Organizations
    {
        get { return _organizations.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public SentDmClient()
    {
        _options = new();

        _withRawResponse = new(() => new SentDmClientWithRawResponse(this._options));
        _templates = new(() => new TemplateService(this));
        _contacts = new(() => new ContactService(this));
        _messages = new(() => new MessageService(this));
        _numberLookup = new(() => new NumberLookupService(this));
        _organizations = new(() => new OrganizationService(this));
    }

    public SentDmClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class SentDmClientWithRawResponse : ISentDmClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string SenderID
    {
        get { return this._options.SenderID; }
        init { this._options.SenderID = value; }
    }

    /// <inheritdoc/>
    public ISentDmClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SentDmClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<ITemplateServiceWithRawResponse> _templates;
    public ITemplateServiceWithRawResponse Templates
    {
        get { return _templates.Value; }
    }

    readonly Lazy<IContactServiceWithRawResponse> _contacts;
    public IContactServiceWithRawResponse Contacts
    {
        get { return _contacts.Value; }
    }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<INumberLookupServiceWithRawResponse> _numberLookup;
    public INumberLookupServiceWithRawResponse NumberLookup
    {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<IOrganizationServiceWithRawResponse> _organizations;
    public IOrganizationServiceWithRawResponse Organizations
    {
        get { return _organizations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw SentDmExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new SentDmIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new SentDmIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is SentDmIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public SentDmClientWithRawResponse()
    {
        _options = new();

        _templates = new(() => new TemplateServiceWithRawResponse(this));
        _contacts = new(() => new ContactServiceWithRawResponse(this));
        _messages = new(() => new MessageServiceWithRawResponse(this));
        _numberLookup = new(() => new NumberLookupServiceWithRawResponse(this));
        _organizations = new(() => new OrganizationServiceWithRawResponse(this));
    }

    public SentDmClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
