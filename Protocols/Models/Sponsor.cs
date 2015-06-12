using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class Sponsor
    {
        public string SponsorCode { get; set; }
        public string SponsorName { get; set; }
        public string SponsorContact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string PONumber { get; set; }

        public Sponsor()
        {
            this.SponsorCode = "";
            this.SponsorName = "";
            this.SponsorContact = "";
            this.Email = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.ZipCode = "";
            this.PhoneNumber = "";
            this.FaxNumber = "";
            this.PONumber = "";
        }

        public Sponsor(Sponsor sponsor)
        {
            this.SponsorCode = sponsor.SponsorCode;
            this.SponsorName = sponsor.SponsorName;
            this.SponsorContact = sponsor.SponsorContact;
            this.Email = sponsor.Email;
            this.Address = sponsor.Address;
            this.City = sponsor.City;
            this.State = sponsor.State;
            this.ZipCode = sponsor.ZipCode;
            this.PhoneNumber = sponsor.PhoneNumber;
            this.FaxNumber = sponsor.FaxNumber;
            this.PONumber = sponsor.PONumber;
        }
    }
}
