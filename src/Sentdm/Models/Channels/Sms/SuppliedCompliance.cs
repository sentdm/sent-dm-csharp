using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// What a market has been given: the identity it registers under, its programme,
/// and any documents attached.              What it does not carry is what the market
/// asks for. That is the subject of GET /v3/compliance/requirements, and it is the
/// same answer for every caller — a description of what a compliance regime wants,
/// not a record of one customer's progress through it. It was reported here as well
/// for a while, which put the same array in six response shapes and left a caller
/// deciding which of two sources to believe.              Present on a list read
/// for markets that register (carrying brand and campaign), but with documents absent
/// — documents are not fetched for a list, because a catalog lookup and a document
/// read per market would multiply across a page. Absent documents is distinct from
/// an empty list: absent says they were not fetched; empty says the market has been
/// given none. The parent object is null only when the market registers with nobody
/// and compliance was not computed — nothing to show at all.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuppliedCompliance, SuppliedComplianceFromRaw>))]
public sealed record class SuppliedCompliance : JsonModel
{
    /// <summary>
    /// The identity this market registers under, with inherit saying whose it is.
    ///              Reported here rather than on the profile because it belongs
    /// to the registration this market files, and only one market files one. It was
    /// a top-level block for a while, which put a per-registration value beside
    /// a list of markets and left a caller to work out which market it belonged to.
    ///              Absent for a market that registers with nobody — such a market
    /// asks for no identity, so there is none to report. Absent and null mean different
    /// things: absent says this market does not ask, null would say it asks and nothing
    /// was supplied.              Untyped, like the request side, because its members
    /// are declared by the market's own schema rather than by a C# class. A typed
    /// pair here would be a second definition of what a market wants, free to drift
    /// from the one that validates.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("brand");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "brand",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The programme this market registers, with inherit saying whose it is.
    ///
    ///
    /// <para>             One, not a list. TcrCampaigns permits several and an account
    /// built on the admin side may hold them, but this surface offers one — which
    /// is what lets the market's PATCH be an upsert rather than a collection with
    /// an addressable create behind it. An account holding several is reported as
    /// its first and refused on write, rather than half-edited.              Carries
    /// no id. Nothing addresses a campaign, and an undeclared key would be refused
    /// if the caller sent this object back — which it is meant to be able to do.</para>
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Campaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "campaign"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "campaign",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// What has been supplied for this market.              Files, not values — the
    /// declared halves above carry the values. A document cannot be a JSON value,
    /// so it is sent as multipart on the channel call and reported here as a reference.
    ///              Absent on a list read, which fetches identity but does not compute
    /// compliance documents per market. Absent and empty mean different things: absent
    /// says the documents were not fetched; empty says the market has been given none.
    /// </summary>
    public IReadOnlyList<SuppliedDocument>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SuppliedDocument>>("documents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SuppliedDocument>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Brand;
        _ = this.Campaign;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
    }

    public SuppliedCompliance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuppliedCompliance(SuppliedCompliance suppliedCompliance)
        : base(suppliedCompliance) { }
#pragma warning restore CS8618

    public SuppliedCompliance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SuppliedCompliance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SuppliedComplianceFromRaw.FromRawUnchecked"/>
    public static SuppliedCompliance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SuppliedComplianceFromRaw : IFromRawJson<SuppliedCompliance>
{
    /// <inheritdoc/>
    public SuppliedCompliance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SuppliedCompliance.FromRawUnchecked(rawData);
}
