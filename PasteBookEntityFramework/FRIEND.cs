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
    
    public partial class FRIEND
    {
        public int ID { get; set; }
        public Nullable<int> FRIEND_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public string REQUEST { get; set; }
        public string BLOCKED { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
    
        public virtual USER USER { get; set; }
        public virtual USER USER1 { get; set; }
    }
}
