using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentdm.Core;
using Sentdm.Services;

namespace Sentdm.Models.Contacts;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IContactService.List(ContactListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ContactListPage(
    IContactServiceWithRawResponse service,
    ContactListParams parameters,
    ContactListPageResponse response
) : IPage<ContactResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ContactResponse> Items
    {
        get { return response.Data?.Contacts ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<ContactResponse>> IPage<ContactResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ContactListPage> Next(CancellationToken cancellationToken = default)
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
        if (obj is not ContactListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
