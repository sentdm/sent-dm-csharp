using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookSecret, WebhookSecretFromRaw>))]
public sealed record class WebhookSecret : JsonModel
{
    public string? SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signing_secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signing_secret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SigningSecret;
    }

    public WebhookSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSecret(WebhookSecret webhookSecret)
        : base(webhookSecret) { }
#pragma warning restore CS8618

    public WebhookSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSecretFromRaw.FromRawUnchecked"/>
    public static WebhookSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookSecretFromRaw : IFromRawJson<WebhookSecret>
{
    /// <inheritdoc/>
    public WebhookSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookSecret.FromRawUnchecked(rawData);
}
