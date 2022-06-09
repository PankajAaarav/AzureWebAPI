using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebAPI
{
    public class ReadWriteIBlobStorage
    {
        public void ReadFile()
        {
            string storageConnection = "";
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("containerName");
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("fileName");
            cloudBlockBlob.DownloadTextAsync();

        } 
        public void WriteFile()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("");
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("containerName");
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("blobName");
            cloudBlockBlob.UploadTextAsync("This is for testing");
        }
    }
}
