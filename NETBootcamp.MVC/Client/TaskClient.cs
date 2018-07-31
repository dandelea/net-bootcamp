using Newtonsoft.Json;
using NETBootcamp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace NETBootcamp.MVC.Client
{
    public class TaskClient
    {
        static HttpClient _client = new HttpClient();

        static string BASE = "http://localhost:8008/";

        static string URL_SECTION = "api/tasks";

        public TaskClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BASE);
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksAsync(int projectId)
        {
            IEnumerable<Task> tasks = null;
            HttpResponseMessage response = await _client.GetAsync(URL_SECTION + $"?ProjectID={projectId}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<IEnumerable<Task>>(json);
            }
            return tasks;
        }

        public static async System.Threading.Tasks.Task<Task> GetTaskAsync(int id)
        {
            Task task = null;
            HttpResponseMessage response = await _client.GetAsync(URL_SECTION + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<Task>(json);
            }
            return task;
        }

        public static async System.Threading.Tasks.Task<Uri> CreateTaskAsync(Task task)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(URL_SECTION, JsonConvert.SerializeObject(task));
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async System.Threading.Tasks.Task<Task> UpdateTaskAsync(Task task)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(URL_SECTION + $"/{task.ID}", JsonConvert.SerializeObject(task));
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            string json = await response.Content.ReadAsStringAsync();
            task = JsonConvert.DeserializeObject<Task>(json);
            return task;
        }

        public static async System.Threading.Tasks.Task<HttpStatusCode> DeleteTaskAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(URL_SECTION + $"/{id}");
            return response.StatusCode;
        }
    }
}