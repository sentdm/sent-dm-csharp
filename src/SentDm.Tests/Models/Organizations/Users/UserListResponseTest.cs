using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Organizations.Users;

namespace SentDm.Tests.Models.Organizations.Users;

public class UserListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserListResponse
        {
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            Users =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "email",
                    InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvitationToken = "invitationToken",
                    InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Role = "role",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        List<CustomerUser> expectedUsers =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Email = "email",
                InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvitationToken = "invitationToken",
                InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                Role = "role",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPageSize, model.PageSize);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.NotNull(model.Users);
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], model.Users[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserListResponse
        {
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            Users =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "email",
                    InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvitationToken = "invitationToken",
                    InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Role = "role",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserListResponse
        {
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            Users =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "email",
                    InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvitationToken = "invitationToken",
                    InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Role = "role",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedPage = 0;
        int expectedPageSize = 0;
        int expectedTotalCount = 0;
        List<CustomerUser> expectedUsers =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Email = "email",
                InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvitationToken = "invitationToken",
                InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                Role = "role",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPageSize, deserialized.PageSize);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.NotNull(deserialized.Users);
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], deserialized.Users[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserListResponse
        {
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            Users =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "email",
                    InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvitationToken = "invitationToken",
                    InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Role = "role",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserListResponse { };

        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Users);
        Assert.False(model.RawData.ContainsKey("users"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserListResponse
        {
            // Null should be interpreted as omitted for these properties
            Page = null,
            PageSize = null,
            TotalCount = null,
            Users = null,
        };

        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.PageSize);
        Assert.False(model.RawData.ContainsKey("pageSize"));
        Assert.Null(model.TotalCount);
        Assert.False(model.RawData.ContainsKey("totalCount"));
        Assert.Null(model.Users);
        Assert.False(model.RawData.ContainsKey("users"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserListResponse
        {
            // Null should be interpreted as omitted for these properties
            Page = null,
            PageSize = null,
            TotalCount = null,
            Users = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserListResponse
        {
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            Users =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "email",
                    InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvitationToken = "invitationToken",
                    InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Role = "role",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        UserListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
