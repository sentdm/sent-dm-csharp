using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Rcs;

namespace Sentdm.Tests.Models.Channels.Rcs;

public class RcsAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RcsAddress
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RcsAddress
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RcsAddress
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RcsAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreet = "street";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RcsAddress
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RcsAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RcsAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RcsAddress
        {
            City = null,
            Country = null,
            PostalCode = null,
            State = null,
            Street = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.PostalCode);
        Assert.True(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RcsAddress
        {
            City = null,
            Country = null,
            PostalCode = null,
            State = null,
            Street = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RcsAddress
        {
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            Street = "street",
        };

        RcsAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}
