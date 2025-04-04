﻿using Newtonsoft.Json;
using GenericApp.Common.Requests;
using GenericApp.Common.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GenericApp.Common.Models;

namespace GenericApp.Common.Services
{
    public class ApiService : IApiService
    {
        private object cables;

        public async Task<ResponseT<UsuarioAppResponse>> GetUserByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string email,
            string password)
        {
            try
            {
                var request = new UserRequest { Email = email, Password = password };
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<UsuarioAppResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var owner = JsonConvert.DeserializeObject<UsuarioAppResponse>(result);
                return new ResponseT<UsuarioAppResponse>
                {
                    IsSuccess = true,
                    Result = owner
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<UsuarioAppResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseT<CausanteResponse>> GetCausanteByCodigoAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string codigo)
        {
            try
            {
                var request = new CausanteRequest { Codigo = codigo};
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<CausanteResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var owner = JsonConvert.DeserializeObject<CausanteResponse>(result);
                return new ResponseT<CausanteResponse>
                {
                    IsSuccess = true,
                    Result = owner
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<CausanteResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseT<ObrasPosteResponse>> GetTicketAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string codigo)
        {
            try
            {
                var request = new TicketRequest { ASTICKET = codigo };
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<ObrasPosteResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var obrasPoste = JsonConvert.DeserializeObject<ObrasPosteResponse>(result);
                return new ResponseT<ObrasPosteResponse>
                {
                    IsSuccess = true,
                    Result = obrasPoste
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<ObrasPosteResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseT<object>> GetObrasDocumentosAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            int IDObrasPostes)
        {
            try
            {
                var model = new NROREGISTRORequest { NROREGISTRO = IDObrasPostes };
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var obrasDocumentos = JsonConvert.DeserializeObject<List<ObraDocumentoResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = obrasDocumentos
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest)
        {
            try
            {
                string request = JsonConvert.SerializeObject(userRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> RecoverPasswordAsync(string urlBase, string servicePrefix, string controller, EmailRequest emailRequest)
        {
            try
            {
                string request = JsonConvert.SerializeObject(emailRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> ModifyUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest, string token)
        {
            try
            {
                string request = JsonConvert.SerializeObject(userRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Response>(answer);
                }

                UserResponse user = JsonConvert.DeserializeObject<UserResponse>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = user
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> ChangePasswordAsync(string urlBase, string servicePrefix, string controller, ChangePasswordRequest changePasswordRequest, string token)
        {
            try
            {
                string request = JsonConvert.SerializeObject(changePasswordRequest);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                Response obj = JsonConvert.DeserializeObject<Response>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        //public async Task<Response> PostAsync<T>(string urlBase, string servicePrefix, string controller, T model, string token)
        //{
        //    try
        //    {
        //        string request = JsonConvert.SerializeObject(model);
        //        StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
        //        HttpClient client = new HttpClient
        //        {
        //            BaseAddress = new Uri(urlBase)
        //        };

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        //        string url = $"{servicePrefix}{controller}";
        //        HttpResponseMessage response = await client.PostAsync(url, content);
        //        string result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = result,
        //            };
        //        }

        //        T item = JsonConvert.DeserializeObject<T>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Result = item
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };
        //    }
        //}

        public async Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller, string token)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseT<object>> PutAsync2<T>(
             string urlBase,
             string servicePrefix,
             string controller,
             T model,
             int id)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new ResponseT<object>
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Stream> GetPictureAsync(string urlBase, string servicePrefix)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                string url = $"{servicePrefix}";
                HttpResponseMessage response = await client.GetAsync(url);
                Stream stream = await response.Content.ReadAsStreamAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return stream;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResponseT<object>> PostAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }
                var res = JsonConvert.DeserializeObject<T>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = res
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> DeleteAsync(
           string urlBase,
           string servicePrefix,
           string controller,
           int id)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> DeleteAsync(
           string urlBase,
           string servicePrefix,
           string controller,
           int id,
           string tokenType,
           string accessToken)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseT<object>> GetObras(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var obras = JsonConvert.DeserializeObject<List<ObraResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = obras
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseT<object>> GetCatalogos(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var catalogos = JsonConvert.DeserializeObject<List<CatalogoResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = catalogos
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseT<object>> GetNroRegistroMax(
           string urlBase,
           string servicePrefix,
           string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = answer
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


        public async Task<ResponseT<object>> GetEntregasForCodigo(
            string urlBase,
            string servicePrefix,
            string controller,
            string codigo)
        {
            try
            {
                var model = codigo ;
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var remotes = JsonConvert.DeserializeObject<List<EntregaResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = remotes
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


        public async Task<ResponseT<object>> GetEntregas2ForCodigo(
            string urlBase,
            string servicePrefix,
            string controller,
            string codigo)
        {
            try
            {
                var model = codigo;
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var remotes = JsonConvert.DeserializeObject<List<EntregaDetalleResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = remotes
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


        public async Task<Response> GetEntregaDetallesPorFecha(string urlBase, string servicePrefix, string controller, EntregaDetallesRequest model)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<EntregaDetalleResponse> entregaDetalles = JsonConvert.DeserializeObject<List<EntregaDetalleResponse>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = entregaDetalles
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<Response> PutAsync<T>(string urlBase, string servicePrefix, string controller, T model, string token)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                T item = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Result = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseT<object>> PutAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id,
            T model,
            string tokenType,
            string accessToken)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new ResponseT<object>
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseT<object>> GetObrasPoste(
            string urlBase,
            string servicePrefix,
            string controller,
            int id)
        {
            try
            {
                var model = new ObraIdRequest { Id = id };
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseT<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var reclamos = JsonConvert.DeserializeObject<List<ObrasPosteResponse>>(answer);
                return new ResponseT<object>
                {
                    IsSuccess = true,
                    Result = reclamos
                };
            }
            catch (Exception ex)
            {
                return new ResponseT<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}