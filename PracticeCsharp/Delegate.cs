using System;

namespace PracticeCsharp
{
    internal class DelegateBasic
    {
        delegate void Process(string s); // デリゲートの定義。これを定義することでメソッドを格納できる様になる。
        
        private void Run(string s)
        {
            Console.WriteLine($"{s}走ります。");
        }

        internal void Do()
        {
            var p = new Process(Run); // メソッドの格納
            p("ちょこちょこ"); // 格納したメソッドの実行
        } 
    }

    internal class DelegaeUse
    {
        delegate void OutPutProcess(string str);

        public void Run()
        {
            var data = new[] {"hoge", "foo", "fuga"};
            ArrayWalk(data, AddQuote);
        }

        private void AddQuote(string data)
        {
            Console.WriteLine($"[{data}]");
        }

        private void ArrayWalk(string[] data, OutPutProcess process)
        {
            foreach (var value in data)
            {
                process(value);
            }
        }
    }
}