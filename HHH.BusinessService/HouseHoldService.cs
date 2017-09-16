using System;
using System.Collections.Generic;
using System.Text;
using HHH.DataModel.UnitOfWork;
using HHH.BusinessEntities;
using HHH.DataModel.DBModels;
using System.Transactions;
using AutoMapper;
using System.Linq;

namespace HHH.BusinessService
{
    public class HouseHoldService : IHouseHoldService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HouseHoldService(IUnitOfWork unitOfWork)
        {
            //_unitOfWork = new UnitOfWork();
            _unitOfWork = unitOfWork;

        }
        public int CreateHouseHold(HouseHoldEntity houseHoldObj, string ClientidClaim)
        {
          //  using (var scope = new TransactionScope())
            {
                Household householdModel = new Household();
                Address addressModel = new Address();
                addressModel = Mapper.Map<AddressEntity, Address>(houseHoldObj.AddressObj);
                householdModel = Mapper.Map<HouseHoldEntity, Household>(houseHoldObj);

                //Need to write a Save method ovveride in DBContext class to set below values.
                addressModel.CreatedBy = ClientidClaim;
                addressModel.CreatedDate = DateTime.Now;
                addressModel.ModifiedBy = ClientidClaim;
                addressModel.ModifiedDate = DateTime.Now;
                _unitOfWork.AddressRepository.Insert(addressModel);
                householdModel.CreatedBy = ClientidClaim;
                householdModel.CreatedDate = DateTime.Now;
                householdModel.ModifiedBy = ClientidClaim;
                householdModel.ModifiedDate = DateTime.Now;
                householdModel.AddressId = addressModel.AddressId;
                householdModel.PersonId = houseHoldObj.PersonId;
                _unitOfWork.HouseholdRepository.Insert(householdModel);
                _unitOfWork.Save();
                return householdModel.HouseHoldId;
            }


        }

        public IEnumerable<HouseHoldEntity> GetAllHouseHold()
        {
            List< HouseHoldEntity>  houseHoldEntityList = new List<HouseHoldEntity>();
            IEnumerable<Household> householdlist = _unitOfWork.HouseholdRepository.GetWithInclude(null, include: "Address");
            foreach (Household hh in householdlist)
            {
                HouseHoldEntity hhe = new HouseHoldEntity();
                hhe.PersonId = hh.PersonId;
                hhe.AddressObj = new AddressEntity();
                hhe.AddressObj = Mapper.Map<Address, AddressEntity>(hh.Address);
                houseHoldEntityList.Add(hhe);
            }
            //  Mapper.Map<List<Household>, List<HouseHoldEntity>>(_householdlist.ToList<Household>(), houseHoldEntityList);
            return houseHoldEntityList;
        }

        //updates the house hold. Either updates the personid(primary gurdian and verified if Address is alread there.
        //If it exists will update the address. In case if Address doesnot exist would add the address
        public int UpdateHouseHold(HouseHoldEntity houseHoldObj, string ClientidClaim)
        {
            Household TemphouseHold=null;
            Household householdModel = new Household();
            Address addressModel = new Address();
            addressModel = Mapper.Map<AddressEntity, Address>(houseHoldObj.AddressObj);
            householdModel = Mapper.Map<HouseHoldEntity, Household>(houseHoldObj);

          var addrObj = _unitOfWork.AddressRepository.GetSingle(x => ((x.AddressLine1 == addressModel.AddressLine1) && (x.AddressLine2 == addressModel.AddressLine2)
              && (x.City == addressModel.City) && (x.Country == addressModel.Country) && (x.StateCode == addressModel.StateCode)
              && (x.StateName == addressModel.StateName) && (x.ZipCode == addressModel.ZipCode)));
            // tbd by person name need to get person id.
            var personObject = _unitOfWork.PersonRepository.GetSingle(x => (x.PersonId == householdModel.PersonId));
            if (addrObj != null && personObject != null)
                TemphouseHold = _unitOfWork.HouseholdRepository.Get(x => ((x.PersonId == personObject.PersonId) && (x.AddressId == addrObj.AddressId))
                                                                            || (x.PersonId == personObject.PersonId)
                                                                            || (x.AddressId == personObject.AddressId));

            if (addrObj != null)
                addressModel.AddressId = addrObj.AddressId;
            else
                _unitOfWork.AddressRepository.Insert(addressModel);

            //get these details from existing entity
            addressModel.CreatedBy = ClientidClaim;
            addressModel.CreatedDate = DateTime.Now;
            addressModel.ModifiedBy = ClientidClaim;
            addressModel.ModifiedDate = DateTime.Now;
            householdModel.CreatedBy = ClientidClaim;
            householdModel.CreatedDate = DateTime.Now;
            householdModel.ModifiedBy = ClientidClaim;
            householdModel.ModifiedDate = DateTime.Now;
            householdModel.AddressId = addressModel.AddressId;
            householdModel.PersonId = houseHoldObj.PersonId;
            householdModel.HouseHoldId = TemphouseHold.HouseHoldId;
            _unitOfWork.HouseholdRepository.Update(householdModel);
            _unitOfWork.Save();
            return householdModel.HouseHoldId;
        }

        public bool DeleteHouseHold(int householdid, string ClientidClaim)
        {
            if (_unitOfWork.HouseholdRepository.Exists(householdid))
            {
                var houseHold= _unitOfWork.HouseholdRepository.Get(x => x.HouseHoldId == householdid);
                _unitOfWork.HouseholdRepository.Delete(houseHold);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePrimaryGuardian(int HouseHoldId, string newGurdianPerson, string ClientidClaim)
        {
            throw new NotImplementedException();
        }

        public HouseHoldEntity GetHouseHoldByPersonID(int personid, string ClientidClaim)
        {
            throw new NotImplementedException();
        }

        public HouseHoldEntity GetHouseHoldByID(int householdId, string ClientidClaim)
        {

            if (_unitOfWork.HouseholdRepository.Exists(householdId))
            {
                var houseHoldDataModel=  _unitOfWork.HouseholdRepository.Get(x => x.HouseHoldId == householdId);
                return  Mapper.Map<Household, HouseHoldEntity>(houseHoldDataModel);
            }
            else
                return null;
        }

        public string GetHouseHoldPrimaryGuardian(int householdid)
        {
            if (_unitOfWork.HouseholdRepository.Exists(householdid))
            {
                var houseHold= _unitOfWork.HouseholdRepository.Get(x => x.HouseHoldId == householdid);
                var personDetails = _unitOfWork.PersonRepository.Get(x => x.PersonId == houseHold.PersonId);
                return personDetails.FirstName;
            }
            else
                return null;
        }
    }
}
