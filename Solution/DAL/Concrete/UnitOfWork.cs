using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ABCltdEmployeesContext _db = new ABCltdEmployeesContext();
        private GenericRepository<HrEmployee> _employeeRepository;
        public IGenericRepository<HrEmployee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new GenericRepository<HrEmployee>(_db);
                return _employeeRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
