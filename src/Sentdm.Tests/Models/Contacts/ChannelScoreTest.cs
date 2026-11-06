using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ChannelScoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string expectedChannel = "channel";
        int expectedFailScore = 0;
        int expectedSuccessScore = 0;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedFailScore, model.FailScore);
        Assert.Equal(expectedSuccessScore, model.SuccessScore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelScore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelScore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        int expectedFailScore = 0;
        int expectedSuccessScore = 0;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedFailScore, deserialized.FailScore);
        Assert.Equal(expectedSuccessScore, deserialized.SuccessScore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelScore { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.FailScore);
        Assert.False(model.RawData.ContainsKey("fail_score"));
        Assert.Null(model.SuccessScore);
        Assert.False(model.RawData.ContainsKey("success_score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelScore { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChannelScore
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            FailScore = null,
            SuccessScore = null,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.FailScore);
        Assert.False(model.RawData.ContainsKey("fail_score"));
        Assert.Null(model.SuccessScore);
        Assert.False(model.RawData.ContainsKey("success_score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelScore
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            FailScore = null,
            SuccessScore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        ChannelScore copied = new(model);

        Assert.Equal(model, copied);
    }
}
