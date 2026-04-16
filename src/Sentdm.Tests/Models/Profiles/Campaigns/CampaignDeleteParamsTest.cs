using System;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Profiles.Campaigns;

namespace Sentdm.Tests.Models.Profiles.Campaigns;

public class CampaignDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProfileID = "770e8400-e29b-41d4-a716-446655440002";
        string expectedCampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901";
        Body expectedBody = new() { Sandbox = false };
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProfileID, parameters.ProfileID);
        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignDeleteParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/profiles/770e8400-e29b-41d4-a716-446655440002/campaigns/b2c3d4e5-f6a7-8901-bcde-f12345678901"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CampaignDeleteParams parameters = new()
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            requestMessage.Headers.GetValues("x-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignDeleteParams
        {
            ProfileID = "770e8400-e29b-41d4-a716-446655440002",
            CampaignID = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
            Body = new() { Sandbox = false },
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CampaignDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body { Sandbox = false };

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, model.Sandbox);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body { Sandbox = false };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body { Sandbox = false };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedSandbox = false;

        Assert.Equal(expectedSandbox, deserialized.Sandbox);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body { Sandbox = false };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            // Null should be interpreted as omitted for these properties
            Sandbox = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body { Sandbox = false };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}
