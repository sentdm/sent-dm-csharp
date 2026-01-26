using System;
using SentDm;

namespace SentDm.Tests;

public class TestBase
{
    protected ISentDmClient client;

    public TestBase()
    {
        client = new SentDmClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            AdminAuthScheme = "My Admin Auth Scheme",
            CustomerAuthScheme = "My Customer Auth Scheme",
        };
    }
}
