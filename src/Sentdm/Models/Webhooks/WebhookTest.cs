using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookTest, WebhookTestFromRaw>))]
public sealed record class WebhookTest : JsonModel
{
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
        _ = this.Message;
        _ = this.Success;
    }

    public WebhookTest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookTest(WebhookTest webhookTest)
        : base(webhookTest) { }
#pragma warning restore CS8618

    public WebhookTest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookTest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookTestFromRaw.FromRawUnchecked"/>
    public static WebhookTest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookTestFromRaw : IFromRawJson<WebhookTest>
{
    /// <inheritdoc/>
    public WebhookTest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookTest.FromRawUnchecked(rawData);
}
