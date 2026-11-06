using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Compliance;

/// <summary>
/// One call to make, with a body that can be sent as it stands.              The
/// steps are ordered and the order is load-bearing: a channel that registers with
/// a regime is filed against a brand, so the brand call comes first and the channel
/// call refuses until it has been made. Doing them in order is the whole of setting
/// a market up.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComplianceSetupStep, ComplianceSetupStepFromRaw>))]
public sealed record class ComplianceSetupStep : JsonModel
{
    /// <summary>
    /// Files to attach as multipart, when this call takes any. Absent when it does not.
    /// </summary>
    public IReadOnlyList<ComplianceAttachmentTemplate>? Attachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ComplianceAttachmentTemplate>>(
                "attachments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ComplianceAttachmentTemplate>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The request body, with every key this market wants already present and the
    /// values left blank. Send it as it stands and the response names each blank
    /// that still has to be filled.
    /// </summary>
    public JsonElement? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <summary>
    /// Path to call. Add the x-profile-id header with an organization key to make
    /// the same call for one of your sender profiles — there is no separate path
    /// for that.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    /// <summary>
    /// What this call sets up: brand or channel.
    /// </summary>
    public string? Resource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resource", value);
        }
    }

    /// <summary>
    /// Position in the sequence, from 1. Steps must be performed in this order.
    /// </summary>
    public int? Step
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("step");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("step", value);
        }
    }

    /// <summary>
    /// Why this market needs this call, in one sentence.
    /// </summary>
    public string? Why
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("why");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("why", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attachments ?? [])
        {
            item.Validate();
        }
        _ = this.Body;
        _ = this.Method;
        _ = this.Path;
        _ = this.Resource;
        _ = this.Step;
        _ = this.Why;
    }

    public ComplianceSetupStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSetupStep(ComplianceSetupStep complianceSetupStep)
        : base(complianceSetupStep) { }
#pragma warning restore CS8618

    public ComplianceSetupStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceSetupStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceSetupStepFromRaw.FromRawUnchecked"/>
    public static ComplianceSetupStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceSetupStepFromRaw : IFromRawJson<ComplianceSetupStep>
{
    /// <inheritdoc/>
    public ComplianceSetupStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComplianceSetupStep.FromRawUnchecked(rawData);
}
