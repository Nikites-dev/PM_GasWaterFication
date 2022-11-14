using System;
using PM_GasWaterFication.Models.Users;

namespace PM_GasWaterFication.Models.Documents
{
    public class DocSource
    {
        public DocSource(String name, bool important, bool approve, String fileName)
        {
            Name = name;
            Important = important;
            Approve = approve;
            FileName = fileName;
        }
        
        public String Name { get; set; }
        
        public bool Important { get; set; }
        
        public bool Approve { get; set; }
        
        public String FileName { get; set; }
        
    }
}