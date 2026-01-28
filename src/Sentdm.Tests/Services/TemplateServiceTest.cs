using System.Threading.Tasks;

namespace Sentdm.Tests.Services;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var templateResponse = await this.client.Templates.Create(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        templateResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var templateResponse = await this.client.Templates.Retrieve(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
        templateResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Templates.List(
            new() { Page = 0, PageSize = 0 },
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Templates.Delete(
            "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
