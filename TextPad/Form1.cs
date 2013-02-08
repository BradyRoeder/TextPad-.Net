using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fileloc;
        string textstream;

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select file you want to open..";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileloc = ofd.FileName.ToString();
                StreamReader sr = new StreamReader(fileloc);
                textstream = sr.ReadToEnd().ToString();
                richTextBox1.Text = textstream;
                saveToolStripMenuItem.Enabled = true;
                string filename = Path.GetFileName(fileloc).ToString();
                this.Text = filename + " - TextPad";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Project while I learning C# :)\r\n          Author : Mohd Shahril", "About");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveas(richTextBox1.Text.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("You want to save text before exit ?", "TextPad", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (fileloc != null)
                    {
                        save(fileloc, richTextBox1.Text.ToString());
                        Environment.Exit(0);
                    }
                    else
                    {
                        saveas(richTextBox1.Text);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileloc != null)
            {
                save(fileloc, richTextBox1.Text.ToString());
            }
            else
            {
                saveas(richTextBox1.Text);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        public void save(string location, string content)
        {
            try
            {
                FileStream fs = new FileStream(location, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content.ToString());
                sw.Dispose();
                fs.Dispose();
            }
            catch
            {
                MessageBox.Show("Error when try to save text");
            }
        }

        public void saveas(string content)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt|All File|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string saveloca = sfd.FileName.ToString();
                try
                {
                    FileStream fs = new FileStream(saveloca, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(content.ToString());
                    sw.Dispose();
                    fs.Dispose();
                }
                catch
                {
                    MessageBox.Show("Error when try to save text");
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("You want to save text before exit ?", "TextPad", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (fileloc != null)
                    {
                        save(fileloc, richTextBox1.Text.ToString());
                        Environment.Exit(0);
                    }
                    else
                    {
                        saveas(richTextBox1.Text);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (fileloc == null)
            {
                this.Text = "Untitled - TextPad";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("You want to save text before enter new pad ?", "TextPad", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (fileloc != null)
                    {
                        save(fileloc, richTextBox1.Text.ToString());
                        fileloc = "";
                        textstream = "";
                        richTextBox1.Text = "";
                        this.Text = "Untitled - TextPad";
                    }
                    else
                    {
                        saveas(richTextBox1.Text);
                        fileloc = "";
                        textstream = "";
                        richTextBox1.Text = "";
                        this.Text = "Untitled - TextPad";
                    }
                }
                else
                {
                    fileloc = "";
                    textstream = "";
                    richTextBox1.Text = "";
                    this.Text = "Untitled - TextPad";
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }




    }
}
