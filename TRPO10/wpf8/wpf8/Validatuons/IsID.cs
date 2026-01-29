using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpf8.Validatuons
{
    public class IsID : ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (value is string s)
            {
                if (s == String.Empty)
                    return new ValidationResult(false, "не может быть пустым");
                for (int i = 0; i < 11; i++)
                {
                    if (!Char.IsNumber(s[i]))
                    {
                        return new ValidationResult(false, "ID должен состоять из цифр");
                    }
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
