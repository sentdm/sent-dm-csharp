using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Represents a message template with comprehensive metadata including definition structure
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateResponse, TemplateResponseFromRaw>))]
public sealed record class TemplateResponse : JsonModel
{
    /// <summary>
    /// The unique identifier of the template
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
    /// The template category (e.g., MARKETING, UTILITY, AUTHENTICATION)
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// The date and time when the template was created
    /// </summary>
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

    /// <summary>
    /// The complete template definition including header, body, footer, and buttons
    /// </summary>
    public TemplateDefinition? Definition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateDefinition>("definition");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("definition", value);
        }
    }

    /// <summary>
    /// The display name of the template (auto-generated if not provided)
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Indicates whether the template is published and available for use
    /// </summary>
    public bool? IsPublished
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPublished");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPublished", value);
        }
    }

    /// <summary>
    /// The template language code (e.g., en_US, es_ES)
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// The approval status of the template (e.g., APPROVED, PENDING, REJECTED, DRAFT)
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

    /// <summary>
    /// The date and time when the template was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// The WhatsApp Business API template ID from Meta
    /// </summary>
    public string? WhatsappTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("whatsappTemplateId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsappTemplateId", value);
        }
    }

    /// <summary>
    /// The WhatsApp template name as registered with Meta
    /// </summary>
    public string? WhatsappTemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("whatsappTemplateName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsappTemplateName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Category;
        _ = this.CreatedAt;
        this.Definition?.Validate();
        _ = this.DisplayName;
        _ = this.IsPublished;
        _ = this.Language;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.WhatsappTemplateID;
        _ = this.WhatsappTemplateName;
    }

    public TemplateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateResponse(TemplateResponse templateResponse)
        : base(templateResponse) { }
#pragma warning restore CS8618

    public TemplateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateResponseFromRaw.FromRawUnchecked"/>
    public static TemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateResponseFromRaw : IFromRawJson<TemplateResponse>
{
    /// <inheritdoc/>
    public TemplateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateResponse.FromRawUnchecked(rawData);
}
