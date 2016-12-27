using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace API_Openstack.Model
{
    public static class API
    {
        private static HttpClient Client = new HttpClient();
        private static string token = string.Empty;

        public static List<Instancia> ListarInstancias()
        {
            ValidarToken();
            return ListarInstancias(token);
        }


        private static void PedirToken()
        {
            string json = @"{
                               ""auth"": {
                                    ""identity"": {
                                            ""methods"": [
                                                ""password""
                                        ],
                                        ""password"": {
                                            ""user"": {
                                                ""name"": ""demo"",
                                                ""domain"": {
                                                    ""name"": ""default""
                                                },
                                                ""password"": ""admin""
                                            }
                                        }
                                    },
                                    ""scope"": {
                                        ""project"": {
                                            ""id"": ""c2dac643b9114da0a1d74904cce56777""
                                        }
                                    }
                                }
                            }";

            var result = Client.PostAsync("http://10.105.231.208/identity/v3/auth/tokens", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                                   
            if (result.Content != null)
            {
                     
                IEnumerable<string> headerValues;

                var keyFound = result.Headers.TryGetValues("X-Subject-Token", out headerValues);
                if (keyFound)
                {
                    token = headerValues.FirstOrDefault();
                }

                //TODO: Implementar el Else               
            }           

        }

        private static void ValidarToken()
        {
            if (token == string.Empty)
            {
                PedirToken();
                Client.DefaultRequestHeaders.Add("x-auth-token", token);
            }

        }

        private static List<Instancia> ListarInstancias(string token)
        {            
            var result = Client.GetAsync("http://10.105.231.208:8774/v2.1/servers").Result;         
            
            //TODO: verificar que no reciba 401
            var responseContent = result.Content.ReadAsStringAsync();

            RootInstancias lista_instacias = new RootInstancias();

            lista_instacias = JsonConvert.DeserializeObject<RootInstancias>(responseContent.Result);

            return lista_instacias.servers;
            
           }

    }
}
