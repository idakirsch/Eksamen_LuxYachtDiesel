using IO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private ClassLuxYachtDieselDB _classDB;
        private ClassWebAPICall _classAPI;
        private DateTime _dato;
        private ClassCurrency _currency;

        private ClassCustomer _selectedCustomer;
        private ClassSupplier _selectedSupplier;
        private ClassCustomer _fallbackCustomer;
        private ClassSupplier _fallbackSupplier;
        private ClassCountry _selectedCustomerCountry;
        private ClassCountry _selectedSupplierCountry;
        private List<ClassCustomer> _listCustomers;
        private List<ClassSupplier> _listSuppliers;
        private List<ClassCountry> _listCountry;
        private List<ClassDieselPrice> _listDieselPrice;
        private ClassDieselPrice _dieselPrice;
        private ClassOrder _order;
        private string _inputDieselPrice;
        private string _inputVolume; 
        private double _customerPrice;
        private double _supplierPrice;
        private double _ownProfit;
        private bool _enableCustomerEdit;
        private bool _enableSupplierEdit;

        public ClassBIZ()
        {
            _classAPI = new ClassWebAPICall();
            _classDB = new ClassLuxYachtDieselDB();
            dato = DateTime.Now.Date;
            currency = new ClassCurrency();

            selectedCustomerCountry = new ClassCountry();
            selectedSupplierCountry = new ClassCountry();
            listCountry = GetAllCountryForListFromDB();

            selectedCustomer = new ClassCustomer();
            selectedSupplier = new ClassSupplier();
            fallbackCustomer = new ClassCustomer();
            fallbackSupplier = new ClassSupplier();
            listCustomers = GetAllCustomersForListFromDB();
            listSuppliers = GetAllSuppliersForListFromDB();
            listDieselPrice = GetAllDieselPriceFromDB();
            dieselPrice = GetDieselPriceFromDB();
            order = new ClassOrder();
            inputDieselPrice = string.Empty;
            inputVolume = "0";
            customerPrice = 0D;
            supplierPrice = 0D;
            ownProfit = 0D;
            enableCustomerEdit = false;
            enableSupplierEdit = false;
        }
        public DateTime dato
        {
            get { return _dato; }
            set
            {
                if (_dato != value)
                {
                    _dato = value;
                }
                Notify("dato");
            }
        }
        public ClassCurrency currency
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
        public ClassCustomer selectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    if (selectedCustomerCountry != value.country)
                        selectedCustomerCountry =
                            listCountry.Find(t => t.Id == value.country.Id);
                }
                Notify("selectedCustomer");
            }
        }
        public ClassSupplier selectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                if (_selectedSupplier != value)
                {
                    _selectedSupplier = value;
                    if (selectedSupplierCountry != value.country)
                        selectedSupplierCountry = listCountry.Find(t => t.Id == value.country.Id);
                }
                Notify("selectedSupplier");
            }
        }
        public ClassCustomer fallbackCustomer
        {
            get { return _fallbackCustomer; }
            set
            {
                if (_fallbackCustomer != value)
                {
                    _fallbackCustomer = value;
                    selectedCustomer = new ClassCustomer(value);
                }
                Notify("fallbackCustomer");
            }
        }
        public ClassSupplier fallbackSupplier
        {
            get { return _fallbackSupplier; }
            set
            {
                if (_fallbackSupplier != value)
                {
                    _fallbackSupplier = value;
                    selectedSupplier = new ClassSupplier(value);
                }
                Notify("fallbackSupplier");
            }
        }
        public ClassCountry selectedCustomerCountry
        {
            get { return _selectedCustomerCountry; }
            set
            {
                if (_selectedCustomerCountry != value)
                {
                    _selectedCustomerCountry = value;
                    if (selectedCustomer != null)
                        selectedCustomer.country = value;
                }
                Notify("selectedCustomerCountry");
            }
        }
        public ClassCountry selectedSupplierCountry
        {
            get { return _selectedSupplierCountry; }
            set
            {
                if (_selectedSupplierCountry != value)
                {
                    _selectedSupplierCountry = value;
                    if (selectedSupplier != null) selectedSupplier.country = value;
                }
                Notify("selectedSupplierCountry");
            }
        }
        public List<ClassCustomer> listCustomers
        {
            get { return _listCustomers; }
            set
            {
                if (_listCustomers != value)
                {
                    _listCustomers = value;
                }
                Notify("listCustomers");
            }
        }
        public List<ClassSupplier> listSuppliers
        {
            get { return _listSuppliers; }
            set
            {
                if (_listSuppliers != value)
                {
                    _listSuppliers = value;
                }
                Notify("listSuppliers");
            }
        }
        public List<ClassCountry> listCountry
        {
            get { return _listCountry; }
            set
            {
                if (_listCountry != value)
                {
                    _listCountry = value;
                }
                Notify("listCountry");
            }
        }
        public List<ClassDieselPrice> listDieselPrice
        {
            get { return _listDieselPrice; }
            set
            {
                if (_listDieselPrice != value)
                {
                    _listDieselPrice = value;
                }
                Notify("listDieselPrice");
            }
        }
        public ClassDieselPrice dieselPrice
        {
            get { return _dieselPrice; }
            set
            {
                if (_dieselPrice != value)
                {
                    _dieselPrice = value;
                }
                Notify("dieselPrice");
            }
        }
        public ClassOrder order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                }
                Notify("order");
            }
        }
        public string inputDieselPrice
        {
            get { return _inputDieselPrice; }
            set
            {
                if (_inputDieselPrice != value)
                {
                    _inputDieselPrice = value;
                }
                Notify("inputDieselPrice");
            }
        }
        public string inputVolume
        {
            get { return _inputVolume; }
            set
            {
                if (_inputVolume != value)
                {
                    if (int.TryParse(value, out int x))
                    {
                        _inputVolume = x.ToString();
                        CalculateAllValuesForOrder(); 
                    }

                }
                Notify("inputVolume");
            }
        }
        public double customerPrice
        {
            get { return _customerPrice; }
            set
            {
                if (_customerPrice != value)
                {
                    _customerPrice = value;
                }
                Notify("customerPrice");
            }
        }
        public double supplierPrice
        {
            get { return _supplierPrice; }
            set
            {
                if (_supplierPrice != value)
                {
                    _supplierPrice = value;
                }
                Notify("supplierPrice");
            }
        }
        public double ownProfit
        {
            get { return _ownProfit; }
            set
            {
                if (_ownProfit != value)
                {
                    _ownProfit = value;
                }
                Notify("ownProfit");
            }
        }
        public bool enableCustomerEdit
        {
            get { return _enableCustomerEdit; }
            set
            {
                if (_enableCustomerEdit != value)
                {
                    _enableCustomerEdit = value;
                }
                Notify("enableCustomerEdit");
                Notify("disableCustomerEdit");
            }
        }
        public bool disableCustomerEdit
        {
            get { return !enableCustomerEdit; }
        }
        public bool enableSupplierEdit
        {
            get { return _enableSupplierEdit; }
            set
            {
                if (_enableSupplierEdit != value)
                {
                    _enableSupplierEdit = value;
                }
                Notify("enableSupplierEdit");
                Notify("disableSupplierEdit");
            }
        }
        public bool disableSupplierEdit
        {
            get { return !enableSupplierEdit; }
        }

        public async Task GetAllCurrencysWebAPI()
        {
            currency = await _classAPI.GetDataFromWebApiAsync();
        }
        public List<ClassCountry> GetAllCountryForListFromDB()
        {
            return _classDB.GetAllCountryFromDB();
        }
        public List<ClassCustomer> GetAllCustomersForListFromDB()
        {
            return _classDB.GetAllCustomerFromDB();
        }
        public List<ClassSupplier> GetAllSuppliersForListFromDB()
        {
            return _classDB.GetAllSuppliersFromDB();
        }
        public List<ClassDieselPrice> GetAllDieselPriceFromDB()
        {
            return _classDB.GetAllOilPricesFromDB();
        }
        public ClassDieselPrice GetDieselPriceFromDB()
        {
            return listDieselPrice.FirstOrDefault();
        }
        public void UpdateOrInsertCustomerInDB()
        {
            // Exit 'editing mode' 
            enableCustomerEdit = false;

            if (selectedCustomer.Id == 0)
            {
                // Insert the customer in the database
                _classDB.SaveCustomerInDB(selectedCustomer);

                // Add a copy of the edited customer to the list
                listCustomers.Add(new ClassCustomer(selectedCustomer));
                // Make sure the newly added customer is selected
                fallbackCustomer = listCustomers.Last();
            }
            else
            {
                // Update the customer in the database
                _classDB.UpdateCustomerInDB(selectedCustomer);

                // Find currently selected customer in the list (doesn't work otherwise??) 
                int index = listCustomers.IndexOf(fallbackCustomer);
                // Replace it with a copy of the newly edited customer
                listCustomers[index] = new ClassCustomer(selectedCustomer);
                // Make sure the updated customer is still the selected customer
                fallbackCustomer = listCustomers[index];
            }
            // Update the list by remaking it (doesn't work otherwise)
            listCustomers = new List<ClassCustomer>(listCustomers);
        }
        public void UpdateOrInsertSupplierInDB()
        {
            enableSupplierEdit = false;

            if (selectedSupplier.Id == 0)
            {
                _classDB.SaveSupplierInDB(selectedSupplier);

                listSuppliers.Add(new ClassSupplier(selectedSupplier));
                fallbackSupplier = listSuppliers.Last();
            }
            else
            {
                _classDB.UpdateSupplierInDB(selectedSupplier);

                int index = listSuppliers.IndexOf(fallbackSupplier);
                listSuppliers[index] = new ClassSupplier(selectedSupplier);
                fallbackSupplier = listSuppliers[index];
            }
            listSuppliers = new List<ClassSupplier>(listSuppliers);
        }
        public void InsertDieselPriceInDB()
        {
            ClassDieselPrice CDP = new ClassDieselPrice();
            CDP.price = Convert.ToDouble(inputDieselPrice);
            _classDB.SavePriceInDB(CDP);
        }
        public void InsertOrderInDB()
        {
            _classDB.SaveOrderInDB(order);
        }
        public void RegretUpdateOrNewCustomerForDB()
        {
            enableCustomerEdit = false;
            selectedCustomer = new ClassCustomer(fallbackCustomer);
        }
        public void RegretUpdateOrNewSupplierForDB()
        {
            enableSupplierEdit = false;
            selectedSupplier = new ClassSupplier(fallbackSupplier);
        }
        public void RegretNewDieselPriceForDB()
        {

        }
        public void RegretNewOrderForDB()
        {
            
        }
        public void CalculateAllValuesForOrder()
        {
            if (selectedCustomer != null && selectedSupplier != null && dieselPrice != null && 
                currency.rates.ContainsKey(selectedCustomer.country.currencyCode) && 
                currency.rates.ContainsKey(selectedSupplier.country.currencyCode) && currency.rates.ContainsKey("DKK"))
            {
                double price = Convert.ToInt32(inputVolume) * dieselPrice.price;

                customerPrice = Math.Round(price + (price * 1.00148) * Convert.ToDouble(currency.rates[selectedCustomer.country.currencyCode]), 3);
                supplierPrice = Math.Round(price + (price * 1.00148) * Convert.ToDouble(currency.rates[selectedSupplier.country.currencyCode]), 3);
                ownProfit = Math.Round(price * 0.00148 * Convert.ToDouble(currency.rates["DKK"]), 3);

            }
        }

    }
}
