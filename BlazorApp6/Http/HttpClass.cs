﻿using Newtonsoft.Json.Linq;
using System.Text;

namespace BlazorApp6.Http;

public class HttpClass
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClass(IHttpClientFactory httpClientFactory)
    {
        this._httpClientFactory = httpClientFactory;
    }
    public async Task<T> GetAsync<T>(string url, string querystring)
    {
        string urlq;
        if (string.IsNullOrEmpty(querystring))
            urlq = url;
        else
            urlq = $"{url}?{querystring}";

        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(urlq);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(jsonString);
                return jo.ToObject<T>();
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }

    public async Task<T> PostAsync<T>(string url, string jsonPayload, string basicAuthToken)
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {basicAuthToken}" );

            HttpContent payload = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, payload);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(jsonString);
                return jo.ToObject<T>();
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }

}
