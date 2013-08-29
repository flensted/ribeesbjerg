﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RibeEsbjergHH.Models
{

    public class Participant
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Køn")]
        public string Sex { get; set; }
        
        [Required]
        [Display(Name = "Fødselsår")]
        public int BornYear { get; set; }

        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postnummer")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "By")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Hjemmetelefon")]
        public string HomePhone { get; set; }

        [Display(Name = "Forælders mobil")]
        public string ParentMobile { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Forælders email")]
        public string ParentEmail { get; set; }

        [Required]
        [Display(Name = "Forælders navn")]
        public string ParentName { get; set; }

        [Display(Name = "Forening")]
        public string Club { get; set; }

        [Required]
        [Display(Name = "Jeg har spillet håndbold i (år)")]
        public float YearsOfHandball { get; set; }

        [Display(Name = "Jeg spiller")]
        public string PlayerPosition { get; set; }


        [Required]
        [Display(Name = "T-shirt-størrelse")]
        public string TShirtSize { get; set; }

        [Display(Name = "Antal extra billetter til ligakamp (max 3)")]
        public int ExtraTickets { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Andre bemærkninger (særlige forhold, medicin, diæter)")]
        public string Comments { get; set; }
    }

    public enum Position
    {
        Bagspiller,
        Streg,
        Fløj,
        Målvogter
    }

}