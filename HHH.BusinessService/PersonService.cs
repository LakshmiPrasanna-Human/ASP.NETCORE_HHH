using System;
using System.Collections.Generic;
using System.Text;
using HHH.BusinessEntities;
using HHH.DataModel.UnitOfWork;
using HHH.DataModel.DBModels;
using AutoMapper;
using System.Linq;


namespace HHH.BusinessService
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonService(IUnitOfWork unitOfWork)
        {
            //_unitOfWork = new UnitOfWork();
            _unitOfWork = unitOfWork;
        }

        public Household householdModel { get; private set; }
       
        public bool CreatePerson(PersonEntity personobj, string ClientidClaim)
        {

            //check Person table for FirstName, Midddle Name and Last Name.
            //if(NOT FOUND)
            //{

            //Check if Address is already there. If not insert address in AddressTable.
            //Check if Primary gurdian details provided in HouseHold exists.
            // Insert person data into Person table. Person id genarated. Get the HouseHold id and update the Household id of person record
            //also update the addressid in person table.

            var houseModel = Mapper.Map<HouseHoldEntity, Household>(personobj.HouseHoldData.ToList()[0]);
            var personModel = Mapper.Map<PersonEntity, Person>(personobj);
            var addressModel = Mapper.Map<AddressEntity, Address>(personobj.HouseHoldData.ToList()[0].AddressObj);

            var personObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == personModel.FirstName) &&
                            (x.MiddleName == personModel.MiddleName) && (x.LastName == personModel.LastName)));
            if (personObj == null)
            {
                var addrObj = _unitOfWork.AddressRepository.Get(x => ((x.AddressLine1 == addressModel.AddressLine1) && (x.AddressLine2 == addressModel.AddressLine2)
                               && (x.City == addressModel.City) && (x.Country == addressModel.Country) && (x.StateCode == addressModel.StateCode)
                               && (x.StateName == addressModel.StateName) && (x.ZipCode == addressModel.ZipCode)));
                if (addrObj == null)
                {
                    addressModel.CreatedBy = ClientidClaim;
                    addressModel.CreatedDate = DateTime.Now;
                    addressModel.ModifiedBy = ClientidClaim;
                    addressModel.ModifiedDate = DateTime.Now;
                    _unitOfWork.AddressRepository.Insert(addressModel);
                    addrObj = addressModel;
                }

                 personModel.AddressId = addressModel.AddressId;
                if (personobj.IsStudent)
                   personModel.StudentId = 1;
                _unitOfWork.PersonRepository.Insert(personModel);
               

                if (personobj.IsPrimaryGurdian)
                {
                    houseModel.CreatedBy = ClientidClaim;
                    houseModel.CreatedDate = DateTime.Now;
                    houseModel.ModifiedBy = ClientidClaim;
                    houseModel.ModifiedDate = DateTime.Now;
                    houseModel.AddressId = addrObj.AddressId;
                    houseModel.PersonId = personobj.HouseHoldData.ToList()[0].PersonId;
                    _unitOfWork.HouseholdRepository.Insert(houseModel);
                    personModel.HouseholdId = houseModel.HouseHoldId;
                    _unitOfWork.PersonRepository.Update(personModel);
                }
                _unitOfWork.Save();

                return true;
            }
            else
                return false;

        }

        public bool DeletePerson(string FirstName, string MiddleName, string LastName, string ClientidClaim)
        {
            var personObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == FirstName) &&
                        (x.MiddleName == MiddleName) && (x.LastName == LastName)));
            if (personObj!= null)
            {
                var person = _unitOfWork.PersonRepository.Get(x => x.PersonId == personObj.PersonId);
                _unitOfWork.PersonRepository.Delete(person);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<PersonEntity> GetAllPerson()
        {
            List<PersonEntity> PersonEntityList = new List<PersonEntity>();
            IEnumerable<Person> personlist = _unitOfWork.PersonRepository.GetAll();
            foreach (Person pp in personlist)
            {
                PersonEntity pEntity = Mapper.Map<Person, PersonEntity>(pp);
                IEnumerable<Household> householdData = _unitOfWork.HouseholdRepository.GetWithInclude(x => x.HouseHoldId == pp.HouseholdId, include: "Address");
                List<HouseHoldEntity> _hhEntityList = new List<HouseHoldEntity>();
                foreach (Household hh in householdData)
                {
                   
                    var householdentity = Mapper.Map<Household, HouseHoldEntity>(hh);
                    householdentity.AddressObj = Mapper.Map<Address, AddressEntity>(hh.Address);
                     _hhEntityList.Add(householdentity);
                }
                pEntity.HouseHoldData = _hhEntityList.ToList();
                // pEntity.HouseHoldData = Mapper.Map<IEnumerable<Household>, IEnumerable<HouseHoldEntity>>(householdData);
                PersonEntityList.Add(pEntity);
             }
             return PersonEntityList;
        }

        public PersonEntity GetPersonByPersonID(int personid, string ClientidClaim)
        {
            if (_unitOfWork.PersonRepository.Exists(personid))
            {
                var PersonDataModel = _unitOfWork.PersonRepository.Get(x => x.PersonId == personid);
                return Mapper.Map<Person, PersonEntity>(PersonDataModel);
            }
            else
                return null;
        }

        public bool UpdatePersonInfo(PersonInfo obj, string ClientidClaim)
        {
            // 1.Update can happen to change DOB, email and phone.
            // 2.Update can happen to change Address and HouseHold details. so need to check if provided data exists, if exists need to modify.
            //verify if FirstName, MiddleName and LastName details exists, If Exists get the details and update DOB, email and phone.
            //verify if FirstName, MiddleName and LastName details exists, If exists update address details. Verify if same address exists.
            //search if same personid exists in HouseHold, if exists update the address details.
            var personObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == obj.FirstName) &&
                             (x.MiddleName == obj.MiddleName) && (x.LastName == obj.LastName)));
            if (personObj != null)
            {
                personObj.FirstName = obj.FirstName;
                personObj.MiddleName = obj.MiddleName;
                personObj.LastName = obj.LastName;
                personObj.Phone = obj.Phone;
                personObj.DateofBirth = obj.DateOfBirth;
                personObj.Email = obj.Email;
                personObj.Phone = obj.Phone;
                _unitOfWork.PersonRepository.Update(personObj);
                return true;
            }
            else
                return false;
        }

        public bool UpdatePersonAddress(PersonAddress pAddress, string ClientidClaim)
        {
            var personObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == pAddress.FirstName) &&
                             (x.MiddleName == pAddress.MiddleName) && (x.LastName == pAddress.LastName)));
            if (personObj != null)
            {
                var addrObj = _unitOfWork.AddressRepository.Get(x => ((x.AddressLine1 == pAddress.addressEntity.AddressLine1) && (x.AddressLine2 == pAddress.addressEntity.AddressLine2)
               && (x.City == pAddress.addressEntity.City) && (x.Country == pAddress.addressEntity.Country) && (x.StateCode == pAddress.addressEntity.StateCode)
               && (x.StateName == pAddress.addressEntity.StateName) && (x.ZipCode == pAddress.addressEntity.ZipCode)));
                var householdObj = _unitOfWork.HouseholdRepository.Get(x => (x.PersonId == personObj.PersonId));
                if (addrObj == null)
                {
                    var addressData = Mapper.Map<AddressEntity, Address>(pAddress.addressEntity);
                    addressData.CreatedDate = DateTime.Now;
                    addressData.ModifiedDate = DateTime.Now;
                    addressData.CreatedBy = "APP";
                    addressData.ModifiedBy = "APP";
                    _unitOfWork.AddressRepository.Insert(addressData);
                    householdObj.AddressId = addressData.AddressId;
                    _unitOfWork.HouseholdRepository.Update(householdObj);
                    personObj.AddressId = addressData.AddressId;
                    _unitOfWork.PersonRepository.Update(personObj);
                    _unitOfWork.Save();
                }
                return true;
            }
            else
                return false;
        }
    }
}
