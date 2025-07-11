using Entity;

namespace UseCase
{
    public class ToDoListManager
    {
        private readonly IToDoItemRepository _repository;
        public ToDoListManager(IToDoItemRepository repo)
        {
            _repository = repo;
        }

        public IEnumerable<Todo> getTodoItems()
        {
            return _repository.GetTodoItems();
        }
        public void Add(Todo item)
        {
            _repository.Add(item);
        }

        public void isCompleted(int id)
        {
            var item = _repository.GetTodoById(id);
            if (item != null)
            {
                item.isCompleted = true;
                _repository.Update(item);
            }
        }

        public void Delete(int id)
        {
            var item = _repository.GetTodoById(id);
            if(item != null)
            {
                _repository.Delete(item);
            }
        }
    }
}
