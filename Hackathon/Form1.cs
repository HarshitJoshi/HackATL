using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hackathon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // subscriptionKey = "0123456789abcdef0123456789ABCDEF"
        private const string subscriptionKey = "d188394483444e09b42d2fa3fc0b2598";

        // localImagePath = @"C:\Documents\LocalImage.jpg"
        private const string localImagePath = @"C:\Users\AliNa\Desktop\HackATL\Images\dog.jpeg";

        // Specify the features to return
        private static readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };

        private void makingRequest()
        {
            ComputerVisionClient computerVision = new ComputerVisionClient(
               new ApiKeyServiceClientCredentials(subscriptionKey),
               new System.Net.Http.DelegatingHandler[] { });
            computerVision.Endpoint = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/describe?maxCandidates=1";

            Console.WriteLine("Images being analyzed ...");
            var t2 = AnalyzeLocalAsync(computerVision, localImagePath);

            Task.WhenAll(t2).Wait(5000);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        // Analyze a local image
        private static async Task AnalyzeLocalAsync(
            ComputerVisionClient computerVision, string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                Console.WriteLine(
                    "\nUnable to open or read localImagePath:\n{0} \n", imagePath);
                return;
            }

            using (Stream imageStream = File.OpenRead(imagePath))
            {
                ImageAnalysis analysis = await computerVision.AnalyzeImageInStreamAsync(
                    imageStream, features);
                DisplayResults(analysis, imagePath);
            }
        }

        // Display the most relevant caption for the image
        private static void DisplayResults(ImageAnalysis analysis, string imageUri)
        {
            Console.WriteLine(imageUri);
            Console.WriteLine(analysis.Description.Captions[0].Text + "\n");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            makingRequest();
        }
    }
}
