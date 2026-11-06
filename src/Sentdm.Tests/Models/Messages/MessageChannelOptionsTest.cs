using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageChannelOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = "country",
            From = ["string"],
            Strategy = "strategy",
        };

        string expectedCountry = "country";
        List<string> expectedFrom = ["string"];
        string expectedStrategy = "strategy";

        Assert.Equal(expectedCountry, model.Country);
        Assert.NotNull(model.From);
        Assert.Equal(expectedFrom.Count, model.From.Count);
        for (int i = 0; i < expectedFrom.Count; i++)
        {
            Assert.Equal(expectedFrom[i], model.From[i]);
        }
        Assert.Equal(expectedStrategy, model.Strategy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = "country",
            From = ["string"],
            Strategy = "strategy",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageChannelOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = "country",
            From = ["string"],
            Strategy = "strategy",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageChannelOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        List<string> expectedFrom = ["string"];
        string expectedStrategy = "strategy";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.NotNull(deserialized.From);
        Assert.Equal(expectedFrom.Count, deserialized.From.Count);
        for (int i = 0; i < expectedFrom.Count; i++)
        {
            Assert.Equal(expectedFrom[i], deserialized.From[i]);
        }
        Assert.Equal(expectedStrategy, deserialized.Strategy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = "country",
            From = ["string"],
            Strategy = "strategy",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageChannelOptions { };

        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Strategy);
        Assert.False(model.RawData.ContainsKey("strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageChannelOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = null,
            From = null,
            Strategy = null,
        };

        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.From);
        Assert.True(model.RawData.ContainsKey("from"));
        Assert.Null(model.Strategy);
        Assert.True(model.RawData.ContainsKey("strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = null,
            From = null,
            Strategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageChannelOptions
        {
            Country = "country",
            From = ["string"],
            Strategy = "strategy",
        };

        MessageChannelOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}
