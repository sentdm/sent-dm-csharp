using System.Text.Json;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;
using Campaigns = Sentdm.Models.Profiles.Campaigns;
using Rcs = Sentdm.Models.Channels.Rcs;
using Sms = Sentdm.Models.Channels.Sms;
using Voice = Sentdm.Models.Channels.Voice;
using Whatsapp = Sentdm.Models.Channels.Whatsapp;

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
            new ApiEnumConverter<string, Campaigns::Status>(),
            new ApiEnumConverter<string, Campaigns::MessagingUseCaseUs>(),
            new ApiEnumConverter<string, Sms::EntityType>(),
            new ApiEnumConverter<string, Sms::UseCaseUseCase>(),
            new ApiEnumConverter<string, Sms::Status>(),
            new ApiEnumConverter<string, Sms::NumberType>(),
            new ApiEnumConverter<string, Rcs::Status>(),
            new ApiEnumConverter<string, Rcs::AgentUseCase>(),
            new ApiEnumConverter<string, Whatsapp::Status>(),
            new ApiEnumConverter<string, Voice::Status>(),
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
    /// <exception cref="SentInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
