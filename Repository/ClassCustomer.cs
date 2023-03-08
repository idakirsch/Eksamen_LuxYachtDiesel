using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCustomer : ClassNotify
    {
        private int _Id;
        private string _name;
        private string _address;
        private string _city;
        private string _postalCode;
        private ClassCountry _country;
        private string _phone;
        private string _mail;
        private bool _active;

        public ClassCustomer()
        {
            Id = 0;
            name = "";
            address = "";
            city = "";
            postalCode = "";
            country = new ClassCountry();
            phone = "";
            mail = "";
            active = true;
        }
        public ClassCustomer(ClassCustomer inCustomer)
        {
            Id = inCustomer.Id;
            name = inCustomer.name;
            address = inCustomer.address;
            city = inCustomer.city;
            postalCode = inCustomer.postalCode;
            country = new ClassCountry(inCustomer.country);
            phone = inCustomer.phone;
            mail = inCustomer.mail;
            active = inCustomer.active;
        }
        public string mail
        {
            get { return _mail; }
            set
            {
                if (_mail != value)
                {
                    _mail = value;
                }
                Notify("mail");
            }
        }
        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                }
                Notify("phone");
            }
        }
        public ClassCountry country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                }
                Notify("country");
            }
        }
        public string postalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                }
                Notify("postalCode");
            }
        }
        public string city
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                }
                Notify("city");
            }
        }
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                }
                Notify("address");
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                Notify("name");
            }
        }
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                }
                Notify("Id");
            }
        }
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                }
                Notify("active");
            }
        }
    }
}
