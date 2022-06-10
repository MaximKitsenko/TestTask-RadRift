// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace RadRiftGame
{
     class Program
    {
        
        class A { }
        class B : A { }
 
        static void Print<T>(T t)
        {
            Console.Write(typeof(T).Name); //  
            Console.Write(t.GetType().Name); // 
        }
 
        static void Main()
        {
            A obj = new B();
            Print(obj); // Print(obj); ~ Print<A>(obj);
            Print(new B());
            Print(42);
            Print(4.2);
            Print("42");
            Print(new A[]{new B()});
        }
        
        //  static void Main(string[] args)
        // {
        //     // object  x = 5;
        //     // object o = x;
        //     // x = 10;
        //     // var y = (int)o;
        //     // Console.Write(y);
        // }

        public static void MergeSortedArrays( List<int> listA, List<int> listB)
        {
            var listAEnumerator = listA.GetEnumerator();
            var listBEnumerator = listB.GetEnumerator();
            var listAB = new List<int>(listA.Count + listB.Count);
            
            // todo: check for empty lists;
            
            var canContinueA = true;
            var canContinueB = true;
            
            listAEnumerator.MoveNext();
            listBEnumerator.MoveNext();
            
            while (canContinueA && canContinueB)
            {
                var takeFormA = listAEnumerator.Current < listBEnumerator.Current;
                if (takeFormA)
                {
                    listAB.Add(listAEnumerator.Current);
                    canContinueA = listAEnumerator.MoveNext();
                }
                else
                {
                    listAB.Add(listBEnumerator.Current);
                    canContinueB = listBEnumerator.MoveNext();
                }
            }
            
            while (canContinueA)
            {
                listAB.Add(listAEnumerator.Current);
                canContinueA = listAEnumerator.MoveNext();
            }
            
            while (canContinueB)
            {
                listAB.Add(listAEnumerator.Current);
                canContinueB = listBEnumerator.MoveNext();
            }
        }
    }
}