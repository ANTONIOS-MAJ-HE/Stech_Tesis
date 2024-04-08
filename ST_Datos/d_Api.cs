using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Api
    {
        public dynamic Post(string url, string json, string autorizacion = null)
        {
            try
            {
                var Client = new RestClient(url);
                var request = new RestRequest(Convert.ToString(Method.Post));
                request.AddHeader("content-type", "aplication/json");
                request.AddParameter("aplication/json", json, ParameterType.RequestBody);

                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }

                RestResponse response = Client.Execute(request);

                dynamic datos = JsonConvert.DeserializeObject(response.Content);

                return datos;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public dynamic Post_fact(string url, string json, string autorizacion = null)
        {
            try
            {
                var options = new RestClientOptions(url)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }
                else
                {
                    request.AddHeader("Authorization", "Bearer MS8xgxjxYuK35TuXP7hpIleXXvqxTQEZDY7Vo8hg4YHnXI5W7G");
                }
                if (json != null)
                {
                    request.AddStringBody(json, DataFormat.Json);
                }
                RestResponse response = client.Execute(request);

                e_RespuestaJson datos = JsonConvert.DeserializeObject <e_RespuestaJson>(response.Content);

                return datos;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public dynamic Post_guide(string url, string json, string autorizacion = null)
        {
            try
            {
                var options = new RestClientOptions(url)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer MS8xgxjxYuK35TuXP7hpIleXXvqxTQEZDY7Vo8hg4YHnXI5W7G");
                if (json != null)
                {
                    request.AddStringBody(json, DataFormat.Json);
                }
                RestResponse response = client.Execute(request);

                e_RespuestaJsonGuias datos = JsonConvert.DeserializeObject<e_RespuestaJsonGuias>(response.Content);

                return datos;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public dynamic Get(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.UserAgent = "";
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.Proxy = null;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);

            string Datos = HttpUtility.HtmlDecode(streamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);

            return data;
        }
        //sobrecarga para filtrar
        public dynamic Get(string url, string filtro)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url + filtro);
            httpWebRequest.UserAgent = "";
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.Proxy = null;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);

            string Datos = HttpUtility.HtmlDecode(streamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);

            return data;
        }
    }
}
