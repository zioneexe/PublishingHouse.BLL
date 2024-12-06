using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;

namespace PublishingHouse.BLL.Service
{
    public class PaymentService(IPrintOrderService orderService, IConfiguration configuration, IHttpClientFactory httpClientFactory) : IPaymentService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public async Task<double> CalculateTotalAmountAsync(int customerId)
        {
            var orders = await orderService.GetByCustomerIdAsync(customerId); 

            return orders.Sum(order => order.Price);
        }

        public async Task<string> SendPaymentRequestAsync(double amount, string cardNumber, int expMonth, int expYear, string cvv)
        {
            var publicKey = configuration["LiqPay:PublicKey"];
            var privateKey = configuration["LiqPay:PrivateKey"];
            var liqPayUrl = configuration["LiqPay:ServerUrl"];

            if (string.IsNullOrWhiteSpace(publicKey) || string.IsNullOrWhiteSpace(privateKey) ||
                string.IsNullOrWhiteSpace(liqPayUrl)) throw new ArgumentException("Configuration is missing or invalid.");

            var data = new
            {
                action = "pay",
                version = 3,
                public_key = publicKey,
                amount = amount,
                currency = configuration["LiqPay:Currency"],
                description = "Publishing House Payment",
                order_id = Guid.NewGuid().ToString(),
                card = cardNumber,
                card_exp_month = expMonth.ToString("D2"),
                card_exp_year = expYear.ToString("D2"),
                card_cvv = cvv
            };

            var json = JsonSerializer.Serialize(data);
            var base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var signature = GenerateSignature(privateKey, base64Data);

            var content = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("data", base64Data),
                new KeyValuePair<string, string>("signature", signature)
            ]);

            var response = await _httpClient.PostAsync(liqPayUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Payment request failed with status code: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 13 || cardNumber.Length > 19)
            {
                return false;
            }

            var sum = 0;
            var parity = cardNumber.Length % 2;

            for (var i = cardNumber.Length - 2; i >= 0; --i)
            {
                if (!char.IsDigit(cardNumber[i]))
                {
                    return false;
                }

                var digit = cardNumber[i] - '0';

                if (i % 2 == parity)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
            }

            return ((10 - (sum % 10)) % 10) == cardNumber[^1] - '0';
        }

        private static string GenerateSignature(string privateKey, string base64Data)
        {
            var input = Encoding.UTF8.GetBytes(privateKey + base64Data + privateKey);
            var hash = SHA1.HashData(input);
            return Convert.ToBase64String(hash);
        }
    }
}
