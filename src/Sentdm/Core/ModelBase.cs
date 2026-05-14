using System.Text.Json;
using Sentdm.Exceptions;
using Sentdm.Models.Profiles;
using Campaigns = Sentdm.Models.Profiles.Campaigns;

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
            new ApiEnumConverter<string, DataBrandComplianceBrandRelationship>(),
            new ApiEnumConverter<string, DataBrandComplianceVertical>(),
            new ApiEnumConverter<string, IdentityStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<
                string,
                ProfileRetrieveResponseDataBrandComplianceBrandRelationship
            >(),
            new ApiEnumConverter<string, ProfileRetrieveResponseDataBrandComplianceVertical>(),
            new ApiEnumConverter<string, ProfileRetrieveResponseDataBrandIdentityStatus>(),
            new ApiEnumConverter<string, ProfileRetrieveResponseDataBrandStatus>(),
            new ApiEnumConverter<
                string,
                ProfileUpdateResponseDataBrandComplianceBrandRelationship
            >(),
            new ApiEnumConverter<string, ProfileUpdateResponseDataBrandComplianceVertical>(),
            new ApiEnumConverter<string, ProfileUpdateResponseDataBrandIdentityStatus>(),
            new ApiEnumConverter<string, ProfileUpdateResponseDataBrandStatus>(),
            new ApiEnumConverter<string, ProfileBrandComplianceBrandRelationship>(),
            new ApiEnumConverter<string, ProfileBrandComplianceVertical>(),
            new ApiEnumConverter<string, ProfileBrandIdentityStatus>(),
            new ApiEnumConverter<string, ProfileBrandStatus>(),
            new ApiEnumConverter<string, BrandRelationship>(),
            new ApiEnumConverter<string, Vertical>(),
            new ApiEnumConverter<string, EntityType>(),
            new ApiEnumConverter<string, ProfileUpdateParamsBrandComplianceBrandRelationship>(),
            new ApiEnumConverter<string, ProfileUpdateParamsBrandComplianceVertical>(),
            new ApiEnumConverter<string, ProfileUpdateParamsBrandBusinessEntityType>(),
            new ApiEnumConverter<string, Campaigns::SharingStatus>(),
            new ApiEnumConverter<string, Campaigns::Status>(),
            new ApiEnumConverter<string, Campaigns::DataUseCaseMessagingUseCaseUs>(),
            new ApiEnumConverter<string, Campaigns::CampaignUpdateResponseDataSharingStatus>(),
            new ApiEnumConverter<string, Campaigns::CampaignUpdateResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Campaigns::CampaignUpdateResponseDataUseCaseMessagingUseCaseUs
            >(),
            new ApiEnumConverter<string, Campaigns::CampaignListResponseDataSharingStatus>(),
            new ApiEnumConverter<string, Campaigns::CampaignListResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Campaigns::CampaignListResponseDataUseCaseMessagingUseCaseUs
            >(),
            new ApiEnumConverter<string, Campaigns::MessagingUseCaseUs>(),
            new ApiEnumConverter<
                string,
                Campaigns::CampaignUpdateParamsCampaignUseCaseMessagingUseCaseUs
            >(),
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
