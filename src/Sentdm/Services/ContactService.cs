using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Services;

/// <inheritdoc/>
public sealed class ContactService : IContactService
{
    readonly Lazy<IContactServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IContactServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISentDmClient _client;

    /// <inheritdoc/>
    public IContactService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContactService(this._client.WithOptions(modifier));
    }

    public ContactService(ISentDmClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ContactServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ContactListResponse> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ContactListItem> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByPhone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ContactListItem> RetrieveID(
        ContactRetrieveIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ContactServiceWithRawResponse : IContactServiceWithRawResponse
{
    readonly ISentDmClientWithRawResponse _client;

    /// <inheritdoc/>
    public IContactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContactServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ContactServiceWithRawResponse(ISentDmClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactListResponse>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContactListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contacts = await response
                    .Deserialize<ContactListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contacts.Validate();
                }
                return contacts;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactListItem>> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContactRetrieveByPhoneParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contactListItem = await response
                    .Deserialize<ContactListItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contactListItem.Validate();
                }
                return contactListItem;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactListItem>> RetrieveID(
        ContactRetrieveIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContactRetrieveIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contactListItem = await response
                    .Deserialize<ContactListItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contactListItem.Validate();
                }
                return contactListItem;
            }
        );
    }
}
