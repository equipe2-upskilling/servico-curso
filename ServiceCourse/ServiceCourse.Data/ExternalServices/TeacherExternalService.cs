using ServiceCourse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ServiceCourse.Data.ExternalServices
{
    public class TeacherExternalService
    {
        private readonly HttpClient httpClient;

        //private static AccessToken? accessToken;
        private static string _apiUrl;

        public TeacherExternalService()
        {
            _apiUrl = "https://localhost:7215";
            httpClient = new HttpClient();
        }
        //public async Task<Teacher> GetTeachers()
        //{
        //    var urlBase = _apiUrl + "/all";

        //    try
        //    {
        //        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ2YWx1ZSI6IntcIklkXCI6MyxcIkVtYWlsXCI6XCJ1c3VhcmlvQGVtYWlsLmNvbVwiLFwiUGFzc3dvcmRcIjpcIjhwY3I4ZUJseUk5MDZSWGNWNUJFZEZhTktmZndqSVpiTjBoRmhRbi8xY1U9XCIsXCJTYWx0XCI6XCJCNDQ2cGlxRllHMnNNSkRWMkhESkNnPT1cIn0iLCJuYmYiOjE2OTAzNzk4MjgsImV4cCI6MTY5MDk4NDYyOCwiaWF0IjoxNjkwMzc5ODI4fQ.TcuxaHULyI82DDHFWvV-3DFFB7KomQp3DnyLlMcrbK8";
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");

        //        HttpResponseMessage response = await httpClient.GetAsync(urlBase);

        //        response.EnsureSuccessStatusCode(); // Lança uma exceção em caso de erro HTTP (códigos 4xx ou 5xx)

        //        string conteudo = await response.Content.ReadAsStringAsync();


        //        Teacher teacher = System.Text.Json.JsonSerializer.Deserialize<Teacher>(conteudo);

        //        return teacher;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro: {ex.Message}");
        //    }
        //    return null;

        //}

        public List<Teacher> GetTeachers()
        {
            var urlBase = _apiUrl + "/all";

            try
            {
                var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ2YWx1ZSI6IntcIklkXCI6MyxcIkVtYWlsXCI6XCJ1c3VhcmlvQGVtYWlsLmNvbVwiLFwiUGFzc3dvcmRcIjpcIjhwY3I4ZUJseUk5MDZSWGNWNUJFZEZhTktmZndqSVpiTjBoRmhRbi8xY1U9XCIsXCJTYWx0XCI6XCJCNDQ2cGlxRllHMnNNSkRWMkhESkNnPT1cIn0iLCJuYmYiOjE2OTAzNzk4MjgsImV4cCI6MTY5MDk4NDYyOCwiaWF0IjoxNjkwMzc5ODI4fQ.TcuxaHULyI82DDHFWvV-3DFFB7KomQp3DnyLlMcrbK8";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = httpClient.GetAsync(urlBase).Result;

                response.EnsureSuccessStatusCode(); // Lança uma exceção em caso de erro HTTP (códigos 4xx ou 5xx)

                string content = response.Content.ReadAsStringAsync().Result;

                List<Teacher> teachers = System.Text.Json.JsonSerializer.Deserialize<List<Teacher>>(content);

                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

    }
}
