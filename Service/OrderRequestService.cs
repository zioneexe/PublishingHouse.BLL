using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class OrderRequestService(IUnitOfWork unitOfWork) : IOrderRequestService
    {
        public async Task<IOrderRequest> GetByIdAsync(int id)
        {
            return await unitOfWork.OrderRequests.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IOrderRequest>> GetAllAsync()
        {
            return await unitOfWork.OrderRequests.GetAllAsync();
        }

        public async Task AddAsync(IOrderRequest entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderRequests.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IOrderRequest entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderRequests.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.OrderRequests.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            ArgumentNullException.ThrowIfNull(file, nameof(file));

            var filePath = await unitOfWork.OrderRequests.SaveFileAsync(file);
            await unitOfWork.CompleteAsync();

            return filePath;
        }

        public async Task<IEnumerable<IOrderRequest>> GetByCustomerIdAsync(int customerId)
        {
            return await unitOfWork.OrderRequests.GetByCustomerIdAsync(customerId);
        }

        public double CalculatePrice(IOrderRequest entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            var printTypePrices = new Dictionary<string, double>
            {
                { "Offset", 0.05 },
                { "Digital", 0.07 },
                { "Letterpress", 0.1 },
                { "Screen Printing", 0.12 }
            };

            var paperTypePrices = new Dictionary<string, double>
            {
                { "Glossy", 0.03 },
                { "Matte", 0.02 },
                { "Coated", 0.04 },
                { "Recycled", 0.01 }
            };

            var coverTypePrices = new Dictionary<string, double>
            {
                { "Softcover", 1.0 },
                { "Hardcover", 2.0 },
                { "Flexible", 1.5 }
            };

            var fasteningTypePrices = new Dictionary<string, double>
            {
                { "Perfect", 0.5 },
                { "Saddle Stitching", 0.3 },
                { "Spiral", 0.4 },
                { "Case", 1.0 }
            };

            if (entity.PrintType == null || entity.PaperType == null || entity.CoverType == null ||
                entity.FasteningType == null || entity.IsLaminated == null)
            {
                throw new ArgumentException("Requires order options missing.");
            }

            const double laminationCost = 0.5;

            if (!printTypePrices.TryGetValue(entity.PrintType, out var printCost))
            {
                throw new ArgumentException($"Invalid print type: {entity.PrintType}");
            }

            if (!paperTypePrices.TryGetValue(entity.PaperType, out var paperCost))
            {
                throw new ArgumentException($"Invalid paper type: {entity.PaperType}");
            }

            if (!coverTypePrices.TryGetValue(entity.CoverType, out var coverCost))
            {
                throw new ArgumentException($"Invalid cover type: {entity.CoverType}");
            }

            if (!fasteningTypePrices.TryGetValue(entity.FasteningType, out var fasteningCost))
            {
                throw new ArgumentException($"Invalid fastening type: {entity.FasteningType}");
            }

            var laminationExtraCost = (entity.IsLaminated ?? false) ? laminationCost : 0;

            var costPerBook = printCost + paperCost + coverCost + fasteningCost + laminationExtraCost;
            var totalCost = costPerBook * entity.Quantity;

            return totalCost;
        }
    }
}
