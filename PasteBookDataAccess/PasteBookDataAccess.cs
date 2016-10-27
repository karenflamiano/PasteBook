using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class PasteBookDataAccess<T> where T : class
    {
        //public bool Create(T newEntity)
        //{
        //    int status = 0;
        //    try
        //    {
        //        using (var context = new PASTEBOOKEntities1())
        //        {
        //            context.Entry(newEntity).State = System.Data.Entity.EntityState.Added;
        //            status = context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return status != 0;

        //}

        public int Add(T newEntity)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Added;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status;

        }

        public bool Edit(T newEntity)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Modified;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status != 0;
        }

        //public int Edit(T newEntity)
        //{
        //    int status = 0;
        //    try
        //    {
        //        using (var context = new PASTEBOOKEntities1())
        //        {
        //            context.Entry(newEntity).State = System.Data.Entity.EntityState.Modified;
        //            status = context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return status;
        //}

        public bool Delete(T newEntity)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Deleted;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status != 0;
        }

        public List<T> GetAllResult()
        {
            List<T> entityList = new List<T>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    entityList = context.Set<T>().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entityList;
        }

        public List<T> GetOneResult(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            List<T> entityList = new List<T>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    entityList = context.Set<T>().Where(predicate).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entityList;
        }
    }
}
