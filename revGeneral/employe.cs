//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace revGeneral
{
    using System;
    using System.Collections.Generic;
    
    public partial class employe
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<double> salaire { get; set; }
        public Nullable<int> code { get; set; }
    
        public virtual entreprise entreprise { get; set; }
    }
}
