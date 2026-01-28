using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

/// <summary>
/// Represents a contact in the customer's contact list
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactListItem, ContactListItemFromRaw>))]
public sealed record class ContactListItem : JsonModel
{
    /// <summary>
    /// The unique identifier of the contact
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
    /// Comma-separated list of available messaging channels for this contact (e.g., "sms,whatsapp")
    /// </summary>
    public string? AvailableChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("availableChannels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("availableChannels", value);
        }
    }

    /// <summary>
    /// The country calling code (e.g., 1 for US/Canada)
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// The default messaging channel to use for this contact (e.g., "sms" or "whatsapp")
    /// </summary>
    public string? DefaultChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("defaultChannel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultChannel", value);
        }
    }

    /// <summary>
    /// The phone number formatted in E.164 standard (e.g., +1234567890)
    /// </summary>
    public string? FormatE164
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatE164");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatE164", value);
        }
    }

    /// <summary>
    /// The phone number formatted for international dialing (e.g., +1 234-567-890)
    /// </summary>
    public string? FormatInternational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatInternational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatInternational", value);
        }
    }

    /// <summary>
    /// The phone number formatted for national dialing (e.g., (234) 567-890)
    /// </summary>
    public string? FormatNational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatNational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatNational", value);
        }
    }

    /// <summary>
    /// The phone number formatted according to RFC 3966 (e.g., tel:+1-234-567-890)
    /// </summary>
    public string? FormatRfc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatRfc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formatRfc", value);
        }
    }

    /// <summary>
    /// The phone number in its original format
    /// </summary>
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

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code (e.g., US, CA, GB)
    /// </summary>
    public string? RegionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regionCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("regionCode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AvailableChannels;
        _ = this.CountryCode;
        _ = this.DefaultChannel;
        _ = this.FormatE164;
        _ = this.FormatInternational;
        _ = this.FormatNational;
        _ = this.FormatRfc;
        _ = this.PhoneNumber;
        _ = this.RegionCode;
    }

    public ContactListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactListItem(ContactListItem contactListItem)
        : base(contactListItem) { }
#pragma warning restore CS8618

    public ContactListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactListItemFromRaw.FromRawUnchecked"/>
    public static ContactListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactListItemFromRaw : IFromRawJson<ContactListItem>
{
    /// <inheritdoc/>
    public ContactListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactListItem.FromRawUnchecked(rawData);
}
