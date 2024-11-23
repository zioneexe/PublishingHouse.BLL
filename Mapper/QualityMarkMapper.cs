using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class QualityMarkMapper
    {
        public static IQualityMark ToEntity(this QualityMarkInput input)
        {
            return new QualityMark
            {
                Name = input.Name,
            };
        }

        public static QualityMarkOutput ToOutputModel(this IQualityMark qualityMark)
        {
            return new QualityMarkOutput
            {
                QualityMarkId = qualityMark.QualityMarkId,
                Name = qualityMark.Name,
                CreateDateTime = qualityMark.CreateDateTime,
                UpdateDateTime = qualityMark.UpdateDateTime
            };
        }
    }
}
