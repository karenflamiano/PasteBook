//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasteBookEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class LIKE
    {
        public int ID { get; set; }
        public Nullable<int> POST_ID { get; set; }
        public Nullable<int> LIKED_BY { get; set; }
    
        public virtual USER USER { get; set; }
        public virtual POST POST { get; set; }
    }
}
