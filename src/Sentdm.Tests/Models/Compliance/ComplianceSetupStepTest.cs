using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Tests.Models.Compliance;

public class ComplianceSetupStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        List<ComplianceAttachmentTemplate> expectedAttachments =
        [
            new()
            {
                FieldName = "field_name",
                Label = "label",
                Required = true,
            },
        ];
        JsonElement expectedBody = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedPath = "path";
        string expectedResource = "resource";
        int expectedStep = 0;
        string expectedWhy = "why";

        Assert.NotNull(model.Attachments);
        Assert.Equal(expectedAttachments.Count, model.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], model.Attachments[i]);
        }
        Assert.NotNull(model.Body);
        Assert.True(JsonElement.DeepEquals(expectedBody, model.Body.Value));
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedResource, model.Resource);
        Assert.Equal(expectedStep, model.Step);
        Assert.Equal(expectedWhy, model.Why);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSetupStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSetupStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ComplianceAttachmentTemplate> expectedAttachments =
        [
            new()
            {
                FieldName = "field_name",
                Label = "label",
                Required = true,
            },
        ];
        JsonElement expectedBody = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedPath = "path";
        string expectedResource = "resource";
        int expectedStep = 0;
        string expectedWhy = "why";

        Assert.NotNull(deserialized.Attachments);
        Assert.Equal(expectedAttachments.Count, deserialized.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], deserialized.Attachments[i]);
        }
        Assert.NotNull(deserialized.Body);
        Assert.True(JsonElement.DeepEquals(expectedBody, deserialized.Body.Value));
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedResource, deserialized.Resource);
        Assert.Equal(expectedStep, deserialized.Step);
        Assert.Equal(expectedWhy, deserialized.Why);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Resource);
        Assert.False(model.RawData.ContainsKey("resource"));
        Assert.Null(model.Step);
        Assert.False(model.RawData.ContainsKey("step"));
        Assert.Null(model.Why);
        Assert.False(model.RawData.ContainsKey("why"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Body = null,
            Method = null,
            Path = null,
            Resource = null,
            Step = null,
            Why = null,
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Resource);
        Assert.False(model.RawData.ContainsKey("resource"));
        Assert.Null(model.Step);
        Assert.False(model.RawData.ContainsKey("step"));
        Assert.Null(model.Why);
        Assert.False(model.RawData.ContainsKey("why"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Body = null,
            Method = null,
            Path = null,
            Resource = null,
            Step = null,
            Why = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceSetupStep
        {
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        Assert.Null(model.Attachments);
        Assert.False(model.RawData.ContainsKey("attachments"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceSetupStep
        {
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComplianceSetupStep
        {
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",

            Attachments = null,
        };

        Assert.Null(model.Attachments);
        Assert.True(model.RawData.ContainsKey("attachments"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceSetupStep
        {
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",

            Attachments = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceSetupStep
        {
            Attachments =
            [
                new()
                {
                    FieldName = "field_name",
                    Label = "label",
                    Required = true,
                },
            ],
            Body = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Path = "path",
            Resource = "resource",
            Step = 0,
            Why = "why",
        };

        ComplianceSetupStep copied = new(model);

        Assert.Equal(model, copied);
    }
}
