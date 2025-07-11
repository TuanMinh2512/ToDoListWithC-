using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase
{
    public interface IToDoItemRepository
    {
        void Add(Todo item);
        void Delete(Todo item);
        Todo GetTodoById(int id);
        IEnumerable<Todo> GetTodoItems();
        void Update(Todo item);
    }
}
