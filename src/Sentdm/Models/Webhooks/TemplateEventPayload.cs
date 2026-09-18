using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Webhooks;

/// <summary>
/// Body of a template status event. Delivered when a template's review outcome changes,
/// so you can react without polling.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TemplateEventPayload, TemplateEventPayloadFromRaw>))]
public sealed record class TemplateEventPayload : JsonModel
{
    /// <summary>
    /// The review status the template just reached, for example APPROVED or REJECTED.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The template's identifier with Meta, assigned when the template is submitted
    /// for review.
    /// </summary>
    public required string WhatsappTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("whatsapp_template_id");
        }
        init { this._rawData.Set("whatsapp_template_id", value); }
    }

    /// <summary>
    /// The account the template belongs to.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Which consent keyword this template answers, when it is one of Sent's auto-replies:
    /// OPT_IN, OPT_OUT, HELP, or OTHER for a customer-defined keyword.
    ///     Omitted for an ordinary template, so its presence is the answer to "is
    /// this an auto-reply". Sent creates the three compliance auto-replies at signup
    /// and they go through review like any other template, so their events arrive
    /// mixed in with the customer's own with nothing else to tell them apart.
    ///            Named for the reader rather than after Template.OptAction, which
    /// it is mapped from. The MCP tool result deliberately keeps OptAction, OptKeywords
    /// and IsOpt: it mirrors the internal shape on purpose and publishes the keywords
    /// too, so renaming one of the three there would leave a surface half in each
    /// vocabulary. Two names for one concept, each consistent within its own surface,
    /// chosen over a rename that breaks MCP clients silently.
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
    /// The template's category, for example UTILITY, MARKETING, or AUTHENTICATION.
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
    /// The channel leg this decision is about, for example whatsapp, sms, or rcs.
    /// A template is reviewed per channel and the legs come back independently, so
    /// each one reports separately.              Omitted when the decision applies
    /// to the template as a whole rather than to one leg. That event is the broader
    /// news: a template-wide rejection blocks every channel, whatever the individual
    /// legs say.
    /// </summary>
    public string? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// The template's language code, for example en_US.
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
    /// Why the template reached Status, when a reason was given. Populated on a rejection.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The template in Sent.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    /// <summary>
    /// The template's display name.
    /// </summary>
    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.WhatsappTemplateID;
        _ = this.AccountID;
        _ = this.AutoReplyAction;
        _ = this.Category;
        _ = this.Channel;
        _ = this.Language;
        _ = this.Reason;
        _ = this.TemplateID;
        _ = this.TemplateName;
    }

    public TemplateEventPayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateEventPayload(TemplateEventPayload templateEventPayload)
        : base(templateEventPayload) { }
#pragma warning restore CS8618

    public TemplateEventPayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateEventPayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateEventPayloadFromRaw.FromRawUnchecked"/>
    public static TemplateEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateEventPayloadFromRaw : IFromRawJson<TemplateEventPayload>
{
    /// <inheritdoc/>
    public TemplateEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateEventPayload.FromRawUnchecked(rawData);
}
