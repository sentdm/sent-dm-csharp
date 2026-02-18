using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

[JsonConverter(
    typeof(JsonModelConverter<
        SentDmServicesCommonContractsPocOsTemplateButtonProps,
        SentDmServicesCommonContractsPocOsTemplateButtonPropsFromRaw
    >)
)]
public sealed record class SentDmServicesCommonContractsPocOsTemplateButtonProps : JsonModel
{
    public int? ActiveFor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activeFor");
        }
        init { this._rawData.Set("activeFor", value); }
    }

    public string? AutofillText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("autofillText");
        }
        init { this._rawData.Set("autofillText", value); }
    }

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
    }

    public string? OfferCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("offerCode");
        }
        init { this._rawData.Set("offerCode", value); }
    }

    public string? OtpType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("otpType");
        }
        init { this._rawData.Set("otpType", value); }
    }

    public string? PackageName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("packageName");
        }
        init { this._rawData.Set("packageName", value); }
    }

    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public string? QuickReplyType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("quickReplyType");
        }
        init { this._rawData.Set("quickReplyType", value); }
    }

    public string? SignatureHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signatureHash");
        }
        init { this._rawData.Set("signatureHash", value); }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init { this._rawData.Set("urlType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveFor;
        _ = this.AutofillText;
        _ = this.CountryCode;
        _ = this.OfferCode;
        _ = this.OtpType;
        _ = this.PackageName;
        _ = this.PhoneNumber;
        _ = this.QuickReplyType;
        _ = this.SignatureHash;
        _ = this.Text;
        _ = this.Url;
        _ = this.UrlType;
    }

    public SentDmServicesCommonContractsPocOsTemplateButtonProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentDmServicesCommonContractsPocOsTemplateButtonProps(
        SentDmServicesCommonContractsPocOsTemplateButtonProps sentDmServicesCommonContractsPocOsTemplateButtonProps
    )
        : base(sentDmServicesCommonContractsPocOsTemplateButtonProps) { }
#pragma warning restore CS8618

    public SentDmServicesCommonContractsPocOsTemplateButtonProps(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentDmServicesCommonContractsPocOsTemplateButtonProps(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentDmServicesCommonContractsPocOsTemplateButtonPropsFromRaw.FromRawUnchecked"/>
    public static SentDmServicesCommonContractsPocOsTemplateButtonProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentDmServicesCommonContractsPocOsTemplateButtonPropsFromRaw
    : IFromRawJson<SentDmServicesCommonContractsPocOsTemplateButtonProps>
{
    /// <inheritdoc/>
    public SentDmServicesCommonContractsPocOsTemplateButtonProps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentDmServicesCommonContractsPocOsTemplateButtonProps.FromRawUnchecked(rawData);
}
