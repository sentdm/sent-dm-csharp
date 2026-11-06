using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhookSecretTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookSecret { SigningSecret = "signing_secret" };

        string expectedSigningSecret = "signing_secret";

        Assert.Equal(expectedSigningSecret, model.SigningSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookSecret { SigningSecret = "signing_secret" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecret>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookSecret { SigningSecret = "signing_secret" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecret>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSigningSecret = "signing_secret";

        Assert.Equal(expectedSigningSecret, deserialized.SigningSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookSecret { SigningSecret = "signing_secret" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookSecret { };

        Assert.Null(model.SigningSecret);
        Assert.False(model.RawData.ContainsKey("signing_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookSecret { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookSecret
        {
            // Null should be interpreted as omitted for these properties
            SigningSecret = null,
        };

        Assert.Null(model.SigningSecret);
        Assert.False(model.RawData.ContainsKey("signing_secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookSecret
        {
            // Null should be interpreted as omitted for these properties
            SigningSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookSecret { SigningSecret = "signing_secret" };

        WebhookSecret copied = new(model);

        Assert.Equal(model, copied);
    }
}
