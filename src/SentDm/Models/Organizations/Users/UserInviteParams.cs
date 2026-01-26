using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using SentDm.Core;

namespace SentDm.Models.Organizations.Users;

/// <summary>
/// Invites a user to an organization or sender profile with a specified role. Requires
/// appropriate permissions. The customerId can be either an organization ID or a
/// profile ID.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserInviteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CustomerID { get; init; }

    public string? Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("email", value);
        }
    }

    public string? InvitedBy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("invitedBy");
        }
        init { this._rawBodyData.Set("invitedBy", value); }
    }

    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public string? Role
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("role");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("role", value);
        }
    }

    public UserInviteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInviteParams(UserInviteParams userInviteParams)
        : base(userInviteParams)
    {
        this.CustomerID = userInviteParams.CustomerID;

        this._rawBodyData = new(userInviteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UserInviteParams(
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
    UserInviteParams(
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
    public static UserInviteParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["CustomerID"] = this.CustomerID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UserInviteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v2/organizations/{0}/users", this.CustomerID)
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
