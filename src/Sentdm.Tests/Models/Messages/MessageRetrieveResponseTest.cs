using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Messages;

namespace Sentdm.Tests.Models.Messages;

public class MessageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CorrectedPrice = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "templateName",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCorrectedPrice = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Event> expectedEvents =
        [
            new()
            {
                Description = "description",
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        MessageBody expectedMessageBody = new()
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };
        string expectedPhoneNumber = "phoneNumber";
        string expectedPhoneNumberInternational = "phoneNumberInternational";
        string expectedRegionCode = "regionCode";
        string expectedStatus = "status";
        string expectedTemplateCategory = "templateCategory";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "templateName";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedCorrectedPrice, model.CorrectedPrice);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.NotNull(model.Events);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedMessageBody, model.MessageBody);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPhoneNumberInternational, model.PhoneNumberInternational);
        Assert.Equal(expectedRegionCode, model.RegionCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateCategory, model.TemplateCategory);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedTemplateName, model.TemplateName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CorrectedPrice = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "templateName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CorrectedPrice = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "templateName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedChannel = "channel";
        string expectedContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedCorrectedPrice = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Event> expectedEvents =
        [
            new()
            {
                Description = "description",
                Status = "status",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        MessageBody expectedMessageBody = new()
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };
        string expectedPhoneNumber = "phoneNumber";
        string expectedPhoneNumberInternational = "phoneNumberInternational";
        string expectedRegionCode = "regionCode";
        string expectedStatus = "status";
        string expectedTemplateCategory = "templateCategory";
        string expectedTemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedTemplateName = "templateName";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedCorrectedPrice, deserialized.CorrectedPrice);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.NotNull(deserialized.Events);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedMessageBody, deserialized.MessageBody);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPhoneNumberInternational, deserialized.PhoneNumberInternational);
        Assert.Equal(expectedRegionCode, deserialized.RegionCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateCategory, deserialized.TemplateCategory);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CorrectedPrice = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "templateName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            CorrectedPrice = 0,
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contactId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PhoneNumberInternational);
        Assert.False(model.RawData.ContainsKey("phoneNumberInternational"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateCategory);
        Assert.False(model.RawData.ContainsKey("templateCategory"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("templateName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            CorrectedPrice = 0,
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            CorrectedPrice = 0,
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            ContactID = null,
            CreatedAt = null,
            CustomerID = null,
            PhoneNumber = null,
            PhoneNumberInternational = null,
            RegionCode = null,
            Status = null,
            TemplateCategory = null,
            TemplateName = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contactId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomerID);
        Assert.False(model.RawData.ContainsKey("customerId"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PhoneNumberInternational);
        Assert.False(model.RawData.ContainsKey("phoneNumberInternational"));
        Assert.Null(model.RegionCode);
        Assert.False(model.RawData.ContainsKey("regionCode"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateCategory);
        Assert.False(model.RawData.ContainsKey("templateCategory"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("templateName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            CorrectedPrice = 0,
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            ContactID = null,
            CreatedAt = null,
            CustomerID = null,
            PhoneNumber = null,
            PhoneNumberInternational = null,
            RegionCode = null,
            Status = null,
            TemplateCategory = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateName = "templateName",
        };

        Assert.Null(model.CorrectedPrice);
        Assert.False(model.RawData.ContainsKey("correctedPrice"));
        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.MessageBody);
        Assert.False(model.RawData.ContainsKey("messageBody"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateName = "templateName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateName = "templateName",

            CorrectedPrice = null,
            Events = null,
            MessageBody = null,
            TemplateID = null,
        };

        Assert.Null(model.CorrectedPrice);
        Assert.True(model.RawData.ContainsKey("correctedPrice"));
        Assert.Null(model.Events);
        Assert.True(model.RawData.ContainsKey("events"));
        Assert.Null(model.MessageBody);
        Assert.True(model.RawData.ContainsKey("messageBody"));
        Assert.Null(model.TemplateID);
        Assert.True(model.RawData.ContainsKey("templateId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateName = "templateName",

            CorrectedPrice = null,
            Events = null,
            MessageBody = null,
            TemplateID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Channel = "channel",
            ContactID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CorrectedPrice = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Events =
            [
                new()
                {
                    Description = "description",
                    Status = "status",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MessageBody = new()
            {
                Buttons = [new() { Type = "type", Value = "value" }],
                Content = "content",
                Footer = "footer",
                Header = "header",
            },
            PhoneNumber = "phoneNumber",
            PhoneNumberInternational = "phoneNumberInternational",
            RegionCode = "regionCode",
            Status = "status",
            TemplateCategory = "templateCategory",
            TemplateID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TemplateName = "templateName",
        };

        MessageRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedDescription = "description";
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedStatus = "status";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event { Description = "description" };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Event
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Event
        {
            Description = "description",
            Status = "status",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageBodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        List<Button> expectedButtons = [new() { Type = "type", Value = "value" }];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBody>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBody>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Button> expectedButtons = [new() { Type = "type", Value = "value" }];
        string expectedContent = "content";
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeader, deserialized.Header);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Footer = "footer",
            Header = "header",
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Footer = "footer",
            Header = "header",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Footer = "footer",
            Header = "header",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Footer = "footer",
            Header = "header",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageBody { Content = "content" };

        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageBody { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
        };

        Assert.Null(model.Buttons);
        Assert.True(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageBody
        {
            Content = "content",

            Buttons = null,
            Footer = null,
            Header = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageBody
        {
            Buttons = [new() { Type = "type", Value = "value" }],
            Content = "content",
            Footer = "footer",
            Header = "header",
        };

        MessageBody copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Button { Type = "type", Value = "value" };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Button { Type = "type", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Button>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Button { Type = "type", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Button>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Button { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Button { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Button { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Button
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Button
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Button { Type = "type", Value = "value" };

        Button copied = new(model);

        Assert.Equal(model, copied);
    }
}
