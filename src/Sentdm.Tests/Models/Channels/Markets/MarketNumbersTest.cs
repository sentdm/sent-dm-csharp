using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Markets;

namespace Sentdm.Tests.Models.Channels.Markets;

public class MarketNumbersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MarketNumbers
        {
            Channel = "channel",
            Country = "country",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    SenderValue = "sender_value",
                    Status = "status",
                    Type = "type",
                },
            ],
        };

        string expectedChannel = "channel";
        string expectedCountry = "country";
        List<MarketNumber> expectedNumbers =
        [
            new()
            {
                AreaCode = "area_code",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SenderValue = "sender_value",
                Status = "status",
                Type = "type",
            },
        ];

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCountry, model.Country);
        Assert.NotNull(model.Numbers);
        Assert.Equal(expectedNumbers.Count, model.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], model.Numbers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MarketNumbers
        {
            Channel = "channel",
            Country = "country",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    SenderValue = "sender_value",
                    Status = "status",
                    Type = "type",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketNumbers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MarketNumbers
        {
            Channel = "channel",
            Country = "country",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    SenderValue = "sender_value",
                    Status = "status",
                    Type = "type",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketNumbers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        string expectedCountry = "country";
        List<MarketNumber> expectedNumbers =
        [
            new()
            {
                AreaCode = "area_code",
                CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SenderValue = "sender_value",
                Status = "status",
                Type = "type",
            },
        ];

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.NotNull(deserialized.Numbers);
        Assert.Equal(expectedNumbers.Count, deserialized.Numbers.Count);
        for (int i = 0; i < expectedNumbers.Count; i++)
        {
            Assert.Equal(expectedNumbers[i], deserialized.Numbers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MarketNumbers
        {
            Channel = "channel",
            Country = "country",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    SenderValue = "sender_value",
                    Status = "status",
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketNumbers { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Numbers);
        Assert.False(model.RawData.ContainsKey("numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketNumbers { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MarketNumbers
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            Country = null,
            Numbers = null,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Numbers);
        Assert.False(model.RawData.ContainsKey("numbers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketNumbers
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            Country = null,
            Numbers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MarketNumbers
        {
            Channel = "channel",
            Country = "country",
            Numbers =
            [
                new()
                {
                    AreaCode = "area_code",
                    CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    SenderValue = "sender_value",
                    Status = "status",
                    Type = "type",
                },
            ],
        };

        MarketNumbers copied = new(model);

        Assert.Equal(model, copied);
    }
}
