using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Organizations;

[JsonConverter(
    typeof(JsonModelConverter<OrganizationListResponse, OrganizationListResponseFromRaw>)
)]
public sealed record class OrganizationListResponse : JsonModel
{
    public IReadOnlyList<Organization>? Organizations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Organization>>("organizations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Organization>?>(
                "organizations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Organizations ?? [])
        {
            item.Validate();
        }
    }

    public OrganizationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationListResponse(OrganizationListResponse organizationListResponse)
        : base(organizationListResponse) { }
#pragma warning restore CS8618

    public OrganizationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationListResponseFromRaw.FromRawUnchecked"/>
    public static OrganizationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationListResponseFromRaw : IFromRawJson<OrganizationListResponse>
{
    /// <inheritdoc/>
    public OrganizationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Organization, OrganizationFromRaw>))]
public sealed record class Organization : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Icon;
        _ = this.Name;
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
    }

    public Organization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Organization(Organization organization)
        : base(organization) { }
#pragma warning restore CS8618

    public Organization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Organization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationFromRaw.FromRawUnchecked"/>
    public static Organization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationFromRaw : IFromRawJson<Organization>
{
    /// <inheritdoc/>
    public Organization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Organization.FromRawUnchecked(rawData);
}
