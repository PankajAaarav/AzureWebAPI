using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebAPI
{
    public class ReadWriteInQueue
    {
        public void WriteInQueue()
        {
            string connectionString = "Your Azure Storage Connection String";
            string queueName = "test";
            QueueClient queue = new QueueClient(connectionString, queueName);
            queue.Create();
            queue.SendMessage("This is the first message.");
            queue.SendMessage("This is the second message.");
            foreach (QueueMessage message in queue.ReceiveMessages(maxMessages: 100).Value)
            {
                //Write your code here to process the messages
                queue.DeleteMessage(message.MessageId, message.PopReceipt);
                //Delete the message once it has been processed
            }
        }
        public static bool DeleteQueue(string queueName)
        {
            try
            {
                string connectionString = "Your Azure Storage Connection String";
                QueueClient queueClient = new QueueClient
                (connectionString, queueName);
                if (queueClient.Exists())
                {
                    queueClient.Delete();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
