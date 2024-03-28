using tasks.Models;

namespace tasks.Interfaces;

  public interface ItaskService
{
      List<Doing> GetAll();

      Doing Get(int id);
      void Post(Doing newTask);      
      void Put(Doing newTask);
      void Delete(int id);
      int Count {get;}
}