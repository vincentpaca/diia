using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace EchoSystems.Common.Global
{
    /// <summary>
    /// ModuleRegistry contains module dlls of this application
    /// </summary>
    public class ModuleRegistry
    {
        private Hashtable m_types = new Hashtable();
        /// <summary>
        /// returns the available UIs
        /// </summary>
        /// <returns>IEnumerator of Module UIs</returns>
        public IEnumerator ModuleUIs()
        {
            return m_types.Values.GetEnumerator();
        }
        /// <summary>
        /// Gets the type given the name
        /// </summary>
        /// <param name="StringTypeName">name</param>
        /// <returns>type</returns>
        public Type GetTypeByName(string StringTypeName)
        {
            return m_types[StringTypeName] as Type;
        }
        /// <summary>
        /// returns the available UI names
        /// </summary>
        /// <returns>IEnumerator of Module UI Names</returns>
        public IEnumerator ModuleUINames()
        {
            return m_types.Keys.GetEnumerator();
        }
        /// <summary>
        /// Registers Modules
        /// </summary>
        /// <param name="file_name">file path of the dll</param>
        /// <returns>if successful</returns>
        public bool RegisterModuleTypes(string file_name)
        {
            Assembly new_assembly;
            Type[] types;
            new_assembly = Assembly.LoadFrom(file_name);
            types = new_assembly.GetTypes();
            foreach (Type t in types)
            {
                if (!t.IsAbstract)
                {
                    if (!m_types.ContainsValue(t))
                    {
                        if (!m_types.Contains(t.FullName))
                            m_types.Add(t.FullName, t);
                    }

                }
            }
            return true;
        }
        /// <summary>
        /// gets the object from a dll
        /// </summary>
        /// <param name="type_name">object path using namespace</param>
        /// <param name="param">parameter for the object</param>
        /// <param name="paramTypes">parameter types</param>
        /// <returns>object</returns>
        public Object CreateObject(string type_name, object[] param, Type[] paramTypes)
        {
            Type obj_type = null;
            ConstructorInfo ci = null;
            if (!m_types.Contains(type_name))
                return null;
            obj_type = (Type)m_types[type_name];
            try
            {
                ci = obj_type.GetConstructor(paramTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Object o;
            if (param != null)
                o = ci.Invoke(param);
            else
                o = ci.Invoke(null);

            return o;
        }
        /// <summary>
        /// gets the form from a dll
        /// </summary>
        /// <param name="type_name">form path using namespace</param>
        /// <param name="param">parameter for the form</param>
        /// <param name="paramTypes">parameter types</param>
        /// <returns>Form</returns>
        public Form CreateObject(string type_name, Type[] paramTypes, object[] param)
        {
            Type form_type = null;
            ConstructorInfo ci = null;
            if (!m_types.Contains(type_name))
                return null;
            form_type = (Type)m_types[type_name];
            try
            {
                ci = form_type.GetConstructor(paramTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Object o = ci.Invoke(param);
            return o as Form;
        }
        /// <summary>
        /// gets the object using name
        /// </summary>
        /// <param name="type_name">path name</param>
        /// <returns>object</returns>
        public Object CreateObject(string type_name)
        {
            Type form_type = null;
            ConstructorInfo ci = null;
            if (!m_types.Contains(type_name))
                return null;
            form_type = (Type)m_types[type_name];
            try
            {
                ci = form_type.GetConstructor(System.Type.EmptyTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Object o = ci.Invoke(null);
            return o;
        }
    }
}
