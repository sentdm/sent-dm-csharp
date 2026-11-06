using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Who pays for a sender profile's traffic, as a read reports it.              Its
/// own type, field for field the same as BillingRequest. Same reason as the brand:
/// a response is not a request, whatever it carries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfileBilling, SenderProfileBillingFromRaw>))]
public sealed record class SenderProfileBilling : JsonModel
{
    /// <summary>
    /// Whether the organization pays, rather than the profile.
    /// </summary>
    public bool? Inherit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inherit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inherit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Inherit;
    }

    public SenderProfileBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileBilling(SenderProfileBilling senderProfileBilling)
        : base(senderProfileBilling) { }
#pragma warning restore CS8618

    public SenderProfileBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileBillingFromRaw.FromRawUnchecked"/>
    public static SenderProfileBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderProfileBillingFromRaw : IFromRawJson<SenderProfileBilling>
{
    /// <inheritdoc/>
    public SenderProfileBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderProfileBilling.FromRawUnchecked(rawData);
}
