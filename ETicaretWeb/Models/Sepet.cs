//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETicaretWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sepet
    {
        public int SepetId { get; set; }
        public string RefAspNetUserId { get; set; }
        public Nullable<int> RefUrunId { get; set; }
        public Nullable<int> Adet { get; set; }
        public Nullable<int> Tutar { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
