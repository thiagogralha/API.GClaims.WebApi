using API.GClaims.CrossCutting;

namespace API.GClaims.Domain.Exceptions
{
    public class UniversalErrorCode
    {
        private const char Constant = 'U';

        public static HandleErrorCode U000 => new HandleErrorCode
        {
            Code = $"{Constant}-001",
            Description = "Undefined error"
        };
    }
}
