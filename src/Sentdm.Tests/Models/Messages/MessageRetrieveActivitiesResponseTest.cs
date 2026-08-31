using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageRetrieveActivitiesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };
        Error expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Meta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveActivitiesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveActivitiesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };
        Error expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Meta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        Assert.Null(model.Meta);
        Assert.False(model.RawData.ContainsKey("meta"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },

            // Null should be interpreted as omitted for these properties
            Meta = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,

            Data = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageRetrieveActivitiesResponse
        {
            Data = new()
            {
                Activities =
                [
                    new()
                    {
                        ActiveContactPrice = "active_contact_price",
                        Description = "description",
                        From = "from",
                        Price = "price",
                        Status = "status",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Pagination = new()
                {
                    Cursors = new() { After = "after", Before = "before" },
                    HasMore = true,
                    Page = 0,
                    PageSize = 0,
                    TotalCount = 0,
                    TotalPages = 0,
                },
            },
            Error = new()
            {
                Code = "code",
                Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
                DocUrl = "doc_url",
                Message = "message",
            },
            Meta = new()
            {
                RequestID = "request_id",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        MessageRetrieveActivitiesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<Activity> expectedActivities =
        [
            new()
            {
                ActiveContactPrice = "active_contact_price",
                Description = "description",
                From = "from",
                Price = "price",
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Activities);
        Assert.Equal(expectedActivities.Count, model.Activities.Count);
        for (int i = 0; i < expectedActivities.Count; i++)
        {
            Assert.Equal(expectedActivities[i], model.Activities[i]);
        }
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Activity> expectedActivities =
        [
            new()
            {
                ActiveContactPrice = "active_contact_price",
                Description = "description",
                From = "from",
                Price = "price",
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pagination expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Activities);
        Assert.Equal(expectedActivities.Count, deserialized.Activities.Count);
        for (int i = 0; i < expectedActivities.Count; i++)
        {
            Assert.Equal(expectedActivities[i], deserialized.Activities[i]);
        }
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.Activities);
        Assert.False(model.RawData.ContainsKey("activities"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Activities = null,
            MessageID = null,
            Pagination = null,
        };

        Assert.Null(model.Activities);
        Assert.False(model.RawData.ContainsKey("activities"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Activities = null,
            MessageID = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedActiveContactPrice = "active_contact_price";
        string expectedDescription = "description";
        string expectedFrom = "from";
        string expectedPrice = "price";
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActiveContactPrice, model.ActiveContactPrice);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Activity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Activity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActiveContactPrice = "active_contact_price";
        string expectedDescription = "description";
        string expectedFrom = "from";
        string expectedPrice = "price";
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActiveContactPrice, deserialized.ActiveContactPrice);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            From = "from",
            Price = "price",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Activity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.False(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Activity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Activity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveContactPrice = null,
            From = null,
            Price = null,
        };

        Assert.Null(model.ActiveContactPrice);
        Assert.True(model.RawData.ContainsKey("active_contact_price"));
        Assert.Null(model.From);
        Assert.True(model.RawData.ContainsKey("from"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Activity
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveContactPrice = null,
            From = null,
            Price = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Activity
        {
            ActiveContactPrice = "active_contact_price",
            Description = "description",
            From = "from",
            Price = "price",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Activity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, model.Cursors);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        bool expectedHasMore = true;
        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        int expectedTotalPages = 0;

        Assert.Equal(expectedCursors, deserialized.Cursors);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("page_size"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("total_count"));
        Assert.Null(model.TotalPages);
        Assert.False(model.RawData.ContainsKey("total_pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Page = null,
            PageSize = null,
            TotalCount = null,
            TotalPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.Null(model.Cursors);
        Assert.False(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        Assert.Null(model.Cursors);
        Assert.True(model.RawData.ContainsKey("cursors"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pagination
        {
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,

            Cursors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CursorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cursors>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cursors>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cursors { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cursors { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Cursors { After = null, Before = null };

        Assert.Null(model.After);
        Assert.True(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.True(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Cursors { After = null, Before = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        Cursors copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, model.DocUrl);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        Dictionary<string, List<string>> expectedDetails = new() { { "foo", ["string"] } };
        string expectedDocUrl = "doc_url";
        string expectedMessage = "message";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.Details[item.Key][i]);
            }
        }
        Assert.Equal(expectedDocUrl, deserialized.DocUrl);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",

            // Null should be interpreted as omitted for these properties
            Code = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Error
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.True(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            Code = "code",
            Message = "message",

            Details = null,
            DocUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedRequestID = "request_id";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVersion = "version";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Meta { };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Meta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("request_id"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Meta
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
            Timestamp = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        Meta copied = new(model);

        Assert.Equal(model, copied);
    }
}
