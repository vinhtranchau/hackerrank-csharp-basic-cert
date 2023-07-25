using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        public IDictionary<string,string> noteCollection = new Dictionary<string, string>();
        
        public NotesStore() {}
        public void AddNote(String state, String name) {
            if(name == ""){
                throw new Exception("Name cannot be empty");
            }else if(state != "completed" && state != "active" && state != "others")
            {
                throw new Exception($"Invalid state {state}");
            }else
            {
                noteCollection.Add(name, state);
            }
            
        }
        public List<String> GetNotes(String state) {
            List<string> li = new List<string>();
            if(state != "completed" && state != "active" && state != "others")
            {
                throw new Exception($"Invalid state {state}");
            }else
            {
                foreach(KeyValuePair<string, string> kvp in noteCollection)
                {
                    if(state == kvp.Value){
                        li.Add(kvp.Key);
                    }
                }
            }
            return li;
            
        }
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
