using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Markets;

namespace Sentdm.Tests.Models.Channels.Markets;

public class MarketNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
            Type = "type",
        };

        string expectedAreaCode = "area_code";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedType = "type";

        Assert.Equal(expectedAreaCode, model.AreaCode);
        Assert.Equal(expectedCampaignID, model.CampaignID);
        Assert.Equal(expectedSenderValue, model.SenderValue);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAreaCode = "area_code";
        string expectedCampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSenderValue = "sender_value";
        string expectedStatus = "status";
        string expectedType = "type";

        Assert.Equal(expectedAreaCode, deserialized.AreaCode);
        Assert.Equal(expectedCampaignID, deserialized.CampaignID);
        Assert.Equal(expectedSenderValue, deserialized.SenderValue);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketNumber { Type = "type" };

        Assert.Null(model.AreaCode);
        Assert.False(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.CampaignID);
        Assert.False(model.RawData.ContainsKey("campaign_id"));
        Assert.Null(model.SenderValue);
        Assert.False(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketNumber { Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MarketNumber
        {
            Type = "type",

            AreaCode = null,
            CampaignID = null,
            SenderValue = null,
            Status = null,
        };

        Assert.Null(model.AreaCode);
        Assert.True(model.RawData.ContainsKey("area_code"));
        Assert.Null(model.CampaignID);
        Assert.True(model.RawData.ContainsKey("campaign_id"));
        Assert.Null(model.SenderValue);
        Assert.True(model.RawData.ContainsKey("sender_value"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketNumber
        {
            Type = "type",

            AreaCode = null,
            CampaignID = null,
            SenderValue = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MarketNumber
        {
            AreaCode = "area_code",
            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SenderValue = "sender_value",
            Status = "status",
            Type = "type",
        };

        MarketNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
