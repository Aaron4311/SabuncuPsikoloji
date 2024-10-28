using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PsychologistManager : IPsychologistService
    {
        private readonly IPsychologistDal _psychologistDal;

        public PsychologistManager(IPsychologistDal psychologistDal)
        {
            _psychologistDal = psychologistDal;
        }

        public async Task<IResult> AddAsync(Psychologist psychologist)
        {
            await _psychologistDal.AddAsync(psychologist);
            return new SuccessResult(Messages.psychologistIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var psychologistToDelete = await _psychologistDal.GetAsync(x => x.Id == id);
            await _psychologistDal.DeleteAsync(psychologistToDelete);
            return new SuccessResult(Messages.psychologistIsDeleted);
        }

        public async Task<IDataResult<List<Psychologist>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Psychologist>>(await _psychologistDal.GetAllAsync(), Messages.psychologistsAreListed);
        }

        public async Task<IDataResult<Psychologist>> GetAsync(int id)
        {
            return new SuccessDataResult<Psychologist>(await _psychologistDal.GetAsync(x => x.Id == id), Messages.psychologistIsListed);
        }

        public async Task<IDataResult<Psychologist>> GetPsychologistByUrl(string psychologistUrl)
        {
            return new SuccessDataResult<Psychologist>(await _psychologistDal.GetAsync(x => x.PsychologistUrl == psychologistUrl), Messages.psychologistIsListed);

        }

        public async Task<IResult> UpdateAsync(Psychologist psychologist)
        {
            await _psychologistDal.UpdateAsync(psychologist);
            return new SuccessResult(Messages.psychologistIsUpdated);
        }
    }
}
