using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ADD THIS PART TO YOUR CODE
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
namespace Hackathon
{
     class ADatabase
    {
        
        private const string EndpointUrl = "https://haccdb.documents.azure.com:443/";
        private const string PrimaryKey = "lr97qvF7lueyXg4XFGGXa9m1XPnI6feeC0HIbcGDcw9Z3eXpB8qw0IE1ISJy2AHxyI85TZFlt7fhLNJtqhqIIQ==";
        private DocumentClient client;
        private async Task GetStartedDemo(String localImagePath, String DBdes, String DBtag)
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.CreateFamilyDocumentIfNotExists("ImageDB", "ImageCollection", andersenFamily);
            //await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = "ImageDB" });
            //await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("ImageDB"), new DocumentCollection { Id = "ImageCollection" });
        }
        public void run(String localImagePath, String DBdes, String DBtags)
        {
            // ADD THIS PART TO YOUR CODE
            try
            {

                GetStartedDemo(localImagePath, DBdes, DBtags).Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine(" ERROR!!!!! {0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine(" ERROR!!!!! {Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                //Console.ReadKey();
            }
        }
        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
        private async Task CreateFamilyDocumentIfNotExists(string databaseName, string collectionName, )
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, family.Id));
                this.WriteToConsoleAndPromptToContinue("Found {0}", family.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), family);
                    this.WriteToConsoleAndPromptToContinue("Created Family {0}", family.Id);
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
