using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpf8.Validatuons
{
    class IsPhone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (value is string s)
            {
                if (s[0] != '8')
                {
                    return new ValidationResult(false, "Должно начинаться с \'8\'");
                }
                if (s.Length > 11)
                {
                    return new ValidationResult(false, "Номер слишком длинный");
                }
                if (s.Length < 11)
                {
                    return new ValidationResult(false, "Номер короткий");
                }
                
                for(int i = 1; i<11;i++)
                {

                    if (!Char.IsNumber(s[i]))
                    {
                        return new ValidationResult(false, "Номер должен состоять из цифр");
                    }
                }
                
            }
            
            
            return ValidationResult.ValidResult;
        }
    }
}
