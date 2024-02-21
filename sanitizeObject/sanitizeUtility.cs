using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sanitizeObject;
    public class ObjectSanitizer
    {
    private readonly Regex SanitizeRegex;
    public ObjectSanitizer()
    {
        SanitizeRegex = new Regex("[^a-zA-Z0-9 .]");
    }

        public void Sanitize<T>(T obj) where T : class
        {

            if (obj == null)
                return;

            Type objType = obj.GetType();
            if (!objType.IsClass)
            {
                throw new ArgumentException("Input must be a class type object.");
            }

              Console.WriteLine($"Object of Class \"{objType.Name}\"");
  var listobj=new List<object>();
            Sanitizer(listobj,obj);
        }
            private  void Sanitizer<T>(List<object> objlist,T obj) where T : class
        {



            if (obj == null)
                return;

        if (objlist.Contains(obj))
        {
            return;
        }
        objlist.Add(obj);


            Type objType = obj.GetType();
            if (!objType.IsClass)
            {
                throw new ArgumentException("Input must be a class type object.");
            }

           //  Console.WriteLine($"Object of Class \"{objType.Name}\"");

            foreach (PropertyInfo property in objType.GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string originalValue = (string)property.GetValue(obj);
                    string sanitizedValue = SanitizeString(originalValue);
                    //Console.WriteLine($"{property.Name} = \"{sanitizedValue}\"");
                    property.SetValue(obj, sanitizedValue);
                }
                else if (property.PropertyType.IsClass && property.PropertyType != typeof(object))
                {
                    object nestedObj = property.GetValue(obj);
                     Sanitizer(objlist, nestedObj);
                }
            }
        }

        public void SanitizeAndReplaceEveryThirdCharacter<T>(T obj) where T : class
        {
            if (obj == null)
                return;

            Type objType = obj.GetType();
            if (!objType.IsClass)
            {
                throw new ArgumentException("Input must be a class type object.");
            }

            //Console.WriteLine($"Object of Class \"{objType.Name}\"");

            foreach (PropertyInfo property in objType.GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string originalValue = (string)property.GetValue(obj);
                    string sanitizedValue = SanitizeAndReplaceEveryThirdCharacterString(originalValue);
                    //Console.WriteLine($"{property.Name} = \"{sanitizedValue}\"");
                    property.SetValue(obj, sanitizedValue);
                }
                else if (property.PropertyType.IsClass && property.PropertyType != typeof(object))
                {
                    object nestedObj = property.GetValue(obj);
                    SanitizeAndReplaceEveryThirdCharacter(nestedObj);
                }
            }
        }

        private  string SanitizeString(string input)
        {
            return SanitizeRegex.Replace(input, "");
        }

        private  string SanitizeAndReplaceEveryThirdCharacterString(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 2; i < charArray.Length; i += 3)
            {
                charArray[i] = ' ';
            }
            return new string(charArray);
        }
    }

