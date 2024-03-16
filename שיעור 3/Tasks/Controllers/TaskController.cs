using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using tasks.Models;
using tasks.Interfaces;

namespace tasks.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : ControllerBase
{
    public  ItaskService taskServices;
 
    public TaskController( ItaskService taskServices)
    {
        this.taskServices=taskServices;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Doing>> Get()
    {
        return taskServices.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult <Doing>Get(int id)
    {
        var task = taskServices.Get(id);
        if (task == null)
            return NotFound();
        return Ok(task); 
    }

        
    [HttpPost]
    public ActionResult Post(Doing newTask)
    {
        var newId = taskServices.Post(newTask);      
        return CreatedAtAction(nameof(Post), new {id=newId}, newTask);      
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Doing newTask)
    {
        taskServices.Put(id, newTask);
        return Ok();
    } 

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
       taskServices.Delete(id);
        return Ok();
    } 


}