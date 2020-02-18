using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeCsharp
{
    public class AsyncBase
    {
        public void Run()
        {
            Task<string> t = ReturnValueParallel(); // この下でawaitが呼ばれているので、処理は呼び出し下に戻る。
            Console.WriteLine("他の処理");
            t.Wait();
            Console.WriteLine(t.Result);
        }

         async Task RunAsync()
        {
            /**
             * Task.Runが呼ばれた時点で、呼びだし元に制御を戻す。（メインスレッド)
             * awaitが付いているので、Countが終わるまで処理を待機する。(サブスレッド）
             */
            await Task.Run(() => Count(1)); 
            Console.WriteLine("処理が終了しました。");
        }

         void Count(int n)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Task{n}: {i}");
            }
        }
        
         Task RunHeavyMethodParallel() // asyncじゃないけど、戻り値がTask
        {
            var tasks = new List<Task>(); // TaskをまとめるListを作成
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                var task = Task.Run(() => Count(x)); // HeavyMethodを開始するというTask
                tasks.Add(task); // を、Listにまとめる
            }
            return Task.WhenAll(tasks); // 全てのTaskが完了した時に完了扱いになるたった一つのTaskを作成
        } // 非同期メソッドではないが、戻り値がTaskなので、このメソッドは一つのタスクを表しているといえる。
        
        
         async Task<string> ReturnValueParallel() // asyncじゃないけど、戻り値がTask
        {
            var tasks = new List<Task>(); // TaskをまとめるListを作成
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                var task = Task.Run(() => Count(x)); // HeavyMethodを開始するというTask
                tasks.Add(task); // を、Listにまとめる
            }
            await Task.WhenAll(tasks); // 全てのTaskが完了した時に完了扱いになるたった一つのTaskを作成

            return "end";
        } // 非同期メソッドではないが、戻り値がTaskなので、このメソッドは一つのタスクを表しているといえる。
    }
}