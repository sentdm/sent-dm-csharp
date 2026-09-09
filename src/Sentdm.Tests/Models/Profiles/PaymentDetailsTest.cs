using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class PaymentDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string expectedCardNumber = "3216699102256101";
        string expectedCvc = "3216";
        string expectedExpiry = "11/66";
        string expectedZipCode = "x";

        Assert.Equal(expectedCardNumber, model.CardNumber);
        Assert.Equal(expectedCvc, model.Cvc);
        Assert.Equal(expectedExpiry, model.Expiry);
        Assert.Equal(expectedZipCode, model.ZipCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCardNumber = "3216699102256101";
        string expectedCvc = "3216";
        string expectedExpiry = "11/66";
        string expectedZipCode = "x";

        Assert.Equal(expectedCardNumber, deserialized.CardNumber);
        Assert.Equal(expectedCvc, deserialized.Cvc);
        Assert.Equal(expectedExpiry, deserialized.Expiry);
        Assert.Equal(expectedZipCode, deserialized.ZipCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentDetails
        {
            CardNumber = "3216699102256101",
            Cvc = "3216",
            Expiry = "11/66",
            ZipCode = "x",
        };

        PaymentDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
