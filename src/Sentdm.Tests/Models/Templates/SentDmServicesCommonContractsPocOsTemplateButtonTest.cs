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
            Props = new()
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
            },
            Type = "x",
            ID = 0,
        };

        SentDmServicesCommonContractsPocOsTemplateButtonProps expectedProps = new()
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
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",
            ID = 0,
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
            Props = new()
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
            },
            Type = "x",
            ID = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateButton>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SentDmServicesCommonContractsPocOsTemplateButtonProps expectedProps = new()
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
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",
            ID = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateButton
        {
            Props = new()
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
            },
            Type = "x",
            ID = 0,
        };

        SentDmServicesCommonContractsPocOsTemplateButton copied = new(model);

        Assert.Equal(model, copied);
    }
}
