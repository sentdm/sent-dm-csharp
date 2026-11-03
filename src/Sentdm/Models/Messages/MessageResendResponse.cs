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
[JsonConverter(typeof(JsonModelConverter<MessageResendResponse, MessageResendResponseFromRaw>))]
public sealed record class MessageResendResponse : JsonModel
{
    /// <summary>
    /// The result of a multi-recipient send.              Declared here rather than
    /// in the service layer. POST /v3/messages used to publish MessageSendResult
    /// — a type in Common.Services.Messaging.Contracts — so the public contract
    /// was whatever the send service happened to return, and changing that service
    /// for an internal reason changed the API. The service keeps its result; this
    /// is what a caller sees, and the mapping between them is a decision the endpoint
    /// makes.              The shape of an immediate send: it never has a scheduled_at
    /// key. A send that carried scheduled_at is a ScheduledSendMessageResponse, and
    /// the endpoint decides which of the two to answer with. From always returns
    /// this type.
    /// </summary>
    public MessageResendResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageResendResponseData>("data");
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

    public MessageResendResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageResendResponse(MessageResendResponse messageResendResponse)
        : base(messageResendResponse) { }
#pragma warning restore CS8618

    public MessageResendResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageResendResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageResendResponseFromRaw.FromRawUnchecked"/>
    public static MessageResendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageResendResponseFromRaw : IFromRawJson<MessageResendResponse>
{
    /// <inheritdoc/>
    public MessageResendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageResendResponse.FromRawUnchecked(rawData);
}
