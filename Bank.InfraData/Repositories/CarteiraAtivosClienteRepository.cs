using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Bank.InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infra.Data.Repositories
{
    public class CarteiraAtivosClienteRepository : ICarteiraAtivosClienteRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<CarteiraAtivosPorCliente> DbSet;

        public CarteiraAtivosClienteRepository(ApplicationDbContext context)
        {
            _context = context; 
            DbSet = _context.Set<CarteiraAtivosPorCliente>();  
        }

        public void AddRange(IEnumerable<CarteiraAtivosPorCliente> entity)
        {
            DbSet.AddRange(entity);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            DbSet.RemoveRange(DbSet);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
