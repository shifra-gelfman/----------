using tasks.Models;
using tasks.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;


namespace tasks.Services
{
    public class TaskService : ItaskService
    {
        List<Doing> tasks { get; }
        private string filePath;
        public TaskService(IWebHostEnvironment webHost)
        {
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "tasks.json");
            using (var jsonFile = File.OpenText(filePath))
            {
                tasks = JsonSerializer.Deserialize<List<Doing>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
        }
        public List<Doing> GetAll() => tasks;

        public Doing Get(int id) => tasks.FirstOrDefault(t => t.Id == id);

        public void Post(Doing task)
        {
            task.Id = tasks.Count() + 1;
            tasks.Add(task);
            saveToFile();
        }

        public void Delete(int id)
        {
            var task = Get(id);
            if (task is null)
                return;

            tasks.Remove(task);
            saveToFile();
        }

        public void Put(Doing task)
        {
            var index = tasks.FindIndex(t => t.Id == task.Id);
            if (index == -1)
                return;

            tasks[index] = task;
            saveToFile();
        }

        public int Count => tasks.Count();
    }
}