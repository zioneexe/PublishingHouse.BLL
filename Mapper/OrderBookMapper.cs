using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class OrderBookMapper
    {
        public static IOrderBook ToEntity(this OrderBookInput input)
        {
            return new OrderBook
            {
                OrderId = input.OrderId,
                BookId = input.BookId,
                BookQuantity = input.BookQuantity
            };
        }

        public static OrderBookOutput ToOutputModel(this IOrderBook orderBook)
        {
            return new OrderBookOutput
            {
                OrderBooksId = orderBook.OrderBooksId,
                OrderId = orderBook.OrderId,
                BookId = orderBook.BookId,
                BookQuantity = orderBook.BookQuantity,
                CreateDateTime = orderBook.CreateDateTime,
                UpdateDateTime = orderBook.UpdateDateTime
            };
        }
    }
}
