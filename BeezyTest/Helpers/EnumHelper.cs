using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BeezyTest.Helpers
{

    public static class EnumStringAttribute
    {
        public static string GetSearchValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            SearchValue[] attrs = fi.GetCustomAttributes(typeof(SearchValue), false) as SearchValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }
    }
    }


    public class SearchValue:Attribute
    {
        private string _value;
        
        public SearchValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }
    }

   
