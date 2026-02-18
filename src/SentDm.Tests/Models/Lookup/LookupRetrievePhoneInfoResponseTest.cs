using System;
using System.Collections.Generic;
using System.Text.Json;
using SentDm.Core;
using SentDm.Models.Lookup;
using Webhooks = SentDm.Models.Webhooks;

namespace SentDm.Tests.Models.Lookup;

public class LookupRetrievePhoneInfoResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        Data expectedData = new()
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LookupRetrievePhoneInfoResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LookupRetrievePhoneInfoResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };
        Webhooks::ApiError expectedError = new()
        {
            Code = "code",
            Details = new Dictionary<string, IReadOnlyList<string>>() { { "foo", ["string"] } },
            DocUrl = "doc_url",
            Message = "message",
        };
        Webhooks::ApiMeta expectedMeta = new()
        {
            RequestID = "request_id",
            ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
                ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Meta = new()
            {
                RequestID = "request_id",
                ResponseTimeMs = 0,
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
        var model = new LookupRetrievePhoneInfoResponse
        {
            Data = new()
            {
                CarrierName = "carrierName",
                IsPorted = true,
                IsValid = true,
                IsVoip = true,
                LineType = "lineType",
                MobileCountryCode = "mobileCountryCode",
                MobileNetworkCode = "mobileNetworkCode",
                PhoneNumber = "phoneNumber",
                Provider = "provider",
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
                ResponseTimeMs = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Version = "version",
            },
            Success = true,
        };

        LookupRetrievePhoneInfoResponse copied = new(model);

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
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        string expectedCarrierName = "carrierName";
        bool expectedIsPorted = true;
        bool expectedIsValid = true;
        bool expectedIsVoip = true;
        string expectedLineType = "lineType";
        string expectedMobileCountryCode = "mobileCountryCode";
        string expectedMobileNetworkCode = "mobileNetworkCode";
        string expectedPhoneNumber = "phoneNumber";
        string expectedProvider = "provider";

        Assert.Equal(expectedCarrierName, model.CarrierName);
        Assert.Equal(expectedIsPorted, model.IsPorted);
        Assert.Equal(expectedIsValid, model.IsValid);
        Assert.Equal(expectedIsVoip, model.IsVoip);
        Assert.Equal(expectedLineType, model.LineType);
        Assert.Equal(expectedMobileCountryCode, model.MobileCountryCode);
        Assert.Equal(expectedMobileNetworkCode, model.MobileNetworkCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
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
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCarrierName = "carrierName";
        bool expectedIsPorted = true;
        bool expectedIsValid = true;
        bool expectedIsVoip = true;
        string expectedLineType = "lineType";
        string expectedMobileCountryCode = "mobileCountryCode";
        string expectedMobileNetworkCode = "mobileNetworkCode";
        string expectedPhoneNumber = "phoneNumber";
        string expectedProvider = "provider";

        Assert.Equal(expectedCarrierName, deserialized.CarrierName);
        Assert.Equal(expectedIsPorted, deserialized.IsPorted);
        Assert.Equal(expectedIsValid, deserialized.IsValid);
        Assert.Equal(expectedIsVoip, deserialized.IsVoip);
        Assert.Equal(expectedLineType, deserialized.LineType);
        Assert.Equal(expectedMobileCountryCode, deserialized.MobileCountryCode);
        Assert.Equal(expectedMobileNetworkCode, deserialized.MobileNetworkCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
        };

        Assert.Null(model.IsValid);
        Assert.False(model.RawData.ContainsKey("isValid"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",

            // Null should be interpreted as omitted for these properties
            IsValid = null,
            PhoneNumber = null,
            Provider = null,
        };

        Assert.Null(model.IsValid);
        Assert.False(model.RawData.ContainsKey("isValid"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",

            // Null should be interpreted as omitted for these properties
            IsValid = null,
            PhoneNumber = null,
            Provider = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            IsValid = true,
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        Assert.Null(model.CarrierName);
        Assert.False(model.RawData.ContainsKey("carrierName"));
        Assert.Null(model.IsPorted);
        Assert.False(model.RawData.ContainsKey("isPorted"));
        Assert.Null(model.IsVoip);
        Assert.False(model.RawData.ContainsKey("isVoip"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("lineType"));
        Assert.Null(model.MobileCountryCode);
        Assert.False(model.RawData.ContainsKey("mobileCountryCode"));
        Assert.Null(model.MobileNetworkCode);
        Assert.False(model.RawData.ContainsKey("mobileNetworkCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            IsValid = true,
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            IsValid = true,
            PhoneNumber = "phoneNumber",
            Provider = "provider",

            CarrierName = null,
            IsPorted = null,
            IsVoip = null,
            LineType = null,
            MobileCountryCode = null,
            MobileNetworkCode = null,
        };

        Assert.Null(model.CarrierName);
        Assert.True(model.RawData.ContainsKey("carrierName"));
        Assert.Null(model.IsPorted);
        Assert.True(model.RawData.ContainsKey("isPorted"));
        Assert.Null(model.IsVoip);
        Assert.True(model.RawData.ContainsKey("isVoip"));
        Assert.Null(model.LineType);
        Assert.True(model.RawData.ContainsKey("lineType"));
        Assert.Null(model.MobileCountryCode);
        Assert.True(model.RawData.ContainsKey("mobileCountryCode"));
        Assert.Null(model.MobileNetworkCode);
        Assert.True(model.RawData.ContainsKey("mobileNetworkCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            IsValid = true,
            PhoneNumber = "phoneNumber",
            Provider = "provider",

            CarrierName = null,
            IsPorted = null,
            IsVoip = null,
            LineType = null,
            MobileCountryCode = null,
            MobileNetworkCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            CarrierName = "carrierName",
            IsPorted = true,
            IsValid = true,
            IsVoip = true,
            LineType = "lineType",
            MobileCountryCode = "mobileCountryCode",
            MobileNetworkCode = "mobileNetworkCode",
            PhoneNumber = "phoneNumber",
            Provider = "provider",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
