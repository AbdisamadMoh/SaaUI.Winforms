using SaaUI.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SaaUI
{
    public partial class SaaFontForm : SaaRoundForm
    {
        public SaaFontForm()
        {
            InitializeComponent();
        }
        protected override void OnMouseDownMoveForm(object sender, MouseEventArgs e)
        {
            base.OnMouseDownMoveForm(sender, e);
        }
        private void saaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void SaaFontForm_Load(object sender, EventArgs e)
        {
            this.AwesomePanel.Visible = this.ElegantPanel.Visible = false;
            this.saaCircularProgress1.Visible = true;
            this.saaCircularProgress1.Value = 0;
            this.saaCircularProgress1.Maximum = nameList.Length;
            this.saaCircularProgress1.BringToFront();
            backgroundWorker1.RunWorkerAsync();

        }
        string[] nameList = System.Enum.GetNames(typeof(Icons));
        Image im = null;
        string text = "";
        bool isAwait = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            var lst = nameList.ToList();
            lst.Sort();
            int c = 0;
            foreach (var item in lst)
            {

                // while (isAwait) { }
                Icons icon = (Icons)Enum.Parse(typeof(Icons), item);
                im = FontImages.GetImage(icon, 32, Color.FromArgb(64, 158, 255));
                List<object> ob = new List<object>()
                {
                    im,
                    item
                };
                text = item;
                if (!FontList.ContainsKey(item))
                {
                    FontList.Add(item, im);
                }
                c++;
                //this.Invoke(new MethodInvoker(() =>
                //{
                //    Call(im, text);
                //}));
                backgroundWorker1.ReportProgress(c, ob);
                isAwait = true;
            }
        }

        Dictionary<string, Image> FontList = new Dictionary<string, Image>();
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            List<object> lst = (List<object>)e.UserState;
            if (lst == null || lst.Count < 1) return;
            var im = (Image)lst[0];
            var text = (string)lst[1];

            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Size = new System.Drawing.Size(300, 35);
            lbl.ForeColor = Color.FromArgb(64, 158, 255);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Margin = new System.Windows.Forms.Padding(5);
            // string s = char.ConvertFromUtf32((int)icon);
            lbl.Name = text;
            lbl.Text = "       " + text.Remove(0, 2);
            lbl.Image = im;
            lbl.ImageAlign = ContentAlignment.MiddleLeft;
            //lbl.Font = new Font("微软雅黑", 12);
            if (text.StartsWith("A_"))
            {
                AwesomePanel.Controls.Add(lbl);
                //saaLabel3.Text = text;
            }
            else
            {
                ElegantPanel.Controls.Add(lbl);
            }
            //  saaLabel3.Text = text;
            this.saaCircularProgress1.BringToFront();
            this.saaCircularProgress1.Value = e.ProgressPercentage;
            saaLabel4.Text = this.saaCircularProgress1.Value + " of " + this.saaCircularProgress1.Maximum + " icons loaded";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //  MessageBox.Show(e.Error.ToString());
            this.AwesomePanel.Visible = true;
            this.ElegantPanel.Visible = false;
            this.saaCircularProgress1.Visible = false;
            saaLabel4.Visible = false;
        }

        private void saaLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saaToggle1_CheckChanged(object sender, EventArgs e)
        {
            if (saaToggle1.Checked)
            {
                AwesomePanel.Visible = true;
                ElegantPanel.Visible = false;
            }
            else
            {
                AwesomePanel.Visible = false;
                ElegantPanel.Visible = true;
            }
        }
        
        private void saaCustomTextBox1_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void SearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string value = "";
                this.Invoke(new MethodInvoker(() =>
                {
                    value = saaCustomTextBox1.Value.ToLower().Trim();
                    saaLabel3.Text = value;
                    
                }));

            foreach (var k in FontList.Keys)
            {
                if (k.ToLower().Trim().Contains(value))
                {
                    List<object> ob = new List<object>()
                    {
                        k,
                        FontList[k]
                    };
                    SearchWorker.ReportProgress(1, ob);
                }
            }
        }

        private void SearchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<object> lst = (List<object>)e.UserState;
            if (lst == null || lst.Count < 1) return;
            var im = (Image)lst[1];
            var text = (string)lst[0];

            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Size = new System.Drawing.Size(300, 35);
            lbl.ForeColor = Color.FromArgb(64, 158, 255);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Margin = new System.Windows.Forms.Padding(5);
            // string s = char.ConvertFromUtf32((int)icon);
            lbl.Name = text;
            lbl.Text = "       " + text.Remove(0, 2);
            lbl.Image = im;
            lbl.ImageAlign = ContentAlignment.MiddleLeft;
            SearchPanel.Controls.Add(lbl);
        }

        private void saaButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(saaCustomTextBox1.Value))
            {
                
                saaCircularProgress1.Maximum = FontList.Keys.Count;
                saaCircularProgress1.Value = 0;
                saaCircularProgress1.Visible = true;
                if (SearchWorker.IsBusy) { SearchWorker.CancelAsync(); }
                SearchWorker.RunWorkerAsync();
            }
            else
            {
                SearchPanel.Visible = false;
                SearchPanel.Controls.Clear();
                SearchPanel.SendToBack();
                if (SearchWorker.IsBusy) SearchWorker.CancelAsync();
            }
        }

        private void SearchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SearchPanel.Visible = true;
            SearchPanel.Controls.Clear();
            SearchPanel.BringToFront();
            saaCircularProgress1.Visible = false;
        }
    }
}
