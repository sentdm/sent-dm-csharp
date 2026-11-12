using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// Messaging channel configuration. All three channels are always present. Each
/// channel has a "configured" flag; configured channels expose additional details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountChannels, AccountChannelsFromRaw>))]
public sealed record class AccountChannels : JsonModel
{
    /// <summary>
    /// RCS channel configuration. When configured, includes the RCS phone number.
    /// </summary>
    public AccountRcsChannel? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountRcsChannel>("rcs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rcs", value);
        }
    }

    /// <summary>
    /// SMS channel configuration. When configured, includes the sending phone number.
    /// </summary>
    public AccountSmsChannel? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountSmsChannel>("sms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sms", value);
        }
    }

    /// <summary>
    /// WhatsApp Business channel configuration. When configured, includes the WhatsApp
    /// phone number and business name.
    /// </summary>
    public AccountWhatsappChannel? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountWhatsappChannel>("whatsapp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Rcs?.Validate();
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public AccountChannels() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountChannels(AccountChannels accountChannels)
        : base(accountChannels) { }
#pragma warning restore CS8618

    public AccountChannels(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountChannels(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountChannelsFromRaw.FromRawUnchecked"/>
    public static AccountChannels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountChannelsFromRaw : IFromRawJson<AccountChannels>
{
    /// <inheritdoc/>
    public AccountChannels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountChannels.FromRawUnchecked(rawData);
}
