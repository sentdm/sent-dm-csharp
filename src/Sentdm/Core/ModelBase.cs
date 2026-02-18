using System.Text.Json;
using Sentdm.Exceptions;
using Sentdm.Models.Brands;
using Campaigns = Sentdm.Models.Brands.Campaigns;

namespace Sentdm.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, EntityType>(),
            new ApiEnumConverter<string, IdentityStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, TcrBrandRelationship>(),
            new ApiEnumConverter<string, TcrVertical>(),
            new ApiEnumConverter<string, Campaigns::MessagingUseCaseUs>(),
            new ApiEnumConverter<string, Campaigns::SharingStatus>(),
            new ApiEnumConverter<string, Campaigns::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SentDmInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
