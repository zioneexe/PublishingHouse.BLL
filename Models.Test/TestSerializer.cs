using PublishingHouse.Domain.Models.Repository;

namespace PublishingHouse.Domain.Models.Test
{
    [TestClass]
    public class TestSerializer
    {
        [TestMethod]
        public void TestMethodSerializeXml()
        {
            var model = new DataModel
            {
                Employees = (List<Employee>)
                [
                    new Employee
                    {
                        Name = "John Doe", Position = "Operator", Email = "john@example.com", Phone = "123-456-7890"
                    },
                    new Employee
                    {
                        Name = "Jane Smith", Position = "Technician", Email = "jane@example.com", Phone = "987-654-3210"
                    },
                    new Employee
                    {
                        Name = "Alice Brown", Position = "Designer", Email = "alice@example.com", Phone = "555-555-5555"
                    }
                ],
                Books = (List<Book>)
                [
                    new Book
                    {
                        Name = "C# in Depth", Author = "Jon Skeet", Isbn = 1234567890, PublicationYear = 2019,
                        Pages = 900
                    },
                    new Book
                    {
                        Name = "Clean Code", Author = "Robert C. Martin", Isbn = 9876543210, PublicationYear = 2008,
                        Pages = 464
                    }
                ],
                Customers = (List<Customer>)
                [
                    new Customer { Name = "Acme Corp", AddressDate = DateTime.Now.AddYears(-2), Email = "info@acme.com" },
                    new Customer
                    {
                        Name = "John Smith", AddressDate = DateTime.Now.AddYears(-1), Email = "john.smith@example.com"
                    }
                ],
                Orders = (List<Order>)
                [
                    new Order
                    {
                        Number = "ORD-001",
                        Description = "Black & White book printing",
                        Status = OrderStatus.Completed,
                        Price = 150.00,
                        Book = new Book
                        {
                            Name = "C# in Depth", Author = "Jon Skeet", Isbn = 1234567890, PublicationYear = 2019,
                            Pages = 900
                        },
                        Employee = new Employee { Name = "John Doe", Position = "Operator" },
                        Customer = new Customer { Name = "Acme Corp", AddressDate = DateTime.Now.AddYears(-2) },
                        RegistrationDate = DateTime.Now.AddMonths(-3),
                        CompletionDate = DateTime.Now.AddDays(-10)
                    },

                    new Order
                    {
                        Number = "ORD-002",
                        Description = "Color book printing",
                        Status = OrderStatus.InProgress,
                        Price = 200.00,
                        Book = new Book
                        {
                            Name = "Clean Code", Author = "Robert C. Martin", Isbn = 9876543210, PublicationYear = 2008,
                            Pages = 464
                        },
                        Employee = new Employee { Name = "Jane Smith", Position = "Technician" },
                        Customer = new Customer { Name = "John Smith", AddressDate = DateTime.Now.AddYears(-1) },
                        RegistrationDate = DateTime.Now.AddMonths(-1),
                        CompletionDate = DateTime.Now.AddMonths(1)
                    }
                ]
            };


            foreach (var book in model.Books)
            {
                book.Pages = 10;
            }

            var xmlRepository = new XmlDataRepository(@"D:\publishingHouse.dat");
            xmlRepository?.SaveDataAsync(model);
        }

        [TestMethod]
        public void TestMethodDeserializeXml()
        {
            var xmlRepository = new XmlDataRepository(@"D:\publishingHouse.dat");
            xmlRepository?.LoadDataAsync();
        }

        [TestMethod]
        public void TestMethodSerializeJson()
        {
            var model = new DataModel
            {
                Employees = (List<Employee>)
                [
                    new Employee
                    {
                        Name = "John Doe", Position = "Operator", Email = "john@example.com", Phone = "123-456-7890"
                    },
                    new Employee
                    {
                        Name = "Jane Smith", Position = "Technician", Email = "jane@example.com", Phone = "987-654-3210"
                    },
                    new Employee
                    {
                        Name = "Alice Brown", Position = "Designer", Email = "alice@example.com", Phone = "555-555-5555"
                    }
                ],
                Books = (List<Book>)
                [
                    new Book
                    {
                        Name = "C# in Depth", Author = "Jon Skeet", Isbn = 1234567890, PublicationYear = 2019,
                        Pages = 900
                    },
                    new Book
                    {
                        Name = "Clean Code", Author = "Robert C. Martin", Isbn = 9876543210, PublicationYear = 2008,
                        Pages = 464
                    }
                ],
                Customers = (List<Customer>)
                [
                    new Customer { Name = "Acme Corp", AddressDate = DateTime.Now.AddYears(-2), Email = "info@acme.com" },
                    new Customer
                    {
                        Name = "John Smith", AddressDate = DateTime.Now.AddYears(-1), Email = "john.smith@example.com"
                    }
                ],
                Orders = (List<Order>)
                [
                    new Order
                    {
                        Number = "ORD-001",
                        Description = "Black & White book printing",
                        Status = OrderStatus.Completed,
                        Price = 150.00,
                        Book = new Book
                        {
                            Name = "C# in Depth", Author = "Jon Skeet", Isbn = 1234567890, PublicationYear = 2019,
                            Pages = 900
                        },
                        Employee = new Employee { Name = "John Doe", Position = "Operator" },
                        Customer = new Customer { Name = "Acme Corp", AddressDate = DateTime.Now.AddYears(-2) },
                        RegistrationDate = DateTime.Now.AddMonths(-3),
                        CompletionDate = DateTime.Now.AddDays(-10)
                    },

                    new Order
                    {
                        Number = "ORD-002",
                        Description = "Color book printing",
                        Status = OrderStatus.InProgress,
                        Price = 200.00,
                        Book = new Book
                        {
                            Name = "Clean Code", Author = "Robert C. Martin", Isbn = 9876543210, PublicationYear = 2008,
                            Pages = 464
                        },
                        Employee = new Employee { Name = "Jane Smith", Position = "Technician" },
                        Customer = new Customer { Name = "John Smith", AddressDate = DateTime.Now.AddYears(-1) },
                        RegistrationDate = DateTime.Now.AddMonths(-1),
                        CompletionDate = DateTime.Now.AddMonths(1)
                    }
                ]
            };


            foreach (var book in model.Books)
            {
                book.Pages = 10;
            }

            var jsonRepository = new JsonDataRepository(@"D:\publishingHouse.dat");
            jsonRepository?.SaveDataAsync(model);
        }

        [TestMethod]
        public void TestMethodDeserializeJson()
        {
            var jsonRepository = new JsonDataRepository(@"D:\publishingHouse.dat");
            jsonRepository?.LoadDataAsync();
        }
    }
}