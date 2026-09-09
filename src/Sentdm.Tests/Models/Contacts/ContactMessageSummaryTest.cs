using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactMessageSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
        };

        List<ChannelScore> expectedChannelScores =
        [
            new()
            {
                Channel = "channel",
                FailScore = 0,
                SuccessScore = 0,
            },
        ];
        List<string> expectedChannelsUsed = ["string"];
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedFirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMessageCount = 0;

        Assert.NotNull(model.ChannelScores);
        Assert.Equal(expectedChannelScores.Count, model.ChannelScores.Count);
        for (int i = 0; i < expectedChannelScores.Count; i++)
        {
            Assert.Equal(expectedChannelScores[i], model.ChannelScores[i]);
        }
        Assert.NotNull(model.ChannelsUsed);
        Assert.Equal(expectedChannelsUsed.Count, model.ChannelsUsed.Count);
        for (int i = 0; i < expectedChannelsUsed.Count; i++)
        {
            Assert.Equal(expectedChannelsUsed[i], model.ChannelsUsed[i]);
        }
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedFirstMessageAt, model.FirstMessageAt);
        Assert.Equal(expectedLastMessageAt, model.LastMessageAt);
        Assert.Equal(expectedMessageCount, model.MessageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactMessageSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactMessageSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ChannelScore> expectedChannelScores =
        [
            new()
            {
                Channel = "channel",
                FailScore = 0,
                SuccessScore = 0,
            },
        ];
        List<string> expectedChannelsUsed = ["string"];
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedFirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedMessageCount = 0;

        Assert.NotNull(deserialized.ChannelScores);
        Assert.Equal(expectedChannelScores.Count, deserialized.ChannelScores.Count);
        for (int i = 0; i < expectedChannelScores.Count; i++)
        {
            Assert.Equal(expectedChannelScores[i], deserialized.ChannelScores[i]);
        }
        Assert.NotNull(deserialized.ChannelsUsed);
        Assert.Equal(expectedChannelsUsed.Count, deserialized.ChannelsUsed.Count);
        for (int i = 0; i < expectedChannelsUsed.Count; i++)
        {
            Assert.Equal(expectedChannelsUsed[i], deserialized.ChannelsUsed[i]);
        }
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedFirstMessageAt, deserialized.FirstMessageAt);
        Assert.Equal(expectedLastMessageAt, deserialized.LastMessageAt);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactMessageSummary
        {
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ChannelScores);
        Assert.False(model.RawData.ContainsKey("channel_scores"));
        Assert.Null(model.ChannelsUsed);
        Assert.False(model.RawData.ContainsKey("channels_used"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.MessageCount);
        Assert.False(model.RawData.ContainsKey("message_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactMessageSummary
        {
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactMessageSummary
        {
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ChannelScores = null,
            ChannelsUsed = null,
            ContactID = null,
            MessageCount = null,
        };

        Assert.Null(model.ChannelScores);
        Assert.False(model.RawData.ContainsKey("channel_scores"));
        Assert.Null(model.ChannelsUsed);
        Assert.False(model.RawData.ContainsKey("channels_used"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contact_id"));
        Assert.Null(model.MessageCount);
        Assert.False(model.RawData.ContainsKey("message_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactMessageSummary
        {
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ChannelScores = null,
            ChannelsUsed = null,
            ContactID = null,
            MessageCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageCount = 0,
        };

        Assert.Null(model.FirstMessageAt);
        Assert.False(model.RawData.ContainsKey("first_message_at"));
        Assert.Null(model.LastMessageAt);
        Assert.False(model.RawData.ContainsKey("last_message_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageCount = 0,

            FirstMessageAt = null,
            LastMessageAt = null,
        };

        Assert.Null(model.FirstMessageAt);
        Assert.True(model.RawData.ContainsKey("first_message_at"));
        Assert.Null(model.LastMessageAt);
        Assert.True(model.RawData.ContainsKey("last_message_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MessageCount = 0,

            FirstMessageAt = null,
            LastMessageAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactMessageSummary
        {
            ChannelScores =
            [
                new()
                {
                    Channel = "channel",
                    FailScore = 0,
                    SuccessScore = 0,
                },
            ],
            ChannelsUsed = ["string"],
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
        };

        ContactMessageSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChannelScoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string expectedChannel = "channel";
        int expectedFailScore = 0;
        int expectedSuccessScore = 0;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedFailScore, model.FailScore);
        Assert.Equal(expectedSuccessScore, model.SuccessScore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelScore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelScore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        int expectedFailScore = 0;
        int expectedSuccessScore = 0;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedFailScore, deserialized.FailScore);
        Assert.Equal(expectedSuccessScore, deserialized.SuccessScore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelScore { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.FailScore);
        Assert.False(model.RawData.ContainsKey("fail_score"));
        Assert.Null(model.SuccessScore);
        Assert.False(model.RawData.ContainsKey("success_score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelScore { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChannelScore
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            FailScore = null,
            SuccessScore = null,
        };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.FailScore);
        Assert.False(model.RawData.ContainsKey("fail_score"));
        Assert.Null(model.SuccessScore);
        Assert.False(model.RawData.ContainsKey("success_score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelScore
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            FailScore = null,
            SuccessScore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelScore
        {
            Channel = "channel",
            FailScore = 0,
            SuccessScore = 0,
        };

        ChannelScore copied = new(model);

        Assert.Equal(model, copied);
    }
}
