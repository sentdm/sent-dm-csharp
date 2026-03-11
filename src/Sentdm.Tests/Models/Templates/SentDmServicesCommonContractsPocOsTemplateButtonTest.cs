using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class SentDmServicesCommonContractsPocOsTemplateButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            ID = 0,
            Props = new()
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
            },
            Type = "type",
        };

        int expectedID = 0;
        SentDmServicesCommonContractsPocOsTemplateButtonProps expectedProps = new()
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
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            ID = 0,
            Props = new()
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
            },
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButton>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            ID = 0,
            Props = new()
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
            },
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButton>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        int expectedID = 0;
        SentDmServicesCommonContractsPocOsTemplateButtonProps expectedProps = new()
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
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            ID = 0,
            Props = new()
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
            },
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Props);
        Assert.False(model.RawData.ContainsKey("props"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Props = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Props);
        Assert.False(model.RawData.ContainsKey("props"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Props = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            ID = 0,
            Props = new()
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
            },
            Type = "type",
        };

        SentDmServicesCommonContractsPocOsTemplateButton copied = new(model);

        Assert.Equal(model, copied);
    }
}
