using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                },
            ],
            DefinitionVersion = "definitionVersion",
            Footer = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
            Header = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };

        SentDmServicesCommonContractsPocOsTemplateBody expectedBody = new()
        {
            MultiChannel = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
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
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
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
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };
        SentDmServicesCommonContractsPocOsAuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<SentDmServicesCommonContractsPocOsTemplateButton> expectedButtons =
        [
            new()
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
            },
        ];
        string expectedDefinitionVersion = "definitionVersion";
        SentDmServicesCommonContractsPocOsTemplateFooter expectedFooter = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
                        VariableType = "x",
                        Alt = "alt",
                        Regex = "regex",
                        ShortUrl = "shortUrl",
                    },
                    Type = "x",
                    ID = 0,
                },
            ],
        };
        SentDmServicesCommonContractsPocOsTemplateHeader expectedHeader = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
                        VariableType = "x",
                        Alt = "alt",
                        Regex = "regex",
                        ShortUrl = "shortUrl",
                    },
                    Type = "x",
                    ID = 0,
                },
            ],
        };

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedAuthenticationConfig, model.AuthenticationConfig);
        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.Equal(expectedDefinitionVersion, model.DefinitionVersion);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                },
            ],
            DefinitionVersion = "definitionVersion",
            Footer = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
            Header = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateDefinition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                },
            ],
            DefinitionVersion = "definitionVersion",
            Footer = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
            Header = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SentDmServicesCommonContractsPocOsTemplateBody expectedBody = new()
        {
            MultiChannel = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
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
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
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
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };
        SentDmServicesCommonContractsPocOsAuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<SentDmServicesCommonContractsPocOsTemplateButton> expectedButtons =
        [
            new()
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
            },
        ];
        string expectedDefinitionVersion = "definitionVersion";
        SentDmServicesCommonContractsPocOsTemplateFooter expectedFooter = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
                        VariableType = "x",
                        Alt = "alt",
                        Regex = "regex",
                        ShortUrl = "shortUrl",
                    },
                    Type = "x",
                    ID = 0,
                },
            ],
        };
        SentDmServicesCommonContractsPocOsTemplateHeader expectedHeader = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
                        VariableType = "x",
                        Alt = "alt",
                        Regex = "regex",
                        ShortUrl = "shortUrl",
                    },
                    Type = "x",
                    ID = 0,
                },
            ],
        };

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedAuthenticationConfig, deserialized.AuthenticationConfig);
        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.Equal(expectedDefinitionVersion, deserialized.DefinitionVersion);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeader, deserialized.Header);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                },
            ],
            DefinitionVersion = "definitionVersion",
            Footer = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
            Header = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
                        },
                    ],
                },
            },
        };

        Assert.Null(model.AuthenticationConfig);
        Assert.False(model.RawData.ContainsKey("authenticationConfig"));
        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.DefinitionVersion);
        Assert.False(model.RawData.ContainsKey("definitionVersion"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
                        },
                    ],
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
                        },
                    ],
                },
            },

            AuthenticationConfig = null,
            Buttons = null,
            DefinitionVersion = null,
            Footer = null,
            Header = null,
        };

        Assert.Null(model.AuthenticationConfig);
        Assert.True(model.RawData.ContainsKey("authenticationConfig"));
        Assert.Null(model.Buttons);
        Assert.True(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.DefinitionVersion);
        Assert.True(model.RawData.ContainsKey("definitionVersion"));
        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
                        },
                    ],
                },
            },

            AuthenticationConfig = null,
            Buttons = null,
            DefinitionVersion = null,
            Footer = null,
            Header = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateDefinition
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "template",
                    Type = "type",
                    Variables =
                    [
                        new()
                        {
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
                                VariableType = "x",
                                Alt = "alt",
                                Regex = "regex",
                                ShortUrl = "shortUrl",
                            },
                            Type = "x",
                            ID = 0,
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
                },
            ],
            DefinitionVersion = "definitionVersion",
            Footer = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
            Header = new()
            {
                Template = "template",
                Type = "type",
                Variables =
                [
                    new()
                    {
                        Name = "x",
                        Props = new()
                        {
                            MediaType = "x",
                            Sample = "x",
                            Url = "x",
                            VariableType = "x",
                            Alt = "alt",
                            Regex = "regex",
                            ShortUrl = "shortUrl",
                        },
                        Type = "x",
                        ID = 0,
                    },
                ],
            },
        };

        TemplateDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}
