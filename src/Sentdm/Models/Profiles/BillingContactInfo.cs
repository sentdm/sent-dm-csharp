using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Billing contact information for a profile. Required when billing_model is "profile"
/// or "profile_and_organization".
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingContactInfo, BillingContactInfoFromRaw>))]
public sealed record class BillingContactInfo : JsonModel
{
    /// <summary>
    /// Email address where invoices will be sent (required)
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Full name of the billing contact or company (required)
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Billing address (optional). Free-form text including street, city, state,
    /// postal code, and country.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Phone number for the billing contact (optional)
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
        _ = this.Address;
        _ = this.Phone;
    }

    public BillingContactInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingContactInfo(BillingContactInfo billingContactInfo)
        : base(billingContactInfo) { }
#pragma warning restore CS8618

    public BillingContactInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingContactInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingContactInfoFromRaw.FromRawUnchecked"/>
    public static BillingContactInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingContactInfoFromRaw : IFromRawJson<BillingContactInfo>
{
    /// <inheritdoc/>
    public BillingContactInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingContactInfo.FromRawUnchecked(rawData);
}
