using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// A paginated list of sender profiles.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderProfilesList, SenderProfilesListFromRaw>))]
public sealed record class SenderProfilesList : JsonModel
{
    /// <summary>
    /// Pagination metadata for list responses
    /// </summary>
    public PaginationMeta? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>("pagination");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pagination", value);
        }
    }

    /// <summary>
    /// The sender_profiles on this page.
    /// </summary>
    public IReadOnlyList<global::Sentdm.Models.SenderProfiles.SenderProfile>? SenderProfiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::Sentdm.Models.SenderProfiles.SenderProfile>
            >("sender_profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::Sentdm.Models.SenderProfiles.SenderProfile>?>(
                "sender_profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.SenderProfiles ?? [])
        {
            item.Validate();
        }
    }

    public SenderProfilesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfilesList(SenderProfilesList senderProfilesList)
        : base(senderProfilesList) { }
#pragma warning restore CS8618

    public SenderProfilesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfilesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderProfilesListFromRaw.FromRawUnchecked"/>
    public static SenderProfilesList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderProfilesListFromRaw : IFromRawJson<SenderProfilesList>
{
    /// <inheritdoc/>
    public SenderProfilesList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderProfilesList.FromRawUnchecked(rawData);
}
