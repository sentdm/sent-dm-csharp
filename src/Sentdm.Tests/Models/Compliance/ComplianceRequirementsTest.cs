using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Compliance;

namespace Sentdm.Tests.Models.Compliance;

public class ComplianceRequirementsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            SenderIDPattern = "sender_id_pattern",
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        string expectedChannel = "channel";
        string expectedCountry = "country";
        bool expectedRequired = true;
        List<ComplianceRequirement> expectedRequirements =
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
        string expectedSenderIDPattern = "sender_id_pattern";
        List<ComplianceSetupStep> expectedSetup =
        [
            new()
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
            },
        ];
        string expectedType = "type";

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedRequired, model.Required);
        Assert.NotNull(model.Requirements);
        Assert.Equal(expectedRequirements.Count, model.Requirements.Count);
        for (int i = 0; i < expectedRequirements.Count; i++)
        {
            Assert.Equal(expectedRequirements[i], model.Requirements[i]);
        }
        Assert.Equal(expectedSenderIDPattern, model.SenderIDPattern);
        Assert.NotNull(model.Setup);
        Assert.Equal(expectedSetup.Count, model.Setup.Count);
        for (int i = 0; i < expectedSetup.Count; i++)
        {
            Assert.Equal(expectedSetup[i], model.Setup[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            SenderIDPattern = "sender_id_pattern",
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceRequirements>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            SenderIDPattern = "sender_id_pattern",
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceRequirements>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        string expectedCountry = "country";
        bool expectedRequired = true;
        List<ComplianceRequirement> expectedRequirements =
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
        string expectedSenderIDPattern = "sender_id_pattern";
        List<ComplianceSetupStep> expectedSetup =
        [
            new()
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
            },
        ];
        string expectedType = "type";

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedRequired, deserialized.Required);
        Assert.NotNull(deserialized.Requirements);
        Assert.Equal(expectedRequirements.Count, deserialized.Requirements.Count);
        for (int i = 0; i < expectedRequirements.Count; i++)
        {
            Assert.Equal(expectedRequirements[i], deserialized.Requirements[i]);
        }
        Assert.Equal(expectedSenderIDPattern, deserialized.SenderIDPattern);
        Assert.NotNull(deserialized.Setup);
        Assert.Equal(expectedSetup.Count, deserialized.Setup.Count);
        for (int i = 0; i < expectedSetup.Count; i++)
        {
            Assert.Equal(expectedSetup[i], deserialized.Setup[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            SenderIDPattern = "sender_id_pattern",
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceRequirements { SenderIDPattern = "sender_id_pattern" };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
        Assert.Null(model.Requirements);
        Assert.False(model.RawData.ContainsKey("requirements"));
        Assert.Null(model.Setup);
        Assert.False(model.RawData.ContainsKey("setup"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceRequirements { SenderIDPattern = "sender_id_pattern" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComplianceRequirements
        {
            SenderIDPattern = "sender_id_pattern",

            // Null should be interpreted as omitted for these properties
            Channel = null,
            Country = null,
            Required = null,
            Requirements = null,
            Setup = null,
            Type = null,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
        Assert.Null(model.Requirements);
        Assert.False(model.RawData.ContainsKey("requirements"));
        Assert.Null(model.Setup);
        Assert.False(model.RawData.ContainsKey("setup"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceRequirements
        {
            SenderIDPattern = "sender_id_pattern",

            // Null should be interpreted as omitted for these properties
            Channel = null,
            Country = null,
            Required = null,
            Requirements = null,
            Setup = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        Assert.Null(model.SenderIDPattern);
        Assert.False(model.RawData.ContainsKey("sender_id_pattern"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",

            SenderIDPattern = null,
        };

        Assert.Null(model.SenderIDPattern);
        Assert.True(model.RawData.ContainsKey("sender_id_pattern"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",

            SenderIDPattern = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceRequirements
        {
            Channel = "channel",
            Country = "country",
            Required = true,
            Requirements =
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
            SenderIDPattern = "sender_id_pattern",
            Setup =
            [
                new()
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
                },
            ],
            Type = "type",
        };

        ComplianceRequirements copied = new(model);

        Assert.Equal(model, copied);
    }
}
