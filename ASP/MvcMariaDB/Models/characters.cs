//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcMariaDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class characters
    {
        public int id { get; set; }
        public string name_character { get; set; }
        public string weapon { get; set; }
        public string element { get; set; }
        public int rarity { get; set; }
        public string birthday { get; set; }
        public string seiyuu { get; set; }
        public string region { get; set; }
        public string description_character { get; set; }
    }
}