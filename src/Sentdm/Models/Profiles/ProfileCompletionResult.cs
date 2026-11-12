using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Profiles;

/// <summary>
/// Response when a profile is already in the completed state and no further action
/// is taken.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProfileCompletionResult, ProfileCompletionResultFromRaw>))]
public sealed record class ProfileCompletionResult : JsonModel
{
    /// <summary>
    /// Human-readable message describing the result.
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

    /// <summary>
    /// Current process status of the profile (e.g., "completed", "submitted", "in_progress").
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Status;
    }

    public ProfileCompletionResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileCompletionResult(ProfileCompletionResult profileCompletionResult)
        : base(profileCompletionResult) { }
#pragma warning restore CS8618

    public ProfileCompletionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileCompletionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileCompletionResultFromRaw.FromRawUnchecked"/>
    public static ProfileCompletionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileCompletionResultFromRaw : IFromRawJson<ProfileCompletionResult>
{
    /// <inheritdoc/>
    public ProfileCompletionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileCompletionResult.FromRawUnchecked(rawData);
}
