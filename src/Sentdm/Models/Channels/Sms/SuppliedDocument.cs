using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentdm.Core;

namespace Sentdm.Models.Channels.Sms;

/// <summary>
/// A document a market asked for and has been given.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuppliedDocument, SuppliedDocumentFromRaw>))]
public sealed record class SuppliedDocument : JsonModel
{
    /// <summary>
    /// Identifier of the upload, for fetching it back through the documents endpoints.
    /// </summary>
    public string? DocumentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_id");
        }
        init { this._rawData.Set("document_id", value); }
    }

    public string? FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    /// <summary>
    /// The catalog's name for this document, matching the requirement it satisfies.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentID;
        _ = this.FileName;
        _ = this.Key;
    }

    public SuppliedDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuppliedDocument(SuppliedDocument suppliedDocument)
        : base(suppliedDocument) { }
#pragma warning restore CS8618

    public SuppliedDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SuppliedDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SuppliedDocumentFromRaw.FromRawUnchecked"/>
    public static SuppliedDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SuppliedDocumentFromRaw : IFromRawJson<SuppliedDocument>
{
    /// <inheritdoc/>
    public SuppliedDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SuppliedDocument.FromRawUnchecked(rawData);
}
