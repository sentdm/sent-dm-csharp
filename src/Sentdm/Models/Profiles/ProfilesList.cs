using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Sentdm.Models.Webhooks;

namespace Sentdm.Models.Profiles;

/// <summary>
/// The profiles in the organization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfilesList, ProfilesListFromRaw>))]
public sealed record class ProfilesList : JsonModel
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
    /// The profiles on this page.
    /// </summary>
    public IReadOnlyList<ProfileDetail>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProfileDetail>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileDetail>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination?.Validate();
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
    }

    public ProfilesList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfilesList(ProfilesList profilesList)
        : base(profilesList) { }
#pragma warning restore CS8618

    public ProfilesList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfilesList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfilesListFromRaw.FromRawUnchecked"/>
    public static ProfilesList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfilesListFromRaw : IFromRawJson<ProfilesList>
{
    /// <inheritdoc/>
    public ProfilesList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfilesList.FromRawUnchecked(rawData);
}
