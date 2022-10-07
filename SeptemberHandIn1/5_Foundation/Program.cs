using System;
using System.Collections.Generic;
using TextClassification.Controller;
using TextClassification.Domain;

namespace SeptemberHandIn1._5_Foundation
{
    class Program
    {
        // example of use 
        static void main(string[] args)
        {
            KnowledgeBuilder nb = new KnowledgeBuilder();

            // initiate the learning process

            nb.Train();

            // getting the (whole) knowledge found in ClassA and in ClassB
            Knowledge k = nb.GetKnowledge();


            // get a part of the knowledge - here just for debugging
            BagOfWords bof = k.GetBagOfWords();

            List<string> entries = bof.GetEntriesInDictionary();
            

            Console.WriteLine("Showing the list of entries in the BagOfWords (initially with wrong entries) :");
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
            
            Console.Read();
        }
    }
}
