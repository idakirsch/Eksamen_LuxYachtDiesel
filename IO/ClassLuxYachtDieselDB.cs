using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class ClassLuxYachtDieselDB : ClassDbCon
    {
        public ClassLuxYachtDieselDB()
        {
            SetCon(@"Server=(localdb)\MSSQLLocalDB;Database=LuxYachtDieselDB;Trusted_Connection=True;");
        }

        public List<ClassCustomer> GetAllCustomerFromDB()
        {
            List<ClassCustomer> listRes = new List<ClassCustomer>();
            string sqlQuery = "SELECT Customers.Id AS CustomerId, " +
                                    "Customers.name, " +
                                    "Customers.address, " +
                                    "Customers.city, " +
                                    "Customers.postalCode, " +
                                    "CountryCurrency.Id AS CountryId, " +
                                    "CountryCurrency.country, " +
                                    "CountryCurrency.countryCode, " +
                                    "CountryCurrency.currency, " +
                                    "CountryCurrency.currencyCode, " +
                                    "Customers.phone, " +
                                    "Customers.mailAdr, " +
                                    "CustomerIsActive.isActive " +
                                "FROM " +
                                    "Customers " +
                                "INNER JOIN " +
                                    "CustomerIsActive " +
                                        "ON " +
                                    "Customers.Id = CustomerIsActive.CustomerId " +
                                "INNER JOIN " +
                                    "CountryCurrency " +
                                        "ON " +
                                    "Customers.country = CountryCurrency.Id " +
                                "ORDER BY name ASC";

            // Hent customer tabellen
            using (DataTable dataTable = DbReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Lav en person for hver række og tilføj den til listen
                    ClassCustomer customer = new ClassCustomer();

                    customer.Id = Convert.ToInt32(row["CustomerId"]);
                    customer.name = row["name"].ToString();
                    customer.address = row["address"].ToString();
                    customer.city = row["city"].ToString();
                    customer.postalCode = row["postalCode"].ToString();
                    customer.country.Id = Convert.ToInt32(row["CountryId"]);
                    customer.country.country = row["country"].ToString();
                    customer.country.countryCode = row["countryCode"].ToString();
                    customer.country.currency = row["currency"].ToString();
                    customer.country.currencyCode = row["currencyCode"].ToString();
                    customer.phone = row["phone"].ToString();
                    customer.mail = row["mailAdr"].ToString();
                    customer.active = Convert.ToBoolean(row["isActive"]);

                    listRes.Add(customer);
                }
            }
            return listRes;
        }
        public int SaveCustomerInDB(ClassCustomer inCustomer)
        {
            string sqlQuery = "INSERT INTO Customers " +
                                    "(name, address, city, postalCode, " +
                                    "country, phone, mailAdr) " +
                                "VALUES " +
                                    "(@name, @address, @city, @postalCode, " +
                                    "@country, @phone, @mailAdr) " +
                                "INSERT INTO CustomerIsActive " +
                                    "(CustomerId, isActive)" +
                                "VALUES " +
                                    "(@CustomerId, @isActive) " +
                                "SELECT SCOPE_IDENTITY()";

            return ExecuteCustomerSqlQuery(inCustomer, sqlQuery, false);
        }
        public int UpdateCustomerInDB(ClassCustomer inCustomer)
        {
            string sqlQuery = "UPDATE Customers " +
                                "SET name = @name, address = @address, " +
                                    "city = @city, postalCode = @postalCode, " +
                                    "country = @country, phone = @phone, " +
                                    "mailAdr = @mailAdr " +
                                "WHERE Id = @Id " +
                                "UPDATE CustomerIsActive " +
                                "SET isActive = @isActive " +
                                "WHERE CustomerId = @Id";
            return ExecuteCustomerSqlQuery(inCustomer, sqlQuery, true);
        }

        public List<ClassSupplier> GetAllSuppliersFromDB()
        {
            List<ClassSupplier> listRes = new List<ClassSupplier>();
            string sqlQuery = "SELECT Suppliers.Id AS SupplierId, " +
                                    "Suppliers.companyName, " +
                                    "Suppliers.contactName, " +
                                    "Suppliers.address, " +
                                    "Suppliers.city, " +
                                    "Suppliers.postalCode, " +
                                    "CountryCurrency.Id AS CountryId, " +
                                    "CountryCurrency.country, " +
                                    "CountryCurrency.countryCode, " +
                                    "CountryCurrency.currency, " +
                                    "CountryCurrency.currencyCode, " +
                                    "Suppliers.phone, " +
                                    "Suppliers.mailAdr, " +
                                    "SuppliersIsActive.isActive " +
                                "FROM " +
                                    "CountryCurrency " +
                                "INNER JOIN " +
                                    "Suppliers " +
                                        "ON " +
                                    "CountryCurrency.Id = Suppliers.country " +
                                "INNER JOIN " +
                                    "SuppliersIsActive " +
                                        "ON " +
                                    "Suppliers.Id = SuppliersIsActive.SuppliersId " +
                                "ORDER BY companyName ASC";

            // Hent customer tabellen
            using (DataTable dataTable = DbReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Lav en supplier for hver række og tilføj den til listen
                    ClassSupplier supplier = new ClassSupplier();

                    supplier.Id = Convert.ToInt32(row["SupplierId"]);
                    supplier.firmName = row["companyName"].ToString();
                    supplier.contactName = row["contactName"].ToString();
                    supplier.address = row["address"].ToString();
                    supplier.city = row["city"].ToString();
                    supplier.postalCode = row["postalCode"].ToString();
                    supplier.country.Id = Convert.ToInt32(row["CountryId"]);
                    supplier.country.country = row["country"].ToString();
                    supplier.country.countryCode = row["countryCode"].ToString();
                    supplier.country.currency = row["currency"].ToString();
                    supplier.country.currencyCode = row["currencyCode"].ToString();
                    supplier.phone = row["phone"].ToString();
                    supplier.mailAdr = row["mailAdr"].ToString();
                    supplier.isActive = Convert.ToBoolean(row["isActive"]);

                    listRes.Add(supplier);
                }
            }

            return listRes;
        }
        public int SaveSupplierInDB(ClassSupplier inSupplier)
        {
            string sqlQuery = "INSERT INTO Suppliers " +
                                    "(companyName, contactName, address, city, " +
                                    "postalCode, country, phone, mailAdr) " +
                                "VALUES " +
                                    "(@companyName, @contactName, @address, @city, " +
                                    "@postalCode, @country, @phone, @mailAdr) " +
                                "INSERT INTO SuppliersIsActive " +
                                    "(SupplierId, isActive)" +
                                "VALUES " +
                                    "(@SupplierId, @isActive) " +
                                "SELECT SCOPE_IDENTITY()";
            return ExecuteSupplierSqlQuery(inSupplier, sqlQuery, false);
        }
        public int UpdateSupplierInDB(ClassSupplier inSupplier)
        {
            string sqlQuery = "UPDATE Suppliers " +
                                "SET " +
                                    "companyName = @companyName, contactName = @contactName, " +
                                    "address = @address, city = @city, " +
                                    "postalCode = @postalCode, country = @country, " +
                                    "phone = @phone, mailAdr = @mailAdr " +
                                "WHERE " +
                                    "Id = @Id " +
                                "UPDATE SuppliersIsActive " +
                                "SET isActive = @isActive " +
                                "WHERE SupplierId = @Id";
            return ExecuteSupplierSqlQuery(inSupplier, sqlQuery, true);
        }

        /// <summary>
        /// Min mail
        ///     Hej Jens
        ///         Da det er nødvendigt at kunne hente alle lande, spørger jeg om lov til at lave en metode, som hente landene fra databasen.
        ///     Med Venlig Hilsen
        ///     Ida Jessen Møller
        /// Svar
        ///     Ja
        /// </summary>
        /// <returns></returns>
        public List<ClassCountry> GetAllCountryFromDB()
        {
            List<ClassCountry> listRes = new List<ClassCountry>();
            string sqlQuery = "SELECT * " +
                                  "FROM " +
                                     "CountryCurrency ";

            // Hent country tabellen
            using (DataTable dataTable = DbReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Lav et land for hver række og tilføj den til listen
                    ClassCountry country = new ClassCountry();

                    country.Id = Convert.ToInt32(row["Id"]);
                    country.country = row["country"].ToString();
                    country.countryCode = row["countryCode"].ToString();
                    country.currency = row["currency"].ToString();
                    country.currencyCode = row["currencyCode"].ToString();

                    listRes.Add(country);
                }
            }

            return listRes;
        }

        //public ClassDieselPrice GetOilPriceFromDB()
        //{
        //    return;
        //}
        public List<ClassDieselPrice> GetAllOilPricesFromDB()
        {
            List<ClassDieselPrice> listRes = new List<ClassDieselPrice>();
            string sqlQuery = "SELECT * " +
                                "From DieselPrice ";

            using (DataTable dataTable = DbReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ClassDieselPrice price = new ClassDieselPrice();

                    price.Id = Convert.ToInt32(row["Id"]);
                    price.date = Convert.ToDateTime(row["date"]);
                    price.price = Convert.ToDouble(row["price"]);

                    listRes.Add(price);
                }
            }
            return listRes.OrderByDescending(CDP=> CDP.date).ThenByDescending(CDP => CDP.Id).ToList();
        }
        /// <summary>
        /// Min mail
        ///     Hej Jens
        ///         Da der skal kunne gemmes Diesel prisen, spørger jeg om lov til at lave en metode, der skal gemme prisen i databasen
        ///     Med Venlig Hilsen
        ///     Ida Jessen Møller
        /// Svar
        ///     Ja
        /// </summary>
        /// <param name="inPrice">ClassDieselPrice</param>
        /// <returns></returns>
        public int SavePriceInDB(ClassDieselPrice inPrice)
        {
            string sqlQuery = "INSERT INTO DieselPrice " +
                              "(date, price) " +
                              "date, price " +
                              "VALUES " +
                              "(@date, @price) " +
                              "SELECT SCOPE_IDENTITY()";
            return ExecutePriceSqlQuery(inPrice, sqlQuery, false);
        }

        public int SaveOrderInDB(ClassOrder inOrder)
        {
            string sqlQuery = "INSERT INTO DieselPrice " +
                                "(customerId, supplierId, dieselVolume, orderDate, dieselPrice, customerRate, supplierRate, ownProfit) " +
                                "VALUES " +
                                "(@customerId, @supplierId, @dieselVolume, @orderDate, @dieselPrice, @customerRate, @supplierRate, @ownProfit) " +
                                "SELECT SCOPE_IDENTITY()";
            return ExecuteOrderSqlQuery(inOrder, sqlQuery, false);
        }

        private int ExecutePriceSqlQuery(ClassDieselPrice inPrice, string sqlQuery, bool updateExisting)
        {
            int res = 0;
            try
            {
                OpenDB();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = inPrice.Id;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = inPrice.date;
                    cmd.Parameters.Add("@price", SqlDbType.Money).Value = inPrice.price;

                    res = updateExisting ? cmd.ExecuteNonQuery() : Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }
        private int ExecuteCustomerSqlQuery(ClassCustomer inCustomer, string sqlQuery, bool updateExisting)
        {
            int res = 0;
            try
            {
                OpenDB();
                // Laver en sql kommando der skal indsætte inPerson
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = inCustomer.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = inCustomer.address;
                    cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = inCustomer.city;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = inCustomer.postalCode;
                    cmd.Parameters.Add("@country", SqlDbType.Int).Value = inCustomer.country.Id;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                    cmd.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = inCustomer.mail;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = inCustomer.Id;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inCustomer.active;

                    res = updateExisting ? cmd.ExecuteNonQuery() : Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }
        private int ExecuteSupplierSqlQuery(ClassSupplier inSupplier, string sqlQuery, bool updateExisting)
        {
            int res = 0;
            try
            {
                OpenDB();
                // Laver en sql kommando der skal indsætte inPerson
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = inSupplier.Id;
                    cmd.Parameters.Add("@companyName", SqlDbType.NVarChar).Value = inSupplier.firmName;
                    cmd.Parameters.Add("@contactName", SqlDbType.NVarChar).Value = inSupplier.contactName;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = inSupplier.address;
                    cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = inSupplier.city;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = inSupplier.postalCode;
                    cmd.Parameters.Add("@country", SqlDbType.Int).Value = inSupplier.country.Id;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inSupplier.phone;
                    cmd.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = inSupplier.mailAdr;
                    cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = inSupplier.Id;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inSupplier.isActive;

                    res = updateExisting ? cmd.ExecuteNonQuery() : Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }
        private int ExecuteOrderSqlQuery(ClassOrder inOrder, string sqlQuery, bool updateExisting)
        {
            int res = 0;
            try
            {
                OpenDB();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = inOrder.customer.Id;
                    cmd.Parameters.Add("@supplierId", SqlDbType.Int).Value = inOrder.supplier.Id;
                    cmd.Parameters.Add("@diselVolume", SqlDbType.Int).Value = Convert.ToInt32(inOrder.volume);
                    cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = inOrder.date;
                    cmd.Parameters.Add("@dieselPrice", SqlDbType.Decimal).Value = inOrder.price;
                    cmd.Parameters.Add("@customerRate", SqlDbType.Decimal).Value = inOrder.customerRate;
                    cmd.Parameters.Add("@supplierRate", SqlDbType.Decimal).Value = inOrder.supplierRate;
                    cmd.Parameters.Add("@ownProfit", SqlDbType.Decimal).Value = inOrder.ownProfit;

                    res = updateExisting ? cmd.ExecuteNonQuery() : Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }

    }
}
