using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Voice;

namespace Sentdm.Tests.Models.Channels.Voice;

public class VoiceTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceToken
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identity = "identity",
            Number = "number",
        };

        string expectedToken = "token";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdentity = "identity";
        string expectedNumber = "number";

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedIdentity, model.Identity);
        Assert.Equal(expectedNumber, model.Number);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceToken
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identity = "identity",
            Number = "number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceToken
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identity = "identity",
            Number = "number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdentity = "identity";
        string expectedNumber = "number";

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedIdentity, deserialized.Identity);
        Assert.Equal(expectedNumber, deserialized.Number);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceToken
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identity = "identity",
            Number = "number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceToken { };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Identity);
        Assert.False(model.RawData.ContainsKey("identity"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceToken { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceToken
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            ExpiresAt = null,
            Identity = null,
            Number = null,
        };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Identity);
        Assert.False(model.RawData.ContainsKey("identity"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceToken
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            ExpiresAt = null,
            Identity = null,
            Number = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceToken
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identity = "identity",
            Number = "number",
        };

        VoiceToken copied = new(model);

        Assert.Equal(model, copied);
    }
}
