using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCountry : ClassNotify
    {
        private int _Id;
        private string _country;
        private string _countryCode;
        private string _currency;
        private string _currencyCode;

        public ClassCountry()
        {
            Id = 0;
            country = "";
            countryCode = "";
            currency = "";
            currencyCode = "";
        }
        public ClassCountry(ClassCountry inCountry)
        {
            Id = inCountry.Id;
            country = inCountry.country;
            countryCode = inCountry.countryCode;
            currency = inCountry.currency;
            currencyCode = inCountry.currencyCode;
        }

        public string currencyCode
        {
            get { return _currencyCode; }
            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                }
                Notify("currencyCode");
            }
        }
        public string currency
        {
            get { return _currency; }
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                }
                Notify("currency");
            }
        }
        public string countryCode
        {
            get { return _countryCode; }
            set
            {
                if (_countryCode != value)
                {
                    _countryCode = value;
                }
                Notify("countryCode");
            }
        }
        public string country
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

    }
}
