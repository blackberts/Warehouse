using Warehouse.Domain.Entities;

namespace Tests.AutoData
{
    public static class ProductData
    {
        public static List<Product> CreateProductList()
        {
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Monitor"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Brick"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wheel"
                },
                new Product()
                {
                    Id = new Guid("45120077-a72a-415a-902f-148d8074fc6a"),
                    Name = "Head"
                },
                new Product()
                {
                    Id = new Guid("e47eb715-ca10-4790-a022-da188c80b745"),
                    Name = "Fish"
                },
                new Product()
                {
                    Id = new Guid("212a1c5d-1ae4-4343-8dd3-8b9669f69e44"),
                    Name = "Mouse"
                },
            };

            return productList;
        }
    }
}
