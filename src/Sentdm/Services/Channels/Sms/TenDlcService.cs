using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.Channels.Sms.TenDlc;

namespace Sentdm.Services.Channels.Sms;

/// <inheritdoc/>
public sealed class TenDlcService : ITenDlcService
{
    readonly Lazy<ITenDlcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITenDlcServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentClient _client;

    /// <inheritdoc/>
    public ITenDlcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenDlcService(this._client.WithOptions(modifier));
    }

    public TenDlcService(ISentClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TenDlcServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> AddCampaign(
        TenDlcAddCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddCampaign(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> AddNumbers(
        TenDlcAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddNumbers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSuppliedCompliance> RetrieveCompliance(
        TenDlcRetrieveComplianceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveCompliance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiResponseOfSmsMarket> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateCampaign(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiResponseOfSmsMarket> UpdateCampaign(
        string campaignID,
        TenDlcUpdateCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateCampaign(parameters with { CampaignID = campaignID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TenDlcServiceWithRawResponse : ITenDlcServiceWithRawResponse
{
    readonly ISentClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITenDlcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenDlcServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TenDlcServiceWithRawResponse(ISentClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> AddCampaign(
        TenDlcAddCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TenDlcAddCampaignParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> AddNumbers(
        TenDlcAddNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TenDlcAddNumbersParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSuppliedCompliance>> RetrieveCompliance(
        TenDlcRetrieveComplianceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TenDlcRetrieveComplianceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSuppliedCompliance = await response
                    .Deserialize<ApiResponseOfSuppliedCompliance>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSuppliedCompliance.Validate();
                }
                return apiResponseOfSuppliedCompliance;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiResponseOfSmsMarket>> UpdateCampaign(
        TenDlcUpdateCampaignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new SentInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<TenDlcUpdateCampaignParams> request = new()
        {
            Method = SentClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiResponseOfSmsMarket = await response
                    .Deserialize<ApiResponseOfSmsMarket>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiResponseOfSmsMarket.Validate();
                }
                return apiResponseOfSmsMarket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiResponseOfSmsMarket>> UpdateCampaign(
        string campaignID,
        TenDlcUpdateCampaignParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateCampaign(parameters with { CampaignID = campaignID }, cancellationToken);
    }
}
