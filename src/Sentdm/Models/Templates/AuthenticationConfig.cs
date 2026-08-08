using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Configuration for AUTHENTICATION category templates
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AuthenticationConfig, AuthenticationConfigFromRaw>))]
public sealed record class AuthenticationConfig : JsonModel
{
    /// <summary>
    /// Whether to add the security recommendation text: "For your security, do not
    /// share this code."
    /// </summary>
    public bool? AddSecurityRecommendation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("addSecurityRecommendation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("addSecurityRecommendation", value);
        }
    }

    /// <summary>
    /// Code expiration time in minutes (1-90). If set, adds footer: "This code expires
    /// in X minutes."
    /// </summary>
    public int? CodeExpirationMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("codeExpirationMinutes");
        }
        init { this._rawData.Set("codeExpirationMinutes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddSecurityRecommendation;
        _ = this.CodeExpirationMinutes;
    }

    public AuthenticationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationConfig(AuthenticationConfig authenticationConfig)
        : base(authenticationConfig) { }
#pragma warning restore CS8618

    public AuthenticationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationConfigFromRaw.FromRawUnchecked"/>
    public static AuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthenticationConfigFromRaw : IFromRawJson<AuthenticationConfig>
{
    /// <inheritdoc/>
    public AuthenticationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuthenticationConfig.FromRawUnchecked(rawData);
}
