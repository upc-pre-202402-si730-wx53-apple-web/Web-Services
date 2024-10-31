using DebtGo.IAM.Interfaces.REST.Resources;
using DebtGo.IAM.Domain.Model.Commands;
using System.Globalization;
using Microsoft.VisualBasic;

namespace DebtGo.IAM.Interfaces.REST.Transform
{
    public class SignUpCommandFromResourceAssembler
    {
        public static SignUpCommand ToCommandFromResource(SignUpResource resource)
        {
            if (!DateTime.TryParseExact(
                    resource.ExpiryDate,
                    "MM-yy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var parsedDate))
                throw new ArgumentException("Invalid Expiry Date format. Expected format: MM-yy");


            return new SignUpCommand(
                resource.Name,
                resource.Email,
                resource.Password,
                resource.CardNumber,
                parsedDate,
                resource.CVV);
        }
    }
}