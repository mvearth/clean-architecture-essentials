using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int? Id { get; protected set; }

        protected void ValidateAndSetId(int? id)
        {
            if (id is not null)
                DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greather than zero");

            Id = id;
        }
    }
}
