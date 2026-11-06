using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Webhooks;

public class WebhooksListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhooksList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Webhooks =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ConsecutiveFailures = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DisplayName = "display_name",
                    EndpointUrl = "endpoint_url",
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                    IsActive = true,
                    IsInheritable = true,
                    LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryCount = 0,
                    SenderProfile = new()
                    {
                        EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                        {
                            { "foo", ["string"] },
                        },
                        EventTypes = ["string"],
                    },
                    SigningSecret = "signing_secret",
                    TimeoutSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebhookVersion = 0,
                },
            ],
        };

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<WebhookResponse> expectedWebhooks =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                IsInheritable = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SenderProfile = new()
                {
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                },
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebhookVersion = 0,
            },
        ];

        Assert.Equal(expectedPagination, model.Pagination);
        Assert.NotNull(model.Webhooks);
        Assert.Equal(expectedWebhooks.Count, model.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], model.Webhooks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhooksList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Webhooks =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ConsecutiveFailures = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DisplayName = "display_name",
                    EndpointUrl = "endpoint_url",
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                    IsActive = true,
                    IsInheritable = true,
                    LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryCount = 0,
                    SenderProfile = new()
                    {
                        EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                        {
                            { "foo", ["string"] },
                        },
                        EventTypes = ["string"],
                    },
                    SigningSecret = "signing_secret",
                    TimeoutSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebhookVersion = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhooksList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhooksList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Webhooks =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ConsecutiveFailures = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DisplayName = "display_name",
                    EndpointUrl = "endpoint_url",
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                    IsActive = true,
                    IsInheritable = true,
                    LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryCount = 0,
                    SenderProfile = new()
                    {
                        EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                        {
                            { "foo", ["string"] },
                        },
                        EventTypes = ["string"],
                    },
                    SigningSecret = "signing_secret",
                    TimeoutSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebhookVersion = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhooksList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };
        List<WebhookResponse> expectedWebhooks =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                DisplayName = "display_name",
                EndpointUrl = "endpoint_url",
                EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "foo", ["string"] },
                },
                EventTypes = ["string"],
                IsActive = true,
                IsInheritable = true,
                LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryCount = 0,
                SenderProfile = new()
                {
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                },
                SigningSecret = "signing_secret",
                TimeoutSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebhookVersion = 0,
            },
        ];

        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.NotNull(deserialized.Webhooks);
        Assert.Equal(expectedWebhooks.Count, deserialized.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], deserialized.Webhooks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhooksList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Webhooks =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ConsecutiveFailures = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DisplayName = "display_name",
                    EndpointUrl = "endpoint_url",
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                    IsActive = true,
                    IsInheritable = true,
                    LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryCount = 0,
                    SenderProfile = new()
                    {
                        EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                        {
                            { "foo", ["string"] },
                        },
                        EventTypes = ["string"],
                    },
                    SigningSecret = "signing_secret",
                    TimeoutSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebhookVersion = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhooksList { };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Webhooks);
        Assert.False(model.RawData.ContainsKey("webhooks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhooksList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhooksList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Webhooks = null,
        };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Webhooks);
        Assert.False(model.RawData.ContainsKey("webhooks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhooksList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Webhooks = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhooksList
        {
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
            Webhooks =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ConsecutiveFailures = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    DisplayName = "display_name",
                    EndpointUrl = "endpoint_url",
                    EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                    {
                        { "foo", ["string"] },
                    },
                    EventTypes = ["string"],
                    IsActive = true,
                    IsInheritable = true,
                    LastDeliveryAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastSuccessfulDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryCount = 0,
                    SenderProfile = new()
                    {
                        EventFilters = new Dictionary<string, IReadOnlyList<string>>()
                        {
                            { "foo", ["string"] },
                        },
                        EventTypes = ["string"],
                    },
                    SigningSecret = "signing_secret",
                    TimeoutSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebhookVersion = 0,
                },
            ],
        };

        WebhooksList copied = new(model);

        Assert.Equal(model, copied);
    }
}
