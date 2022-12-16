using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public abstract class StringConverter
    {
        private static Dictionary<Type, StringConverter> ConverterMap = new Dictionary<Type, StringConverter>()
        {
            {typeof(Rect),new RectStringConverter()},
            {typeof(string),new StringStringConverter()},
            {typeof(bool),new BooleanStringConverter()}
        };

        public static StringConverter<T> Get<T>()
        {
            if (ConverterMap.TryGetValue(typeof(T), out var t))
            {
                return t as StringConverter<T>;
            }

            return default;
        }
    }
    public abstract class StringConverter<T> : StringConverter
    {
        public virtual string ConvertToString(T t)
        {
            return t.ToString();
        }

        public abstract bool TryConvert(string self, out T result);
    }
}