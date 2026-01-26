using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using SentDm.Core;

namespace SentDm.Models.Contacts;

/// <summary>
/// Retrieves a contact by their phone number for the authenticated customer. Phone
/// number should be in international format (e.g., +1234567890). The customer ID
/// is extracted from the authentication token.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContactRetrieveByPhoneParams : ParamsBase
{
    /// <summary>
    /// The phone number in international format (e.g., +1234567890)
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawQueryData.Set("phoneNumber", value); }
    }

    public required string XApiKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNotNullClass<string>("x-api-key");
        }
        init { this._rawHeaderData.Set("x-api-key", value); }
    }

    public required string XSenderID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNotNullClass<string>("x-sender-id");
        }
        init { this._rawHeaderData.Set("x-sender-id", value); }
    }

    public ContactRetrieveByPhoneParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactRetrieveByPhoneParams(ContactRetrieveByPhoneParams contactRetrieveByPhoneParams)
        : base(contactRetrieveByPhoneParams) { }
#pragma warning restore CS8618

    public ContactRetrieveByPhoneParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactRetrieveByPhoneParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ContactRetrieveByPhoneParams FromRawUnchecked(
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

    public virtual bool Equals(ContactRetrieveByPhoneParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v2/contacts/phone")
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
