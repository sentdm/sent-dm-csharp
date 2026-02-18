using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Brands.Campaigns;

/// <summary>
/// Campaign data for create or update operation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CampaignData, CampaignDataFromRaw>))]
public sealed record class CampaignData : JsonModel
{
    /// <summary>
    /// Campaign description
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Campaign name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Campaign type (e.g., "KYC", "App")
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// List of use cases with sample messages
    /// </summary>
    public required IReadOnlyList<UseCase> UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UseCase>>("useCases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UseCase>>(
                "useCases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Comma-separated keywords that trigger help message (e.g., "HELP, INFO, SUPPORT")
    /// </summary>
    public string? HelpKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpKeywords");
        }
        init { this._rawData.Set("helpKeywords", value); }
    }

    /// <summary>
    /// Message sent when user requests help
    /// </summary>
    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpMessage");
        }
        init { this._rawData.Set("helpMessage", value); }
    }

    /// <summary>
    /// Description of how messages flow in the campaign
    /// </summary>
    public string? MessageFlow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageFlow");
        }
        init { this._rawData.Set("messageFlow", value); }
    }

    /// <summary>
    /// Comma-separated keywords that trigger opt-in (e.g., "YES, START, SUBSCRIBE")
    /// </summary>
    public string? OptinKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinKeywords");
        }
        init { this._rawData.Set("optinKeywords", value); }
    }

    /// <summary>
    /// Message sent when user opts in
    /// </summary>
    public string? OptinMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optinMessage");
        }
        init { this._rawData.Set("optinMessage", value); }
    }

    /// <summary>
    /// Comma-separated keywords that trigger opt-out (e.g., "STOP, UNSUBSCRIBE, END")
    /// </summary>
    public string? OptoutKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutKeywords");
        }
        init { this._rawData.Set("optoutKeywords", value); }
    }

    /// <summary>
    /// Message sent when user opts out
    /// </summary>
    public string? OptoutMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("optoutMessage");
        }
        init { this._rawData.Set("optoutMessage", value); }
    }

    /// <summary>
    /// URL to privacy policy
    /// </summary>
    public string? PrivacyPolicyLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privacyPolicyLink");
        }
        init { this._rawData.Set("privacyPolicyLink", value); }
    }

    /// <summary>
    /// URL to terms and conditions
    /// </summary>
    public string? TermsAndConditionsLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("termsAndConditionsLink");
        }
        init { this._rawData.Set("termsAndConditionsLink", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.Type;
        foreach (var item in this.UseCases)
        {
            item.Validate();
        }
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.MessageFlow;
        _ = this.OptinKeywords;
        _ = this.OptinMessage;
        _ = this.OptoutKeywords;
        _ = this.OptoutMessage;
        _ = this.PrivacyPolicyLink;
        _ = this.TermsAndConditionsLink;
    }

    public CampaignData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignData(CampaignData campaignData)
        : base(campaignData) { }
#pragma warning restore CS8618

    public CampaignData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignDataFromRaw.FromRawUnchecked"/>
    public static CampaignData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CampaignDataFromRaw : IFromRawJson<CampaignData>
{
    /// <inheritdoc/>
    public CampaignData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CampaignData.FromRawUnchecked(rawData);
}

/// <summary>
/// Campaign use case with sample messages
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
{
    /// <summary>
    /// US messaging use case category
    /// </summary>
    public required ApiEnum<string, MessagingUseCaseUs> MessagingUseCaseUs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessagingUseCaseUs>>(
                "messagingUseCaseUs"
            );
        }
        init { this._rawData.Set("messagingUseCaseUs", value); }
    }

    /// <summary>
    /// Sample messages for this use case (1-5 messages, max 1024 characters each)
    /// </summary>
    public required IReadOnlyList<string> SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sampleMessages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MessagingUseCaseUs.Validate();
        _ = this.SampleMessages;
    }

    public UseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UseCase(UseCase useCase)
        : base(useCase) { }
#pragma warning restore CS8618

    public UseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UseCaseFromRaw.FromRawUnchecked"/>
    public static UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UseCaseFromRaw : IFromRawJson<UseCase>
{
    /// <inheritdoc/>
    public UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UseCase.FromRawUnchecked(rawData);
}
