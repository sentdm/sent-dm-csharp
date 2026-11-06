using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// WhatsApp Business channel configuration. When configured, includes the WhatsApp
/// phone number and business name.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountWhatsappChannel, AccountWhatsappChannelFromRaw>))]
public sealed record class AccountWhatsappChannel : JsonModel
{
    /// <summary>
    /// WhatsApp Business display name
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("business_name");
        }
        init { this._rawData.Set("business_name", value); }
    }

    /// <summary>
    /// Whether WhatsApp is configured for this account
    /// </summary>
    public bool? Configured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("configured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configured", value);
        }
    }

    /// <summary>
    /// WhatsApp phone number in E.164 format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessName;
        _ = this.Configured;
        _ = this.PhoneNumber;
    }

    public AccountWhatsappChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountWhatsappChannel(AccountWhatsappChannel accountWhatsappChannel)
        : base(accountWhatsappChannel) { }
#pragma warning restore CS8618

    public AccountWhatsappChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountWhatsappChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountWhatsappChannelFromRaw.FromRawUnchecked"/>
    public static AccountWhatsappChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountWhatsappChannelFromRaw : IFromRawJson<AccountWhatsappChannel>
{
    /// <inheritdoc/>
    public AccountWhatsappChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountWhatsappChannel.FromRawUnchecked(rawData);
}
