using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Channels.Sms;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Channels.Sms;

public class ApiResponseOfListOfSmsMarketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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

        List<SmsMarket> expectedData =
        [
            new()
            {
                Compliance = new()
                {
                    Brand = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaign = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaigns =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Documents =
                    [
                        new()
                        {
                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            FileName = "file_name",
                            Key = "key",
                        },
                    ],
                },
                Country = "country",
                NumberType = "number_type",
                Numbers =
                [
                    new()
                    {
                        AreaCode = "area_code",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        SenderValue = "sender_value",
                        Status = "status",
                    },
                ],
                Reason = "reason",
                ReasonCode = "reason_code",
                Status = Status.Provisioning,
            },
        ];
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedMeta, model.Meta);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfListOfSmsMarket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var deserialized = JsonSerializer.Deserialize<ApiResponseOfListOfSmsMarket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SmsMarket> expectedData =
        [
            new()
            {
                Compliance = new()
                {
                    Brand = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaign = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Campaigns =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Documents =
                    [
                        new()
                        {
                            DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            FileName = "file_name",
                            Key = "key",
                        },
                    ],
                },
                Country = "country",
                NumberType = "number_type",
                Numbers =
                [
                    new()
                    {
                        AreaCode = "area_code",
                        CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        SenderValue = "sender_value",
                        Status = "status",
                    },
                ],
                Reason = "reason",
                ReasonCode = "reason_code",
                Status = Status.Provisioning,
            },
        ];
        ErrorDetail expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };
        bool expectedSuccess = true;

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedMeta, deserialized.Meta);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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
        var model = new ApiResponseOfListOfSmsMarket
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
        var model = new ApiResponseOfListOfSmsMarket
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
        var model = new ApiResponseOfListOfSmsMarket
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
        var model = new ApiResponseOfListOfSmsMarket
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
        var model = new ApiResponseOfListOfSmsMarket
        {
            Data =
            [
                new()
                {
                    Compliance = new()
                    {
                        Brand = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaign = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Campaigns =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Documents =
                        [
                            new()
                            {
                                DocumentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                                FileName = "file_name",
                                Key = "key",
                            },
                        ],
                    },
                    Country = "country",
                    NumberType = "number_type",
                    Numbers =
                    [
                        new()
                        {
                            AreaCode = "area_code",
                            CampaignID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                            SenderValue = "sender_value",
                            Status = "status",
                        },
                    ],
                    Reason = "reason",
                    ReasonCode = "reason_code",
                    Status = Status.Provisioning,
                },
            ],
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

        ApiResponseOfListOfSmsMarket copied = new(model);

        Assert.Equal(model, copied);
    }
}
