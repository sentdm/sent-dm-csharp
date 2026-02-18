using System;
using System.Net.Http;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Category = "MARKETING",
            CreationSource = null,
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template = "Hello {{0:variable}}! Welcome to {{1:variable}}.",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                            new()
                            {
                                ID = 1,
                                Name = "company",
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
            Language = "en_US",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        string expectedCategory = "MARKETING";
        TemplateDefinition expectedDefinition = new()
        {
            Body = new()
            {
                MultiChannel = new()
                {
                    Template = "Hello {{0:variable}}! Welcome to {{1:variable}}.",
                    Type = null,
                    Variables =
                    [
                        new()
                        {
                            ID = 0,
                            Name = "name",
                            Props = new()
                            {
                                Alt = null,
                                MediaType = null,
                                Sample = "John",
                                ShortUrl = null,
                                Url = null,
                                VariableType = "text",
                            },
                            Type = "variable",
                        },
                        new()
                        {
                            ID = 1,
                            Name = "company",
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
        string expectedLanguage = "en_US";
        bool expectedSubmitForReview = false;
        bool expectedTestMode = false;
        string expectedIdempotencyKey = "req_abc123_retry1";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Null(parameters.CreationSource);
        Assert.Equal(expectedDefinition, parameters.Definition);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedSubmitForReview, parameters.SubmitForReview);
        Assert.Equal(expectedTestMode, parameters.TestMode);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Category = "MARKETING",
            CreationSource = null,
            Language = "en_US",
        };

        Assert.Null(parameters.Definition);
        Assert.False(parameters.RawBodyData.ContainsKey("definition"));
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
        var parameters = new TemplateCreateParams
        {
            Category = "MARKETING",
            CreationSource = null,
            Language = "en_US",

            // Null should be interpreted as omitted for these properties
            Definition = null,
            SubmitForReview = null,
            TestMode = null,
            IdempotencyKey = null,
        };

        Assert.Null(parameters.Definition);
        Assert.False(parameters.RawBodyData.ContainsKey("definition"));
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
        var parameters = new TemplateCreateParams
        {
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template = "Hello {{0:variable}}! Welcome to {{1:variable}}.",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                            new()
                            {
                                ID = 1,
                                Name = "company",
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
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.CreationSource);
        Assert.False(parameters.RawBodyData.ContainsKey("creation_source"));
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
                        Template = "Hello {{0:variable}}! Welcome to {{1:variable}}.",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                            new()
                            {
                                ID = 1,
                                Name = "company",
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
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",

            Category = null,
            CreationSource = null,
            Language = null,
        };

        Assert.Null(parameters.Category);
        Assert.True(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.CreationSource);
        Assert.True(parameters.RawBodyData.ContainsKey("creation_source"));
        Assert.Null(parameters.Language);
        Assert.True(parameters.RawBodyData.ContainsKey("language"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.sent.dm/v3/templates"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateCreateParams parameters = new() { IdempotencyKey = "req_abc123_retry1" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateCreateParams
        {
            Category = "MARKETING",
            CreationSource = null,
            Definition = new()
            {
                Body = new()
                {
                    MultiChannel = new()
                    {
                        Template = "Hello {{0:variable}}! Welcome to {{1:variable}}.",
                        Type = null,
                        Variables =
                        [
                            new()
                            {
                                ID = 0,
                                Name = "name",
                                Props = new()
                                {
                                    Alt = null,
                                    MediaType = null,
                                    Sample = "John",
                                    ShortUrl = null,
                                    Url = null,
                                    VariableType = "text",
                                },
                                Type = "variable",
                            },
                            new()
                            {
                                ID = 1,
                                Name = "company",
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
            Language = "en_US",
            SubmitForReview = false,
            TestMode = false,
            IdempotencyKey = "req_abc123_retry1",
        };

        TemplateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
