using System;
using System.Drawing;
using System.Windows.Forms;
using Windows.Foundation.Collections;
using Windows.System;

namespace My
{
    sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async void button1_Click(object sender, EventArgs e)
        {
            var data = new ValueSet().SetRequestMessage(RequestBox.Text);

            var result = await MyProtocolClientHelper.LaunchAsync(data);

            if (result.Status == LaunchUriStatus.Success)
            {
                ResponseBox.Text = result.Result.GetResponseMessage();
                ResponseBox.ForeColor = SystemColors.WindowText;
            }
            else
            {
                ResponseBox.Text = $"Status: {result.Status}";
                ResponseBox.ForeColor = Color.Red;
            }
        }
    }
}