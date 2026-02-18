using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactDeleteParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            Body = new() { TestMode = false },
        };

        string expectedID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        Body expectedBody = new() { TestMode = false };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        ContactDeleteParams parameters = new()
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            Body = new() { TestMode = false },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.sent.dm/v3/contacts/6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactDeleteParams
        {
            ID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
            Body = new() { TestMode = false },
        };

        ContactDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body { TestMode = false };

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, model.TestMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body { TestMode = false };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body { TestMode = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedTestMode = false;

        Assert.Equal(expectedTestMode, deserialized.TestMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body { TestMode = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        Assert.Null(model.TestMode);
        Assert.False(model.RawData.ContainsKey("test_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            TestMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body { TestMode = false };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}
