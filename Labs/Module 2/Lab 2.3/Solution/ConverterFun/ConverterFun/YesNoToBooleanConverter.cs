using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ConverterFun
{
    [ValueConversion(typeof(string), typeof(bool?))]
    class YesNoToBooleanConverter : IValueConverter
    {
        Dictionary<string, TranslationElement> _translations;

        public YesNoToBooleanConverter()
        {
            _translations = new Dictionary<string, TranslationElement>
            {
                ["en"] = TranslationElement.English,
                ["de"] = new TranslationElement { Yes = "Ja", No = "Nein" },
                ["da"] = new TranslationElement { Yes = "Ja", No = "Nej" },
            };
        }

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if (!targetType.IsAssignableFrom(typeof(bool?)))
            {
                throw new InvalidOperationException("The target must be a boolean!");
            }

            TranslationElement te = GetTranslation(culture);

            string s = value.ToString().Trim();
            if (string.Compare(s, te.Yes) == 0)
            {
                return true;
            }
            else if (string.Compare(s, te.No) == 0)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if (!targetType.IsAssignableFrom(typeof(string)))
            {
                throw new InvalidOperationException("The target must be a string!");
            }

            TranslationElement te = GetTranslation(culture);

            if (value is bool?)
            {
                bool? b = (bool?)value;
                if (b.HasValue)
                {
                    return b.Value ? te.Yes : te.No;
                }
            }

            return Binding.DoNothing;
        }

        private TranslationElement GetTranslation( CultureInfo culture )
        {
            // Use English as a default if there are no translation element
            TranslationElement te = TranslationElement.English;

            string languageName = culture.TwoLetterISOLanguageName;
            if (_translations.ContainsKey(languageName))
            {
                te = _translations[languageName];
            }

            return te;
        }
    }
}
