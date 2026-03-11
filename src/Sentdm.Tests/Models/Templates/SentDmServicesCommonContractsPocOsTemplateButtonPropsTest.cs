using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class SentDmServicesCommonContractsPocOsTemplateButtonPropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 0,
            AutofillText = "autofillText",
            CountryCode = "countryCode",
            OfferCode = "offerCode",
            OtpType = "otpType",
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            QuickReplyType = "quickReplyType",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "url",
            UrlType = "urlType",
        };

        int expectedActiveFor = 0;
        string expectedAutofillText = "autofillText";
        string expectedCountryCode = "countryCode";
        string expectedOfferCode = "offerCode";
        string expectedOtpType = "otpType";
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedQuickReplyType = "quickReplyType";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        string expectedUrl = "url";
        string expectedUrlType = "urlType";

        Assert.Equal(expectedActiveFor, model.ActiveFor);
        Assert.Equal(expectedAutofillText, model.AutofillText);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedOfferCode, model.OfferCode);
        Assert.Equal(expectedOtpType, model.OtpType);
        Assert.Equal(expectedPackageName, model.PackageName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedQuickReplyType, model.QuickReplyType);
        Assert.Equal(expectedSignatureHash, model.SignatureHash);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedUrlType, model.UrlType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 0,
            AutofillText = "autofillText",
            CountryCode = "countryCode",
            OfferCode = "offerCode",
            OtpType = "otpType",
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            QuickReplyType = "quickReplyType",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "url",
            UrlType = "urlType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButtonProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 0,
            AutofillText = "autofillText",
            CountryCode = "countryCode",
            OfferCode = "offerCode",
            OtpType = "otpType",
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            QuickReplyType = "quickReplyType",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "url",
            UrlType = "urlType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButtonProps>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        int expectedActiveFor = 0;
        string expectedAutofillText = "autofillText";
        string expectedCountryCode = "countryCode";
        string expectedOfferCode = "offerCode";
        string expectedOtpType = "otpType";
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedQuickReplyType = "quickReplyType";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        string expectedUrl = "url";
        string expectedUrlType = "urlType";

        Assert.Equal(expectedActiveFor, deserialized.ActiveFor);
        Assert.Equal(expectedAutofillText, deserialized.AutofillText);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedOfferCode, deserialized.OfferCode);
        Assert.Equal(expectedOtpType, deserialized.OtpType);
        Assert.Equal(expectedPackageName, deserialized.PackageName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedQuickReplyType, deserialized.QuickReplyType);
        Assert.Equal(expectedSignatureHash, deserialized.SignatureHash);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedUrlType, deserialized.UrlType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 0,
            AutofillText = "autofillText",
            CountryCode = "countryCode",
            OfferCode = "offerCode",
            OtpType = "otpType",
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            QuickReplyType = "quickReplyType",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "url",
            UrlType = "urlType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps { };

        Assert.Null(model.ActiveFor);
        Assert.False(model.RawData.ContainsKey("activeFor"));
        Assert.Null(model.AutofillText);
        Assert.False(model.RawData.ContainsKey("autofillText"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.OfferCode);
        Assert.False(model.RawData.ContainsKey("offerCode"));
        Assert.Null(model.OtpType);
        Assert.False(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.False(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.QuickReplyType);
        Assert.False(model.RawData.ContainsKey("quickReplyType"));
        Assert.Null(model.SignatureHash);
        Assert.False(model.RawData.ContainsKey("signatureHash"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.UrlType);
        Assert.False(model.RawData.ContainsKey("urlType"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = null,
            AutofillText = null,
            CountryCode = null,
            OfferCode = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            QuickReplyType = null,
            SignatureHash = null,
            Text = null,
            Url = null,
            UrlType = null,
        };

        Assert.Null(model.ActiveFor);
        Assert.True(model.RawData.ContainsKey("activeFor"));
        Assert.Null(model.AutofillText);
        Assert.True(model.RawData.ContainsKey("autofillText"));
        Assert.Null(model.CountryCode);
        Assert.True(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.OfferCode);
        Assert.True(model.RawData.ContainsKey("offerCode"));
        Assert.Null(model.OtpType);
        Assert.True(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.True(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.QuickReplyType);
        Assert.True(model.RawData.ContainsKey("quickReplyType"));
        Assert.Null(model.SignatureHash);
        Assert.True(model.RawData.ContainsKey("signatureHash"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
        Assert.Null(model.UrlType);
        Assert.True(model.RawData.ContainsKey("urlType"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = null,
            AutofillText = null,
            CountryCode = null,
            OfferCode = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            QuickReplyType = null,
            SignatureHash = null,
            Text = null,
            Url = null,
            UrlType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 0,
            AutofillText = "autofillText",
            CountryCode = "countryCode",
            OfferCode = "offerCode",
            OtpType = "otpType",
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            QuickReplyType = "quickReplyType",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "url",
            UrlType = "urlType",
        };

        SentDmServicesCommonContractsPocOsTemplateButtonProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
