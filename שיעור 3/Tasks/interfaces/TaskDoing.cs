using tasks.Models;

namespace tasks.Interfaces;

  public interface ItaskService
{
      List<Doing> GetAll();

      Doing Get(int id);
      int Post(Doing newTask);      
      void Put(int id, Doing newTask);
        
      void Delete(int id);
}