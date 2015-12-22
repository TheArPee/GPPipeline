using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            bool success = pp.ProcessFilter(ref data);
            MessageBox.Show(success.ToString());
            MessageBox.Show(data);
        }
    }
}