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

        private async Task GetStartedDemo(Image i)
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            Console.WriteLine("Phassing here 5");
            await this.CreateImageDocumentIfNotExists(i);
            Console.WriteLine("Phassing here 6");

        }

        public void run(Image i)
        {
            // ADD THIS PART TO YOUR CODE
            try
            {
                GetStartedDemo(i).Wait();
            }
            catch (DocumentClientException de)
            {
                Console.WriteLine("it's 1!!!!!!");
                Exception baseException = de.GetBaseException();
                Console.WriteLine(" ERROR!!!!! {0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("it's 2!!!!!!");
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
            /*UConsole.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();*/
        }

        public async Task CreateImageDocumentIfNotExists(Image i)
        {
            try
            {
                Console.WriteLine("Phassing here");
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri("ImageDB", "ImageCollection", i.ImageID));
                Console.WriteLine("Phassing here 1");
                this.WriteToConsoleAndPromptToContinue("Found {0}", i.ImageID);
            }
            catch (DocumentClientException de)
            {
                Console.WriteLine("it's 3!!!!!!");
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ImageDB", "ImageCollection"), i);
                    this.WriteToConsoleAndPromptToContinue("Created Image {0}", i.ImageID);
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
