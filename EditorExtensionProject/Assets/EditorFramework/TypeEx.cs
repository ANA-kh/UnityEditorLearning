using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace EditorFramework
{
    public static class TypeEx
    {
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.FullName.StartsWith("Unity") 
                                   && !assembly.FullName.StartsWith("Psd")
                                   && !assembly.FullName.StartsWith("vs"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(self));
        }
        
        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssemblies<TClassAttribute>(this Type self) where TClassAttribute : Attribute
        {
            return self.GetSubTypesInAssemblies()
                .Where(type => type.GetCustomAttribute<TClassAttribute>(true) != null);
        }
    }
}