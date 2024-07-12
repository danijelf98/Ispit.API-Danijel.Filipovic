using Ispit.API.Context;
using Ispit.API.Model.Binding;
using Ispit.API.Model.Dbo;
using Ispit.API.Services.Interface;

namespace Ispit.API.Services.Implementation
{
    public class ToDoListServices : IToDoListServices
    {
        private readonly ApplicationDbContext db;

        public async Task<ToDoList> AddToDoList(ToDoListBinding model)
        {
            var dbo = new ToDoList
            {
                Title = model.Title,
                Description = model.Description,
                IsCompleted = model.IsCompleted
            };

            db.ToDoLists.Add(dbo);
            await db.SaveChangesAsync();
            return dbo;
        }
        public async Task<ToDoList> GetToDoList(int id)
        {
            var dbo = await db.ToDoLists.FindAsync(id);
            return dbo;
        }
        public async Task<ToDoList> DeleteToDoList(int id)
        {
            var dbo = await db.ToDoLists.FindAsync(id);
            db.ToDoLists.Remove(dbo);
            await db.SaveChangesAsync();
            return dbo;
        }
        public async Task<ToDoList> UpdateToDoList(int id, ToDoListBinding model)
        {
            var dbo = await db.ToDoLists.FindAsync(id);
            if (dbo != null)
            {
                dbo.Title = model.Title;
                dbo.Description = model.Description;
                dbo.IsCompleted = model.IsCompleted;

                db.ToDoLists.Update(dbo);
                await db.SaveChangesAsync();
            }
            return dbo;
        }
    }
}
