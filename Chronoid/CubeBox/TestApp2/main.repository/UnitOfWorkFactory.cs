using Repository.Interface;
using System;

namespace Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
        public TUnitUofWork Create<TUnitUofWork>() where TUnitUofWork : IUnitOfWork
        {
            throw new NotImplementedException();
        }

        public TUnitUofWork Create<TUnitUofWork>(string connectionString) where TUnitUofWork : IUnitOfWork
        {
            throw new NotImplementedException();
        }
    }
}
