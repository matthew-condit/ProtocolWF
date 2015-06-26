using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class SponsorContact
    {
        public string SponsorCode { get; set; }
        public string ContactCode { get; set; }
        public string SponsorName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string PONumber { get; set; }

        public SponsorContact()
        {
            this.SponsorCode = "";
            this.ContactCode = "";
            this.SponsorName = "";
            this.ContactName = "";
            this.Email = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.ZipCode = "";
            this.PhoneNumber = "";
            this.FaxNumber = "";
            this.PONumber = "";
        }

        public SponsorContact(SponsorContact sponsor)
        {
            this.SponsorCode = sponsor.SponsorCode;
            this.ContactCode = sponsor.ContactCode;
            this.SponsorName = sponsor.SponsorName;
            this.ContactName = sponsor.ContactName;
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
