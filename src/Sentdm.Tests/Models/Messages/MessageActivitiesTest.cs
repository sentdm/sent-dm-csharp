using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Messages;

public class MessageActivitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageActivities
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        List<MessageActivity> expectedActivities =
        [
            new()
            {
                ActiveContactPrice = "active_contact_price",
                Description = "description",
                From = "from",
                Price = "price",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PaginationMeta expectedPagination = new()
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
        var model = new MessageActivities
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<MessageActivities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageActivities
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var deserialized = JsonSerializer.Deserialize<MessageActivities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MessageActivity> expectedActivities =
        [
            new()
            {
                ActiveContactPrice = "active_contact_price",
                Description = "description",
                From = "from",
                Price = "price",
                Reason = "reason",
                ReasonCode = "reason_code",
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedMessageID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PaginationMeta expectedPagination = new()
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
        var model = new MessageActivities
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new MessageActivities { };

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
        var model = new MessageActivities { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageActivities
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
        var model = new MessageActivities
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
        var model = new MessageActivities
        {
            Activities =
            [
                new()
                {
                    ActiveContactPrice = "active_contact_price",
                    Description = "description",
                    From = "from",
                    Price = "price",
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        MessageActivities copied = new(model);

        Assert.Equal(model, copied);
    }
}
