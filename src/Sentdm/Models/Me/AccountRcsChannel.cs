using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Me;

/// <summary>
/// RCS channel configuration. When configured, includes the RCS phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountRcsChannel, AccountRcsChannelFromRaw>))]
public sealed record class AccountRcsChannel : JsonModel
{
    /// <summary>
    /// Whether RCS is configured for this account
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
    /// RCS-enabled phone number in E.164 format
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

    public AccountRcsChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRcsChannel(AccountRcsChannel accountRcsChannel)
        : base(accountRcsChannel) { }
#pragma warning restore CS8618

    public AccountRcsChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRcsChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountRcsChannelFromRaw.FromRawUnchecked"/>
    public static AccountRcsChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountRcsChannelFromRaw : IFromRawJson<AccountRcsChannel>
{
    /// <inheritdoc/>
    public AccountRcsChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountRcsChannel.FromRawUnchecked(rawData);
}
