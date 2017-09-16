using HHH.DataModel.DBModels;
using HHH.DataModel.Repository;
using System;


namespace HHH.DataModel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private HHHContext _context = null;
        private IGenericRepository<Person> _personRepository;
        private IGenericRepository<Household> _householdRepository;
        private IGenericRepository<Address> _addressRepository;
        private IGenericRepository<PersonRelationship> _personRelationshipRepository;
        private IGenericRepository<RelationshipType> _personRelationshipTypeRepository;

        public UnitOfWork()
        {
            _context = new HHHContext();
        }

        /// <summary>
        /// Get/Set Property for person repository.
        /// </summary>
        public IGenericRepository<Person> PersonRepository
        {
            get
            {
                if (this._personRepository == null)
                    this._personRepository = new GenericRepository<Person>(_context);
                return _personRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public IGenericRepository<Household> HouseholdRepository
        {
            get
            {
                if (this._householdRepository == null)
                    this._householdRepository = new GenericRepository<Household>(_context);
                return _householdRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public IGenericRepository<Address> AddressRepository
        {
            get
            {
                if (this._addressRepository == null)
                    this._addressRepository = new GenericRepository<Address>(_context);
                return _addressRepository;
            }
        }

        public IGenericRepository<PersonRelationship> PersonRelationshipRepository
        {
            get
            {
                if (this._personRelationshipRepository == null)
                    this._personRelationshipRepository = new GenericRepository<PersonRelationship>(_context); 
                return _personRelationshipRepository;
            }
        }

        public IGenericRepository<RelationshipType> PersonRelationshipTypeRepository
        {
            get
            {
                if (this._personRelationshipTypeRepository == null)
                    this._personRelationshipTypeRepository = new GenericRepository<RelationshipType>(_context);
                return _personRelationshipTypeRepository;
            }
        }
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            //try
            {
                _context.SaveChanges();
            }
            //catch (DbEntityValidationException e)
            //{

            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

            //    throw e;
            //}

        }



        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}

