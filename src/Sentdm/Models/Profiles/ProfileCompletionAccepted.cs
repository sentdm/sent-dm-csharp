using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Response acknowledging that profile completion has been accepted and started
/// in the background. The provided webhook URL will be called when processing finishes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileCompletionAccepted, ProfileCompletionAcceptedFromRaw>)
)]
public sealed record class ProfileCompletionAccepted : JsonModel
{
    /// <summary>
    /// Human-readable message describing the accepted state.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
    }

    public ProfileCompletionAccepted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCompletionAccepted(ProfileCompletionAccepted profileCompletionAccepted)
        : base(profileCompletionAccepted) { }
#pragma warning restore CS8618

    public ProfileCompletionAccepted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileCompletionAccepted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileCompletionAcceptedFromRaw.FromRawUnchecked"/>
    public static ProfileCompletionAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileCompletionAcceptedFromRaw : IFromRawJson<ProfileCompletionAccepted>
{
    /// <inheritdoc/>
    public ProfileCompletionAccepted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileCompletionAccepted.FromRawUnchecked(rawData);
}
