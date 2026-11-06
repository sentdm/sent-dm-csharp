using System;
using System.Net.Http;
using Sentdm.Models.Compliance;

namespace Sentdm.Tests.Models.Compliance;

public class ComplianceRetrieveRequirementsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedChannel = "channel";
        string expectedCountry = "country";
        string expectedType = "type";
        string expectedXProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXProfileID, parameters.XProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            XProfileID = null,
        };

        Assert.Null(parameters.XProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-profile-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawQueryData.ContainsKey("country"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Channel = null,
            Country = null,
            Type = null,
        };

        Assert.Null(parameters.Channel);
        Assert.True(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Country);
        Assert.True(parameters.RawQueryData.ContainsKey("country"));
        Assert.Null(parameters.Type);
        Assert.True(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        ComplianceRetrieveRequirementsParams parameters = new()
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.sent.dm/v3/compliance/requirements?channel=channel&country=country&type=type"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ComplianceRetrieveRequirementsParams parameters = new()
        {
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
        var parameters = new ComplianceRetrieveRequirementsParams
        {
            Channel = "channel",
            Country = "country",
            Type = "type",
            XProfileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ComplianceRetrieveRequirementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
