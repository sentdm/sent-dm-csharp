using System;
using Sentdm;

namespace Sentdm.Tests;

public class TestBase
{
    protected ISentClient client;

    public TestBase()
    {
        client = new SentClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
