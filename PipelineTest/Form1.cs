using System;
using System.Windows.Forms;
using GPPipeline;

namespace PipelineTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PipelineManager<string> pp = PipelineFactory.CreateFromConfiguration<string>("filterPipeline");
            string data = "test data";
            var success = pp.ProcessFilter(ref data);
            MessageBox.Show(success.ToString());
            MessageBox.Show(data);
        }
    }
}