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
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
            AutofillText = "autofillText",
            OtpType = "otpType",
            PackageName = "packageName",
            SignatureHash = "signatureHash",
        };

        int expectedActiveFor = 1;
        string expectedCountryCode = "x";
        string expectedOfferCode = "x";
        string expectedPhoneNumber = "x";
        string expectedQuickReplyType = "x";
        string expectedText = "text";
        string expectedUrl = "x";
        string expectedUrlType = "x";
        string expectedAutofillText = "autofillText";
        string expectedOtpType = "otpType";
        string expectedPackageName = "packageName";
        string expectedSignatureHash = "signatureHash";

        Assert.Equal(expectedActiveFor, model.ActiveFor);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedOfferCode, model.OfferCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedQuickReplyType, model.QuickReplyType);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedUrlType, model.UrlType);
        Assert.Equal(expectedAutofillText, model.AutofillText);
        Assert.Equal(expectedOtpType, model.OtpType);
        Assert.Equal(expectedPackageName, model.PackageName);
        Assert.Equal(expectedSignatureHash, model.SignatureHash);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
            AutofillText = "autofillText",
            OtpType = "otpType",
            PackageName = "packageName",
            SignatureHash = "signatureHash",
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
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
            AutofillText = "autofillText",
            OtpType = "otpType",
            PackageName = "packageName",
            SignatureHash = "signatureHash",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButtonProps>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        int expectedActiveFor = 1;
        string expectedCountryCode = "x";
        string expectedOfferCode = "x";
        string expectedPhoneNumber = "x";
        string expectedQuickReplyType = "x";
        string expectedText = "text";
        string expectedUrl = "x";
        string expectedUrlType = "x";
        string expectedAutofillText = "autofillText";
        string expectedOtpType = "otpType";
        string expectedPackageName = "packageName";
        string expectedSignatureHash = "signatureHash";

        Assert.Equal(expectedActiveFor, deserialized.ActiveFor);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedOfferCode, deserialized.OfferCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedQuickReplyType, deserialized.QuickReplyType);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedUrlType, deserialized.UrlType);
        Assert.Equal(expectedAutofillText, deserialized.AutofillText);
        Assert.Equal(expectedOtpType, deserialized.OtpType);
        Assert.Equal(expectedPackageName, deserialized.PackageName);
        Assert.Equal(expectedSignatureHash, deserialized.SignatureHash);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
            AutofillText = "autofillText",
            OtpType = "otpType",
            PackageName = "packageName",
            SignatureHash = "signatureHash",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
        };

        Assert.Null(model.AutofillText);
        Assert.False(model.RawData.ContainsKey("autofillText"));
        Assert.Null(model.OtpType);
        Assert.False(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.False(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.SignatureHash);
        Assert.False(model.RawData.ContainsKey("signatureHash"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",

            AutofillText = null,
            OtpType = null,
            PackageName = null,
            SignatureHash = null,
        };

        Assert.Null(model.AutofillText);
        Assert.True(model.RawData.ContainsKey("autofillText"));
        Assert.Null(model.OtpType);
        Assert.True(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.True(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.SignatureHash);
        Assert.True(model.RawData.ContainsKey("signatureHash"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",

            AutofillText = null,
            OtpType = null,
            PackageName = null,
            SignatureHash = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButtonProps
        {
            ActiveFor = 1,
            CountryCode = "x",
            OfferCode = "x",
            PhoneNumber = "x",
            QuickReplyType = "x",
            Text = "text",
            Url = "x",
            UrlType = "x",
            AutofillText = "autofillText",
            OtpType = "otpType",
            PackageName = "packageName",
            SignatureHash = "signatureHash",
        };

        SentDmServicesCommonContractsPocOsTemplateButtonProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
