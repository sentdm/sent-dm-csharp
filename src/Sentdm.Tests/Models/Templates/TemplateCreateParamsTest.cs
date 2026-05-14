using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
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
                    Rcs = new()
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
        Definition expectedDefinition = new()
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
                Rcs = new()
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
                    Rcs = new()
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
                    Rcs = new()
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
                    Rcs = new()
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

public class DefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Definition
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
                Rcs = new()
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

        Body expectedBody = new()
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
            Rcs = new()
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
        AuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<Button> expectedButtons =
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
        string expectedDefinitionVersion = "1.0";
        Footer expectedFooter = new()
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
        Header expectedHeader = new()
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
        var model = new Definition
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
                Rcs = new()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Definition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Definition
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
                Rcs = new()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Definition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Body expectedBody = new()
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
            Rcs = new()
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
        AuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<Button> expectedButtons =
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
        string expectedDefinitionVersion = "1.0";
        Footer expectedFooter = new()
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
        Header expectedHeader = new()
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
        var model = new Definition
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
                Rcs = new()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Definition
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
                Rcs = new()
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
        var model = new Definition
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
                Rcs = new()
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
        var model = new Definition
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
                Rcs = new()
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
        var model = new Definition
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
                Rcs = new()
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
        var model = new Definition
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
                Rcs = new()
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

        Definition copied = new(model);

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
            Rcs = new()
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

        MultiChannel expectedMultiChannel = new()
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
        Rcs expectedRcs = new()
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
        Sms expectedSms = new()
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
        Whatsapp expectedWhatsapp = new()
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

        Assert.Equal(expectedMultiChannel, model.MultiChannel);
        Assert.Equal(expectedRcs, model.Rcs);
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
            Rcs = new()
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
            Rcs = new()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        MultiChannel expectedMultiChannel = new()
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
        Rcs expectedRcs = new()
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
        Sms expectedSms = new()
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
        Whatsapp expectedWhatsapp = new()
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

        Assert.Equal(expectedMultiChannel, deserialized.MultiChannel);
        Assert.Equal(expectedRcs, deserialized.Rcs);
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
            Rcs = new()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.MultiChannel);
        Assert.False(model.RawData.ContainsKey("multiChannel"));
        Assert.Null(model.Rcs);
        Assert.False(model.RawData.ContainsKey("rcs"));
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
            Rcs = null,
            Sms = null,
            Whatsapp = null,
        };

        Assert.Null(model.MultiChannel);
        Assert.True(model.RawData.ContainsKey("multiChannel"));
        Assert.Null(model.Rcs);
        Assert.True(model.RawData.ContainsKey("rcs"));
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
            Rcs = null,
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
            Rcs = new()
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

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MultiChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultiChannel
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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<Variable> expectedVariables =
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
        var model = new MultiChannel
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultiChannel
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<Variable> expectedVariables =
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
        var model = new MultiChannel
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MultiChannel { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MultiChannel { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MultiChannel
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
        var model = new MultiChannel
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
        var model = new MultiChannel
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

        MultiChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Variable
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
        };

        string expectedName = "x";
        Props expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Variable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Variable>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Variable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Variable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        Props expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Variable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Variable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Variable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Variable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Variable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Variable
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
        };

        Variable copied = new(model);

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
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
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
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Props>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Props
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        Props copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rcs
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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<RcsVariable> expectedVariables =
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
        var model = new Rcs
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rcs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rcs
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rcs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<RcsVariable> expectedVariables =
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
        var model = new Rcs
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rcs { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rcs { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Rcs
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
        var model = new Rcs
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
        var model = new Rcs
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

        Rcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RcsVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RcsVariable
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
        };

        string expectedName = "x";
        RcsVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RcsVariable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RcsVariable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        RcsVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RcsVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RcsVariable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RcsVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RcsVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RcsVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RcsVariable
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
        };

        RcsVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RcsVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        RcsVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SmsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sms
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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<SmsVariable> expectedVariables =
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
        var model = new Sms
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sms>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sms
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sms>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<SmsVariable> expectedVariables =
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
        var model = new Sms
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sms { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sms { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Sms
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
        var model = new Sms
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
        var model = new Sms
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

        Sms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SmsVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsVariable
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
        };

        string expectedName = "x";
        SmsVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsVariable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsVariable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        SmsVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsVariable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SmsVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsVariable
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
        };

        SmsVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SmsVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        SmsVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Whatsapp
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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<WhatsappVariable> expectedVariables =
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
        var model = new Whatsapp
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Whatsapp
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<WhatsappVariable> expectedVariables =
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
        var model = new Whatsapp
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Whatsapp { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Whatsapp { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Whatsapp
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
        var model = new Whatsapp
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
        var model = new Whatsapp
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

        Whatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappVariable
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
        };

        string expectedName = "x";
        WhatsappVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappVariable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappVariable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        WhatsappVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsappVariable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsappVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WhatsappVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsappVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappVariable
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
        };

        WhatsappVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        WhatsappVariableProps copied = new(model);

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

        ButtonProps expectedProps = new()
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
        var model = new Button
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
        var deserialized = JsonSerializer.Deserialize<Button>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Button
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
        var deserialized = JsonSerializer.Deserialize<Button>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ButtonProps expectedProps = new()
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
        var model = new Button
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
        var model = new Button
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
        var model = new Button
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
        var model = new Button
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
        var model = new Button
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
        var model = new Button
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

        Button copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ButtonPropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ButtonProps
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
        var model = new ButtonProps
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
        var deserialized = JsonSerializer.Deserialize<ButtonProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ButtonProps
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
        var deserialized = JsonSerializer.Deserialize<ButtonProps>(
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
        var model = new ButtonProps
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
        var model = new ButtonProps
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
        var model = new ButtonProps
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
        var model = new ButtonProps
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
        var model = new ButtonProps
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
        var model = new ButtonProps
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

        ButtonProps copied = new(model);

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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<FooterVariable> expectedVariables =
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Footer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<FooterVariable> expectedVariables =
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

        Footer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FooterVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FooterVariable
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
        };

        string expectedName = "x";
        FooterVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FooterVariable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FooterVariable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        FooterVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FooterVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FooterVariable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FooterVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FooterVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FooterVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FooterVariable
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
        };

        FooterVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FooterVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        FooterVariableProps copied = new(model);

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

        string expectedTemplate = "template";
        string expectedType = "type";
        List<HeaderVariable> expectedVariables =
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Header>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<HeaderVariable> expectedVariables =
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

        Header copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeaderVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HeaderVariable
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
        };

        string expectedName = "x";
        HeaderVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProps, model.Props);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HeaderVariable
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HeaderVariable
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        HeaderVariableProps expectedProps = new()
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };
        string expectedType = "x";
        int expectedID = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProps, deserialized.Props);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HeaderVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HeaderVariable
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HeaderVariable
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HeaderVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HeaderVariable
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HeaderVariable
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
        };

        HeaderVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeaderVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedSample, model.Sample);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVariableType, model.VariableType);
        Assert.Equal(expectedAlt, model.Alt);
        Assert.Equal(expectedRegex, model.Regex);
        Assert.Equal(expectedShortUrl, model.ShortUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderVariableProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HeaderVariableProps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaType = "x";
        string expectedSample = "x";
        string expectedUrl = "x";
        string expectedVariableType = "x";
        string expectedAlt = "alt";
        string expectedRegex = "regex";
        string expectedShortUrl = "shortUrl";

        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedSample, deserialized.Sample);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVariableType, deserialized.VariableType);
        Assert.Equal(expectedAlt, deserialized.Alt);
        Assert.Equal(expectedRegex, deserialized.Regex);
        Assert.Equal(expectedShortUrl, deserialized.ShortUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        Assert.Null(model.Alt);
        Assert.False(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.False(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.False(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        Assert.Null(model.Alt);
        Assert.True(model.RawData.ContainsKey("alt"));
        Assert.Null(model.Regex);
        Assert.True(model.RawData.ContainsKey("regex"));
        Assert.Null(model.ShortUrl);
        Assert.True(model.RawData.ContainsKey("shortUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",

            Alt = null,
            Regex = null,
            ShortUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        HeaderVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
