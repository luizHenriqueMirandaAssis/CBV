using CBV.Core.Application.Interfaces.Handle;
using CBV.Core.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CBV.Infra.Http.Handle
{
    public class HttpHandle : IHttpHandle
    {
        private readonly IJsonHandle _jsonHanlde;

        public HttpHandle(IJsonHandle jsonHanlde)
        {
            _jsonHanlde = jsonHanlde;
        }

        public  async Task<HttpResponse> GetTokenBasic(HttpRequestToken requestToken)
        {
            string clientId = requestToken.ClientId;
            string clientSecret = requestToken.ClientSecret;
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            try
            {
                using (var client = new HttpClient())
                {
                    //Define Headers
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                    //Prepare Request Body
                    List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                };

                    FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                    //Request Token
                    var request = await client.PostAsync(requestToken.Url, requestBody);
                    var response = await request.Content.ReadAsStringAsync();
                    return HttpResponse.Build(request.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return HttpResponse.Build(HttpStatusCode.InternalServerError, ex);
            }
          
        }
        public async Task<HttpResponse> PostAsync(string url, object content, string token = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                    {
                        var json = _jsonHanlde.SerializeObject(content);
                        using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                        {
                            request.Content = stringContent;

                            using (var response = await client
                                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                .ConfigureAwait(false))
                            {
                                response.EnsureSuccessStatusCode();

                                var valueResponse = response.Content.ReadAsStringAsync().Result;
                                return HttpResponse.Build(response.StatusCode, valueResponse);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return HttpResponse.Build(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<HttpResponse> GetAsync(string url, string token = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    using (var response = await client.SendAsync(request))
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        return HttpResponse.Build(response.StatusCode, content);
                    }
                }
            }
            catch (Exception ex)
            {
                return HttpResponse.Build(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
