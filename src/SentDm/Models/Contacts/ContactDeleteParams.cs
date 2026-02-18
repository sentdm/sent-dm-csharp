using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using SentDm.Models.Webhooks;

namespace SentDm.Models.Contacts;

/// <summary>
/// Dissociates a contact from the authenticated customer. Inherited contacts cannot
/// be deleted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContactDeleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Request to delete/dissociate a contact
    /// </summary>
    public required global::SentDm.Models.Contacts.Body Body
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<global::SentDm.Models.Contacts.Body>("body");
        }
        init { this._rawBodyData.Set("body", value); }
    }

    public ContactDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactDeleteParams(ContactDeleteParams contactDeleteParams)
        : base(contactDeleteParams)
    {
        this.ID = contactDeleteParams.ID;

        this._rawBodyData = new(contactDeleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ContactDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ContactDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ContactDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v3/contacts/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// Request to delete/dissociate a contact
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::SentDm.Models.Contacts.Body,
        global::SentDm.Models.Contacts.BodyFromRaw
    >)
)]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Test mode flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? TestMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("test_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("test_mode", value);
        }
    }

    public static implicit operator MutationRequest(global::SentDm.Models.Contacts.Body body) =>
        new() { TestMode = body.TestMode };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TestMode;
    }

    public Body() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body(global::SentDm.Models.Contacts.Body body)
        : base(body) { }
#pragma warning restore CS8618

    public Body(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Body(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::SentDm.Models.Contacts.BodyFromRaw.FromRawUnchecked"/>
    public static global::SentDm.Models.Contacts.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyFromRaw : IFromRawJson<global::SentDm.Models.Contacts.Body>
{
    /// <inheritdoc/>
    public global::SentDm.Models.Contacts.Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::SentDm.Models.Contacts.Body.FromRawUnchecked(rawData);
}
