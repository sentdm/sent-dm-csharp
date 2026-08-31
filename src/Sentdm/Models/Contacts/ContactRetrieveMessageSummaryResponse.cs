using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Contacts;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContactRetrieveMessageSummaryResponse,
        ContactRetrieveMessageSummaryResponseFromRaw
    >)
)]
public sealed record class ContactRetrieveMessageSummaryResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public ContactRetrieveMessageSummaryResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContactRetrieveMessageSummaryResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error information
    /// </summary>
    public ContactRetrieveMessageSummaryResponseError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContactRetrieveMessageSummaryResponseError>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Request and response metadata
    /// </summary>
    public ContactRetrieveMessageSummaryResponseMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContactRetrieveMessageSummaryResponseMeta>(
                "meta"
            );
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

    public ContactRetrieveMessageSummaryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactRetrieveMessageSummaryResponse(
        ContactRetrieveMessageSummaryResponse contactRetrieveMessageSummaryResponse
    )
        : base(contactRetrieveMessageSummaryResponse) { }
#pragma warning restore CS8618

    public ContactRetrieveMessageSummaryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactRetrieveMessageSummaryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactRetrieveMessageSummaryResponseFromRaw.FromRawUnchecked"/>
    public static ContactRetrieveMessageSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactRetrieveMessageSummaryResponseFromRaw
    : IFromRawJson<ContactRetrieveMessageSummaryResponse>
{
    /// <inheritdoc/>
    public ContactRetrieveMessageSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactRetrieveMessageSummaryResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContactRetrieveMessageSummaryResponseData,
        ContactRetrieveMessageSummaryResponseDataFromRaw
    >)
)]
public sealed record class ContactRetrieveMessageSummaryResponseData : JsonModel
{
    public IReadOnlyList<ChannelScore>? ChannelScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChannelScore>>("channel_scores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ChannelScore>?>(
                "channel_scores",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? ChannelsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels_used");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "channels_used",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact_id", value);
        }
    }

    public DateTimeOffset? FirstMessageAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("first_message_at");
        }
        init { this._rawData.Set("first_message_at", value); }
    }

    public DateTimeOffset? LastMessageAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_message_at");
        }
        init { this._rawData.Set("last_message_at", value); }
    }

    public int? MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("message_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ChannelScores ?? [])
        {
            item.Validate();
        }
        _ = this.ChannelsUsed;
        _ = this.ContactID;
        _ = this.FirstMessageAt;
        _ = this.LastMessageAt;
        _ = this.MessageCount;
    }

    public ContactRetrieveMessageSummaryResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactRetrieveMessageSummaryResponseData(
        ContactRetrieveMessageSummaryResponseData contactRetrieveMessageSummaryResponseData
    )
        : base(contactRetrieveMessageSummaryResponseData) { }
#pragma warning restore CS8618

    public ContactRetrieveMessageSummaryResponseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactRetrieveMessageSummaryResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactRetrieveMessageSummaryResponseDataFromRaw.FromRawUnchecked"/>
    public static ContactRetrieveMessageSummaryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactRetrieveMessageSummaryResponseDataFromRaw
    : IFromRawJson<ContactRetrieveMessageSummaryResponseData>
{
    /// <inheritdoc/>
    public ContactRetrieveMessageSummaryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactRetrieveMessageSummaryResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChannelScore, ChannelScoreFromRaw>))]
public sealed record class ChannelScore : JsonModel
{
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel", value);
        }
    }

    /// <summary>
    /// Percentage (0-100) of messages on this channel that ended in FAILED.
    /// </summary>
    public int? FailScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("fail_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fail_score", value);
        }
    }

    /// <summary>
    /// Percentage (0-100) of messages on this channel that reached a successful terminal
    /// state: SENT/DELIVERED/READ for outbound, RECEIVED for inbound.
    /// </summary>
    public int? SuccessScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("success_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success_score", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.FailScore;
        _ = this.SuccessScore;
    }

    public ChannelScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelScore(ChannelScore channelScore)
        : base(channelScore) { }
#pragma warning restore CS8618

    public ChannelScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelScoreFromRaw.FromRawUnchecked"/>
    public static ChannelScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelScoreFromRaw : IFromRawJson<ChannelScore>
{
    /// <inheritdoc/>
    public ChannelScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelScore.FromRawUnchecked(rawData);
}

/// <summary>
/// Error information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContactRetrieveMessageSummaryResponseError,
        ContactRetrieveMessageSummaryResponseErrorFromRaw
    >)
)]
public sealed record class ContactRetrieveMessageSummaryResponseError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g., "RESOURCE_001")
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Additional validation error details (field-level errors)
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// URL to documentation about this error
    /// </summary>
    public string? DocUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("doc_url");
        }
        init { this._rawData.Set("doc_url", value); }
    }

    /// <summary>
    /// Human-readable error message
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Details;
        _ = this.DocUrl;
        _ = this.Message;
    }

    public ContactRetrieveMessageSummaryResponseError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactRetrieveMessageSummaryResponseError(
        ContactRetrieveMessageSummaryResponseError contactRetrieveMessageSummaryResponseError
    )
        : base(contactRetrieveMessageSummaryResponseError) { }
#pragma warning restore CS8618

    public ContactRetrieveMessageSummaryResponseError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactRetrieveMessageSummaryResponseError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactRetrieveMessageSummaryResponseErrorFromRaw.FromRawUnchecked"/>
    public static ContactRetrieveMessageSummaryResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactRetrieveMessageSummaryResponseErrorFromRaw
    : IFromRawJson<ContactRetrieveMessageSummaryResponseError>
{
    /// <inheritdoc/>
    public ContactRetrieveMessageSummaryResponseError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactRetrieveMessageSummaryResponseError.FromRawUnchecked(rawData);
}

/// <summary>
/// Request and response metadata
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContactRetrieveMessageSummaryResponseMeta,
        ContactRetrieveMessageSummaryResponseMetaFromRaw
    >)
)]
public sealed record class ContactRetrieveMessageSummaryResponseMeta : JsonModel
{
    /// <summary>
    /// Unique identifier for this request (for tracing and support)
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_id", value);
        }
    }

    /// <summary>
    /// Server timestamp when the response was generated
    /// </summary>
    public DateTimeOffset? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// API version used for this request
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
        _ = this.Timestamp;
        _ = this.Version;
    }

    public ContactRetrieveMessageSummaryResponseMeta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactRetrieveMessageSummaryResponseMeta(
        ContactRetrieveMessageSummaryResponseMeta contactRetrieveMessageSummaryResponseMeta
    )
        : base(contactRetrieveMessageSummaryResponseMeta) { }
#pragma warning restore CS8618

    public ContactRetrieveMessageSummaryResponseMeta(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactRetrieveMessageSummaryResponseMeta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactRetrieveMessageSummaryResponseMetaFromRaw.FromRawUnchecked"/>
    public static ContactRetrieveMessageSummaryResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactRetrieveMessageSummaryResponseMetaFromRaw
    : IFromRawJson<ContactRetrieveMessageSummaryResponseMeta>
{
    /// <inheritdoc/>
    public ContactRetrieveMessageSummaryResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactRetrieveMessageSummaryResponseMeta.FromRawUnchecked(rawData);
}
