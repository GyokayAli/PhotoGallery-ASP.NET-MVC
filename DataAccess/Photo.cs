//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photo
    {
        public int ID { get; set; }
        public string PHOTO_NAME { get; set; }
        public byte[] PHOTO_IMG { get; set; }
        public int ALBUM_ID { get; set; }
    
        public virtual Album Album { get; set; }
    }
}