using System;
using System.Net.Http;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Category = "MARKETING",
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
            Language = null,
            Name = "Updated Welcome Message",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedCategory = "MARKETING";
        TemplateDefinition expectedDefinition = new()
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
        string expectedName = "Updated Welcome Message";
        bool expectedSubmitForReview = false;
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedDefinition, parameters.Definition);
        Assert.Null(parameters.Language);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSubmitForReview, parameters.SubmitForReview);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Category = "MARKETING",
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
            Language = null,
            Name = "Updated Welcome Message",
        };

        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submit_for_review"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Category = "MARKETING",
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
            Language = null,
            Name = "Updated Welcome Message",

            // Null should be interpreted as omitted for these properties
            SubmitForReview = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submit_for_review"));
        Assert.Null(parameters.TestMode);
        Assert.False(parameters.RawBodyData.ContainsKey("test_mode"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Definition);
        Assert.False(parameters.RawBodyData.ContainsKey("definition"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",

            Category = null,
            Definition = null,
            Language = null,
            Name = null,
        };

        Assert.Null(parameters.Category);
        Assert.True(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Definition);
        Assert.True(parameters.RawBodyData.ContainsKey("definition"));
        Assert.Null(parameters.Language);
        Assert.True(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateUpdateParams parameters = new() { ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/templates/7ba7b820-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateUpdateParams parameters = new()
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            IdempotencyKey = "req_abc123_retry1",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Category = "MARKETING",
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
            Language = null,
            Name = "Updated Welcome Message",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        TemplateUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
