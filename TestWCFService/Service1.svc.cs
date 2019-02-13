using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestWCFService
{
    public class Service1 : ITestService
    {
        TestDBContext ContextDB = new TestDBContext();

        void ITestService.AddCustomer(Customer customer)
        {
            ContextDB.Customers.Add(customer);            
            ContextDB.SaveChanges();            
        }

        void ITestService.AddProduct(Product product)
        {
            ContextDB.Products.Add(product);
            ContextDB.SaveChanges();
        }

        void ITestService.DeleteCustomer(Customer customer)
        {
            ContextDB.Customers.Remove(ContextDB.Customers.FirstOrDefault(x => x.Id == customer.Id));
            ContextDB.Products.RemoveRange(ContextDB.Products.Where(x => x.Customer.Id == customer.Id));
            ContextDB.SaveChanges();
        }

        void ITestService.DeleteProduct(Product product)
        {
            ContextDB.Products.Remove(ContextDB.Products.FirstOrDefault(x => x.Id == product.Id));
            ContextDB.SaveChanges();
        }

        ObservableCollection<Customer> ITestService.GetCustomers()
        {
            return new ObservableCollection<Customer>(ContextDB.Customers);
        }

        ObservableCollection<Product> ITestService.GetProducts(Customer customer)
        {
            ObservableCollection<Product> ans = new ObservableCollection<Product>(ContextDB.Products.Where(x => x.Customer.Id == customer.Id));
            return ans;
        }

        void ITestService.UpdateCustomer(Customer customer)
        {
            var result = ContextDB.Customers.SingleOrDefault(x => x.Id == customer.Id);
            if (result != null)
            {
                result.Address = customer.Address;
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                result.Phone = customer.Phone;
                ContextDB.SaveChanges();
            }
        }

        void ITestService.UpdateProduct(Product product)
        {
            var result = ContextDB.Products.SingleOrDefault(x => x.Id == product.Id);
            if (result != null)
            {
                result.Count = product.Count;
                result.Name = product.Name;
                result.Price = product.Price;
                ContextDB.SaveChanges();
            }
        }
    }
}
