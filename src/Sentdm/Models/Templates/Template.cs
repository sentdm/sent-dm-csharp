using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Templates;

/// <summary>
/// Template response for v3 API
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Which customer owns this — the key's own, or the profile named in x-profile-id.
    /// Says whose resource this is, which the resource's own id does not.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

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
    /// Which consent keyword this template answers, when it is one of Sent's auto-replies:
    /// OPT_IN, OPT_OUT, HELP, or OTHER for a customer-defined keyword. Null for
    /// an ordinary template, and omitted from the response, so its presence is the
    /// answer to "is this an auto-reply".              Deliberately not required,
    /// unlike CustomerId, even though the same "no single mapper" argument applies:
    /// NJsonSchema publishes a C# required member in the schema's required array,
    /// so the contract would have advertised a field this response omits for every
    /// ordinary template, and a generated client could refuse the common case. A
    /// compile-time guard is not worth a wrong published contract. Every mapping
    /// site sets it explicitly, and TemplateResponseSchemaTests pins the field as
    /// optional so it cannot be reintroduced.
    /// </summary>
    public string? AutoReplyAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auto_reply_action");
        }
        init { this._rawData.Set("auto_reply_action", value); }
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
    /// The channels this template's definition can render on, in canonical order:
    /// sms, whatsapp, rcs.              Derived from the definition's body, mirroring
    /// each channel's send-time fallback chain, so a channel is listed only when
    /// a real body would be produced for it: SMS reads sms ?? multiChannel, WhatsApp
    /// reads whatsapp ?? multiChannel, and RCS reads rcs ?? multiChannel ?? sms.
    /// A multiChannel body therefore reports all three, and the extra SMS fallback
    /// on RCS is why an sms/whatsapp pair reports RCS too.              This says
    /// what the content can render on, not what may be sent: sending also needs
    /// the template approved for that channel.
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
    /// Template status: DRAFT, PENDING, APPROVED, REJECTED. A template created with
    /// submit_for_review: false starts as DRAFT and stays there until it is submitted.
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
        _ = this.CustomerID;
        _ = this.ID;
        _ = this.AutoReplyAction;
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

    [SetsRequiredMembers]
    public Template(string customerID)
        : this()
    {
        this.CustomerID = customerID;
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}
