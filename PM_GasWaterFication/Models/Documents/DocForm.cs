using System;

namespace PM_GasWaterFication.Models.Documents
{
    public class DocForm
    {
        public DocForm(String summary)
        {
            Summary = summary;
        }
        
        public String Summary {get; set; }
        
        public String Date {get; set; }
        
    }
}