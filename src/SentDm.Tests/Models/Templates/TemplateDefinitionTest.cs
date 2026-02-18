using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Templates;

namespace SentDm.Tests.Models.Templates;

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
            DefinitionVersion = "definitionVersion",
            Footer = new()
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
            Header = new()
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
        };

        Body expectedBody = new()
        {
            MultiChannel = new()
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
        };
        AuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<Button> expectedButtons =
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
        ];
        string expectedDefinitionVersion = "definitionVersion";
        Footer expectedFooter = new()
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
        };
        Header expectedHeader = new()
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
            DefinitionVersion = "definitionVersion",
            Footer = new()
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
            Header = new()
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
            DefinitionVersion = "definitionVersion",
            Footer = new()
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
            Header = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Body expectedBody = new()
        {
            MultiChannel = new()
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
        };
        AuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<Button> expectedButtons =
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
        ];
        string expectedDefinitionVersion = "definitionVersion";
        Footer expectedFooter = new()
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
        };
        Header expectedHeader = new()
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
            DefinitionVersion = "definitionVersion",
            Footer = new()
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
            Header = new()
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
            DefinitionVersion = "definitionVersion",
            Footer = new()
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
            Header = new()
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
        };

        TemplateDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body
        {
            MultiChannel = new()
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
        };

        TemplateBodyContent expectedMultiChannel = new()
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
        };
        TemplateBodyContent expectedSms = new()
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
        };
        TemplateBodyContent expectedWhatsapp = new()
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
        };

        Assert.Equal(expectedMultiChannel, model.MultiChannel);
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body
        {
            MultiChannel = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body
        {
            MultiChannel = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        TemplateBodyContent expectedMultiChannel = new()
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
        };
        TemplateBodyContent expectedSms = new()
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
        };
        TemplateBodyContent expectedWhatsapp = new()
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
        };

        Assert.Equal(expectedMultiChannel, deserialized.MultiChannel);
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body
        {
            MultiChannel = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.MultiChannel);
        Assert.False(model.RawData.ContainsKey("multiChannel"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Body
        {
            MultiChannel = null,
            Sms = null,
            Whatsapp = null,
        };

        Assert.Null(model.MultiChannel);
        Assert.True(model.RawData.ContainsKey("multiChannel"));
        Assert.Null(model.Sms);
        Assert.True(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Whatsapp);
        Assert.True(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            MultiChannel = null,
            Sms = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body
        {
            MultiChannel = new()
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
        };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthenticationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        bool expectedAddSecurityRecommendation = true;
        int expectedCodeExpirationMinutes = 0;

        Assert.Equal(expectedAddSecurityRecommendation, model.AddSecurityRecommendation);
        Assert.Equal(expectedCodeExpirationMinutes, model.CodeExpirationMinutes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthenticationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthenticationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAddSecurityRecommendation = true;
        int expectedCodeExpirationMinutes = 0;

        Assert.Equal(expectedAddSecurityRecommendation, deserialized.AddSecurityRecommendation);
        Assert.Equal(expectedCodeExpirationMinutes, deserialized.CodeExpirationMinutes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuthenticationConfig { CodeExpirationMinutes = 0 };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuthenticationConfig { CodeExpirationMinutes = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AuthenticationConfig
        {
            CodeExpirationMinutes = 0,

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuthenticationConfig
        {
            CodeExpirationMinutes = 0,

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuthenticationConfig { AddSecurityRecommendation = true };

        Assert.Null(model.CodeExpirationMinutes);
        Assert.False(model.RawData.ContainsKey("codeExpirationMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuthenticationConfig { AddSecurityRecommendation = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,

            CodeExpirationMinutes = null,
        };

        Assert.Null(model.CodeExpirationMinutes);
        Assert.True(model.RawData.ContainsKey("codeExpirationMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,

            CodeExpirationMinutes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        AuthenticationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Button
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
        Props expectedProps = new()
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
        var model = new Button
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
        var deserialized = JsonSerializer.Deserialize<Button>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Button
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
        var deserialized = JsonSerializer.Deserialize<Button>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        int expectedID = 0;
        Props expectedProps = new()
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
        var model = new Button
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
        var model = new Button { };

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
        var model = new Button { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Button
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
        var model = new Button
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
        var model = new Button
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

        Button copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Props
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
        var model = new Props
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
        var deserialized = JsonSerializer.Deserialize<Props>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Props
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
        var deserialized = JsonSerializer.Deserialize<Props>(element, ModelBase.SerializerOptions);
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
        var model = new Props
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
        var model = new Props { };

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
        var model = new Props { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Props
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
        var model = new Props
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
        var model = new Props
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

        Props copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FooterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Footer
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
        };

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
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
        ];

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Footer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Footer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Footer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Footer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
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
        ];

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Footer
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Footer
        {
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
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Footer
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Footer
        {
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

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Footer
        {
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

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Footer { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Footer { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Footer
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Footer
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Footer
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
        };

        Footer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeaderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Header
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
        };

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
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
        ];

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Header
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Header>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Header
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Header>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateVariable> expectedVariables =
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
        ];

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Header
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Header
        {
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
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Header
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Header
        {
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

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Header
        {
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

            // Null should be interpreted as omitted for these properties
            Template = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Header { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Header { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Header
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Header
        {
            Template = "template",

            Type = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Header
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
        };

        Header copied = new(model);

        Assert.Equal(model, copied);
    }
}
