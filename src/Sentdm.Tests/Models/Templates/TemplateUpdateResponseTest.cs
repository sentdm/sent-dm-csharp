using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;

namespace Sentdm.Tests.Models.Templates;

public class TemplateUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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

        TemplateUpdateResponseData expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };
        TemplateUpdateResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        TemplateUpdateResponseMeta expectedMeta = new()
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TemplateUpdateResponseData expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };
        TemplateUpdateResponseError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        TemplateUpdateResponseMeta expectedMeta = new()
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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
        var model = new TemplateUpdateResponse
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
        var model = new TemplateUpdateResponse
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
        var model = new TemplateUpdateResponse
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
        var model = new TemplateUpdateResponse
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
        var model = new TemplateUpdateResponse
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Category = "category",
                Channels = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsPublished = true,
                Language = "language",
                Name = "name",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
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

        TemplateUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCategory = "category";
        List<string> expectedChannels = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsPublished = true;
        string expectedLanguage = "language";
        string expectedName = "name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVariables = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsPublished, model.IsPublished);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCategory = "category";
        List<string> expectedChannels = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsPublished = true;
        string expectedLanguage = "language";
        string expectedName = "name";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVariables = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsPublished, deserialized.IsPublished);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            Channels = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("is_published"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            Channels = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            Channels = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            CreatedAt = null,
            IsPublished = null,
            Language = null,
            Name = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("is_published"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            Channels = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            CreatedAt = null,
            IsPublished = null,
            Language = null,
            Name = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",

            Channels = null,
            UpdatedAt = null,
            Variables = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",

            Channels = null,
            UpdatedAt = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateUpdateResponseData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Category = "category",
            Channels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsPublished = true,
            Language = "language",
            Name = "name",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Variables = ["string"],
        };

        TemplateUpdateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateResponseErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseError>(
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
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
        {
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError { Code = "code", Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.DocUrl);
        Assert.False(model.RawData.ContainsKey("doc_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateUpdateResponseError { Code = "code", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
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
        var model = new TemplateUpdateResponseError
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };

        TemplateUpdateResponseError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateUpdateResponseMetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateUpdateResponseMeta
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
        var model = new TemplateUpdateResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseMeta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateUpdateResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateUpdateResponseMeta>(
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
        var model = new TemplateUpdateResponseMeta
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
        var model = new TemplateUpdateResponseMeta { };

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
        var model = new TemplateUpdateResponseMeta { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateUpdateResponseMeta
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
        var model = new TemplateUpdateResponseMeta
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
        var model = new TemplateUpdateResponseMeta
        {
            RequestID = "request_id",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Version = "version",
        };

        TemplateUpdateResponseMeta copied = new(model);

        Assert.Equal(model, copied);
    }
}
