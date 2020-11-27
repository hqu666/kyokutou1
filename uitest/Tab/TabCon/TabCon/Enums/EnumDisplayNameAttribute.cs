using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace TabCon.Enums
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute(string name)
        {
            this.name = name;
        }

        private string name;
        public string Name { get { return GetName(CultureInfo.CurrentCulture); } }
        public string GetName(CultureInfo culture)
        {
            return this.name;
        }
    }

    public class EnumDisplayNameConverter : EnumConverter
    {
        public EnumDisplayNameConverter(Type type)
            : base(type)
        { }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var v = value as string;
            if (null != v)
            {
                foreach (var field in base.EnumType.GetFields())
                {
                    var name = this.GetDisplayName(field, culture);
                    if (v == name)
                        return field.GetValue(null);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value == null)
                {
                    return null;
                }
                var valueName = Enum.GetName(base.EnumType, value);
                if (null != valueName)
                {
                    var field = base.EnumType.GetField(valueName);
                    var name = this.GetDisplayName(field, culture);
                    if (null != name)
                        return name;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private string GetDisplayName(FieldInfo field, CultureInfo culture)
        {
            if (null == field) return null;
            var type = typeof(EnumDisplayNameAttribute);
            var attribute = Attribute.GetCustomAttribute(field, type);
            return (null == attribute as EnumDisplayNameAttribute) ? null : (attribute as EnumDisplayNameAttribute).GetName(culture);
        }
    }
}
