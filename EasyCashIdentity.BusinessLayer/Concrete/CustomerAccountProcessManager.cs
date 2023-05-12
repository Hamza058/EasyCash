using EashCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Delete(t);
        }

        public void TInsert(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Insert(t);
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Update(t);
        }

        CustomerAccountProcess IGenericServise<CustomerAccountProcess>.TGetByID(int id)
        {
            return _customerAccountProcessDal.GetByID(id);
        }

        List<CustomerAccountProcess> IGenericServise<CustomerAccountProcess>.TGetList()
        {
            return _customerAccountProcessDal.GetList();
        }
    }
}
