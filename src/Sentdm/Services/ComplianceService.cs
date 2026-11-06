using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class ComplianceService : IComplianceService
{
    readonly Lazy<IComplianceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComplianceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public IComplianceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComplianceService(this._client.WithOptions(modifier));
    }

    public ComplianceService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ComplianceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfComplianceRequirements> RetrieveRequirements(
        ComplianceRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveRequirements(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ComplianceServiceWithRawResponse : IComplianceServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComplianceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ComplianceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComplianceServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfComplianceRequirements>> RetrieveRequirements(
        ComplianceRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ComplianceRetrieveRequirementsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfComplianceRequirements = await response
                    .Deserialize<ApiResponseOfComplianceRequirements>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfComplianceRequirements.Validate();
                }
                return apiResponseOfComplianceRequirements;
            }
        );
    }
}
