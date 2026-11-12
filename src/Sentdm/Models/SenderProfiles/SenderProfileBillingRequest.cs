using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Who pays for what a sender profile sends.              Ownership reads the same
/// way as BrandRequest and CampaignRequest: inherit: true is the organization paying;
/// inherit: false (or an empty block) is the profile paying for itself.
///     An absent block is the one place billing differs from brand and campaign:
/// a profile still has to be paid for, so omitting billing stores ProfileAndOrganizationBilling
/// — the profile pays first and its organization covers what the profile's balance
/// cannot (see ResolveStored). { "name": "..." } stays a complete request.
///        Billing carries no fields of its own yet, so a profile paying for itself
/// is { "inherit": false } — or an empty block, which means the same. That is thinner
/// than brand and campaign, where supplying data is the act of owning; it becomes
/// ordinary the moment billing gains a contact or a payment method to carry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SenderProfileBillingRequest, SenderProfileBillingRequestFromRaw>)
)]
public sealed record class SenderProfileBillingRequest : JsonModel
{
    /// <summary>
    /// Whether the parent organization pays. false is the profile paying for itself.
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

    public SenderProfileBillingRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileBillingRequest(SenderProfileBillingRequest senderProfileBillingRequest)
        : base(senderProfileBillingRequest) { }
#pragma warning restore CS8618

    public SenderProfileBillingRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileBillingRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileBillingRequestFromRaw.FromRawUnchecked"/>
    public static SenderProfileBillingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderProfileBillingRequestFromRaw : IFromRawJson<SenderProfileBillingRequest>
{
    /// <inheritdoc/>
    public SenderProfileBillingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderProfileBillingRequest.FromRawUnchecked(rawData);
}
