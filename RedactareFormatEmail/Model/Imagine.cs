//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIandModelLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Imagine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imagine()
        {
            this.Available = 0;
            this.ProprietateImagines = new HashSet<ProprietateImagine>();
        }
    
        public int Id { get; set; }
        public string FullPath { get; set; }
        public byte Available { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProprietateImagine> ProprietateImagines { get; set; }
        public virtual MediaList MediaList { get; set; }
    }
}
