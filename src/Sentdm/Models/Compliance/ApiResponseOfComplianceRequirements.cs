using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Compliance;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfComplianceRequirements,
        ApiResponseOfComplianceRequirementsFromRaw
    >)
)]
public sealed record class ApiResponseOfComplianceRequirements : JsonModel
{
    /// <summary>
    /// Everything a market expects of a sender, for one channel, country and sender type.
    /// </summary>
    public ComplianceRequirements? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComplianceRequirements>("data");
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

    public ApiResponseOfComplianceRequirements() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfComplianceRequirements(
        ApiResponseOfComplianceRequirements apiResponseOfComplianceRequirements
    )
        : base(apiResponseOfComplianceRequirements) { }
#pragma warning restore CS8618

    public ApiResponseOfComplianceRequirements(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfComplianceRequirements(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfComplianceRequirementsFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfComplianceRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfComplianceRequirementsFromRaw : IFromRawJson<ApiResponseOfComplianceRequirements>
{
    /// <inheritdoc/>
    public ApiResponseOfComplianceRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfComplianceRequirements.FromRawUnchecked(rawData);
}
