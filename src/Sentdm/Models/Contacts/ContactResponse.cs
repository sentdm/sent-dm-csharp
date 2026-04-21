using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

/// <summary>
/// Contact response for v3 API Uses snake_case for JSON property names
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactResponse, ContactResponseFromRaw>))]
public sealed record class ContactResponse : JsonModel
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
    /// Consent status by channel. Keys: "sms", "whatsapp". Values: "opted_in", "opted_out".
    /// All channels will have the same status because consent is global across channels.
    /// A STOP on any channel opts out of all channels; a START opts in to all.
    /// </summary>
    public IReadOnlyDictionary<string, string>? ChannelConsent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "channel_consent"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "channel_consent",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
    /// Whether the contact has opted out of messaging
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
        _ = this.ChannelConsent;
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

    public ContactResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactResponse(ContactResponse contactResponse)
        : base(contactResponse) { }
#pragma warning restore CS8618

    public ContactResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactResponseFromRaw.FromRawUnchecked"/>
    public static ContactResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactResponseFromRaw : IFromRawJson<ContactResponse>
{
    /// <inheritdoc/>
    public ContactResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactResponse.FromRawUnchecked(rawData);
}
