using Autofac.Core;
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
using Service = Entity.Concrete.Service;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<IResult> AddAsync(Service service)
        {
            await _serviceDal.AddAsync(service);
            return new SuccessResult(Messages.serviceIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var serviceToDelete = await _serviceDal.GetAsync(x => x.Id == id);
            await _serviceDal.DeleteAsync(serviceToDelete);
            return new SuccessResult(Messages.serviceIsDeleted);
        }

        public async Task<IDataResult<List<Service>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Service>>(await _serviceDal.GetAllAsync(),Messages.servicesAreListed);
        }

        public async Task<IDataResult<Service>> GetAsync(int id)
        {
            return new SuccessDataResult<Service>(await _serviceDal.GetAsync(x => x.Id == id), Messages.serviceIsListed);
        }

        public async Task<IDataResult<Service>> GetServiceByUrl(string serviceUrl)
        {
            return new SuccessDataResult<Service>(await _serviceDal.GetAsync(x => x.ServiceUrl == serviceUrl), Messages.serviceIsListed);

        }

        public async Task<IResult> UpdateAsync(Service service)
        {
            await _serviceDal.UpdateAsync(service);
            return new SuccessResult(Messages.serviceIsUpdated);
        }
    }
}
