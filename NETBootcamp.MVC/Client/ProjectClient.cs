using Newtonsoft.Json;
using NETBootcamp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace NETBootcamp.MVC.Client
{
    public class ProjectClient
    {

        static HttpClient _client = new HttpClient();

        static string BASE = "http://localhost:8008/";

        static string URL_SECTION = "api/projects";

        public ProjectClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BASE);
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Project>> GetProjectsAsync()
        {
            IEnumerable<Project> projects = null;
            HttpResponseMessage response = await _client.GetAsync(URL_SECTION);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(json);
            }
            return projects;
        }

        public static async System.Threading.Tasks.Task<Project> GetProjectAsync(int id)
        {
            Project project = null;
            HttpResponseMessage response = await _client.GetAsync(URL_SECTION + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<Project>(json);
            }
            return project;
        }

        public static async System.Threading.Tasks.Task<Uri> CreateProjectAsync(Project project)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(URL_SECTION, JsonConvert.SerializeObject(project));
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async System.Threading.Tasks.Task<Project> UpdateProjectAsync(Project project)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(URL_SECTION + $"/{project.ID}", JsonConvert.SerializeObject(project));
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            string json = await response.Content.ReadAsStringAsync();
            project = JsonConvert.DeserializeObject<Project>(json);
            return project;
        }

        public static async System.Threading.Tasks.Task<HttpStatusCode> DeleteProjectAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(URL_SECTION + $"/{id}");
            return response.StatusCode;
        }
    }
}