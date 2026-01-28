using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Organizations.Users;

[JsonConverter(typeof(JsonModelConverter<CustomerUser, CustomerUserFromRaw>))]
public sealed record class CustomerUser : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customerId", value);
        }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    public DateTimeOffset? InvitationSentAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("invitationSentAt");
        }
        init { this._rawData.Set("invitationSentAt", value); }
    }

    public string? InvitationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invitationToken");
        }
        init { this._rawData.Set("invitationToken", value); }
    }

    public DateTimeOffset? InvitationTokenExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("invitationTokenExpiresAt");
        }
        init { this._rawData.Set("invitationTokenExpiresAt", value); }
    }

    public DateTimeOffset? LastLoginAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastLoginAt");
        }
        init { this._rawData.Set("lastLoginAt", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("role", value);
        }
    }

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.Email;
        _ = this.InvitationSentAt;
        _ = this.InvitationToken;
        _ = this.InvitationTokenExpiresAt;
        _ = this.LastLoginAt;
        _ = this.Name;
        _ = this.Role;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public CustomerUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerUser(CustomerUser customerUser)
        : base(customerUser) { }
#pragma warning restore CS8618

    public CustomerUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUserFromRaw.FromRawUnchecked"/>
    public static CustomerUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerUserFromRaw : IFromRawJson<CustomerUser>
{
    /// <inheritdoc/>
    public CustomerUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerUser.FromRawUnchecked(rawData);
}
