using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles;

namespace Sentdm.Tests.Models.Profiles;

public class SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfoTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPrimaryUseCase = "primaryUseCase";

        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.Equal(expectedVertical, model.Vertical);
        Assert.NotNull(model.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, model.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], model.DestinationCountries[i]);
        }
        Assert.Equal(expectedExpectedMessagingVolume, model.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, model.IsTcrApplication);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, model.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, model.PrimaryUseCase);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, TcrBrandRelationship> expectedBrandRelationship =
            TcrBrandRelationship.BasicAccount;
        ApiEnum<string, TcrVertical> expectedVertical = TcrVertical.Professional;
        List<DestinationCountry> expectedDestinationCountries =
        [
            new() { ID = "id", IsMain = true },
        ];
        string expectedExpectedMessagingVolume = "expectedMessagingVolume";
        bool expectedIsTcrApplication = true;
        string expectedNotes = "notes";
        string expectedPhoneNumberPrefix = "phoneNumberPrefix";
        string expectedPrimaryUseCase = "primaryUseCase";

        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.Equal(expectedVertical, deserialized.Vertical);
        Assert.NotNull(deserialized.DestinationCountries);
        Assert.Equal(expectedDestinationCountries.Count, deserialized.DestinationCountries.Count);
        for (int i = 0; i < expectedDestinationCountries.Count; i++)
        {
            Assert.Equal(expectedDestinationCountries[i], deserialized.DestinationCountries[i]);
        }
        Assert.Equal(expectedExpectedMessagingVolume, deserialized.ExpectedMessagingVolume);
        Assert.Equal(expectedIsTcrApplication, deserialized.IsTcrApplication);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPhoneNumberPrefix, deserialized.PhoneNumberPrefix);
        Assert.Equal(expectedPrimaryUseCase, deserialized.PrimaryUseCase);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
            };

        Assert.Null(model.DestinationCountries);
        Assert.False(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.False(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.False(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.False(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.False(model.RawData.ContainsKey("primaryUseCase"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,

                DestinationCountries = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PrimaryUseCase = null,
            };

        Assert.Null(model.DestinationCountries);
        Assert.True(model.RawData.ContainsKey("destinationCountries"));
        Assert.Null(model.ExpectedMessagingVolume);
        Assert.True(model.RawData.ContainsKey("expectedMessagingVolume"));
        Assert.Null(model.IsTcrApplication);
        Assert.True(model.RawData.ContainsKey("isTcrApplication"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PhoneNumberPrefix);
        Assert.True(model.RawData.ContainsKey("phoneNumberPrefix"));
        Assert.Null(model.PrimaryUseCase);
        Assert.True(model.RawData.ContainsKey("primaryUseCase"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,

                DestinationCountries = null,
                ExpectedMessagingVolume = null,
                IsTcrApplication = null,
                Notes = null,
                PhoneNumberPrefix = null,
                PrimaryUseCase = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo
            {
                BrandRelationship = TcrBrandRelationship.BasicAccount,
                Vertical = TcrVertical.Professional,
                DestinationCountries = [new() { ID = "id", IsMain = true }],
                ExpectedMessagingVolume = "expectedMessagingVolume",
                IsTcrApplication = true,
                Notes = "notes",
                PhoneNumberPrefix = "phoneNumberPrefix",
                PrimaryUseCase = "primaryUseCase",
            };

        SentDmServicesEndpointsCustomerApIv3ContractsRequestsBrandsBrandComplianceInfo copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}
