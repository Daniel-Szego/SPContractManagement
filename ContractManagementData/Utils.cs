using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ContractManagementData
{
    /// <summary>
    /// Zusätzliche Dienstleistungen.
    /// </summary>
    public class Utils
    {
    }

    /// <summary>
    /// Kopieren Funktionalität.
    /// </summary>
    public static class Copy
    {
        /// <summary>
        /// Kopieren die klasse Eingenschaftern auf der wrapper Eingenschaften.
        /// </summary>
        /// <param name="input">originelle Objekte</param>
        /// <returns>wrapper Objekte </returns>
        public static object CopyPropertyToWrapper(object input)
        {
            object newObject = null;
            Type oldType = input.GetType();
            string newTypeName = oldType.FullName + "Wrapper";
            Type newType = Type.GetType(newTypeName);
            if (newType != null)
            {
                newObject = Activator.CreateInstance(newType);
                foreach (PropertyInfo oldProp in oldType.GetProperties())
                {
                    foreach (PropertyInfo newProp in newType.GetProperties())
                    {
                        if(oldProp.Name.Equals(newProp.Name))
                        {
                            newProp.SetValue(newObject, oldProp.GetValue(input, null), null);
                        }   
                    }
                }
            }
            return newObject;
        }

        /// <summary>
        /// Kopieren die wrapper Eingenschaftern auf der klasse Eingenschaften.
        /// </summary>
        /// <param name="input">wrapper Objekte</param>
        /// <returns>entity Objekte</returns>
        public static object CopyPropertyFromWrapper(object input)
        {
            Type oldType = input.GetType();
            string newTypeName = oldType.FullName.Substring(0, oldType.FullName.Count() - 7);
            Type newType = Type.GetType(newTypeName);
            if (newType != null)
            {
                object newObject = Activator.CreateInstance(newType);
                foreach (PropertyInfo oldProp in oldType.GetProperties())
                {
                    foreach (PropertyInfo newProp in newType.GetProperties())
                    {
                        if (oldProp.Name.Equals(newProp.Name))
                        {
                            newProp.SetValue(newObject, oldProp.GetValue(input, null), null);
                        }
                    }
                }
            }
            return newType;
        }
    }
}
