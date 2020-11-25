using CarStoreDbEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF.Repository
{
    public abstract class BaseRepository<Entity> where Entity : BaseEntity
    {      
        public DbContext context { get; set; }
        public DbSet<Entity> items { get; set; }


        public BaseRepository()
        {
            context = new AppContext();
            items = context.Set<Entity>();
        }

        public void Delete(int id)
        {
            Entity entity = GetById(id);
            Delete(entity);
        }

        private void Delete(Entity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<Entity> GetAll()
        {
            return items.ToList();
        }

        public List<Entity> GetAll(Expression<Func<Entity, bool>> filter)
        {
            return items.Where(filter).ToList();
        }

        public Entity GetById(int id)
        {
            return items.Find(id);
        }

        public void Save(Entity entity)
        {
            if (entity.Id > 0)
            {
                Update(entity);
            }
            else
            {
                Insert(entity);
            }
            context.SaveChanges();
        }

        private void Insert(Entity entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }   
        private void Update(Entity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }


    }
}
