using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Reads one of your sender profiles.
///
/// <para>The document mirrors `POST /v3/sender-profiles`, with three differences
/// that follow from this being a read rather than a request.</para>
///
/// <para>`channels.sms` is a **list**. Create takes the one market a profile starts
/// in; a profile can go on to send in several, and this reports all of them, each
/// with its own `status`.</para>
///
/// <para>`compliance.brand` comes back **in full, with `inherit` saying whose it
/// is**. On a request `{ "inherit": true }` carries no data because there is nothing
/// to send; here it carries the data, because the point of a read is to say what
/// the profile actually sends under.</para>
///
/// <para>**There is no `campaigns` array.** Brand, campaign, and compliance documents
/// are reported at the profile root in `compliance`. A profile running on your organization's
/// campaign is asked for none of the campaign fields, so `compliance.campaign` carries
/// `{ "inherit": true }` with no campaign data.</para>
///
/// <para>`api_key` is **never** returned here. It is shown once, by create.</para>
///
/// <para>A profile belonging to another organization reads as `404`, not `403`: saying
/// which of the two it is would confirm the id exists.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SenderProfileRetrieveParams : ParamsBase
{
    public string? ID { get; init; }

    public SenderProfileRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileRetrieveParams(SenderProfileRetrieveParams senderProfileRetrieveParams)
        : base(senderProfileRetrieveParams)
    {
        this.ID = senderProfileRetrieveParams.ID;
    }
#pragma warning restore CS8618

    public SenderProfileRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SenderProfileRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SenderProfileRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v3/sender-profiles/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
