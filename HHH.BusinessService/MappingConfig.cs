using System;
using System.Collections.Generic;
using System.Text;
using  AutoMapper;
using HHH.BusinessEntities;
using HHH.DataModel.DBModels;

namespace HHH.BusinessService
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Address, AddressEntity>();
                config.CreateMap<IEnumerable<Household>,IEnumerable<HouseHoldEntity>>();
                config.CreateMap<IEnumerable<HouseHoldEntity>,IEnumerable<Household>>();
                config.CreateMap<AddressEntity, Address >();
                config.CreateMap<HouseHoldEntity, Household>();
                config.CreateMap< Household, HouseHoldEntity>();
                config.CreateMap<Person, PersonEntity>();
                config.CreateMap<PersonEntity, Person>();
            });
        }
    }
}
