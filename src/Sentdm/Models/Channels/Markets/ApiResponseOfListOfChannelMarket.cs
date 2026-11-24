using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Markets;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfListOfChannelMarket,
        ApiResponseOfListOfChannelMarketFromRaw
    >)
)]
public sealed record class ApiResponseOfListOfChannelMarket : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public IReadOnlyList<ChannelMarket>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChannelMarket>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChannelMarket>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Error?.Validate();
        this.Meta?.Validate();
        _ = this.Success;
    }

    public ApiResponseOfListOfChannelMarket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfListOfChannelMarket(
        ApiResponseOfListOfChannelMarket apiResponseOfListOfChannelMarket
    )
        : base(apiResponseOfListOfChannelMarket) { }
#pragma warning restore CS8618

    public ApiResponseOfListOfChannelMarket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfListOfChannelMarket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfListOfChannelMarketFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfListOfChannelMarket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfListOfChannelMarketFromRaw : IFromRawJson<ApiResponseOfListOfChannelMarket>
{
    /// <inheritdoc/>
    public ApiResponseOfListOfChannelMarket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfListOfChannelMarket.FromRawUnchecked(rawData);
}
