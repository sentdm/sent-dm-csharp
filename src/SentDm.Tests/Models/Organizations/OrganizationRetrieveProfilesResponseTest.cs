using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Organizations;

namespace SentDm.Tests.Models.Organizations;

public class OrganizationRetrieveProfilesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    ShortName = "shortName",
                },
            ],
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ProfileSummary> expectedProfiles =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
                Name = "name",
                ShortName = "shortName",
            },
        ];

        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.NotNull(model.Profiles);
        Assert.Equal(expectedProfiles.Count, model.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], model.Profiles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    ShortName = "shortName",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationRetrieveProfilesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    ShortName = "shortName",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationRetrieveProfilesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ProfileSummary> expectedProfiles =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Icon = "icon",
                Name = "name",
                ShortName = "shortName",
            },
        ];

        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.NotNull(deserialized.Profiles);
        Assert.Equal(expectedProfiles.Count, deserialized.Profiles.Count);
        for (int i = 0; i < expectedProfiles.Count; i++)
        {
            Assert.Equal(expectedProfiles[i], deserialized.Profiles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    ShortName = "shortName",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse { };

        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            // Null should be interpreted as omitted for these properties
            OrganizationID = null,
            Profiles = null,
        };

        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.Profiles);
        Assert.False(model.RawData.ContainsKey("profiles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            // Null should be interpreted as omitted for these properties
            OrganizationID = null,
            Profiles = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrganizationRetrieveProfilesResponse
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Profiles =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Icon = "icon",
                    Name = "name",
                    ShortName = "shortName",
                },
            ],
        };

        OrganizationRetrieveProfilesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
