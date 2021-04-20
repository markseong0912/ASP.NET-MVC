using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewVidly.Models
{
    public class Customer //purely for domain class
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter{ get; set; }
        public MembershipType MembershipType { get; set; } //navigation property
        public byte MembershipTypeId { get; set; }
    }
}