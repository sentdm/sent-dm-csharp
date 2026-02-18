using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Templates;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiResponseTemplate, ApiResponseTemplateFromRaw>))]
public sealed record class ApiResponseTemplate : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public Template? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Template>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
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

    public ApiResponseTemplate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseTemplate(ApiResponseTemplate apiResponseTemplate)
        : base(apiResponseTemplate) { }
#pragma warning restore CS8618

    public ApiResponseTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseTemplateFromRaw.FromRawUnchecked"/>
    public static ApiResponseTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseTemplateFromRaw : IFromRawJson<ApiResponseTemplate>
{
    /// <inheritdoc/>
    public ApiResponseTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiResponseTemplate.FromRawUnchecked(rawData);
}
