using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Payment card details for a profile. Accepted when billing_model is "profile" or
/// "profile_and_organization". These details are not stored on our servers and will
/// be forwarded to the payment processor.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaymentDetails, PaymentDetailsFromRaw>))]
public sealed record class PaymentDetails : JsonModel
{
    /// <summary>
    /// Card number (digits only, 13–19 characters)
    /// </summary>
    public required string CardNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_number");
        }
        init { this._rawData.Set("card_number", value); }
    }

    /// <summary>
    /// Card security code (3–4 digits)
    /// </summary>
    public required string Cvc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cvc");
        }
        init { this._rawData.Set("cvc", value); }
    }

    /// <summary>
    /// Card expiry date in MM/YY format (e.g. "09/27")
    /// </summary>
    public required string Expiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiry");
        }
        init { this._rawData.Set("expiry", value); }
    }

    /// <summary>
    /// Billing ZIP / postal code associated with the card
    /// </summary>
    public required string ZipCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip_code");
        }
        init { this._rawData.Set("zip_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardNumber;
        _ = this.Cvc;
        _ = this.Expiry;
        _ = this.ZipCode;
    }

    public PaymentDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentDetails(PaymentDetails paymentDetails)
        : base(paymentDetails) { }
#pragma warning restore CS8618

    public PaymentDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentDetailsFromRaw.FromRawUnchecked"/>
    public static PaymentDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentDetailsFromRaw : IFromRawJson<PaymentDetails>
{
    /// <inheritdoc/>
    public PaymentDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentDetails.FromRawUnchecked(rawData);
}
