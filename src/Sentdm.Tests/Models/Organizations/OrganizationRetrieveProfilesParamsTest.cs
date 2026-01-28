using System;
using Sentdm.Models.Organizations;

namespace Sentdm.Tests.Models.Organizations;

public class OrganizationRetrieveProfilesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OrganizationRetrieveProfilesParams
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
        };

        string expectedOrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";

        Assert.Equal(expectedOrgID, parameters.OrgID);
    }

    [Fact]
    public void Url_Works()
    {
        OrganizationRetrieveProfilesParams parameters = new()
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", SenderID = "My Sender ID" });

        Assert.Equal(
            new Uri(
                "https://api.sent.dm/v2/organizations/6ba7b810-9dad-11d1-80b4-00c04fd430c8/profiles"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OrganizationRetrieveProfilesParams
        {
            OrgID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
        };

        OrganizationRetrieveProfilesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
