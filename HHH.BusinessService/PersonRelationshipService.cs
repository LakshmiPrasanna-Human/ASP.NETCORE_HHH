using System;
using System.Collections.Generic;
using System.Text;
using HHH.BusinessEntities;
using HHH.DataModel.UnitOfWork;
using HHH.DataModel.DBModels;
using System.Linq;

namespace HHH.BusinessService
{
    public class PersonRelationshipService : IPersonRelationship
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonRelationshipService(IUnitOfWork unitOfWork)
        {
            //_unitOfWork = new UnitOfWork();
          _unitOfWork = unitOfWork;

        }
        public bool CreatePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity)
        {
            //for a given student name , get the person details from Person table. If does not exist return.
            //If student person details exists in Person table, get those details.
            //For a given student get all the existing PersonRelationships, if exists any specific Relationship type would return. 
            //Insert into PerdonRelationship table for the list of the person data provided, before that verify each of the Person details exists
            //in Person table.
            List<PersonRelationship> personRelationInsertData = new List<PersonRelationship>();
            IEnumerable<RelationshipType> relationshipTypesData = _unitOfWork.PersonRelationshipTypeRepository.GetAll();
            var personObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == personRelationshipentity.StudentFirstName) &&
                         (x.MiddleName == personRelationshipentity.StudentMiddleName) && (x.LastName == personRelationshipentity.StudentLastName)));
            if (personObj != null)
            {
                foreach (PersonRelationshipEntity data in personRelationshipentity.RelationShipEntities)
                {
                    //get the list of personid's for all the person names in input parameter
                    personRelationInsertData.Add(new PersonRelationship
                    {
                        PersonId = _unitOfWork.PersonRepository.GetFirst(x => ((x.FirstName == data.FirstName) &&
                        (x.MiddleName == data.MiddleName) && (x.LastName == data.LastName))).PersonId,
                        StudentPersonId = personObj.PersonId,
                        RelationshipTypeId = _unitOfWork.PersonRelationshipTypeRepository.GetFirst(x => (x.RelationshipTypeCode == data.RelatioshipType)).RelationshipType1,
                        EffectiveFrom = DateTime.Now,
                        EffectiveTo = DateTime.Now,
                        CreatedBy = "CLIENTID",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "CLIENTID",
                        ModifiedDate = DateTime.Now
                    });
                }

                foreach (PersonRelationship data in personRelationInsertData)
                    _unitOfWork.PersonRelationshipRepository.Insert(data);
                _unitOfWork.Save();
                return true;
            }
            else
                return false;

        }

        public bool DeletePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity)
        {
            // 1. get the student id from student name in person table.
            // 2. for each of the student relation in the list get the personid and verify if person id exists in PersonRelationShip table
            // delete person id from PersonRelationShip table.
            var studentpersonObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == personRelationshipentity.StudentFirstName) &&
                       (x.MiddleName == personRelationshipentity.StudentMiddleName) && (x.LastName == personRelationshipentity.StudentLastName)));
            if (studentpersonObj != null)
            {
                foreach (PersonRelationshipEntity data in personRelationshipentity.RelationShipEntities)
                {
                    var Personid = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == data.FirstName) &&
                           (x.MiddleName == data.MiddleName) && (x.LastName == data.LastName))).PersonId;
                    PersonRelationship obj = _unitOfWork.PersonRelationshipRepository.GetFirst(x => (x.PersonId == Personid));
                    if (obj.StudentPersonId == studentpersonObj.PersonId)
                    {
                        _unitOfWork.PersonRelationshipRepository.Delete(obj);
                        _unitOfWork.Save();
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
           
        }

        public bool UpdatePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity)
        {
            //For a given student get all the existing PersonRelationships. Compare with the input Relationships and update.
            var studentpersonObj = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == personRelationshipentity.StudentFirstName) &&
                      (x.MiddleName == personRelationshipentity.StudentMiddleName) && (x.LastName == personRelationshipentity.StudentLastName)));
            List<PersonRelationship> query = _unitOfWork.PersonRelationshipRepository.GetMany(x => (x.StudentPersonId == studentpersonObj.StudentId)).ToList();
            if (studentpersonObj != null)
            {
                foreach (PersonRelationshipEntity data in personRelationshipentity.RelationShipEntities)
                {
                    var PersonRelationData = _unitOfWork.PersonRepository.Get(x => ((x.FirstName == personRelationshipentity.StudentFirstName) &&
                       (x.MiddleName == personRelationshipentity.StudentMiddleName) && (x.LastName == personRelationshipentity.StudentLastName)));
                    //get the relationship code for above person from PersonRelationShip
                    var presentPersonRelationData = _unitOfWork.PersonRelationshipRepository.Get(x => (x.PersonId == PersonRelationData.PersonId));
                    _unitOfWork.PersonRelationshipRepository.Delete(presentPersonRelationData);

                }
                _unitOfWork.Save();
                return true;
            }
            else
                return false;
        }
    }
        
}
