using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Rcs;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseOfRcsAgent, ApiResponseOfRcsAgentFromRaw>))]
public sealed record class ApiResponseOfRcsAgent : JsonModel
{
    /// <summary>
    /// An RCS agent as its owner sees it: the order form back, plus where the submission
    /// stands.              Not RcsSenderResponse. That one is the admin projection
    /// and carries the pipeline we track about a customer's request — internalStatus,
    /// statusReason, isLaunched — and the S3 keys behind the assets. None of that
    /// is the customer's to read: an internal status is a note to ourselves, and
    /// an S3 key is a storage detail that would become a contract the moment it was
    /// published.              What is here is what the caller sent, in the names
    /// it sent them under, plus the three things only we can answer: the record's
    /// id, its status, and the number it sends from. So a read after a write shows
    /// the form as stored rather than as echoed.
    /// </summary>
    public RcsAgent? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsAgent>("data");
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

    public ApiResponseOfRcsAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfRcsAgent(ApiResponseOfRcsAgent apiResponseOfRcsAgent)
        : base(apiResponseOfRcsAgent) { }
#pragma warning restore CS8618

    public ApiResponseOfRcsAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfRcsAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfRcsAgentFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfRcsAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfRcsAgentFromRaw : IFromRawJson<ApiResponseOfRcsAgent>
{
    /// <inheritdoc/>
    public ApiResponseOfRcsAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfRcsAgent.FromRawUnchecked(rawData);
}
