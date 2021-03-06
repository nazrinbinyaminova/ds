//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VoguishTemplate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Cat_Id { get; set; }
        public int Author_Id { get; set; }
        public Nullable<System.DateTime> Add_Date { get; set; }
        public Nullable<int> View_Count { get; set; }
        public int Filess_Id { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Filess Filess { get; set; }
    }
}
