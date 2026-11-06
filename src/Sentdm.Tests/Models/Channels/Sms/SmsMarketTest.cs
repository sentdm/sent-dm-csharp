using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Exceptions;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SmsMarketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        SmsMarketCompliance expectedCompliance = new()
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };
        string expectedCountry = "country";
        string expectedNumberType = "number_type";
        List<SmsNumber> expectedNumbers =
        [
            new()
            {
                AreaCode = "area_code",
                SenderValue = "sender_value",
                Status = "status",
            },
        ];
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        string expectedSenderValue = "sender_value";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;

        Assert.Equal(expectedCompliance, model.Compliance);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedNumberType, model.NumberType);
        Assert.NotNull(model.Numbers);
        Assert.Equal(expectedNumbers.Count, model.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], model.Numbers[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsMarket>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsMarket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SmsMarketCompliance expectedCompliance = new()
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };
        string expectedCountry = "country";
        string expectedNumberType = "number_type";
        List<SmsNumber> expectedNumbers =
        [
            new()
            {
                AreaCode = "area_code",
                SenderValue = "sender_value",
                Status = "status",
            },
        ];
        string expectedReason = "reason";
        string expectedReasonCode = "reason_code";
        string expectedSenderValue = "sender_value";
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;

        Assert.Equal(expectedCompliance, deserialized.Compliance);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedNumberType, deserialized.NumberType);
        Assert.NotNull(deserialized.Numbers);
        Assert.Equal(expectedNumbers.Count, deserialized.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], deserialized.Numbers[i]);
        }
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        Assert.Null(model.Numbers);
        Assert.False(model.RawData.ContainsKey("numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,

            // Null should be interpreted as omitted for these properties
            Numbers = null,
        };

        Assert.Null(model.Numbers);
        Assert.False(model.RawData.ContainsKey("numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,

            // Null should be interpreted as omitted for these properties
            Numbers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsMarket
        {
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
        };

        Assert.Null(model.Compliance);
        Assert.False(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.NumberType);
        Assert.False(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.False(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsMarket
        {
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SmsMarket
        {
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],

            Compliance = null,
            Country = null,
            NumberType = null,
            Reason = null,
            ReasonCode = null,
            SenderValue = null,
            Status = null,
        };

        Assert.Null(model.Compliance);
        Assert.True(model.RawData.ContainsKey("compliance"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.NumberType);
        Assert.True(model.RawData.ContainsKey("number_type"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.ReasonCode);
        Assert.True(model.RawData.ContainsKey("reason_code"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsMarket
        {
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],

            Compliance = null,
            Country = null,
            NumberType = null,
            Reason = null,
            ReasonCode = null,
            SenderValue = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsMarket
        {
            Compliance = new()
            {
                Brand = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Campaign = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Documents =
                [
                    new()
                    {
                        DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        FileName = "file_name",
                        Key = "key",
                    },
                ],
            },
            Country = "country",
            NumberType = "number_type",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    SenderValue = "sender_value",
                    Status = "status",
                },
            ],
            Reason = "reason",
            ReasonCode = "reason_code",
            SenderValue = "sender_value",
            Status = Status.Provisioning,
        };

        SmsMarket copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SmsMarketComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };

        Dictionary<string, JsonElement> expectedBrand = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedCampaign = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<Document> expectedDocuments =
        [
            new()
            {
                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                FileName = "file_name",
                Key = "key",
            },
        ];

        Assert.NotNull(model.Brand);
        Assert.Equal(expectedBrand.Count, model.Brand.Count);
        foreach (var item in expectedBrand)
        {
            Assert.True(model.Brand.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Brand[item.Key]));
        }
        Assert.NotNull(model.Campaign);
        Assert.Equal(expectedCampaign.Count, model.Campaign.Count);
        foreach (var item in expectedCampaign)
        {
            Assert.True(model.Campaign.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Campaign[item.Key]));
        }
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsMarketCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SmsMarketCompliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedBrand = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedCampaign = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<Document> expectedDocuments =
        [
            new()
            {
                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                FileName = "file_name",
                Key = "key",
            },
        ];

        Assert.NotNull(deserialized.Brand);
        Assert.Equal(expectedBrand.Count, deserialized.Brand.Count);
        foreach (var item in expectedBrand)
        {
            Assert.True(deserialized.Brand.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Brand[item.Key]));
        }
        Assert.NotNull(deserialized.Campaign);
        Assert.Equal(expectedCampaign.Count, deserialized.Campaign.Count);
        foreach (var item in expectedCampaign)
        {
            Assert.True(deserialized.Campaign.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Campaign[item.Key]));
        }
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SmsMarketCompliance { };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Campaign);
        Assert.False(model.RawData.ContainsKey("campaign"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SmsMarketCompliance { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = null,
            Campaign = null,
            Documents = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Campaign);
        Assert.True(model.RawData.ContainsKey("campaign"));
        Assert.Null(model.Documents);
        Assert.True(model.RawData.ContainsKey("documents"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = null,
            Campaign = null,
            Documents = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SmsMarketCompliance
        {
            Brand = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Campaign = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Documents =
            [
                new()
                {
                    DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    FileName = "file_name",
                    Key = "key",
                },
            ],
        };

        SmsMarketCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Key = "key",
        };

        string expectedDocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedKey = "key";

        Assert.Equal(expectedDocumentID, model.DocumentID);
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedKey, model.Key);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Key = "key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Key = "key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileName = "file_name";
        string expectedKey = "key";

        Assert.Equal(expectedDocumentID, deserialized.DocumentID);
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedKey, deserialized.Key);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Key = "key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",

            // Null should be interpreted as omitted for these properties
            Key = null,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",

            // Null should be interpreted as omitted for these properties
            Key = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { Key = "key" };

        Assert.Null(model.DocumentID);
        Assert.False(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("file_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { Key = "key" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Document
        {
            Key = "key",

            DocumentID = null,
            FileName = null,
        };

        Assert.Null(model.DocumentID);
        Assert.True(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.FileName);
        Assert.True(model.RawData.ContainsKey("file_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            Key = "key",

            DocumentID = null,
            FileName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Document
        {
            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileName = "file_name",
            Key = "key",
        };

        Document copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SentInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.PendingReview)]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
