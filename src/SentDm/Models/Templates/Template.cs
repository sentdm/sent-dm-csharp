using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SentDm.Core;

namespace SentDm.Models.Templates;

/// <summary>
/// Template response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Unique template identifier
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
    /// Template category: MARKETING, UTILITY, AUTHENTICATION
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
    /// Supported channels: sms, whatsapp
    /// </summary>
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When the template was created
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
    /// Whether the template is published and active
    /// </summary>
    public bool? IsPublished
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_published", value);
        }
    }

    /// <summary>
    /// Template language code (e.g., en_US)
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
    /// Template display name
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
    /// Template status: APPROVED, PENDING, REJECTED
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
    /// When the template was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Template variables for personalization
    /// </summary>
    public IReadOnlyList<string>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("variables");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Category;
        _ = this.Channels;
        _ = this.CreatedAt;
        _ = this.IsPublished;
        _ = this.Language;
        _ = this.Name;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.Variables;
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}
