using Ispit.API.Model.Binding;
using Ispit.API.Model.Dbo;

namespace Ispit.API.Services.Interface
{
    public interface IToDoListServices
    {
        Task<ToDoList> AddToDoList(ToDoListBinding model);
        Task<ToDoList> DeleteToDoList(int id);
        Task<ToDoList> GetToDoList(int id);
        Task<ToDoList> UpdateToDoList(int id, ToDoListBinding model);
    }
}