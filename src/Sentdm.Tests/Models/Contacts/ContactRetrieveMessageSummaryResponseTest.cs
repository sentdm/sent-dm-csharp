using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Contacts;

namespace Sentdm.Tests.Models.Contacts;

public class ContactRetrieveMessageSummaryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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

        ContactRetrieveMessageSummaryResponseData expectedData = new()
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
        ContactRetrieveMessageSummaryResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ContactRetrieveMessageSummaryResponseMeta expectedMeta = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContactRetrieveMessageSummaryResponseData expectedData = new()
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
        ContactRetrieveMessageSummaryResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ContactRetrieveMessageSummaryResponseMeta expectedMeta = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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
        var model = new ContactRetrieveMessageSummaryResponse
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
        var model = new ContactRetrieveMessageSummaryResponse
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
        var model = new ContactRetrieveMessageSummaryResponse
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
        var model = new ContactRetrieveMessageSummaryResponse
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
        var model = new ContactRetrieveMessageSummaryResponse
        {
            Data = new()
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

        ContactRetrieveMessageSummaryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactRetrieveMessageSummaryResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseData>(
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
        {
            FirstMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastMessageAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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
        var model = new ContactRetrieveMessageSummaryResponseData
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

        ContactRetrieveMessageSummaryResponseData copied = new(model);

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

public class ContactRetrieveMessageSummaryResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseError>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Code = "code",
            Message = "message",
        };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Code = "code",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
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
        var model = new ContactRetrieveMessageSummaryResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        ContactRetrieveMessageSummaryResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactRetrieveMessageSummaryResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseMeta
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
        var model = new ContactRetrieveMessageSummaryResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactRetrieveMessageSummaryResponseMeta>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new ContactRetrieveMessageSummaryResponseMeta
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
        var model = new ContactRetrieveMessageSummaryResponseMeta { };

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
        var model = new ContactRetrieveMessageSummaryResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactRetrieveMessageSummaryResponseMeta
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
        var model = new ContactRetrieveMessageSummaryResponseMeta
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
        var model = new ContactRetrieveMessageSummaryResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        ContactRetrieveMessageSummaryResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
