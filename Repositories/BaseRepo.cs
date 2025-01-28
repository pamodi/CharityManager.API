using CharityManager.API.Data;
using CharityManager.API.Entity;
using CharityManager.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CharityManager.API.Repositories
{
    public class BaseRepo(AppDbContext context) : IRepo
    {
        public AppDbContext _context = context;

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw HandleConcurrencyError(ex);
            }
            catch (DbUpdateException ex)
            {
                throw HandleDbUpdateError(ex);
            }
        }

        protected virtual Exception HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store 
            ex.Entries.Single().Reload();

            throw new Exception("Something unexpected happen in the server");
        }

        protected virtual Exception HandleDbUpdateError(DbUpdateException ex)
        {
            // Update the values of the entity that failed to save from the store 
            ex.Entries.Single().Reload();

            throw new Exception("DB Update Error");
        }
    }

    public static class ExtensionOperation
    {
        public static T MarkAsDelete<T>(this Object obj) where T : BaseModel, ISupportSoftDelete
        {
            ISupportSoftDelete i = obj as ISupportSoftDelete;
            if (i != null)
            {
                i.DeletedAt = DateTimeOffset.Now;
                return obj as T;
            }
            else
                return null;
        }
    }
}
