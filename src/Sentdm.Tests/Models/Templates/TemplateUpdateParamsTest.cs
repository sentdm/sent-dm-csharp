using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
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
                                Name = "x",
                                Props = new()
                                {
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
            },
            Language = null,
            Name = "Updated Welcome Message",
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8";
        string expectedCategory = "MARKETING";
        TemplateUpdateParamsDefinition expectedDefinition = new()
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
        string expectedName = "Updated Welcome Message";
        bool expectedSandbox = false;
        bool expectedSubmitForReview = false;
        string expectedIdempotencyKey = "req_abc123_retry1";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedDefinition, parameters.Definition);
        Assert.Null(parameters.Language);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSandbox, parameters.Sandbox);
        Assert.Equal(expectedSubmitForReview, parameters.SubmitForReview);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
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
                                Name = "x",
                                Props = new()
                                {
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
            },
            Language = null,
            Name = "Updated Welcome Message",
        };

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
                                Name = "x",
                                Props = new()
                                {
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
            },
            Language = null,
            Name = "Updated Welcome Message",

            // Null should be interpreted as omitted for these properties
            Sandbox = null,
            SubmitForReview = null,
            IdempotencyKey = null,
            XProfileID = null,
        };

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
        var parameters = new TemplateUpdateParams
        {
            ID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

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

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.sent.dm/v3/templates/7ba7b820-9dad-11d1-80b4-00c04fd430c8"),
                url
            )
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
                                Name = "x",
                                Props = new()
                                {
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
            },
            Language = null,
            Name = "Updated Welcome Message",
            Sandbox = false,
            SubmitForReview = false,
            IdempotencyKey = "req_abc123_retry1",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TemplateUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TemplateUpdateParamsDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinition
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

        TemplateUpdateParamsDefinitionBody expectedBody = new()
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
        TemplateUpdateParamsDefinitionAuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<TemplateUpdateParamsDefinitionButton> expectedButtons =
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
        TemplateUpdateParamsDefinitionFooter expectedFooter = new()
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
        TemplateUpdateParamsDefinitionHeader expectedHeader = new()
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
        var model = new TemplateUpdateParamsDefinition
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinition
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TemplateUpdateParamsDefinitionBody expectedBody = new()
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
        TemplateUpdateParamsDefinitionAuthenticationConfig expectedAuthenticationConfig = new()
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };
        List<TemplateUpdateParamsDefinitionButton> expectedButtons =
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
        TemplateUpdateParamsDefinitionFooter expectedFooter = new()
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
        TemplateUpdateParamsDefinitionHeader expectedHeader = new()
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
        var model = new TemplateUpdateParamsDefinition
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
        var model = new TemplateUpdateParamsDefinition
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
        var model = new TemplateUpdateParamsDefinition
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
        var model = new TemplateUpdateParamsDefinition
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
        var model = new TemplateUpdateParamsDefinition
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
        var model = new TemplateUpdateParamsDefinition
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

        TemplateUpdateParamsDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBody
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

        TemplateUpdateParamsDefinitionBodyMultiChannel expectedMultiChannel = new()
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
        TemplateUpdateParamsDefinitionBodyRcs expectedRcs = new()
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
        TemplateUpdateParamsDefinitionBodySms expectedSms = new()
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
        TemplateUpdateParamsDefinitionBodyWhatsapp expectedWhatsapp = new()
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
        var model = new TemplateUpdateParamsDefinitionBody
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBody>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBody
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBody>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TemplateUpdateParamsDefinitionBodyMultiChannel expectedMultiChannel = new()
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
        TemplateUpdateParamsDefinitionBodyRcs expectedRcs = new()
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
        TemplateUpdateParamsDefinitionBodySms expectedSms = new()
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
        TemplateUpdateParamsDefinitionBodyWhatsapp expectedWhatsapp = new()
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
        var model = new TemplateUpdateParamsDefinitionBody
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
        var model = new TemplateUpdateParamsDefinitionBody { };

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
        var model = new TemplateUpdateParamsDefinitionBody { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBody
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
        var model = new TemplateUpdateParamsDefinitionBody
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
        var model = new TemplateUpdateParamsDefinitionBody
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

        TemplateUpdateParamsDefinitionBody copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyMultiChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        List<TemplateUpdateParamsDefinitionBodyMultiChannelVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannel>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannel>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionBodyMultiChannelVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannel
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

        TemplateUpdateParamsDefinitionBodyMultiChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyMultiChannelVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannelVariable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionBodyMultiChannelVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyMultiChannelVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionBodyMultiChannelVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyRcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        List<TemplateUpdateParamsDefinitionBodyRcsVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionBodyRcsVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        var model = new TemplateUpdateParamsDefinitionBodyRcs { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcs { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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
        var model = new TemplateUpdateParamsDefinitionBodyRcs
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

        TemplateUpdateParamsDefinitionBodyRcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyRcsVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionBodyRcsVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcsVariable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcsVariable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionBodyRcsVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionBodyRcsVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyRcsVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcsVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyRcsVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyRcsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionBodyRcsVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodySmsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        List<TemplateUpdateParamsDefinitionBodySmsVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionBodySmsVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        var model = new TemplateUpdateParamsDefinitionBodySms { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySms { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        var model = new TemplateUpdateParamsDefinitionBodySms
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
        var model = new TemplateUpdateParamsDefinitionBodySms
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

        TemplateUpdateParamsDefinitionBodySms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodySmsVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionBodySmsVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySmsVariable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySmsVariable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionBodySmsVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionBodySmsVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodySmsVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySmsVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodySmsVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodySmsVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionBodySmsVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyWhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        List<TemplateUpdateParamsDefinitionBodyWhatsappVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsapp>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionBodyWhatsappVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsapp
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

        TemplateUpdateParamsDefinitionBodyWhatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyWhatsappVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionBodyWhatsappVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsappVariable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsappVariable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionBodyWhatsappVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionBodyWhatsappVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionBodyWhatsappVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsappVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionBodyWhatsappVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
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
        var model = new TemplateUpdateParamsDefinitionBodyWhatsappVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionBodyWhatsappVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionAuthenticationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
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
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionAuthenticationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionAuthenticationConfig>(
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
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            CodeExpirationMinutes = 0,
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            CodeExpirationMinutes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
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
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
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
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
        };

        Assert.Null(model.CodeExpirationMinutes);
        Assert.False(model.RawData.ContainsKey("codeExpirationMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
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
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,

            CodeExpirationMinutes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateUpdateParamsDefinitionAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        TemplateUpdateParamsDefinitionAuthenticationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionButton
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

        TemplateUpdateParamsDefinitionButtonProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionButton>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionButton
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionButton>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TemplateUpdateParamsDefinitionButtonProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var model = new TemplateUpdateParamsDefinitionButton
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
        var model = new TemplateUpdateParamsDefinitionButton
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

        TemplateUpdateParamsDefinitionButton copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionButtonPropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionButtonProps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionButtonProps>(
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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
        var model = new TemplateUpdateParamsDefinitionButtonProps
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

        TemplateUpdateParamsDefinitionButtonProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionFooterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooter
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
        List<TemplateUpdateParamsDefinitionFooterVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionFooter
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooter
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionFooterVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionFooter
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
        var model = new TemplateUpdateParamsDefinitionFooter { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooter { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooter
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
        var model = new TemplateUpdateParamsDefinitionFooter
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
        var model = new TemplateUpdateParamsDefinitionFooter
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

        TemplateUpdateParamsDefinitionFooter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionFooterVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionFooterVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooterVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooterVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionFooterVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionFooterVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionFooterVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionFooterVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooterVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionFooterVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
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
        var model = new TemplateUpdateParamsDefinitionFooterVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionFooterVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionHeaderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeader
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
        List<TemplateUpdateParamsDefinitionHeaderVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionHeader
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeader>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeader
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeader>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedType = "type";
        List<TemplateUpdateParamsDefinitionHeaderVariable> expectedVariables =
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
        var model = new TemplateUpdateParamsDefinitionHeader
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
        var model = new TemplateUpdateParamsDefinitionHeader { Template = "template" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeader { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeader
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
        var model = new TemplateUpdateParamsDefinitionHeader
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
        var model = new TemplateUpdateParamsDefinitionHeader
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

        TemplateUpdateParamsDefinitionHeader copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionHeaderVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        TemplateUpdateParamsDefinitionHeaderVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeaderVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeaderVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        TemplateUpdateParamsDefinitionHeaderVariableProps expectedProps = new()
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariable
        {
            Name = "x",
            Props = new()
            {
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

        TemplateUpdateParamsDefinitionHeaderVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateParamsDefinitionHeaderVariablePropsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeaderVariableProps>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var deserialized =
            JsonSerializer.Deserialize<TemplateUpdateParamsDefinitionHeaderVariableProps>(
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
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
        var model = new TemplateUpdateParamsDefinitionHeaderVariableProps
        {
            MediaType = "x",
            Sample = "x",
            Url = "x",
            VariableType = "x",
            Alt = "alt",
            Regex = "regex",
            ShortUrl = "shortUrl",
        };

        TemplateUpdateParamsDefinitionHeaderVariableProps copied = new(model);

        Assert.Equal(model, copied);
    }
}
