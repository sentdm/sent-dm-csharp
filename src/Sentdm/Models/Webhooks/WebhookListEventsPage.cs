using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Services;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IWebhookService.ListEvents(WebhookListEventsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class WebhookListEventsPage(
    IWebhookServiceWithRawResponse service,
    WebhookListEventsParams parameters,
    WebhookListEventsPageResponse response
) : IPage<WebhookListEventsResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<WebhookListEventsResponse> Items
    {
        get { return response.Data?.Events ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<WebhookListEventsResponse>> IPage<WebhookListEventsResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<WebhookListEventsPage> Next(CancellationToken cancellationToken = default)
    {
        var currentPageNumber = parameters.Page ?? 1;
        using var nextResponse = await service
            .ListEvents(parameters with { Page = currentPageNumber + 1 }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not WebhookListEventsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
