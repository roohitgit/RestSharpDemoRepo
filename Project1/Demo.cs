using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1

{
    public class Demo<T>
    {
        public ListOfUsersDTO GetUsers()

        {
            var restClient = new RestClient("https://reqres.in");                   // Sets the BaseUrl property for requests made by this client instance
            var restRequest = new RestRequest("/api/users?page=2", Method.Get);     // Container for data used to make requests
            restRequest.AddHeader("Accept", "application/json");                    // Adds a header to the request.
            restRequest.RequestFormat = DataFormat.Json;                            // Serializer to use when writing request bodies.
            RestResponse response = restClient.Execute(restRequest);                // Executes the request
            var content = response.Content;                                         // String representation of response content
            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);     // The deserialized object from the JSON string.
            return users;

        }

        public ListOfUsersDTO GetUsers(string endpoint)
        {
            var user = new APIHelper<ListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUsersDTO content = user.GetContent<ListOfUsersDTO>(response);
            return content;
        }



        public CreateUserDTO CreateUser()

        {
            var restClient = new RestClient("https://reqres.in");
            var restRequest = new RestRequest("/api/users?page=2", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<CreateUserDTO>(content);
            return users;
        }

        //public CreateUserDTO CreateUser(string endpoint, dynamic payload)
        //{
        //    var user = new APIHelper<CreateUserDTO>();
        //    var url = user.SetUrl(endpoint);
        //    var request = user.CreatePostRequest(payload);
        //    var response = user.GetResponse(url, request);
        //    CreateUserDTO content = user.GetContent<CreateUserDTO>(response);
        //    return content;
        //}


        public CreateUserDTO CreateUser(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl(endpoint);
            var jsonReq = user.Serialize(payload);
            var request = user.CreatePostRequest(jsonReq);
            var response = user.GetResponse(url, request);
            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);
            return content;
        }






    }
}
