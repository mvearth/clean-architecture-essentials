using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(null, name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(id, name, description, price, stock, image);
        }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public void Update(int? id, string name, string description, decimal price, int stock, string image, int? categoryId)
        {
            ValidateDomain(id, name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(int? id, string name, string description, decimal price, int Stock, string image)
        {
            ValidateAndSetId(id);
            ValidateAndSetName(name);
            ValidateAndSetDescription(description);
            ValidateAndSetPrice(price);
            ValidateAndSetStock(Stock);
            ValidateAndSetImage(image);
        }

        private void ValidateAndSetName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length <= 3, "Invalid name. Name is too short, minimum 3 chars");

            Name = name;
        }

        private void ValidateAndSetDescription(string description)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Invalid name. Name is required");

            DomainExceptionValidation.When(description.Length <= 3, "Invalid description. Description is too short, minimum 3 chars");

            Description = description;
        }

        private void ValidateAndSetPrice(decimal price)
        {
            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            Price = price;
        }

        private void ValidateAndSetStock(int stock)
        {
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            Stock = stock;
        }

        private void ValidateAndSetImage(string image)
        {
            DomainExceptionValidation.When(image.Length > 0, "Invalid image name. Too long, maximum 250 chars");
        }
    }
}
