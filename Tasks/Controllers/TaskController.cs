using Microsoft.AspNetCore.Mvc;
using tasks.Models;

namespace tasks.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : ControllerBase
{
    private static List<task> arr;
    static TaskController()
    {
        arr = new List<task>
        {
            new task {Id = 1, description = "to do homeWork", IsDone = false}
        };
    }
    
    [HttpGet]
    public IEnumerable<task> Get()
    {
        return arr;
    }
    
    [HttpGet("{id}")]
    public task Get(int id)
    {
        return arr.FirstOrDefault(p => p.Id == id);
    }

        
    [HttpPost]
    public void Post(task newTask)
    {
        int max = arr.Max(p => p.Id);
        newTask.Id = max + 1;
        arr.Add(newTask);        
    }

    [HttpPut("{id}")]
    public void Put(int id, task newTask)
    {
       if (id == newTask.Id)
        {
            var task = arr.Find(p => p.Id == id);
            if (task != null)
            {
                int index = arr.IndexOf(task);
                arr[index] = newTask;
            }
        }
    } 

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var task = arr.Find(p => p.Id == id);
        if (task != null)
        {
            arr.Remove(task);
        }
    } 


}