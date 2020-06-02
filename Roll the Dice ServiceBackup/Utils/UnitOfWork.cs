using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Utils
{

    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    [InjectableAttributeTransient]
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private member variables...

        private RolltheDiceDBEntities rolltheDiceEntities = null;

        private string _token = String.Empty;


        #endregion

        public UnitOfWork()
        {
            rolltheDiceEntities = new RolltheDiceDBEntities();

        }

        #region Public Repository Creation properties...


        public GenericRepository<TEntity> RepositoryClient<TEntity>() where TEntity : class
        {
            GenericRepository<TEntity> _gr = null;

            string type = typeof(TEntity).ToString();
            _gr = new GenericRepository<TEntity>(rolltheDiceEntities);

            _gr.Context = rolltheDiceEntities;
            return _gr;
        }

        public RolltheDiceDBEntities Repository()
        {
            return this.rolltheDiceEntities;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Save method.
        /// </summary>


        public void SaveChanges()
        {
            try
            {
                rolltheDiceEntities.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DbEntityValidationHandler(e);
            }
            catch (DbUpdateException)
            {
                //TODO - agregar catch para controlar excepcion de delete sin cascade
                throw;
            }
            catch (Exception ex)
            {
                var e = ex;
            }

        }

        private void DbEntityValidationHandler(DbEntityValidationException e)
        {
            var outputLines = new List<string>();
            foreach (var eve in e.EntityValidationErrors)
            {
                outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                foreach (var ve in eve.ValidationErrors)
                {
                    outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                }
            }
            //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

            throw e;
        }

        #endregion

        #region Implementing IDisposable...

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
                    Debug.WriteLine("UnitOfWork is being disposed");
                    rolltheDiceEntities.Dispose();
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
        #endregion
    }
}