using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Contacts;

/// <summary>
/// A paginated list of contacts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactsList, ContactsListFromRaw>))]
public sealed record class ContactsList : JsonModel
{
    /// <summary>
    /// The contacts on this page.
    /// </summary>
    public IReadOnlyList<ContactResponse>? Contacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ContactResponse>>("contacts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ContactResponse>?>(
                "contacts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Contacts ?? [])
        {
            item.Validate();
        }
        this.Pagination?.Validate();
    }

    public ContactsList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactsList(ContactsList contactsList)
        : base(contactsList) { }
#pragma warning restore CS8618

    public ContactsList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactsList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactsListFromRaw.FromRawUnchecked"/>
    public static ContactsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactsListFromRaw : IFromRawJson<ContactsList>
{
    /// <inheritdoc/>
    public ContactsList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactsList.FromRawUnchecked(rawData);
}
