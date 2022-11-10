using System;

namespace PM_GasWaterFication.Models.Users
{
    public class Builder : User
    {
        public Builder()
        {
            
        }
        
        public String pBuilder { get; set; }
        
        public int OGRN { get; set; } // 13
        
        public int INN { get; set; } // 10
        
        public int KPP { get; set; } // 9
        
        public String Address { get; set; }
        
        public int NumPhone { get; set; } // 11
      
        public String HeadOfExecutiveCommittee { get; set; }
    }
}