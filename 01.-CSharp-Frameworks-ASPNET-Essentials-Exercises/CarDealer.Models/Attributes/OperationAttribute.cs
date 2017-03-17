namespace CarDealer.Models.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class OperationAttribute : ValidationAttribute

    {
        public override bool IsValid(object value)
        {
            string opeartionValue = value.ToString();

            if (opeartionValue == "Add" || opeartionValue == "Delete" || opeartionValue == "Edit")
            {
                return true;
            }

            return false;
        }
    }
}
