using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PM_GasWaterFication.Models.Documents
{
    public class ProjectData
    {
        public ProjectData()
        {
            
        }
        
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        
        [BsonIgnoreIfDefault]
        
        public String TypeProject { get; set; }
        
        public String ClientPartner { get; set; }
        
        public String DesignerPartner { get; set; }
        
        public String BuilderPartner { get; set; }
        
        public String DataCreate { get; set; }

        public List<DocSource> ListDocs { get; set; }
        
        public List<DocForm> ListForm { get; set; }
    }
}