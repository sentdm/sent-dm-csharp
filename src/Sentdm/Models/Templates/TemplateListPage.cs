using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Services;

namespace Sentdm.Models.Templates;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITemplateService.List(TemplateListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TemplateListPage(
    ITemplateServiceWithRawResponse service,
    TemplateListParams parameters,
    TemplateListPageResponse response
) : IPage<Template>
{
    /// <inheritdoc/>
    public IReadOnlyList<Template> Items
    {
        get { return response.Data?.Templates ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            var pageNumber = response.Data?.Pagination?.Page ?? 1;
            var pageCount = response.Data?.Pagination?.TotalPages;
            if (pageCount == null)
            {
                return true;
            }
            return pageNumber < pageCount;
        }
        catch (SentInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<Template>> IPage<Template>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TemplateListPage> Next(CancellationToken cancellationToken = default)
    {
        var currentPageNumber = parameters.Page ?? 1;
        using var nextResponse = await service
            .List(parameters with { Page = currentPageNumber + 1 }, cancellationToken)
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
        if (obj is not TemplateListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
