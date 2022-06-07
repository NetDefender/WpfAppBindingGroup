using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfAppPerformance
{
    public sealed class ValidationMain : ValidationRule
    {
        public ValidationMain(Func<BindingGroup, string> validationLogic)
        {
            ValidationLogic = validationLogic;
            ValidationStep = ValidationStep.ConvertedProposedValue;
        }

        public Func<BindingGroup, string> ValidationLogic
        {
            get;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup binding = (BindingGroup)value;
            string error = ValidationLogic(binding);
            if (!string.IsNullOrEmpty(error))
            {
                return new ValidationResult(false, error);
            }

            return ValidationResult.ValidResult;
        }
    }
}
