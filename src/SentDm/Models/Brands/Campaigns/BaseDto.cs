using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Brands.Campaigns;

[JsonConverter(typeof(JsonModelConverter<BaseDto, BaseDtoFromRaw>))]
public sealed record class BaseDto : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public BaseDto() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BaseDto(BaseDto baseDto)
        : base(baseDto) { }
#pragma warning restore CS8618

    public BaseDto(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseDto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaseDtoFromRaw.FromRawUnchecked"/>
    public static BaseDto FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseDtoFromRaw : IFromRawJson<BaseDto>
{
    /// <inheritdoc/>
    public BaseDto FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BaseDto.FromRawUnchecked(rawData);
}
