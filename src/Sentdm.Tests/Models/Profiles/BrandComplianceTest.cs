using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class BrandComplianceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phone_number_prefix";
        string expectedPrimaryUseCase = "primary_use_case";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.NotNull(model.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, model.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], model.DestinationCountries[i]);
        }
        Assert.Equal(expectedIsTcrApplication, model.IsTcrApplication);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, model.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, model.PrimaryUseCase);
        Assert.Equal(expectedVertical, model.Vertical);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandCompliance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandCompliance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phone_number_prefix";
        string expectedPrimaryUseCase = "primary_use_case";
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;

        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.NotNull(deserialized.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, deserialized.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], deserialized.DestinationCountries[i]);
        }
        Assert.Equal(expectedIsTcrApplication, deserialized.IsTcrApplication);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, deserialized.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, deserialized.PrimaryUseCase);
        Assert.Equal(expectedVertical, deserialized.Vertical);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destination_countries"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("is_tcr_application"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            DestinationCountries = null,
            IsTcrApplication = null,
        };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destination_countries"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("is_tcr_application"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,

            // Null should be interpreted as omitted for these properties
            DestinationCountries = null,
            IsTcrApplication = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
        };

        Assert.Null(model.BrandRelationship);
        Assert.False(model.RawData.ContainsKey("brand_relationship"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.False(model.RawData.ContainsKey("phone_number_prefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.False(model.RawData.ContainsKey("primary_use_case"));
        Assert.Null(model.Vertical);
        Assert.False(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,

            BrandRelationship = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
            Vertical = null,
        };

        Assert.Null(model.BrandRelationship);
        Assert.True(model.RawData.ContainsKey("brand_relationship"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.True(model.RawData.ContainsKey("phone_number_prefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.True(model.RawData.ContainsKey("primary_use_case"));
        Assert.Null(model.Vertical);
        Assert.True(model.RawData.ContainsKey("vertical"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandCompliance
        {
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,

            BrandRelationship = null,
            Notes = null,
            PhoneNumberPrefix = null,
            PrimaryUseCase = null,
            Vertical = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandCompliance
        {
            BrandRelationship = TcrBrandRelationship.BasicAccount,
            DestinationCountries = [new() { ID = "id", IsMain = true }],
            IsTcrApplication = true,
            Notes = "notes",
            PhoneNumberPrefix = "phone_number_prefix",
            PrimaryUseCase = "primary_use_case",
            Vertical = TcrVertical.Professional,
        };

        BrandCompliance copied = new(model);

        Assert.Equal(model, copied);
    }
}
