using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPsychologistService
    {
        Task<IDataResult<List<Psychologist>>> GetAllAsync();
        Task<IDataResult<Psychologist>> GetAsync(int id);
        Task<IResult> AddAsync(Psychologist psychologist);
        Task<IResult> UpdateAsync(Psychologist psychologist);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<Psychologist>> GetPsychologistByUrl(string psychologistUrl);
    }
}
