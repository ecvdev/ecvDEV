using System.Collections.Generic;
using ecvLib.Core.ecvDomain;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs;

namespace ecvLibServices.ecvServices
{
    public partial interface IService<TDto, TDtoList, TEntity> where TDto: class
        where TDtoList : class
        where TEntity: class
    {
        /// <summary>
        /// 
        /// Gets an Entity by identifier
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <returns>DTO</returns>
        TDto GetEntityById(int entityId);

        /// <summary>
        /// Gets all records in DTO
        /// </summary>
        /// <returns>List DTOs</returns>
        IEnumerable<TDto> GetAll();        

        /// <summary>
        /// Gets few fields as list
        /// </summary>
        /// <returns>DTOList</returns>
        IEnumerable<TDtoList> GetList();

        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="objTEntity">Entity</param>
        void CreateEntity(TEntity objTEntity);

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="objTEntity">Entity</param>
        void UpdateEntity(TEntity objTEntity);


        /// <summary>
        /// Save the entity
        /// </summary>
        /// <param name="objTDto">DTO</param>
        ecvOperationStatus SaveEntity(TDto objTDto);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entityId">Entity</param>
        ecvOperationStatus DeleteEntity(int entityId);

        /// <summary>
        /// Check Entity Business And Validation Rules
        /// </summary>
        /// <param name="objTDto">DTO</param>
        List<ecvRuleViolation> processBAVRules(TDto objTDto);

        int Complete();

    }// End of -- public partial interface IService
}
