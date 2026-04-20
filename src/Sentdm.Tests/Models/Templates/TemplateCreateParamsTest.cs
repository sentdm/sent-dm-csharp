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
                                Name = "name",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "John",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 0,
                            },
                            new()
                            {
                                Name = "company",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "SentDM",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 1,
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
                DefinitionVersion = "1.0",
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
            },
            Language = "en_US",
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                            Name = "name",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "John",
                                Url = "x",
                                VariableType = "text",
                                Alt = null,
                                Regex = null,
                                ShortUrl = null,
                            },
                            Type = "variable",
                            ID = 0,
                        },
                        new()
                        {
                            Name = "company",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "SentDM",
                                Url = "x",
                                VariableType = "text",
                                Alt = null,
                                Regex = null,
                                ShortUrl = null,
                            },
                            Type = "variable",
                            ID = 1,
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
            DefinitionVersion = "1.0",
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
        string expectedLanguage = "en_US";
        bool expectedSandbox = false;
        bool expectedSubmitForReview = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Null(parameters.CreationSource);
        Assert.Equal(expectedDefinition, parameters.Definition);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedSubmitForReview, parameters.SubmitForReview);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
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
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submit_for_review"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
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
            Sandbox = null,
            SubmitForReview = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

        Assert.Null(parameters.Definition);
        Assert.False(parameters.RawBodyData.ContainsKey("definition"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.SubmitForReview);
        Assert.False(parameters.RawBodyData.ContainsKey("submit_for_review"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
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
                                Name = "name",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "John",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 0,
                            },
                            new()
                            {
                                Name = "company",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "SentDM",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 1,
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
                DefinitionVersion = "1.0",
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
            },
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                                Name = "name",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "John",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 0,
                            },
                            new()
                            {
                                Name = "company",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "SentDM",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 1,
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
                DefinitionVersion = "1.0",
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
            },
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

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

        Assert.True(TestBase.UrisEqual(new Uri("https://api.sent.dm/v3/templates"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TemplateCreateParams parameters = new()
        {
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["req_abc123_retry1"], requestMessage.Headers.GetValues("Idempotency-Key"));
        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
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
                                Name = "name",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "John",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 0,
                            },
                            new()
                            {
                                Name = "company",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "SentDM",
                                    Url = "x",
                                    VariableType = "text",
                                    Alt = null,
                                    Regex = null,
                                    ShortUrl = null,
                                },
                                Type = "variable",
                                ID = 1,
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
                DefinitionVersion = "1.0",
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
            },
            Language = "en_US",
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TemplateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
