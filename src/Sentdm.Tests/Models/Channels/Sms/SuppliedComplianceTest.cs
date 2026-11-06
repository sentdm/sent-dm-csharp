using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;

namespace Sentdm.Tests.Models.Channels.Sms;

public class SuppliedComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SuppliedCompliance
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
        List<SuppliedDocument> expectedDocuments =
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
        var model = new SuppliedCompliance
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
        var deserialized = JsonSerializer.Deserialize<SuppliedCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SuppliedCompliance
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
        var deserialized = JsonSerializer.Deserialize<SuppliedCompliance>(
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
        List<SuppliedDocument> expectedDocuments =
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
        var model = new SuppliedCompliance
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
        var model = new SuppliedCompliance { };

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
        var model = new SuppliedCompliance { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SuppliedCompliance
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
        var model = new SuppliedCompliance
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
        var model = new SuppliedCompliance
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

        SuppliedCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}
