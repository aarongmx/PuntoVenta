using Avalonia.Data;
using Avalonia.Data.Converters;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaViews.Converters
{
    public class FormaPagoConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string sourceText && parameter is string targetCase && targetType.IsAssignableTo(typeof(string)))
            {
                switch (targetCase)
                {
                    case "upper":
                    case "SQL":
                        return sourceText.ToUpper();
                    case "lower":
                        return sourceText.ToLower();
                    case "title": // Every First Letter Uppercase
                        var txtinfo = new System.Globalization.CultureInfo("en-US", false)
                                        .TextInfo;
                        return txtinfo.ToTitleCase(sourceText);
                    default:
                        // invalid option, return the exception below
                        break;
                }
            }

            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
