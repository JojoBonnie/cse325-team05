using System.Net.Http.Json;
using System.Text.Json;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Retrieve tasks for a user
    public async Task<List<TaskModel>> GetTasksAsync(string userId)
    {
        try
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskModel>>($"api/tasks/{userId}");
            return tasks ?? new List<TaskModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching tasks: {ex.Message}");
            return new List<TaskModel>();
        }
    }

    // Create a new task
    public async Task<bool> AddTaskAsync(TaskModel task)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/tasks", task);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding task: {ex.Message}");
            return false;
        }
    }

    // Update an existing task
    public async Task<bool> UpdateTaskAsync(TaskModel task)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/tasks/{task.Id}", task);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating task: {ex.Message}");
            return false;
        }
    }

    // Delete a task
    public async Task<bool> DeleteTaskAsync(string taskId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/tasks/{taskId}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting task: {ex.Message}");
            return false;
        }
    }
}
