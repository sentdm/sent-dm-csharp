using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactCreateResponse, ContactCreateResponseFromRaw>))]
public sealed record class ContactCreateResponse : JsonModel
{
    /// <summary>
    /// Contact response for v3 API Uses snake_case for JSON property names
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
    /// Error information
    /// </summary>
    public Error? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Error>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public Meta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>("meta");
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

    public ContactCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactCreateResponse(ContactCreateResponse contactCreateResponse)
        : base(contactCreateResponse) { }
#pragma warning restore CS8618

    public ContactCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactCreateResponseFromRaw.FromRawUnchecked"/>
    public static ContactCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactCreateResponseFromRaw : IFromRawJson<ContactCreateResponse>
{
    /// <inheritdoc/>
    public ContactCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact response for v3 API Uses snake_case for JSON property names
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique identifier for the contact
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Comma-separated list of available messaging channels (e.g., "sms,whatsapp")
    /// </summary>
    public string? AvailableChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("available_channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("available_channels", value);
        }
    }

    /// <summary>
    /// Country calling code (e.g., 1 for US/Canada)
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// When the contact was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Default messaging channel to use (e.g., "sms" or "whatsapp")
    /// </summary>
    public string? DefaultChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("default_channel", value);
        }
    }

    /// <summary>
    /// Phone number in E.164 format (e.g., +1234567890)
    /// </summary>
    public string? FormatE164
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format_e164");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format_e164", value);
        }
    }

    /// <summary>
    /// Phone number in international format (e.g., +1 234-567-890)
    /// </summary>
    public string? FormatInternational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format_international");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format_international", value);
        }
    }

    /// <summary>
    /// Phone number in national format (e.g., (234) 567-890)
    /// </summary>
    public string? FormatNational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format_national");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format_national", value);
        }
    }

    /// <summary>
    /// Phone number in RFC 3966 format (e.g., tel:+1-234-567-890)
    /// </summary>
    public string? FormatRfc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format_rfc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format_rfc", value);
        }
    }

    /// <summary>
    /// Whether this is an inherited contact (read-only)
    /// </summary>
    public bool? IsInherited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_inherited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_inherited", value);
        }
    }

    /// <summary>
    /// Whether the contact has opted out of messaging. Single source of truth — opt-out
    /// is per-contact, not per-channel.
    /// </summary>
    public bool? OptOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("opt_out");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opt_out", value);
        }
    }

    /// <summary>
    /// Phone number in original format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code (e.g., US, CA, GB)
    /// </summary>
    public string? RegionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    /// <summary>
    /// When the contact was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AvailableChannels;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.DefaultChannel;
        _ = this.FormatE164;
        _ = this.FormatInternational;
        _ = this.FormatNational;
        _ = this.FormatRfc;
        _ = this.IsInherited;
        _ = this.OptOut;
        _ = this.PhoneNumber;
        _ = this.RegionCode;
        _ = this.UpdatedAt;
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

/// <summary>
/// Error information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public Meta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta(Meta meta)
        : base(meta) { }
#pragma warning restore CS8618

    public Meta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meta.FromRawUnchecked(rawData);
}
