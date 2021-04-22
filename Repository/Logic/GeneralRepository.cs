using Model;
using OP.Infrastructure.Repository.Interfaces;
using OP.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OP.Infrastructure.Repository.Logic
{

    public class GeneralRepository<T> :   IRepository<T> where T : class  
    {
        private readonly OPedia db;
        private  readonly DbSet<T> table;
        public GeneralRepository()
        {
            db = new OPedia();
           
            table = db.Set<T>();

        }

        
        public T Add(T Entity)
        {
            try
            {
                AddWithoutSave(Entity);
                if (SaveChange())
                    return Entity;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IQueryable<T> GetALl() {
            return table;
        
        }
        public T AddWithoutSave(T Enitity)
        {
            table.Add(Enitity);
            return Enitity;
        }

        public T Get(int id)
        {
           
            return table.Find(id);
        }

        public bool SaveChange()
        {
            try
            {
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T Entity)
        {
            if (UpdateWithoutSave(Entity)) 
            {
                return SaveChange();
            }
            return false;
        }

        public bool UpdateWithoutSave(T Entity)
        {
            try
            {
                table.Attach(Entity);
                db.Entry(Entity).State = EntityState.Modified;
                return true;

            }
            catch(Exception ex) {
               

                    return false;
                

               
            
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool AddRange(ICollection<T> Entity)
        {
            try
            {
                table.AddRange(Entity);
                return SaveChange();
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public virtual T Get(string id)
        {
          return  table.Find(id);
        }
    }
}