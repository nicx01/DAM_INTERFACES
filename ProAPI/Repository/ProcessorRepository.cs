using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPelicula.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class ProcessorRepository : IProcessorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProcessorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ProcessorEntity> GetProcessors()
        {
            return _context.Processors.OrderBy(p => p.Marca).ToList();
        }

        public ProcessorEntity GetProcessor(int id)
        {
            return _context.Processors.FirstOrDefault(p => p.Id == id);
        }

        public bool CreateProcessor(ProcessorEntity processor)
        {
            _context.Processors.Add(processor);
            return Save();
        }

        public bool UpdateProcessor(ProcessorEntity processor)
        {
            _context.Processors.Update(processor);
            return Save();
        }

        public bool DeleteProcessor(int id)
        {
            var processor = GetProcessor(id);
            if (processor == null)
                return false;

            _context.Processors.Remove(processor);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
