using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Tests.Models.Compliance;

public class ComplianceRequirementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Key = "key",
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            Required = true,
            RequiredWhen = "required_when",
            Type = "type",
        };

        string expectedFormat = "format";
        List<ComplianceRequirement> expectedItemFields =
        [
            new()
            {
                Format = "format",
                ItemFields = [],
                Key = "key",
                Label = "label",
                MaxItems = 0,
                MinLength = 0,
                Notes = "notes",
                Options = ["string"],
                Required = true,
                RequiredWhen = "required_when",
                Type = "type",
            },
        ];
        string expectedKey = "key";
        string expectedLabel = "label";
        int expectedMaxItems = 0;
        int expectedMinLength = 0;
        string expectedNotes = "notes";
        List<string> expectedOptions = ["string"];
        bool expectedRequired = true;
        string expectedRequiredWhen = "required_when";
        string expectedType = "type";

        Assert.Equal(expectedFormat, model.Format);
        Assert.NotNull(model.ItemFields);
        Assert.Equal(expectedItemFields.Count, model.ItemFields.Count);
        for (int i = 0; i < expectedItemFields.Count; i++)
        {
            Assert.Equal(expectedItemFields[i], model.ItemFields[i]);
        }
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedMaxItems, model.MaxItems);
        Assert.Equal(expectedMinLength, model.MinLength);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.NotNull(model.Options);
        Assert.Equal(expectedOptions.Count, model.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], model.Options[i]);
        }
        Assert.Equal(expectedRequired, model.Required);
        Assert.Equal(expectedRequiredWhen, model.RequiredWhen);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Key = "key",
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            Required = true,
            RequiredWhen = "required_when",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceRequirement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Key = "key",
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            Required = true,
            RequiredWhen = "required_when",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceRequirement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFormat = "format";
        List<ComplianceRequirement> expectedItemFields =
        [
            new()
            {
                Format = "format",
                ItemFields = [],
                Key = "key",
                Label = "label",
                MaxItems = 0,
                MinLength = 0,
                Notes = "notes",
                Options = ["string"],
                Required = true,
                RequiredWhen = "required_when",
                Type = "type",
            },
        ];
        string expectedKey = "key";
        string expectedLabel = "label";
        int expectedMaxItems = 0;
        int expectedMinLength = 0;
        string expectedNotes = "notes";
        List<string> expectedOptions = ["string"];
        bool expectedRequired = true;
        string expectedRequiredWhen = "required_when";
        string expectedType = "type";

        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.NotNull(deserialized.ItemFields);
        Assert.Equal(expectedItemFields.Count, deserialized.ItemFields.Count);
        for (int i = 0; i < expectedItemFields.Count; i++)
        {
            Assert.Equal(expectedItemFields[i], deserialized.ItemFields[i]);
        }
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedMaxItems, deserialized.MaxItems);
        Assert.Equal(expectedMinLength, deserialized.MinLength);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.NotNull(deserialized.Options);
        Assert.Equal(expectedOptions.Count, deserialized.Options.Count);
        for (int i = 0; i < expectedOptions.Count; i++)
        {
            Assert.Equal(expectedOptions[i], deserialized.Options[i]);
        }
        Assert.Equal(expectedRequired, deserialized.Required);
        Assert.Equal(expectedRequiredWhen, deserialized.RequiredWhen);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Key = "key",
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            Required = true,
            RequiredWhen = "required_when",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            RequiredWhen = "required_when",
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            RequiredWhen = "required_when",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            RequiredWhen = "required_when",

            // Null should be interpreted as omitted for these properties
            Key = null,
            Required = null,
            Type = null,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            RequiredWhen = "required_when",

            // Null should be interpreted as omitted for these properties
            Key = null,
            Required = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceRequirement
        {
            Key = "key",
            Required = true,
            Type = "type",
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.ItemFields);
        Assert.False(model.RawData.ContainsKey("item_fields"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.MaxItems);
        Assert.False(model.RawData.ContainsKey("max_items"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("min_length"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.RequiredWhen);
        Assert.False(model.RawData.ContainsKey("required_when"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceRequirement
        {
            Key = "key",
            Required = true,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComplianceRequirement
        {
            Key = "key",
            Required = true,
            Type = "type",

            Format = null,
            ItemFields = null,
            Label = null,
            MaxItems = null,
            MinLength = null,
            Notes = null,
            Options = null,
            RequiredWhen = null,
        };

        Assert.Null(model.Format);
        Assert.True(model.RawData.ContainsKey("format"));
        Assert.Null(model.ItemFields);
        Assert.True(model.RawData.ContainsKey("item_fields"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.MaxItems);
        Assert.True(model.RawData.ContainsKey("max_items"));
        Assert.Null(model.MinLength);
        Assert.True(model.RawData.ContainsKey("min_length"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Options);
        Assert.True(model.RawData.ContainsKey("options"));
        Assert.Null(model.RequiredWhen);
        Assert.True(model.RawData.ContainsKey("required_when"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceRequirement
        {
            Key = "key",
            Required = true,
            Type = "type",

            Format = null,
            ItemFields = null,
            Label = null,
            MaxItems = null,
            MinLength = null,
            Notes = null,
            Options = null,
            RequiredWhen = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceRequirement
        {
            Format = "format",
            ItemFields =
            [
                new()
                {
                    Format = "format",
                    ItemFields = [],
                    Key = "key",
                    Label = "label",
                    MaxItems = 0,
                    MinLength = 0,
                    Notes = "notes",
                    Options = ["string"],
                    Required = true,
                    RequiredWhen = "required_when",
                    Type = "type",
                },
            ],
            Key = "key",
            Label = "label",
            MaxItems = 0,
            MinLength = 0,
            Notes = "notes",
            Options = ["string"],
            Required = true,
            RequiredWhen = "required_when",
            Type = "type",
        };

        ComplianceRequirement copied = new(model);

        Assert.Equal(model, copied);
    }
}
