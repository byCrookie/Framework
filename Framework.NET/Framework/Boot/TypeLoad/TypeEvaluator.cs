using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac.Util;

namespace Framework.Boot.TypeLoad
{
    internal class TypeEvaluator : ITypeEvaluator
    {
        public IEnumerable<Type> EvaluateTypes(Assembly assembly)
        {
            try
            {
                return Load(assembly);
            }
            catch (Exception ex)
            {
                throw new TypeLoadException("Loading types failed. " + ex.Message);
            }
        }

        private static IEnumerable<Type> Load(Assembly assembly)
        {
            return assembly.GetLoadableTypes();
        }
    }
}