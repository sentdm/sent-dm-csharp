using System;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Brands;

namespace SentDm.Tests.Models.Brands;

public class BrandDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandDeleteParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Body = new() { TestMode = false },
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        Body expectedBody = new() { TestMode = false };

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        BrandDeleteParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Body = new() { TestMode = false },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandDeleteParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            Body = new() { TestMode = false },
        };

        BrandDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body { TestMode = false };

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, model.TestMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body { TestMode = false };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body { TestMode = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, deserialized.TestMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body { TestMode = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body { TestMode = false };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}
