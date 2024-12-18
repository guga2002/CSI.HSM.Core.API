using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Payment
{
    public class PaymentMethod:AbstractEntity
    {
        public required string Method {  get; set; }
    }
}
