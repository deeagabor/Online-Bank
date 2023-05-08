using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Utilities
{
    public static class ExistValue
    {
        public static bool find(this int[] array, int target)
        {
            return array.Contains(target);
        }
    }

    public class DepositPeriodAttribute:ValidationAttribute
    {
        private int[] array = { 1, 6, 12 };

        public override bool IsValid(object? value)
        {
            bool isExist = array.find((int)value);

            if (isExist)
                return true;
            else
                return false;
        }
    }
}
