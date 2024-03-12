using ErrorOr;

namespace Domain.DomainErrors;
public static partial class Errors{
    public static class Events{
        public static Error AddressWithBadFormat=> 
        Error.Validation("Event.Address", "Address is not valid format.");
    }
}