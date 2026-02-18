using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;
using Webhooks = SentDm.Models.Webhooks;

namespace SentDm.Models.Lookup;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        LookupRetrievePhoneInfoResponse,
        LookupRetrievePhoneInfoResponseFromRaw
    >)
)]
public sealed record class LookupRetrievePhoneInfoResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public Webhooks::ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public Webhooks::ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public LookupRetrievePhoneInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LookupRetrievePhoneInfoResponse(
        LookupRetrievePhoneInfoResponse lookupRetrievePhoneInfoResponse
    )
        : base(lookupRetrievePhoneInfoResponse) { }
#pragma warning restore CS8618

    public LookupRetrievePhoneInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LookupRetrievePhoneInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LookupRetrievePhoneInfoResponseFromRaw.FromRawUnchecked"/>
    public static LookupRetrievePhoneInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LookupRetrievePhoneInfoResponseFromRaw : IFromRawJson<LookupRetrievePhoneInfoResponse>
{
    /// <inheritdoc/>
    public LookupRetrievePhoneInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LookupRetrievePhoneInfoResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? CarrierName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrierName");
        }
        init { this._rawData.Set("carrierName", value); }
    }

    public bool? IsPorted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPorted");
        }
        init { this._rawData.Set("isPorted", value); }
    }

    public bool? IsValid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isValid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isValid", value);
        }
    }

    public bool? IsVoip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVoip");
        }
        init { this._rawData.Set("isVoip", value); }
    }

    public string? LineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lineType");
        }
        init { this._rawData.Set("lineType", value); }
    }

    public string? MobileCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mobileCountryCode");
        }
        init { this._rawData.Set("mobileCountryCode", value); }
    }

    public string? MobileNetworkCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mobileNetworkCode");
        }
        init { this._rawData.Set("mobileNetworkCode", value); }
    }

    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneNumber", value);
        }
    }

    public string? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierName;
        _ = this.IsPorted;
        _ = this.IsValid;
        _ = this.IsVoip;
        _ = this.LineType;
        _ = this.MobileCountryCode;
        _ = this.MobileNetworkCode;
        _ = this.PhoneNumber;
        _ = this.Provider;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
