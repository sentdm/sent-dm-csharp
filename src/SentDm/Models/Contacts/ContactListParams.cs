using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using SentDm.Core;

namespace SentDm.Models.Contacts;

/// <summary>
/// Retrieves a paginated list of contacts for the authenticated customer. Supports
/// server-side pagination with configurable page size. The customer ID is extracted
/// from the authentication token.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContactListParams : ParamsBase
{
    /// <summary>
    /// The page number (zero-indexed). Default is 0.
    /// </summary>
    public required int Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<int>("page");
        }
        init { this._rawQueryData.Set("page", value); }
    }

    /// <summary>
    /// The number of items per page. Default is 20.
    /// </summary>
    public required int PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<int>("pageSize");
        }
        init { this._rawQueryData.Set("pageSize", value); }
    }

    public ContactListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactListParams(ContactListParams contactListParams)
        : base(contactListParams) { }
#pragma warning restore CS8618

    public ContactListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ContactListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ContactListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/contacts")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
