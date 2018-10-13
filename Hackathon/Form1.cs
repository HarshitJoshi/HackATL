using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections;
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
        String DBdes = "";
        IList<String> DBtagToArray;
        public Form1()
        {
            InitializeComponent();
        }
        static int loadedImage = 0;
        private static string[] imagesArray = Directory.GetFiles("..\\..\\Images", "*.jpg")
                                     .Select(Path.GetFileName)
                                     .ToArray();
        private const string subscriptionKey = "d606cf63094f42df8698487d3c968a55";
        public string localImagePath = "";

        // Specify the features to return
        private readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };

        private void makingRequest()
        {
            localImagePath = @"..\\..\\Images\" + imagesArray[loadedImage];
            ComputerVisionClient computerVision = new ComputerVisionClient(
               new ApiKeyServiceClientCredentials(subscriptionKey),
               new System.Net.Http.DelegatingHandler[] { });
            computerVision.Endpoint = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/describe?maxCandidates=1";

            Console.WriteLine("Images being analyzed ...");
            var t2 = AnalyzeLocalAsync(computerVision, localImagePath);

            //Task.WhenAll(t2).Wait(5000);
            Console.WriteLine("Press ENTER to exit");
            
            //Console.ReadLine();
        }

        // Analyze a local image
        private async Task AnalyzeLocalAsync(
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
        private void DisplayResults(ImageAnalysis analysis, string imageUri)
        {
            image.Load(imageUri);
            tagsTB.Clear();
            DBdes = analysis.Description.Captions[0].Text;
            imageLabel.Text = "Description: " + analysis.Description.Captions[0].Text;
            DBtagToArray = analysis.Description.Tags;
            for (int i = 0; i < analysis.Description.Tags.Count; i++)
            {
                tagsTB.AppendText(analysis.Description.Tags[i] + "\n");

            }
            Image img = new Image(imagesArray[loadedImage], DBdes);
            ADatabase db = new ADatabase();
            db.run(img);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            makingRequest();     
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (loadedImage != (imagesArray.Length - 1))
            {
                loadedImage++;
            }
            else
            {
                loadedImage = 0;
            }
            makingRequest();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (loadedImage != 0)
            {
                loadedImage--;
            }
            else
            {
                loadedImage = imagesArray.Length - 1;
            }
            makingRequest();
        }
    }
}
