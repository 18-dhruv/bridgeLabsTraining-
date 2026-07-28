using System;



namespace Strings
{
    
    public class Str
    {
        
        public static int count(String s)
        {
            char[] arr = s.ToCharArray();
            return arr.Length;
        }
        public static void sentence()
        {
            var sentence = Console.ReadLine();
            string[] arr = sentence.Split(" ");
            int max = 0;
            string a = "ghj";
            foreach(string s in arr)
            {
                if (count(s) > max)
                {
                    max = Math.Max(count(s), max);
                    a = s;
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(a);
        }
        
        
        
    }
}

