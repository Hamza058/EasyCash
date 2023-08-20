using EashCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
    }
}
