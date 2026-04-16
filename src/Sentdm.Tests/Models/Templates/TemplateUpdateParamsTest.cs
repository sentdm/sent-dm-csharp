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
                                Name = "x",
                                Props = new()
                                {
                                    MediaType = "x",
                                    Sample = "x",
                                    Url = "x",
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
                            Name = "x",
                            Props = new()
                            {
                                MediaType = "x",
                                Sample = "x",
                                Url = "x",
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
