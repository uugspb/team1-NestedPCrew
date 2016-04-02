using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hackathon
{
    public static class Assets
    {
        private static readonly string rootNamespace = typeof (Assets).Namespace;
        private static readonly string rootNamespaceWithDot = rootNamespace + ".";

        public static TObject Load<TObject, TEnum>(TEnum name)
            where TObject : Object
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Resources.Load<TObject>(GetPath(name));
        }

        public static T Load<T>() where T : Object
        {
            string fullName = GetCleanFullName<T>();
            return Resources.Load<T>(fullName);
        }

        private static string GetPath<TEnum>(TEnum name)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return GetCleanFullName<TEnum>() + "/" + name;
        }

        private static string GetCleanFullName<T>()
        {
            var type = typeof (T);
            return type.FullName.Replace(rootNamespaceWithDot, "").Replace(".", "/");
        }
    }
}