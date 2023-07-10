using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Services;

internal class TaskService
{
    private readonly List<TaskItem> tasks;

    public TaskService()
    {
        tasks = new List<TaskItem>();
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public void DeleteTask(string taskId)
    {
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            tasks.Remove(task);
        }
    }

    public void MarkTaskAsDone(string taskId)
    {
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsDone = true;
        }
    }

    public List<TaskItem> GetTasks()
    {
        return tasks;
    }
}
