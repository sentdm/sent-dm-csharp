using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Tests.Models.Brands.Campaigns;

public class CampaignDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { TestMode = false },
        };

        string expectedBrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        string expectedCampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901";
        Body expectedBody = new() { TestMode = false };

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        CampaignDeleteParams parameters = new()
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { TestMode = false },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v3/brands/a1b2c3d4-e5f6-7890-abcd-ef1234567890/campaigns/b2c3d4e5-f6a7-8901-bcde-f12345678901"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            BrandID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { TestMode = false },
        };

        CampaignDeleteParams copied = new(parameters);

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
