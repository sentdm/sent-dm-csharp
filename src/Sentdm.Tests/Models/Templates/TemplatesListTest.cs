using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Templates;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Templates;

public class TemplatesListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplatesList
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
            Templates =
            [
                new()
                {
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AutoReplyAction = "auto_reply_action",
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
        List<Template> expectedTemplates =
        [
            new()
            {
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AutoReplyAction = "auto_reply_action",
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
        ];

        Assert.Equal(expectedPagination, model.Pagination);
        Assert.NotNull(model.Templates);
        Assert.Equal(expectedTemplates.Count, model.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], model.Templates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplatesList
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
            Templates =
            [
                new()
                {
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AutoReplyAction = "auto_reply_action",
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatesList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplatesList
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
            Templates =
            [
                new()
                {
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AutoReplyAction = "auto_reply_action",
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatesList>(
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
        List<Template> expectedTemplates =
        [
            new()
            {
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AutoReplyAction = "auto_reply_action",
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
        ];

        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.NotNull(deserialized.Templates);
        Assert.Equal(expectedTemplates.Count, deserialized.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], deserialized.Templates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplatesList
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
            Templates =
            [
                new()
                {
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AutoReplyAction = "auto_reply_action",
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplatesList { };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplatesList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplatesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Templates = null,
        };

        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplatesList
        {
            // Null should be interpreted as omitted for these properties
            Pagination = null,
            Templates = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplatesList
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
            Templates =
            [
                new()
                {
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    AutoReplyAction = "auto_reply_action",
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
            ],
        };

        TemplatesList copied = new(model);

        Assert.Equal(model, copied);
    }
}
