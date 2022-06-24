using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PetStore.Domain;
using RestSharp;


namespace PetStore.Repository
{
    /// <summary>
    /// PetStoreApi class - handles the restapi calls.
    /// </summary>
    public class PetStoreApi : IPetStoreApi
    {
        private string _baseUrl;
        private string _statusUrl;
        private RestClient _restClient;
        private RestRequest restRequest;

        /// <summary>
        /// Petstore Api constructor
        /// </summary>
        public PetStoreApi()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
             _baseUrl = config["PetStoreApi:BaseUrl"];
             _statusUrl = config["PetStoreApi:StatusUrl"];
             _restClient = new RestClient(_baseUrl);
             restRequest = new RestRequest();
             restRequest.AddHeader("content-type", "application/json");
             restRequest.AddHeader("Accept", "application/json");
        }

        /// <summary>
        /// GetPetsByStatus - calls the rest api to retrieve pets by status
        /// </summary>
        /// <param name="petStatus"></param>
        /// <returns></returns>
        public List<Pet> GetPetsByStatus(PetStatus petStatus)
        {
            restRequest.Method = Method.GET;
            restRequest.Resource = string.Format(_statusUrl, petStatus.ToString().ToLower());
            
            IRestResponse<List<Pet>> response = ExecuteRestRequest(restRequest);

            var result = response.Data;

            return result;
        }

        /// <summary>
        /// Restsharp call to rest api
        /// </summary>
        /// <param name="restRequest"></param>
        /// <returns></returns>
        private  IRestResponse<List<Pet>> ExecuteRestRequest(RestRequest restRequest)
        {
            return  _restClient.Execute<List<Pet>>(restRequest);
        }
    }
}
