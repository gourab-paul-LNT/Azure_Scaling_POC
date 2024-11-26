using System;
using System.Threading.Tasks;
using Azure.Storage.Queues; // Namespace for Queue storage types

namespace QueueProducer
{
    class Program
    {
        private const string connectionString = "<Your_Storage_Account_Connection_String>";
        private const string queueName = "myqueue";

        static async Task Main(string[] args)
        {
            // Create a unique name for the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue if it doesn't already exist
            await queueClient.CreateIfNotExistsAsync();

            if (queueClient.Exists())
            {
                Console.WriteLine($"Queue created: '{queueName}'");

                // Send a message to the queue
                string message = "Hello, Azure Queue!";
                await queueClient.SendMessageAsync(message);
                Console.WriteLine($"Message sent: '{message}'");
            }
            else
            {
                Console.WriteLine($"Queue '{queueName}' does not exist.");
            }
        }
    }
}