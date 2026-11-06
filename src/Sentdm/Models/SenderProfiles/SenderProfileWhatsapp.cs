using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// The profile's own WhatsApp Business Account, named by the two identifiers the
/// organization cannot answer for you.              No mode: a profile's WABA is
/// its own or it has none. Sharing the organization's would mean sharing its inbox
/// and its throughput, which makes the two indistinguishable to a recipient — so
/// inheriting is not offered rather than refused.              Everything derivable
/// is derived. Whenever this block is present, the solution the account arrived through,
/// the client business portfolio that owns it, the access token and that token's
/// expiry are all resolved from the organization by IPartnerSolutionService.ResolveAccountCredentialsAsync
/// — the first two off the org's shared-account listing, the token minted against
/// the org's own solution. They were previously asked for and are no longer accepted:
/// solution_id and owner_business_id are Meta's answer about provenance, so taking
/// them from the caller let a request assert a partnership Meta disagreed with,
/// and the listing has to be consulted regardless because it is what proves the
/// account is one this organization may reach.              No access token, and
/// there never was one here: it is minted per client business portfolio and rotates
/// roughly every sixty days, so a pasted value would be stale before it was useful.
/// Asking a customer to mint a System User token in Meta Business Manager is skilled
/// work in a console they were never meant to see, and it would say nothing about
/// which solution the account came from or when it is revoked.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfileWhatsapp, SenderProfileWhatsappFromRaw>))]
public sealed record class SenderProfileWhatsapp : JsonModel
{
    /// <summary>
    /// The Meta phone-number id this profile sends from. Must already be registered
    /// under WabaId.              Optional. Omit it to attach the account now and
    /// settle the number later: the channel reads as ACTION_NEEDED with CHANNEL_007,
    /// and the profile's WhatsApp messages fail until a number is named. They do
    /// not fall back to the organization's account. Nothing picks one on your behalf.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_id");
        }
        init { this._rawData.Set("phone_number_id", value); }
    }

    /// <summary>
    /// WhatsApp Business Account id — one of the accounts shared into your organization.
    /// Required: the organization holds one per client, and nothing but the caller
    /// says which belongs to this profile.
    /// </summary>
    public string? WabaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("waba_id");
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumberID;
        _ = this.WabaID;
    }

    public SenderProfileWhatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileWhatsapp(SenderProfileWhatsapp senderProfileWhatsapp)
        : base(senderProfileWhatsapp) { }
#pragma warning restore CS8618

    public SenderProfileWhatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileWhatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfileWhatsappFromRaw.FromRawUnchecked"/>
    public static SenderProfileWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderProfileWhatsappFromRaw : IFromRawJson<SenderProfileWhatsapp>
{
    /// <inheritdoc/>
    public SenderProfileWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderProfileWhatsapp.FromRawUnchecked(rawData);
}
