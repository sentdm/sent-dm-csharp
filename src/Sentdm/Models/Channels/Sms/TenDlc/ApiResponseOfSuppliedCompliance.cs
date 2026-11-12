using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Channels.Sms.TenDlc;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ApiResponseOfSuppliedCompliance,
        ApiResponseOfSuppliedComplianceFromRaw
    >)
)]
public sealed record class ApiResponseOfSuppliedCompliance : JsonModel
{
    /// <summary>
    /// What a market has been given: the identity it registers under, its programme,
    /// and any documents attached.              What it does not carry is what the
    /// market asks for. That is the subject of GET /v3/compliance/requirements, and
    /// it is the same answer for every caller — a description of what a compliance
    /// regime wants, not a record of one customer's progress through it. It was
    /// reported here as well for a while, which put the same array in six response
    /// shapes and left a caller deciding which of two sources to believe.
    ///       Present on a list read for markets that register (carrying brand and
    /// campaign), but with documents absent — documents are not fetched for a list,
    /// because a catalog lookup and a document read per market would multiply across
    /// a page. Absent documents is distinct from an empty list: absent says they
    /// were not fetched; empty says the market has been given none. The parent object
    /// is null only when the market registers with nobody and compliance was not
    /// computed — nothing to show at all.
    /// </summary>
    public SuppliedCompliance? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SuppliedCompliance>("data");
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

    public ApiResponseOfSuppliedCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiResponseOfSuppliedCompliance(
        ApiResponseOfSuppliedCompliance apiResponseOfSuppliedCompliance
    )
        : base(apiResponseOfSuppliedCompliance) { }
#pragma warning restore CS8618

    public ApiResponseOfSuppliedCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiResponseOfSuppliedCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiResponseOfSuppliedComplianceFromRaw.FromRawUnchecked"/>
    public static ApiResponseOfSuppliedCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiResponseOfSuppliedComplianceFromRaw : IFromRawJson<ApiResponseOfSuppliedCompliance>
{
    /// <inheritdoc/>
    public ApiResponseOfSuppliedCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiResponseOfSuppliedCompliance.FromRawUnchecked(rawData);
}
