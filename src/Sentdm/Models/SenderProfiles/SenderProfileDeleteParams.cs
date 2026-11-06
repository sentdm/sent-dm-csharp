using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentdm.Core;

namespace Sentdm.Models.SenderProfiles;

/// <summary>
/// Deletes one of your sender profiles and returns `204`.
///
/// <para>The delete is **soft**: the profile stops being usable and stops appearing
/// in reads, and its message history is kept, because deleting a profile must not
/// delete the record of what it sent.</para>
///
/// <para>## What it releases</para>
///
/// <para>Anything the profile still held goes with it. A **phone number** returns
/// to our inventory and can be given to whoever asks next — it does not stay reserved
/// for you, and getting the same number back afterwards is not something we can promise.
/// A **WhatsApp account of its own** is deregistered from Meta. Its routing rules
/// stop being used, so nothing sends through the profile after this call.</para>
///
/// <para>A profile that only inherits from its organization holds nothing of its
/// own and releases nothing.</para>
///
/// <para>## When it is refused</para>
///
/// <para>A number the profile holds that your **WhatsApp Business Account still carries**
/// refuses the delete with a `409 CONFLICT_012`, and nothing is deleted: it would
/// return to our shared inventory while Meta still routes WhatsApp to it, and the
/// next customer given it could not register it at all. Only you can take it off
/// the account — deregister **and** delete it in WhatsApp Manager, then try again.
/// A `409 CONFLICT_013` means we could not read the account, so we cannot tell either way.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SenderProfileDeleteParams : ParamsBase
{
    public string? ID { get; init; }

    public SenderProfileDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderProfileDeleteParams(SenderProfileDeleteParams senderProfileDeleteParams)
        : base(senderProfileDeleteParams)
    {
        this.ID = senderProfileDeleteParams.ID;
    }
#pragma warning restore CS8618

    public SenderProfileDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderProfileDeleteParams(
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
    public static SenderProfileDeleteParams FromRawUnchecked(
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

    public virtual bool Equals(SenderProfileDeleteParams? other)
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
