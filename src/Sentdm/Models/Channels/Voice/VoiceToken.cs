using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Voice;

/// <summary>
/// A short-lived token your app passes to the voice client SDK to register
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceToken, VoiceTokenFromRaw>))]
public sealed record class VoiceToken : JsonModel
{
    /// <summary>
    /// The signed token. Hand it to the client SDK unchanged.
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token", value);
        }
    }

    /// <summary>
    /// When the token expires (UTC)
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// The identity the token was minted for
    /// </summary>
    public string? Identity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("identity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identity", value);
        }
    }

    /// <summary>
    /// The phone number this identity is now bound to, in E.164 format
    /// </summary>
    public string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.ExpiresAt;
        _ = this.Identity;
        _ = this.Number;
    }

    public VoiceToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceToken(VoiceToken voiceToken)
        : base(voiceToken) { }
#pragma warning restore CS8618

    public VoiceToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceTokenFromRaw.FromRawUnchecked"/>
    public static VoiceToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoiceTokenFromRaw : IFromRawJson<VoiceToken>
{
    /// <inheritdoc/>
    public VoiceToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoiceToken.FromRawUnchecked(rawData);
}
