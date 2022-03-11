using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int? Id { get; private set; }

        public string Name { get; private set; }

        public Category(string? name)
        {
            ValidateDomain(null, name);
        }

        public Category(int? id, string name)
        {
            ValidateDomain(id, name);
        }

        public ICollection<Product> Products { get; set; }

        public void UpdateName(string name) => ValidateAndSetName(name);

        private void ValidateDomain(int? id, string name)
        {
            ValidateAndSetId(id);
            ValidateAndSetName(name);
        }

        private void ValidateAndSetId(int? id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greather than zero");

            Id = id;
        }

        private void ValidateAndSetName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length <= 3, "Invalid name. Name is too short, minimum 3 chars");

            Name = name;
        }
    }
}
