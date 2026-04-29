using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookEventTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventType = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEventType = "event_type";
        bool expectedIsActive = true;
        string expectedName = "name";
        List<WebhookEventType> expectedSubTypes =
        [
            new()
            {
                Description = "description",
                DisplayName = "display_name",
                EventType = "event_type",
                IsActive = true,
                Name = "name",
                SubTypes = [],
            },
        ];

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.SubTypes);
        Assert.Equal(expectedSubTypes.Count, model.SubTypes.Count);
        for (int i = 0; i < expectedSubTypes.Count; i++)
        {
            Assert.Equal(expectedSubTypes[i], model.SubTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventType = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEventType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventType = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEventType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        string expectedEventType = "event_type";
        bool expectedIsActive = true;
        string expectedName = "name";
        List<WebhookEventType> expectedSubTypes =
        [
            new()
            {
                Description = "description",
                DisplayName = "display_name",
                EventType = "event_type",
                IsActive = true,
                Name = "name",
                SubTypes = [],
            },
        ];

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.SubTypes);
        Assert.Equal(expectedSubTypes.Count, deserialized.SubTypes.Count);
        for (int i = 0; i < expectedSubTypes.Count; i++)
        {
            Assert.Equal(expectedSubTypes[i], deserialized.SubTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventType = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            EventType = "event_type",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            EventType = "event_type",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            EventType = "event_type",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            IsActive = null,
            Name = null,
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            EventType = "event_type",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            IsActive = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookEventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));
        Assert.Null(model.SubTypes);
        Assert.False(model.RawData.ContainsKey("sub_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookEventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookEventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",

            Description = null,
            EventType = null,
            SubTypes = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.EventType);
        Assert.True(model.RawData.ContainsKey("event_type"));
        Assert.Null(model.SubTypes);
        Assert.True(model.RawData.ContainsKey("sub_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookEventType
        {
            DisplayName = "display_name",
            IsActive = true,
            Name = "name",

            Description = null,
            EventType = null,
            SubTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookEventType
        {
            Description = "description",
            DisplayName = "display_name",
            EventType = "event_type",
            IsActive = true,
            Name = "name",
            SubTypes =
            [
                new()
                {
                    Description = "description",
                    DisplayName = "display_name",
                    EventType = "event_type",
                    IsActive = true,
                    Name = "name",
                    SubTypes = [],
                },
            ],
        };

        WebhookEventType copied = new(model);

        Assert.Equal(model, copied);
    }
}
