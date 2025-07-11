using Entity;
using UseCase;

namespace Infrastructure
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly List<Todo> list;
        private int nextId = 1;

        public ToDoItemRepository()
        {
            list = new List<Todo>();
        }

        public void Add(Todo item)
        {
            item.id = nextId++;
            list.Add(item);
        }

        public void Delete(Todo item)
        {
            list.Remove(item);
        }

        public Todo GetTodoById(int id)
        {
            var item = list.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                throw new Exception("Khong co item todo co id nay");
            }
            return item;
        }

        public IEnumerable<Todo> GetTodoItems()
        {
            return list;
        }

        public void Update(Todo item)
        {
            var item_update = list.FirstOrDefault(t => t.id == item.id);
            if (item_update == null)
            {
                throw new Exception("Khong co item todo co id nay");
            }
            item_update.text = item.text;
            item_update.isCompleted = item.isCompleted;
        }
    }
}
