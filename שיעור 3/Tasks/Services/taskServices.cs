using tasks.Models;
using tasks.Interfaces;

namespace tasks.Services;


public  class TaskService : ItaskService
{
    private  List<Doing> arr;
    public TaskService()  
    {
        arr = new List<Doing>
        {
            new Doing { Id = 1, description = "teach",IsDone = false},
            new Doing { Id = 2, description = "clear", IsDone= false},
            new Doing { Id = 3, description = "buy", IsDone= true},
        };
    }  

    public  List<Doing> GetAll() => arr;

    public Doing Get(int id)
    {
        return arr.FirstOrDefault(t => t.Id == id);
    }
    public  int Post(Doing newTask)
    {
        int max = arr.Max(t => t.Id);
        newTask.Id = max + 1;
        arr.Add(newTask);  
        return newTask.Id;      
    }        
    public  void Put(int id, Doing newTask)
    {
        if (id == newTask.Id)
        {
            var task = arr.Find(t => t.Id == id);
            if (task != null)
            {
                int index = arr.IndexOf(task);
                arr[index] =newTask;
            }
        }
    }
        
    public  void Delete(int id)
    {

            var task = arr.Find(t => t.Id == id);
            if (task != null)
            {
                arr.Remove(task);
            }

    }
}
