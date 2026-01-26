using System;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

public class TemplateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            Category = "MARKETING",
            Language = "en_US",
            SubmitForReview = false,
        };

        TemplateDefinition expectedDefinition = new()
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template =
                        "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                    Type = null,
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "customerName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "John Doe",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
                Sms = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Whatsapp = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
            },
            AuthenticationConfig = new()
            {
                AddSecurityRecommendation = true,
                CodeExpirationMinutes = 0,
            },
            Buttons =
            [
                new()
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
                },
            ],
            DefinitionVersion = "1.0",
            Footer = new()
            {
                Template = "Best regards, The SentDM Team",
                Type = "text",
                Variables =
                [
                    new()
                    {
                        ID = 0,
                        Name = "name",
                        Props = new()
                        {
                            Alt = "alt",
                            MediaType = "mediaType",
                            Sample = "sample",
                            ShortUrl = "shortUrl",
                            Url = "url",
                            VariableType = "variableType",
                        },
                        Type = "type",
                    },
                ],
            },
            Header = new()
            {
                Template = "Welcome to {{1:variable}}!",
                Type = "text",
                Variables =
                [
                    new()
                    {
                        ID = 1,
                        Name = "companyName",
                        Props = new()
                        {
                            Alt = null,
                            MediaType = null,
                            Sample = "SentDM",
                            ShortUrl = null,
                            Url = null,
                            VariableType = "text",
                        },
                        Type = "variable",
                    },
                ],
            },
        };
        string expectedCategory = "MARKETING";
        string expectedLanguage = "en_US";
        bool expectedSubmitForReview = false;

        Assert.Equal(expectedDefinition, parameters.Definition);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedSubmitForReview, parameters.SubmitForReview);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            Category = "MARKETING",
            Language = "en_US",
        };

        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submitForReview"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            Category = "MARKETING",
            Language = "en_US",

            // Null should be interpreted as omitted for these properties
            SubmitForReview = null,
        };

        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submitForReview"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            SubmitForReview = false,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            SubmitForReview = false,

            Category = null,
            Language = null,
        };

        Assert.Null(parameters.Category);
        Assert.True(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Language);
        Assert.True(parameters.RawBodyData.ContainsKey("language"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateCreateParams parameters = new()
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
        };

        var url = parameters.Url(
            new()
            {
                AdminAuthScheme = "My Admin Auth Scheme",
                CustomerAuthScheme = "My Customer Auth Scheme",
            }
        );

        Assert.Equal(new Uri("https://api.sent.dm/v2/templates"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template =
                            "Hello {{1:variable}}, thank you for joining our service. We're excited to help you with your messaging needs!",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 1,
                                Name = "customerName",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John Doe",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                        ],
                    },
                    Sms = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                    Whatsapp = new()
                    {
                        Template = "template",
                        Type = "type",
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = "alt",
                                    MediaType = "mediaType",
                                    Sample = "sample",
                                    ShortUrl = "shortUrl",
                                    Url = "url",
                                    VariableType = "variableType",
                                },
                                Type = "type",
                            },
                        ],
                    },
                },
                AuthenticationConfig = new()
                {
                    AddSecurityRecommendation = true,
                    CodeExpirationMinutes = 0,
                },
                Buttons =
                [
                    new()
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
                    },
                ],
                DefinitionVersion = "1.0",
                Footer = new()
                {
                    Template = "Best regards, The SentDM Team",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = "alt",
                                MediaType = "mediaType",
                                Sample = "sample",
                                ShortUrl = "shortUrl",
                                Url = "url",
                                VariableType = "variableType",
                            },
                            Type = "type",
                        },
                    ],
                },
                Header = new()
                {
                    Template = "Welcome to {{1:variable}}!",
                    Type = "text",
                    Variables =
                    [
                        new()
                        {
                            ID = 1,
                            Name = "companyName",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "SentDM",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                    ],
                },
            },
            Category = "MARKETING",
            Language = "en_US",
            SubmitForReview = false,
        };

        TemplateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
