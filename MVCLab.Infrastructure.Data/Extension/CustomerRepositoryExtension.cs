using MVCLab.Domain.CRM;
using MVCLab.Infrastructure.Data.CRM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab.Infrastructure.Data.Extension
{
    public static class CustomerRepositoryExtension
    {
        public static IQueryable<Customer> GetByIDUseSP(this IRepository<Customer> rep,int id)
        {
            var idParameter = new SqlParameter("OnBehalfPerson", id);

            var customers = (rep as GenericRepository<Customer>).context.Database.SqlQuery<Customer>(
                "spGetCustomers @idParameter",idParameter);

            return customers.AsQueryable();
        }

    }
}
