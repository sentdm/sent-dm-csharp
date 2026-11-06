using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Compliance;

/// <summary>
/// A file this market wants, and the multipart field to send it as.
/// Separate from compliance because a file is not JSON: the channel call accepts
/// multipart, and each file is named after the key it satisfies. Listing documents
/// among the JSON entries would describe a request nobody could send.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComplianceAttachmentTemplate, ComplianceAttachmentTemplateFromRaw>)
)]
public sealed record class ComplianceAttachmentTemplate : JsonModel
{
    /// <summary>
    /// The multipart field name to attach the file under.
    /// </summary>
    public string? FieldName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("field_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("field_name", value);
        }
    }

    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    public bool? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("required", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldName;
        _ = this.Label;
        _ = this.Required;
    }

    public ComplianceAttachmentTemplate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceAttachmentTemplate(ComplianceAttachmentTemplate complianceAttachmentTemplate)
        : base(complianceAttachmentTemplate) { }
#pragma warning restore CS8618

    public ComplianceAttachmentTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceAttachmentTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceAttachmentTemplateFromRaw.FromRawUnchecked"/>
    public static ComplianceAttachmentTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceAttachmentTemplateFromRaw : IFromRawJson<ComplianceAttachmentTemplate>
{
    /// <inheritdoc/>
    public ComplianceAttachmentTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceAttachmentTemplate.FromRawUnchecked(rawData);
}
