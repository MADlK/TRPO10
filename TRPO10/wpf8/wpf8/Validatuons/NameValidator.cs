using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpf8.Validatuons
{
    public class NameValidator: ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (value is string s)
            {
                if (s == String.Empty)
                    return new ValidationResult(false, "не может быть пустым");
                if (!Char.IsUpper(s[0]))
                {
                    return new ValidationResult(false, "Должно начинаться с буквы");
                }
                if (s.Length < 2)
                {
                    return new ValidationResult(false, "Имя не может быть из одной буквы");
                }

                for (int i = 0; i < s.Length - 1; i++)
                {

                    if (!Char.IsLetter(s[i]))
                    {
                        return new ValidationResult(false, "Имя не может содержать цифры или спец. символы");
                    }
                }

            }


            return ValidationResult.ValidResult;
        }
    }
}
