using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceNumberCreatedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        string expectedCallbackUrl = "callback_url";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedDefaultForAppCalls = true;
        string expectedNumber = "number";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDefaultForAppCalls, model.DefaultForAppCalls);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedCallbackSecret, model.CallbackSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceNumberCreated>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceNumberCreated>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallbackUrl = "callback_url";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedDefaultForAppCalls = true;
        string expectedNumber = "number";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDefaultForAppCalls, deserialized.DefaultForAppCalls);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedCallbackSecret, deserialized.CallbackSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceNumberCreated { CallbackUrl = "callback_url" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DefaultForAppCalls);
        Assert.False(model.RawData.ContainsKey("default_for_app_calls"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceNumberCreated { CallbackUrl = "callback_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DefaultForAppCalls = null,
            Number = null,
            Status = null,
            UpdatedAt = null,
            CallbackSecret = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DefaultForAppCalls);
        Assert.False(model.RawData.ContainsKey("default_for_app_calls"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DefaultForAppCalls = null,
            Number = null,
            Status = null,
            UpdatedAt = null,
            CallbackSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceNumberCreated
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceNumberCreated
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VoiceNumberCreated
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",

            CallbackUrl = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.True(model.RawData.ContainsKey("callback_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceNumberCreated
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",

            CallbackUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceNumberCreated
        {
            CallbackUrl = "callback_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultForAppCalls = true,
            Number = "number",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CallbackSecret = "callback_secret",
        };

        VoiceNumberCreated copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponsePropertiesTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                CallbackSecret = "callback_secret",
            };

        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackSecret, model.CallbackSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                CallbackSecret = "callback_secret",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                CallbackSecret = "callback_secret",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCallbackSecret = "callback_secret";

        Assert.Equal(expectedCallbackSecret, deserialized.CallbackSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                CallbackSecret = "callback_secret",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            { };

        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                // Null should be interpreted as omitted for these properties
                CallbackSecret = null,
            };

        Assert.Null(model.CallbackSecret);
        Assert.False(model.RawData.ContainsKey("callback_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                // Null should be interpreted as omitted for these properties
                CallbackSecret = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties
            {
                CallbackSecret = "callback_secret",
            };

        SentDmServicesEndpointsCustomerApIv3ChannelsResponsesVoiceNumberCreatedResponseProperties copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
