# Sent Dm C# API Library

The Sent Dm C# SDK provides convenient access to the Sent Dm REST API from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

## Installation

```bash
git clone git@github.com:stainless-sdks/sent-dm-csharp.git
dotnet add reference sent-dm-csharp/src/SentDm
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System.Collections.Generic;
using SentDm;
using SentDm.Models.Messages;

SentDmClient client = new();

MessageSendToPhoneParams parameters = new()
{
    PhoneNumber = "+1234567890",
    TemplateID = "7ba7b820-9dad-11d1-80b4-00c04fd430c8",
    TemplateVariables = new Dictionary<string, string>()
    {
        { "name", "John Doe" }, { "order_id", "12345" }
    },
};

await client.Messages.SendToPhone(parameters);
```

## Client configuration

Configure the client using environment variables:

```csharp
using SentDm;

// Configured using the SENT_DM_API_KEY, SENT_DM_SENDER_ID and SENT_DM_BASE_URL environment variables
SentDmClient client = new();
```

Or manually:

```csharp
using SentDm;

SentDmClient client = new()
{
    ApiKey = "My API Key",
    SenderID = "My Sender ID",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property   | Environment variable | Required | Default value           |
| ---------- | -------------------- | -------- | ----------------------- |
| `ApiKey`   | `SENT_DM_API_KEY`    | true     | -                       |
| `SenderID` | `SENT_DM_SENDER_ID`  | true     | -                       |
| `BaseUrl`  | `SENT_DM_BASE_URL`   | true     | `"https://api.sent.dm"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Messages.SendToPhone(parameters);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Sent Dm API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Templates.Create` should be called with an instance of `TemplateCreateParams`, and it will return an instance of `Task<TemplateResponse>`.

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Messages.SendToPhone(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using SentDm.Models.Templates;

var response = await client.WithRawResponse.Templates.Create(parameters);
TemplateResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `SentDmApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                             |
| ------ | ------------------------------------- |
| 400    | `SentDmBadRequestException`           |
| 401    | `SentDmUnauthorizedException`         |
| 403    | `SentDmForbiddenException`            |
| 404    | `SentDmNotFoundException`             |
| 422    | `SentDmUnprocessableEntityException`  |
| 429    | `SentDmRateLimitException`            |
| 5xx    | `SentDm5xxException`                  |
| others | `SentDmUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `SentDm4xxException`.

false

- `SentDmIOException`: I/O networking errors.

- `SentDmInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `SentDmException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using SentDm;

SentDmClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Messages.SendToPhone(parameters);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using SentDm;

SentDmClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Messages.SendToPhone(parameters);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `SentDmInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var templateResponse = client.Templates.Create(parameters);
templateResponse.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using SentDm;

SentDmClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var templateResponse = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Templates.Create(parameters);

Console.WriteLine(templateResponse);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/sent-dm-csharp/issues) with questions, bugs, or suggestions.
