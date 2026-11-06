using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookSenderProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];

        Assert.NotNull(model.EventFilters);
        Assert.Equal(expectedEventFilters.Count, model.EventFilters.Count);
        foreach (var item in expectedEventFilters)
        {
            Assert.True(model.EventFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.EventFilters[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.EventFilters[item.Key][i]);
            }
        }
        Assert.NotNull(model.EventTypes);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSenderProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSenderProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, List<string>> expectedEventFilters = new() { { "foo", ["string"] } };
        List<string> expectedEventTypes = ["string"];

        Assert.NotNull(deserialized.EventFilters);
        Assert.Equal(expectedEventFilters.Count, deserialized.EventFilters.Count);
        foreach (var item in expectedEventFilters)
        {
            Assert.True(deserialized.EventFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.EventFilters[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.EventFilters[item.Key][i]);
            }
        }
        Assert.NotNull(deserialized.EventTypes);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
        };

        Assert.Null(model.EventTypes);
        Assert.False(model.RawData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookSenderProfile { EventTypes = ["string"] };

        Assert.Null(model.EventFilters);
        Assert.False(model.RawData.ContainsKey("event_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookSenderProfile { EventTypes = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventTypes = ["string"],

            EventFilters = null,
        };

        Assert.Null(model.EventFilters);
        Assert.True(model.RawData.ContainsKey("event_filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventTypes = ["string"],

            EventFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookSenderProfile
        {
            EventFilters = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "foo", ["string"] },
            },
            EventTypes = ["string"],
        };

        WebhookSenderProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
