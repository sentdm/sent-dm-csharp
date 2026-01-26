using System;
using System.Net.Http;
using SentDm.Exceptions;

namespace SentDm.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    /// </summary>
    public HttpClient HttpClient { get; set; } = new();

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("SENT_DM_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="ISentDmClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; }

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    Lazy<string> _adminAuthScheme = new(() =>
        Environment.GetEnvironmentVariable("SENT_DM_ADMIN_AUTH_SCHEME")
        ?? throw new SentDmInvalidDataException(
            string.Format("{0} cannot be null", nameof(AdminAuthScheme)),
            new ArgumentNullException(nameof(AdminAuthScheme))
        )
    );
    public string AdminAuthScheme
    {
        readonly get { return _adminAuthScheme.Value; }
        set { _adminAuthScheme = new(() => value); }
    }

    Lazy<string> _customerAuthScheme = new(() =>
        Environment.GetEnvironmentVariable("SENT_DM_CUSTOMER_AUTH_SCHEME")
        ?? throw new SentDmInvalidDataException(
            string.Format("{0} cannot be null", nameof(CustomerAuthScheme)),
            new ArgumentNullException(nameof(CustomerAuthScheme))
        )
    );
    public string CustomerAuthScheme
    {
        readonly get { return _customerAuthScheme.Value; }
        set { _customerAuthScheme = new(() => value); }
    }
}
