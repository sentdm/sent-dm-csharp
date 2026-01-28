using System;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Organizations.Users;

namespace Sentdm.Tests.Models.Organizations.Users;

public class CustomerUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUser
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedEmail = "email";
        DateTimeOffset expectedInvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvitationToken = "invitationToken";
        DateTimeOffset expectedInvitationTokenExpiresAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedRole = "role";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedInvitationSentAt, model.InvitationSentAt);
        Assert.Equal(expectedInvitationToken, model.InvitationToken);
        Assert.Equal(expectedInvitationTokenExpiresAt, model.InvitationTokenExpiresAt);
        Assert.Equal(expectedLastLoginAt, model.LastLoginAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerUser
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUser
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedEmail = "email";
        DateTimeOffset expectedInvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvitationToken = "invitationToken";
        DateTimeOffset expectedInvitationTokenExpiresAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedRole = "role";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedInvitationSentAt, deserialized.InvitationSentAt);
        Assert.Equal(expectedInvitationToken, deserialized.InvitationToken);
        Assert.Equal(expectedInvitationTokenExpiresAt, deserialized.InvitationTokenExpiresAt);
        Assert.Equal(expectedLastLoginAt, deserialized.LastLoginAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerUser
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUser
        {
            InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvitationToken = "invitationToken",
            InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUser
        {
            InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvitationToken = "invitationToken",
            InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerUser
        {
            InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvitationToken = "invitationToken",
            InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Email = null,
            Name = null,
            Role = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerUser
        {
            InvitationSentAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvitationToken = "invitationToken",
            InvitationTokenExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastLoginAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CustomerID = null,
            Email = null,
            Name = null,
            Role = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerUser
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "email",
            Name = "name",
            Role = "role",
            Status = "status",
        };

        Assert.Null(model.InvitationSentAt);
        Assert.False(model.RawData.ContainsKey("invitationSentAt"));
        Assert.Null(model.InvitationToken);
        Assert.False(model.RawData.ContainsKey("invitationToken"));
        Assert.Null(model.InvitationTokenExpiresAt);
        Assert.False(model.RawData.ContainsKey("invitationTokenExpiresAt"));
        Assert.Null(model.LastLoginAt);
        Assert.False(model.RawData.ContainsKey("lastLoginAt"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerUser
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "email",
            Name = "name",
            Role = "role",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerUser
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "email",
            Name = "name",
            Role = "role",
            Status = "status",

            InvitationSentAt = null,
            InvitationToken = null,
            InvitationTokenExpiresAt = null,
            LastLoginAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.InvitationSentAt);
        Assert.True(model.RawData.ContainsKey("invitationSentAt"));
        Assert.Null(model.InvitationToken);
        Assert.True(model.RawData.ContainsKey("invitationToken"));
        Assert.Null(model.InvitationTokenExpiresAt);
        Assert.True(model.RawData.ContainsKey("invitationTokenExpiresAt"));
        Assert.Null(model.LastLoginAt);
        Assert.True(model.RawData.ContainsKey("lastLoginAt"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerUser
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "email",
            Name = "name",
            Role = "role",
            Status = "status",

            InvitationSentAt = null,
            InvitationToken = null,
            InvitationTokenExpiresAt = null,
            LastLoginAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerUser
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
        };

        CustomerUser copied = new(model);

        Assert.Equal(model, copied);
    }
}
