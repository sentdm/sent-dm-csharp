using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;
using Webhooks = Sentdm.Models.Webhooks;

namespace Sentdm.Models.Me;

/// <summary>
/// Standard API response envelope for all v3 endpoints
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MeRetrieveResponse, MeRetrieveResponseFromRaw>))]
public sealed record class MeRetrieveResponse : JsonModel
{
    /// <summary>
    /// The response data (null if error)
    /// </summary>
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Error details (null if successful)
    /// </summary>
    public Webhooks::ApiError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Metadata about the request and response
    /// </summary>
    public Webhooks::ApiMeta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhooks::ApiMeta>("meta");
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

    public MeRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeRetrieveResponse(MeRetrieveResponse meRetrieveResponse)
        : base(meRetrieveResponse) { }
#pragma warning restore CS8618

    public MeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeRetrieveResponseFromRaw : IFromRawJson<MeRetrieveResponse>
{
    /// <inheritdoc/>
    public MeRetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The response data (null if error)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Customer ID (organization, account, or profile)
    /// </summary>
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

    /// <summary>
    /// Messaging channel configuration
    /// </summary>
    public Channels? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Channels>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// When the account was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Account description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Contact email address
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Account icon URL
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    /// <summary>
    /// Account name
    /// </summary>
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

    /// <summary>
    /// Organization ID (only for profile type — the parent organization)
    /// </summary>
    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// List of profiles (populated for organization type, empty for user and profile types)
    /// </summary>
    public IReadOnlyList<Profile>? Profiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Profile>>("profiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Profile>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Profile settings (only for profile type)
    /// </summary>
    public ProfileSettings? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileSettings>("settings");
        }
        init { this._rawData.Set("settings", value); }
    }

    /// <summary>
    /// Short name / abbreviation (only for profile type)
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("short_name");
        }
        init { this._rawData.Set("short_name", value); }
    }

    /// <summary>
    /// Profile status (only for profile type): incomplete, pending_review, approved, etc.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Account type: "organization" (has profiles), "user" (no profiles), or "profile"
    /// (child of an organization)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channels?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Email;
        _ = this.Icon;
        _ = this.Name;
        _ = this.OrganizationID;
        foreach (var item in this.Profiles ?? [])
        {
            item.Validate();
        }
        this.Settings?.Validate();
        _ = this.ShortName;
        _ = this.Status;
        _ = this.Type;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Messaging channel configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Channels, ChannelsFromRaw>))]
public sealed record class Channels : JsonModel
{
    /// <summary>
    /// RCS channel (provider: vibes)
    /// </summary>
    public Rcs? Rcs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rcs>("rcs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rcs", value);
        }
    }

    /// <summary>
    /// SMS channel (providers: telnyx, sinch)
    /// </summary>
    public Sms? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Sms>("sms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sms", value);
        }
    }

    /// <summary>
    /// WhatsApp Business channel (provider: meta)
    /// </summary>
    public Whatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Whatsapp>("whatsapp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Rcs?.Validate();
        this.Sms?.Validate();
        this.Whatsapp?.Validate();
    }

    public Channels() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Channels(Channels channels)
        : base(channels) { }
#pragma warning restore CS8618

    public Channels(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channels(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsFromRaw.FromRawUnchecked"/>
    public static Channels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsFromRaw : IFromRawJson<Channels>
{
    /// <inheritdoc/>
    public Channels FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channels.FromRawUnchecked(rawData);
}

/// <summary>
/// RCS channel (provider: vibes)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rcs, RcsFromRaw>))]
public sealed record class Rcs : JsonModel
{
    /// <summary>
    /// Whether RCS is configured for this account
    /// </summary>
    public bool? Configured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("configured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configured", value);
        }
    }

    /// <summary>
    /// RCS-enabled phone number in E.164 format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Configured;
        _ = this.PhoneNumber;
    }

    public Rcs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rcs(Rcs rcs)
        : base(rcs) { }
#pragma warning restore CS8618

    public Rcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RcsFromRaw.FromRawUnchecked"/>
    public static Rcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RcsFromRaw : IFromRawJson<Rcs>
{
    /// <inheritdoc/>
    public Rcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rcs.FromRawUnchecked(rawData);
}

/// <summary>
/// SMS channel (providers: telnyx, sinch)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sms, SmsFromRaw>))]
public sealed record class Sms : JsonModel
{
    /// <summary>
    /// Whether SMS is configured for this account
    /// </summary>
    public bool? Configured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("configured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configured", value);
        }
    }

    /// <summary>
    /// Sending phone number in E.164 format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Configured;
        _ = this.PhoneNumber;
    }

    public Sms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sms(Sms sms)
        : base(sms) { }
#pragma warning restore CS8618

    public Sms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Sms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SmsFromRaw.FromRawUnchecked"/>
    public static Sms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SmsFromRaw : IFromRawJson<Sms>
{
    /// <inheritdoc/>
    public Sms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Sms.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp Business channel (provider: meta)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Whatsapp, WhatsappFromRaw>))]
public sealed record class Whatsapp : JsonModel
{
    /// <summary>
    /// WhatsApp Business display name
    /// </summary>
    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("business_name");
        }
        init { this._rawData.Set("business_name", value); }
    }

    /// <summary>
    /// Whether WhatsApp is configured for this account
    /// </summary>
    public bool? Configured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("configured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configured", value);
        }
    }

    /// <summary>
    /// WhatsApp phone number in E.164 format
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessName;
        _ = this.Configured;
        _ = this.PhoneNumber;
    }

    public Whatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Whatsapp(Whatsapp whatsapp)
        : base(whatsapp) { }
#pragma warning restore CS8618

    public Whatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Whatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappFromRaw.FromRawUnchecked"/>
    public static Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappFromRaw : IFromRawJson<Whatsapp>
{
    /// <inheritdoc/>
    public Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Whatsapp.FromRawUnchecked(rawData);
}

/// <summary>
/// Profile (sender profile) response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Profile, ProfileFromRaw>))]
public sealed record class Profile : JsonModel
{
    /// <summary>
    /// Profile unique identifier
    /// </summary>
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

    /// <summary>
    /// When the profile was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Profile description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Profile icon URL
    /// </summary>
    public string? Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    /// <summary>
    /// Profile name
    /// </summary>
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

    /// <summary>
    /// User's role in this profile: admin, billing, developer (inherited from organization
    /// if not explicitly set)
    /// </summary>
    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Profile configuration settings
    /// </summary>
    public ProfileSettings? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileSettings>("settings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    /// <summary>
    /// Profile short name (abbreviation)
    /// </summary>
    public string? ShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("short_name");
        }
        init { this._rawData.Set("short_name", value); }
    }

    /// <summary>
    /// Profile setup status: incomplete, pending_review, approved, rejected
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Icon;
        _ = this.Name;
        _ = this.Role;
        this.Settings?.Validate();
        _ = this.ShortName;
        _ = this.Status;
    }

    public Profile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Profile(Profile profile)
        : base(profile) { }
#pragma warning restore CS8618

    public Profile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Profile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileFromRaw.FromRawUnchecked"/>
    public static Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileFromRaw : IFromRawJson<Profile>
{
    /// <inheritdoc/>
    public Profile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Profile.FromRawUnchecked(rawData);
}
