using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : IAssociaCarteira
    {
        void AddRange(IEnumerable<T> entity);
        void DeleteAll();

    }
}
