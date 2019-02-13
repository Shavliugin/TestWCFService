using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestWCFService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        ObservableCollection<Customer> GetCustomers();

        [OperationContract]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        void DeleteCustomer(Customer customer);

        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]
        ObservableCollection<Product> GetProducts(Customer customer);

        [OperationContract]
        void UpdateProduct(Product product);

        [OperationContract]
        void DeleteProduct(Product product);

        [OperationContract]
        void AddProduct(Product product);

    }

    [DataContract]
    public class Product
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int customerId;
        [DataMember]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private Customer customer;
        [DataMember]
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        private string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private float price;
        [DataMember]
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int count;
        [DataMember]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }

    [DataContract]
    public class Customer
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string phone;
        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string address;
        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
