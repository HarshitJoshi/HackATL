using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public const string subscriptionKey = "d61126ba7857423d95f8e6ad6e8fe743";
        private void makePost()
        {
            var values = new Dictionary<string, string>
        {
            { "thing1", "hello" },
                 { "thing2", "world" }
               };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            data.AppendText("Data recieved:");

        }
    }
}