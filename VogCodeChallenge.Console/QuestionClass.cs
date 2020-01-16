using System;
using System.Collections.Generic;

namespace VogCodeChallenge.ConsoleQuestion
{
    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "jeffrey"
        };

        public static void TestQuestion()
        {
            //using (var enumerator = NamesList.GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        Console.WriteLine(enumerator.Current);
            //    }
            //}

            //easier way
            foreach (var item in NamesList)
            {
                Console.WriteLine(item);
            }

            //faster way
            for (int i = 0; i < NamesList.Count; i++)
            {
                Console.WriteLine(NamesList[i]);
            }
        }
    }

}
