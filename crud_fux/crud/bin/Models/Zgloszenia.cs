//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zgloszenia
    {
        public int idOferty { get; set; }
        public string imie_nazwisko { get; set; }
        public string firma { get; set; }
        public string nr_telefonu { get; set; }
        public string mail { get; set; }
        public string m_zamieszkania { get; set; }
        public string nazwa_imprezy { get; set; }
        public string rodzaj_tresc { get; set; }
        public string miejsce_realizacji { get; set; }
        public string czas_trwania { get; set; }
        public string cyklicznosc { get; set; }
        public string charakter_uczestnictwa { get; set; }
        public string forma_organizacyjna { get; set; }
        public string cele { get; set; }
        public string termin_odbycia { get; set; }
        public string ceny_bilet { get; set; }
        public string dod_uslugi { get; set; }
        public string stanZgloszenia { get; set; }
        public Nullable<System.DateTime> dataOtrzymaniaZgloszenia { get; set; }
    }
}
