using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Messages;

/// <summary>
/// Sends a message to one or more recipients using a template. Supports multi-channel
/// broadcast — when multiple channels are specified (e.g. ["sms", "whatsapp"]), a
/// separate message is created for each (recipient, channel) pair. Returns immediately
/// with per-recipient message IDs for async tracking via webhooks or the GET /messages/{id} endpoint.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Channels to broadcast on, e.g. ["whatsapp", "sms"]. Each channel produces
    /// a separate message per recipient. "sent" = auto-detect, "rcs" = reserved (skipped).
    /// Defaults to ["sent"] (auto-detect) if omitted.
    /// </summary>
    public IReadOnlyList<string>? Channel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("channel");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "channel",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template reference (by id or name, with optional parameters)
    /// </summary>
    public Template? Template
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Template>("template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("template", value);
        }
    }

    /// <summary>
    /// Test mode flag - when true, the operation is simulated without side effects
    /// Useful for testing integrations without actual execution
    /// </summary>
    public bool? TestMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("test_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("test_mode", value);
        }
    }

    /// <summary>
    /// List of recipient phone numbers in E.164 format (multi-recipient fan-out)
    /// </summary>
    public IReadOnlyList<string>? To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public MessageSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendParams(MessageSendParams messageSendParams)
        : base(messageSendParams)
    {
        this._rawBodyData = new(messageSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MessageSendParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static MessageSendParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MessageSendParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v3/messages")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Template reference (by id or name, with optional parameters)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Template ID (mutually exclusive with name)
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Template name (mutually exclusive with id)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Template variable parameters for personalization
    /// </summary>
    public IReadOnlyDictionary<string, string>? Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("parameters");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Parameters;
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}
