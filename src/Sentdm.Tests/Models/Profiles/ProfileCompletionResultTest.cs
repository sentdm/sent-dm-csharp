using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class ProfileCompletionResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileCompletionResult { Message = "message", Status = "status" };

        string expectedMessage = "message";
        string expectedStatus = "status";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileCompletionResult { Message = "message", Status = "status" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileCompletionResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileCompletionResult { Message = "message", Status = "status" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileCompletionResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        string expectedStatus = "status";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileCompletionResult { Message = "message", Status = "status" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfileCompletionResult { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfileCompletionResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProfileCompletionResult
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfileCompletionResult
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileCompletionResult { Message = "message", Status = "status" };

        ProfileCompletionResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
