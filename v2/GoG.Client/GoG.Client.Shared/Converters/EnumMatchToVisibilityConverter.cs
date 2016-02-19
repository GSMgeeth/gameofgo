﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GoG.Client.Converters
{
    /// <summary>
    /// A converter that matches an enum value against a list of members of that enum
    /// and produces a Visibility value as the conversion result.
    /// </summary>
    public class EnumMatchToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Matches an enum value against a list of members of that enum. 
        /// If a match is found then the converter produces the value Visibility.Visible. Otherwise it produces the value Visibility.Collapsed.
        /// Example of usage: 
        ///     Visibility="{Binding Day, Converter={StaticResource EnumMatchToVisibleConverter}, ConverterParameter=Sunday;Saturday}"
        /// </summary>
        /// <param name="value">A member of any enumeration type</param>
        /// <param name="parameter">
        /// A semicolon delimited list containing the string representation of the enumeration values that will be matched against value.
        /// </param>
        /// <returns>
        /// Visibility.Visible if a match is found between value and an item in the list specified by parameter.
        /// Visibility.Collapsed otherwise.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ConvertersUtils.EnumValueMatches(value, parameter.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// ConvertBack is not supported. It will throw a NotSupportedException if invoked.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}