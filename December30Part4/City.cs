//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace December30Part4
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long District_ID { get; set; }
        public string Mayor { get; set; }
        public int Population { get; set; }
    
        public virtual District District { get; set; }
    }
}
