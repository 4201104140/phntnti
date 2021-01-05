using System;
using Microsoft.TimeoutManager;

namespace TimeoutManager.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var a = new TimeoutManagerFactory().CreateTimeoutManager<Test>(0);
            var b = new Test() { Id = 1, Name = "Tai" };
            Console.WriteLine(a.CountTimeout(b));
            Console.WriteLine(a.CountTimeout(b));
        }
    }

    public class Test
    {
        public int Id;
        public string Name;
    }
}
