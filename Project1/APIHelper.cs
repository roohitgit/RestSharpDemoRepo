using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace Project1
{
    public class APIHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://reqres.in/";


        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(baseUrl);
            return restClient;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest("api/users", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }


        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest("api/users", Method.Put);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }


        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest("api/users?page=2", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            //restRequest.RequestFormat = DataFormat.Json;
            return restRequest;
        }

        //public RestRequest CreateDeleteRequest(string payload)
        //{
        //    var restRequest = new RestRequest("api/users", Method.Delete);
        //    restRequest.AddHeader("Accept", "application/json");
        //    return restRequest;
        //}




        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }



        public string Serialize(dynamic content)
        {
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
            return serializeObject;
        }





    }
}
