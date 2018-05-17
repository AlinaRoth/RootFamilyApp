using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Extensions
{
    public class DataAnnotationExtension
    {
        /// <summary>
        /// Gets the attribute from class property. Is nullable!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static T GetAttributeFrom<T>(object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T) property.GetCustomAttributes(attrType, false).FirstOrDefault();
        }
    }
}