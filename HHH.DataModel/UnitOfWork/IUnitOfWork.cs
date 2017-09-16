using System;
using System.Collections.Generic;
using System.Text;
using HHH.DataModel.DBModels;
using HHH.DataModel.Repository;

namespace HHH.DataModel.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Household> HouseholdRepository { get;  }
        IGenericRepository<Address> AddressRepository { get;  }
        IGenericRepository<PersonRelationship> PersonRelationshipRepository { get;  }
        IGenericRepository<RelationshipType> PersonRelationshipTypeRepository { get;  }
        void Save();
    }
}
