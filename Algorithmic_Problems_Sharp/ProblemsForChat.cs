using System;
using System.Collections.Generic;
using System.Text;
using static Algorithmic_Problems_Sharp.WorkSpace;

namespace Algorithmic_Problems_Sharp
{
    internal class ProblemsForChat
    {
        //// Задача 1
        //[Flags]
        //public enum Status
        //{
        //    Funny = 0x01,
        //    Hilarious = 0x02,
        //    Boring = 0x04,
        //    Cool = 0x08,
        //    Interesting = 0x10,
        //    Informative = 0x20,
        //    Error = 0x40
        //}
        //var code = 24;
        //var q = (Status)code;
        //Console.WriteLine(String.Format("This Quiz is: {0}", (Status)code));


        //// Задача 2
        //var arr1 = Enumerable.Range(0, 100).Select(x => x * 2).ToArray();
        //var arr2 = arr1.TakeWhile(x => x % 2 == 0).Except(arr1).Select(x => x).ToArray();

        //Console.WriteLine(Enumerable.SequenceEqual(arr1, arr2));


        //// Задача 3
        /////static async void IterateAsync(int[] nums)
        //{
        //    await new Task(() => DoIterations(nums));
        //}

        //static void DoIterations(int[] nums)
        //{
        //    foreach (var num in nums)
        //    {
        //        Console.WriteLine(num);
        //    }
        //}

        //static async Task Main(string[] args)
        //{

        //    var nums = new int[500];
        //    for (int i = 0, j = 1; i < nums.Length; i++, j++)
        //    {
        //        nums[i] = j;
        //    }

        //    IterateAsync(nums);

        //    for (int i = 0; i < 500; i++)
        //    {
        //        Console.WriteLine("Main method");
        //    }

        //}



        //// Задача 4
        ////Для каждой строки массива: если у строки четный индекс - к этой строке приписывается "marked"; 
        ////если у строки нечетный индекс - она становится пустой. При выводе увидим только строки четных индексов с припиской "marked".

        //string[] strings = new string[] { "a", "b", "c", "d", "e", "f", "g" };
        //var output = strings.Select(s => Array.IndexOf(strings, s) % 2 == 0 ? s += " marked" : "");

        //foreach (var str in output)
        //{
        //    Console.Write(str + " ");
        //}

        //"a marked b c marked d e marked f g marked"
        //"a marked  c marked  e marked  g marked"
        //"a c e g"
        //"b marked  d marked  f marked"
        //Показать результат



        //// Задача 5
        //// Создается объект A, однако внутри он содержит члены класса B
        //// Вопрос со звездочкой: что выведется, если убрать модификаторы virtual, override и sealed?
        //A class!
        //B class!
        //Ошибка компиляции
        //Ошибка рантайма
        //Показать результат
        //class WorkSpace
        //{
        //    class A
        //    {
        //        internal virtual void DoWork()
        //        {
        //            Console.WriteLine("A class!");
        //        }
        //    }

        //    class B : A
        //    {
        //        internal sealed override void DoWork()
        //        {
        //            Console.WriteLine("B class!");
        //        }
        //    }

        //    static async Task Main(string[] args)
        //    {
        //        A a = new B();
        //        a.DoWork();
        //    }
        //}



        //// Задача 6
        //// Каков результат выполнения данного downcast?
        //Будет System.InvalidCastException во время рантайма, т.к.приводится такой Person, который не содержит в себе конкретного Student, и при этом приведение прописано без использования слова AS.

        // Null
        // Not null
        // Ошибка компиляции 
        // Ошибка рантайма 
        // Посмотреть результат

        //public class Person { }
        //public class Student : Person { }

        //Student student = (Student)new Person();

        //Console.WriteLine(student == null ? "Null" : "Not null");



        //// Задача 7
        ///// Что происходит в данном коде?
        //// При добавлении в список объекты упаковываются в object и помещаются в кучу; при приведении к int распаковываются и помещаются в стэк.

        // Только boxing
        // Только unboxing
        // Boxing, затем unboxing 
        // Unboxing, затем boxing
        // Посмотреть результат

        //var x = 25;
        //var y = 35;

        //List<object> digits = new List<object>() { x, y };

        //var result = (int)digits[0] + (int)digits[1];


        //// Задача 8
        // Enumerable.Intersect находит пересечение множеств, представленных двумя последовательностями, без вывода дубликатов.
        // Что будет выведено на консоль?
        // 1, 2, 3, 6, 7, 8
        // 4, 5
        // 4, 4, 5, 5
        // 4, 4, 4, 5, 5, 5
        // 1, 2, 3, 4, 5, 6, 7, 8
        // Показать результат

        //var arr1 = new int[] { 1, 2, 3, 4, 5 };
        //var arr2 = new int[] { 4, 4, 5, 5, 6, 7, 8 };

        //foreach (var num in arr1.Intersect(arr2))
        //{
        //    Console.Write(num + " ");
        //}


        //// Задача 9
        //// Каков результат выполнения программы?
        //// Ошибка рантайма: System.InvalidOperationException. При сортировке неявное приведение не производится.
        //// 1  2  a  b  c
        //// a  b  c  1  2
        //// 1  a  2  b  c
        //// Ошибка компиляции
        //// Ошибка рантайма 

        //object[] arr = new object[] {'a', 1, 'b', 2, 'c' };

        //Array.Sort(arr);

        //foreach (var obj in arr)
        //{
        //    Console.WriteLine(obj + " ");
        //}



        //// Задача 10
        //// Каков результат выполнения программы?
        // Ключевое слово out схоже с ref, но при использовании out необязательно использовать
        // заранее инициализированные переменные, и функция требует присвоения значения каждому аргументу out.
       
        // 15, 25
        // 0, 0
        // Ошибка компиляции
        // Ошибка времени выполнения 

        //void Method(out int num1, out int num2)
        //{
        //    num1 = 15;
        //    num2 = 25;
        //}

        //Method(out int x, out int y);

        //Console.WriteLine($"{x}, {y}");




        //// Задача 11
        //// Каков результат выполнения программы?



    }
}
