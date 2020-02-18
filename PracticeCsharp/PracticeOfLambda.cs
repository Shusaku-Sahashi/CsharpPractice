using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PracticeCsharp
{
    public class PracticeOfLambda
    {
        public void Run()
        {
            Enumerable.Range(0, 10).ToList().ForEach(v => Console.WriteLine(v * v));
        }
    }
}