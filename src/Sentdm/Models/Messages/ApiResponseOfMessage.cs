using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Messages;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfMessage, ApiResponseOfMessageFromRaw>))]
public sealed record class ApiResponseOfMessage : JsonModel
{
    /// <summary>
    /// Message response for v3 API — same shape as v2 with snake_case JSON conventions.
    ///              The shape of a message that was sent immediately: it never has
    /// a scheduled_at key. A message that is or was held for a later instant is a
    /// ScheduledMessageResponse, and the endpoint decides which of the two to answer
    /// with. From always returns this type.
    /// </summary>
    public Message? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Message>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ErrorDetail? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorDetail>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiMeta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
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
        this.Data?.Validate();
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ApiResponseOfMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfMessage(ApiResponseOfMessage apiResponseOfMessage)
        : base(apiResponseOfMessage) { }
#pragma warning restore CS8618

    public ApiResponseOfMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfMessageFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfMessageFromRaw : IFromRawJson<ApiResponseOfMessage>
{
    /// <inheritdoc/>
    public ApiResponseOfMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfMessage.FromRawUnchecked(rawData);
}
