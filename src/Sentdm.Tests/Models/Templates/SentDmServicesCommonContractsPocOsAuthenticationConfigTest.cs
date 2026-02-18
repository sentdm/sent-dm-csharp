using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class SentDmServicesCommonContractsPocOsAuthenticationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        bool expectedAddSecurityRecommendation = true;
        int expectedCodeExpirationMinutes = 0;

        Assert.Equal(expectedAddSecurityRecommendation, model.AddSecurityRecommendation);
        Assert.Equal(expectedCodeExpirationMinutes, model.CodeExpirationMinutes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsAuthenticationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesCommonContractsPocOsAuthenticationConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedAddSecurityRecommendation = true;
        int expectedCodeExpirationMinutes = 0;

        Assert.Equal(expectedAddSecurityRecommendation, deserialized.AddSecurityRecommendation);
        Assert.Equal(expectedCodeExpirationMinutes, deserialized.CodeExpirationMinutes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            CodeExpirationMinutes = 0,
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            CodeExpirationMinutes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            CodeExpirationMinutes = 0,

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            CodeExpirationMinutes = 0,

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
        };

        Assert.Null(model.CodeExpirationMinutes);
        Assert.False(model.RawData.ContainsKey("codeExpirationMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,

            CodeExpirationMinutes = null,
        };

        Assert.Null(model.CodeExpirationMinutes);
        Assert.True(model.RawData.ContainsKey("codeExpirationMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,

            CodeExpirationMinutes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentDmServicesCommonContractsPocOsAuthenticationConfig
        {
            AddSecurityRecommendation = true,
            CodeExpirationMinutes = 0,
        };

        SentDmServicesCommonContractsPocOsAuthenticationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
