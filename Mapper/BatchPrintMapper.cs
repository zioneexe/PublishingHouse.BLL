using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class BatchPrintMapper
    {
        public static IBatchPrint ToEntity(this BatchPrintInput input)
        {
            return new BatchPrint
            {
                Number = input.Number,
                BookQuantity = input.BookQuantity,
                OrderId = input.OrderId,
                PrintDate = input.PrintDate,
                QualityMarkId = input.QualityMarkId,
            };
        }

        public static BatchPrintOutput ToOutputModel(this IBatchPrint batchPrint)
        {
            return new BatchPrintOutput
            {
                BatchPrintId = batchPrint.BatchPrintId,
                Number = batchPrint.Number,
                BookQuantity = batchPrint.BookQuantity,
                OrderId = batchPrint.OrderId,
                PrintDate = batchPrint.PrintDate,
                QualityMarkId = batchPrint.QualityMarkId,
                CreateDateTime = batchPrint.CreateDateTime,
                UpdateDateTime = batchPrint.UpdateDateTime
            };
        }
    }
}
