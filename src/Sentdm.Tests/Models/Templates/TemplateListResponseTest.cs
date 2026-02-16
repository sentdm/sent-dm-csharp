using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Definition = new()
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
                    },
                    DisplayName = "displayName",
                    IsPublished = true,
                    Language = "language",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WhatsappTemplateID = "whatsappTemplateId",
                    WhatsappTemplateName = "whatsappTemplateName",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        List<TemplateResponseV2> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Definition = new()
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
                },
                DisplayName = "displayName",
                IsPublished = true,
                Language = "language",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WhatsappTemplateID = "whatsappTemplateId",
                WhatsappTemplateName = "whatsappTemplateName",
            },
        ];
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Definition = new()
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
                    },
                    DisplayName = "displayName",
                    IsPublished = true,
                    Language = "language",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WhatsappTemplateID = "whatsappTemplateId",
                    WhatsappTemplateName = "whatsappTemplateName",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Definition = new()
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
                    },
                    DisplayName = "displayName",
                    IsPublished = true,
                    Language = "language",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WhatsappTemplateID = "whatsappTemplateId",
                    WhatsappTemplateName = "whatsappTemplateName",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TemplateResponseV2> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Definition = new()
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
                },
                DisplayName = "displayName",
                IsPublished = true,
                Language = "language",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WhatsappTemplateID = "whatsappTemplateId",
                WhatsappTemplateName = "whatsappTemplateName",
            },
        ];
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Definition = new()
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
                    },
                    DisplayName = "displayName",
                    IsPublished = true,
                    Language = "language",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WhatsappTemplateID = "whatsappTemplateId",
                    WhatsappTemplateName = "whatsappTemplateName",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateListResponse { };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("totalPages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Category = "category",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Definition = new()
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
                    },
                    DisplayName = "displayName",
                    IsPublished = true,
                    Language = "language",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WhatsappTemplateID = "whatsappTemplateId",
                    WhatsappTemplateName = "whatsappTemplateName",
                },
            ],
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        TemplateListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
