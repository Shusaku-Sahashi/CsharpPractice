using System;

namespace RefrectionPractice.Fundamental
{
    public class GetClassName
    {
        private Command command = new Command();
        
        public void GetInstanceName()
        {
            Console.WriteLine(command.GetType().Name);
        }

        public void GetTypeFromString()
        {
            var typeName = command.GetType().FullName + ", " + command.GetType().Assembly.GetName().Name;
            Console.WriteLine(Type.GetType(typeName));

            var assemblyName = command.GetType().AssemblyQualifiedName;
            Console.WriteLine(Type.GetType(assemblyName));

            var typeFullName = command.GetType().FullName;
            Console.WriteLine(Type.GetType(typeFullName));
        }
    }

    public class Command
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}