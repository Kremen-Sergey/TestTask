using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface.Entities
{
    //base generic interface for all catalogs:shop catalog, user's catalog, etc.
    public interface ICatalog<TEntity>
    {
        //List of all entities available for using
        LinkedList<TEntity> ListEntities { get; set; }
        //list of Pedestals. Pedestal used as table leg.
        //pedestal is list of entities and those entites are unevailable for using
        LinkedList<LinkedList<TEntity>> Pedestals { get; set; }
        void AddEntityToCatalog(TEntity entity);
        void DeleteEntityFromCatalog(TEntity entity);
    }
}
