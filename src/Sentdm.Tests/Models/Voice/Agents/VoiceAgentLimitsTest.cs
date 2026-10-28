using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentLimitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };

        List<string> expectedAllowedCountries = ["string"];
        int expectedMaxCallSeconds = 0;
        int expectedMaxConcurrentCalls = 0;

        Assert.NotNull(model.AllowedCountries);
        Assert.Equal(expectedAllowedCountries.Count, model.AllowedCountries.Count);
        for (int i = 0; i < expectedAllowedCountries.Count; i++)
        {
            Assert.Equal(expectedAllowedCountries[i], model.AllowedCountries[i]);
        }
        Assert.Equal(expectedMaxCallSeconds, model.MaxCallSeconds);
        Assert.Equal(expectedMaxConcurrentCalls, model.MaxConcurrentCalls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentLimits>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentLimits>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedCountries = ["string"];
        int expectedMaxCallSeconds = 0;
        int expectedMaxConcurrentCalls = 0;

        Assert.NotNull(deserialized.AllowedCountries);
        Assert.Equal(expectedAllowedCountries.Count, deserialized.AllowedCountries.Count);
        for (int i = 0; i < expectedAllowedCountries.Count; i++)
        {
            Assert.Equal(expectedAllowedCountries[i], deserialized.AllowedCountries[i]);
        }
        Assert.Equal(expectedMaxCallSeconds, deserialized.MaxCallSeconds);
        Assert.Equal(expectedMaxConcurrentCalls, deserialized.MaxConcurrentCalls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentLimits { AllowedCountries = ["string"] };

        Assert.Null(model.MaxCallSeconds);
        Assert.False(model.RawData.ContainsKey("max_call_seconds"));
        Assert.Null(model.MaxConcurrentCalls);
        Assert.False(model.RawData.ContainsKey("max_concurrent_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentLimits { AllowedCountries = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],

            // Null should be interpreted as omitted for these properties
            MaxCallSeconds = null,
            MaxConcurrentCalls = null,
        };

        Assert.Null(model.MaxCallSeconds);
        Assert.False(model.RawData.ContainsKey("max_call_seconds"));
        Assert.Null(model.MaxConcurrentCalls);
        Assert.False(model.RawData.ContainsKey("max_concurrent_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],

            // Null should be interpreted as omitted for these properties
            MaxCallSeconds = null,
            MaxConcurrentCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentLimits { MaxCallSeconds = 0, MaxConcurrentCalls = 0 };

        Assert.Null(model.AllowedCountries);
        Assert.False(model.RawData.ContainsKey("allowed_countries"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentLimits { MaxCallSeconds = 0, MaxConcurrentCalls = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceAgentLimits
        {
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,

            AllowedCountries = null,
        };

        Assert.Null(model.AllowedCountries);
        Assert.True(model.RawData.ContainsKey("allowed_countries"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentLimits
        {
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,

            AllowedCountries = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentLimits
        {
            AllowedCountries = ["string"],
            MaxCallSeconds = 0,
            MaxConcurrentCalls = 0,
        };

        VoiceAgentLimits copied = new(model);

        Assert.Equal(model, copied);
    }
}
