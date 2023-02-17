using NewsAppMaui.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace NewsAppMaui.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTasksAsync();
        Task SaveTaskAsync(TodoItem item, bool isNewItem);
        Task DeleteTaskAsync(TodoItem item);
    }
}
