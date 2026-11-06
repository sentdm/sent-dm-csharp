using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Tests.Models.Compliance;

public class ComplianceAttachmentTemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Label = "label",
            Required = true,
        };

        string expectedFieldName = "field_name";
        string expectedLabel = "label";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldName, model.FieldName);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedRequired, model.Required);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Label = "label",
            Required = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceAttachmentTemplate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Label = "label",
            Required = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceAttachmentTemplate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFieldName = "field_name";
        string expectedLabel = "label";
        bool expectedRequired = true;

        Assert.Equal(expectedFieldName, deserialized.FieldName);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedRequired, deserialized.Required);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Label = "label",
            Required = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceAttachmentTemplate { Label = "label" };

        Assert.Null(model.FieldName);
        Assert.False(model.RawData.ContainsKey("field_name"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceAttachmentTemplate { Label = "label" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            Label = "label",

            // Null should be interpreted as omitted for these properties
            FieldName = null,
            Required = null,
        };

        Assert.Null(model.FieldName);
        Assert.False(model.RawData.ContainsKey("field_name"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            Label = "label",

            // Null should be interpreted as omitted for these properties
            FieldName = null,
            Required = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceAttachmentTemplate { FieldName = "field_name", Required = true };

        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceAttachmentTemplate { FieldName = "field_name", Required = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Required = true,

            Label = null,
        };

        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Required = true,

            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceAttachmentTemplate
        {
            FieldName = "field_name",
            Label = "label",
            Required = true,
        };

        ComplianceAttachmentTemplate copied = new(model);

        Assert.Equal(model, copied);
    }
}
