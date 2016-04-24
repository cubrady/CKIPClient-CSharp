using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CKIP;

namespace CKIPClientCS
{
    public partial class Form1 : Form
    {
        CKIPSS _ckip = null;

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            init();

            bool isSuccess;
            string errorMsg;
            List<string> result = _ckip.Send(textBox3.Text, out isSuccess, out errorMsg);

            if (!isSuccess)
                MessageBox.Show(errorMsg);

            foreach (string s in result)
            {
                textBox4.Text += s + "\r\n\r\n";
                segment(s);
            }
        }

        private void segment(string s)
        {
            string[] seperatorTerm = { "　" };
            string[] seperatorWA = { "(", ")" };
            string[] terms = s.Split(seperatorTerm, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < terms.Length; i++)
            {
                string[] termAndWA = terms[i].Split(seperatorWA, StringSplitOptions.None);
                if (termAndWA[0] != "")
                {
                    listBox1.Items.Add(termAndWA[0] + "\t詞性：" + termAndWA[1]);
                }
            } 
        }

        private void init()
        {
            if (_ckip == null)
            {
                _ckip = new CKIPSS(textBox1.Text, textBox2.Text);
            }

            textBox4.Text = "";
        }
    }
}
