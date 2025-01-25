using System.Collections.Generic;
using System.Threading.Tasks;
using RestAPI.Models.Entity;
using RestAPI.Models.Dto;

namespace RestAPI.Repository.IRepository
{
    public interface IProcessorRepository
    {
        ICollection<ProcessorEntity> GetProcessors();
        ProcessorEntity GetProcessor(int id);
        bool CreateProcessor(ProcessorEntity processor);
        bool UpdateProcessor(ProcessorEntity processor);
        bool DeleteProcessor(int id);
        bool Save();
    }
}
