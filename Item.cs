using System;

namespace OneListClientReDo
{
    public class Item
    {
        // not in Pascal case - ruby convention not C#
    // If you trust the api then let the information be converted by the method
        public int id { get; set; }
        public string text { get; set; }
        public bool complete { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public string CompletedStatus 
        {
            // custom "get" for a property about to be a turnery.
            get {
                // TURNERY statement
                // return Boolean expression ? value when true : value when false; <-- inline if/else
                return complete ? "Completed" : "Not Completed";
            //     if (complete == true)
            //     {
            //         return "Completed";
            //     }
            //     else
            //     {
            //         return "Not completed";
            //     }
            }
        }
    }
}