using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15_HW
{


    
    class MyClass
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }

    

    class Program
    {
        
        static void Main()
        {
            //1
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            
            //2
            MyClass myObject = new MyClass();
            myObject.MyProperty1 = 42;
            myObject.MyProperty2 = "Hello, Reflection!";
            Type myType = myObject.GetType();
            PropertyInfo[] properties = myType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(myObject)}");
            }
            string myString = "Hello, Reflection!";

            
            //3
            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            string result = (string)substringMethod.Invoke(myString, new object[] { 0, 5 });
            Console.WriteLine(result);


            
            //4
            Type listType = typeof(List<>);
            ConstructorInfo[] constructors = listType.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }

        }
    }
}
}
