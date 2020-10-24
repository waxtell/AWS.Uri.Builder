using System;

namespace AWS.Uri.Builder.Extensions
{
    internal static class EnumExtensions
    {
        public static string TryGetName<TEnum>(this TEnum @enum) where TEnum : struct
        {
            try
            {
                var enumName = Enum.GetName(typeof(TEnum), @enum);

                return enumName;
            }
            catch
            {
                // ignore
            }

            return null;
        }
    }
}
