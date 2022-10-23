namespace Novus.Payer1060.BusinessObjects.Utilities
{
    public static class MoneyUtilities
    {
        /// <summary>
        /// Removes the dollar signs and parenthesis from the string so that the values can be rolled up.
        /// Example $100 = 100, ($100) = -100
        /// </summary>
        /// <param name="money">The string to be converted to standard format.</param>
        /// <returns>Returns a string without the chars, or as is if they are not found.</returns>
        public static string FormatMoney(string money)
        {
            if (string.IsNullOrEmpty(money))
                return money;

            if (money.Length == 1)
            {
                money += ".00";
                return money;
            }
            if (!string.IsNullOrEmpty(money) && (money.Substring(0, 1) == "$"))
            {
                money = money.Replace("$", "");
                return money;
            }
            if (!string.IsNullOrEmpty(money) && (money.Substring(0, 2) == "($"))
            {
                money = money.Replace("($", "-").Replace(")", "");
                return money;
            }

            else
                return money;
        }

        /// <summary>
        /// Converts the amounts given into standard format or empty string.
        /// Example 1 = 0.01, 10 = 0.10, 100 = 1.00, 1000 = 10.00
        /// </summary>
        /// <param name="amount">The amount string to be converted to standard format.</param>
        /// <returns>Returns an amount string in standard format or empty string if invalid.</returns>
        public static string AmountFormat(string amount)
        {
            var newAmount = amount?.Trim() ?? string.Empty;
            if (newAmount.Length < 1)
                return string.Empty;

            amount = int.TryParse(newAmount, out var amt) ? (amt / 100.0).ToString("0.00") : string.Empty;

            return amount;
        }
    }
}
