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

        public static List<Instancia> API_ListarInstancias()
        {
            ValidarToken();
            return ListarInstancias();
        }

        public static Instancia2 API_DetalleDeInstancia(string id)
        {
            ValidarToken();
            return DetalleDeInstancia(id);
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
                                            ""id"": ""e70b21ba6d19403d95a6d86d96e4d7e2""
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

        private static List<Instancia> ListarInstancias()
        {            
            var result = Client.GetAsync("http://10.105.231.208:8774/v2.1/servers").Result;         
            
            //TODO: verificar que no reciba 401
            var responseContent = result.Content.ReadAsStringAsync();

            RootInstancias lista_instacias = new RootInstancias();

            lista_instacias = JsonConvert.DeserializeObject<RootInstancias>(responseContent.Result);

            return lista_instacias.servers;
            
           }

        private static Instancia2 DetalleDeInstancia(string id)
        {
            string url = "http://10.105.231.208:8774/v2.1/servers/" + id;

            var result = Client.GetAsync(url).Result;
            var responseContent = result.Content.ReadAsStringAsync();

            UnaInstancia instancia = new UnaInstancia();

            instancia = JsonConvert.DeserializeObject<UnaInstancia>(responseContent.Result);

            return instancia.server;

        }

    }
}
