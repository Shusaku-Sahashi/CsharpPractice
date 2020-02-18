using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExceptionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeToBinary();
            DeSerializeFromBinary();
        }

        static void SerializeToBinary()
        {
            using var stream = new FileStream("./data_file.dat", FileMode.Create);
            var formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(stream, new CustomException("Serialization時にError発生", "{\"Name\":\"太郎\"}"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void DeSerializeFromBinary()
        {
            using var stream = new FileStream("./data_file.dat", FileMode.Open);
            var formatter = new BinaryFormatter();

            CustomException exception = null;
            try
            {
                exception = formatter.Deserialize(stream) as CustomException;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (exception != null) Console.WriteLine(exception.Message);
            if (exception != null) Console.WriteLine(exception.ObjectGraph);
        }
    }
}