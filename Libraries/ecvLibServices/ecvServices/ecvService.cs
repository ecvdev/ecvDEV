using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibDAL.ecvRepositories;
using ecvLib.Core.ecvMapper;

namespace ecvLibServices.ecvServices
{
    public class ecvService<TDto, TDtoList, TEntity> : IService<TDto,  TDtoList, TEntity> where TDto : class,new()
        where TDtoList : class, new()
        where TEntity : class
    {

        public IUnitOfWork _unitOfWork;
        IRepository<TEntity> _repository;

        List<ecvRuleViolation> bavrIssues;
        //ecvOperationStatus _ServiceStatus;

        //ctor
        public ecvService(IUnitOfWork unitOfWork)
        {
            bavrIssues = new List<ecvRuleViolation>();
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.getRepository<TEntity>();
        }


        public int Complete()
        {
            return _unitOfWork.Complete();
        }

        public void CreateEntity(TEntity objTEntity)
        {
            _repository.Add(objTEntity);
        }

        public ecvOperationStatus DeleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDto GetEntityById(int entityId)
        {
            //throw new NotImplementedException();
            var _entity = _repository.Get(entityId);

            TDto _DTO;

            if (_entity == null)
            {
                _DTO = null;
            }
            else
            {
                _DTO = new TDto();
                var _Mapper = new ecvMapper<TEntity, TDto>();

                _DTO = _Mapper.CreateMappedObject(_entity);
            }

            return _DTO;
        }

        public IEnumerable<TDtoList> GetList()
        {
            //throw new NotImplementedException();

            var _List = _repository.GetAll().ToList();

            IList<TDtoList> _ListDTOs;

            if (_List == null)
            {
                _ListDTOs = null;
            }
            else
            {
                var _ListMapper = new ecvMapper<TEntity, TDtoList>();

                _ListDTOs = _ListMapper.CreateMappedObject(_List);
            }

            return _ListDTOs;
        }

        public List<ecvRuleViolation> processBAVRules(TDto objTDto)
        {
            throw new NotImplementedException();
        }

        public ecvOperationStatus SaveEntity(TDto objTDto)
        {
            throw new NotImplementedException();            

        }// End of -- public ecvOperationStatus SaveEntity(TDto objTDto)

        public void UpdateEntity(TEntity objTEntity)
        {
            throw new NotImplementedException();
        }

    }// End of -- public class ecvService
}
