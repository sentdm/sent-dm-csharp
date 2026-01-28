using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Organizations;

[JsonConverter(
    typeof(JsonModelConverter<
        OrganizationRetrieveProfilesResponse,
        OrganizationRetrieveProfilesResponseFromRaw
    >)
)]
public sealed record class OrganizationRetrieveProfilesResponse : JsonModel
{
    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organizationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("organizationId", value);
        }
    }

    public IReadOnlyList<ProfileSummary>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProfileSummary>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileSummary>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OrganizationID;
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
    }

    public OrganizationRetrieveProfilesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRetrieveProfilesResponse(
        OrganizationRetrieveProfilesResponse organizationRetrieveProfilesResponse
    )
        : base(organizationRetrieveProfilesResponse) { }
#pragma warning restore CS8618

    public OrganizationRetrieveProfilesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRetrieveProfilesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRetrieveProfilesResponseFromRaw.FromRawUnchecked"/>
    public static OrganizationRetrieveProfilesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationRetrieveProfilesResponseFromRaw
    : IFromRawJson<OrganizationRetrieveProfilesResponse>
{
    /// <inheritdoc/>
    public OrganizationRetrieveProfilesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRetrieveProfilesResponse.FromRawUnchecked(rawData);
}
