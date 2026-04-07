using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class SentDmServicesCommonContractsPocOsTemplateBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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

        TemplateBodyContent expectedMultiChannel = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        TemplateBodyContent expectedSms = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        TemplateBodyContent expectedWhatsapp = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateBody>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsTemplateBody>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        TemplateBodyContent expectedMultiChannel = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        TemplateBodyContent expectedSms = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        TemplateBodyContent expectedWhatsapp = new()
        {
            Template = "template",
            Type = "type",
            Variables =
            [
                new()
                {
                    Name = "x",
                    Props = new()
                    {
                        MediaType = "x",
                        Sample = "x",
                        Url = "x",
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
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody { };

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
        var model = new SentDmServicesCommonContractsPocOsTemplateBody { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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
        var model = new SentDmServicesCommonContractsPocOsTemplateBody
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

        SentDmServicesCommonContractsPocOsTemplateBody copied = new(model);

        Assert.Equal(model, copied);
    }
}
