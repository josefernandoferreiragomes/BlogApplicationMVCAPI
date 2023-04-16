using BlogApplication.WebSite.BlogApplicationService;
using BlogApplication.WebSite.Interfaces;
using BlogManager;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BlogApplication.WebSite.Factories
{
    
    public class ServiceClientFactory<T> : AbstractServiceClientFactory<T>
        
    {
        private HttpClient _httpClient;

        public ServiceClientFactory()
        {
            _httpClient = new HttpClient();
        }

        public T Data;
        public override T GetClient()
        {
            switch(typeof(T).Name)
            {
                case "ProductServiceClient":
                    Data = (T)Activator.CreateInstance(typeof(T),"BasicHttpBinding_IProductService");
                    break;
                case "BlogClient":
                    _httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["BlogApiclientUrl"]);
                    Data = (T)Activator.CreateInstance(typeof(T),_httpClient);
                    break;
            }
            return Data;
        }
    }
}