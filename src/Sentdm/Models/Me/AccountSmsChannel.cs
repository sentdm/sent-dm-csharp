using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// SMS channel configuration. When configured, includes the sending phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountSmsChannel, AccountSmsChannelFromRaw>))]
public sealed record class AccountSmsChannel : JsonModel
{
    /// <summary>
    /// Whether SMS is configured for this account
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
    /// Sending phone number in E.164 format
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
        _ = this.Configured;
        _ = this.PhoneNumber;
    }

    public AccountSmsChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSmsChannel(AccountSmsChannel accountSmsChannel)
        : base(accountSmsChannel) { }
#pragma warning restore CS8618

    public AccountSmsChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSmsChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSmsChannelFromRaw.FromRawUnchecked"/>
    public static AccountSmsChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountSmsChannelFromRaw : IFromRawJson<AccountSmsChannel>
{
    /// <inheritdoc/>
    public AccountSmsChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountSmsChannel.FromRawUnchecked(rawData);
}
