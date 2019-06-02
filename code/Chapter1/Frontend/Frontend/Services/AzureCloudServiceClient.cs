﻿using System;

namespace Frontend.Services
{
    public sealed class AzureCloudServiceClient : ICloudServiceClient
    {
        private Uri baseUri = new Uri("https://localhost:44398");

        public AzureCloudServiceClient()
        {
            // Ignore self-signed certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public IDataTable<T> GetTable<T>() where T : TableData
        {
            var tableName = typeof(T).Name.ToLowerInvariant();
            return new RESTDataTable<T>(baseUri, $"api/{tableName}s");
        }
    }
}