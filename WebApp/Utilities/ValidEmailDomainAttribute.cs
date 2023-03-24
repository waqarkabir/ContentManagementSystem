using System.ComponentModel.DataAnnotations;

namespace WebApp.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
          string[] strings = value.ToString().Split('@');

            if (strings[1].ToUpper() == allowedDomain.ToUpper())
            { 
                return true;
            }

            return false;
        }
    }
}
