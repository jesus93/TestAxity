using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AXITY
{
    public class UnitOfWork : IDisposable
    {
        private AxityEntities _context = new AxityEntities();
        private GenericRepository<Products> _products;
        private GenericRepository<Cat_Products> _catProducts;
        private GenericRepository<Users> _users;

        public GenericRepository<Products> ProductsRepository
        {
            get
            {
                if(this._products == null)
                {
                    this._products = new GenericRepository<Products>(_context);
                }

                return _products;
            }
        }

        public GenericRepository<Cat_Products> CatProductsRepository
        {
            get
            {
                if(this._catProducts == null)
                {
                    this._catProducts = new GenericRepository<Cat_Products>(_context);
                }

                return _catProducts;
            }
        }

        public GenericRepository<Users> UsersRepository
        {
            get
            {
                if(this._users == null)
                {
                    this._users = new GenericRepository<Users>(_context);

                }

                return this._users;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
