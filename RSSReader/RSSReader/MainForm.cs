using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSSReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will call the 'New Folder' helper method
            MessageBox.Show("Will create a New Folder");
        }

        private void newChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will call the 'New Channel' helper method
            MessageBox.Show("Will create a New Channel");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will open the Help Contents
            MessageBox.Show("Will open the Help Contents");
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will open the Help Index
            MessageBox.Show("Will open the Help Index");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will open the Help Search 
            MessageBox.Show("Will open the Help Search");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Will open the About Dialog
            MessageBox.Show("Will open the About Dialog");
        }

        private void editFolderToolstripButton_Click(object sender, EventArgs e)
        {
            // create an instance of FolderDialog
            FolderDialog folderDia = new FolderDialog();

            // has to work with the current form
            DialogResult result = folderDia.ShowDialog();

            // did the user click the OK button
            if (result == DialogResult.OK)
            {
                MessageBox.Show("User selected OK");
            }
            else
            {
                MessageBox.Show("User selected Cancel");
            }            
        }

        private void addFolderToolstripButton_Click(object sender, EventArgs e)
        {
            // create an instance of FolderDialog
            FolderDialog folderDia = new FolderDialog();

            DialogResult result = folderDia.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("User selected OK");
            }
            else
            {
                MessageBox.Show("User selected Cancel");
            }
        }

        private void deleteFolderToolStripButton_Click(object sender, EventArgs e)
        {
            // TODO: Will delete current folder.
            MessageBox.Show("Will Delete current Folder");
        }

        private void addChannelToolstripButton_Click(object sender, EventArgs e)
        {
            // create an instance of ChannelDialog
            ChannelDialog channelDia = new ChannelDialog();

            DialogResult result = channelDia.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("User clicked OK");
            }
            else
            {
                MessageBox.Show("User clicked Cancel");
            }
        }

        private void editChannelToolstripButton_Click(object sender, EventArgs e)
        {
            // create an instance of ChannelDialog
            ChannelDialog channelDia = new ChannelDialog();

            DialogResult result = channelDia.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("User clicked OK");
            }
            else
            {
                MessageBox.Show("User clicked Cancel");
            }
        }

        private void deleteChannelToolstripButton_Click(object sender, EventArgs e)
        {
            // TODO: Delete selected Channel
            MessageBox.Show("Will delete channel"); 
        }

        private void refreshRSSFeed_Click(object sender, EventArgs e)
        {
            // hard code the URL to test the app
            string rssURL = "http://www.rte.ie/news/rss/news-headlines.xml";

            RssManager.RefreshRSS(rssURL);       
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rssDataSet.NewsItem' table. You can move, or remove it, as needed.
            this.newsItemTableAdapter.Fill(this.rssDataSet.NewsItem);
            // TODO: This line of code loads data into the 'rssDataSet.Channel' table. You can move, or remove it, as needed.
            this.channelTableAdapter.Fill(this.rssDataSet.Channel);
            // TODO: This line of code loads data into the 'rssDataSet.Folder' table. You can move, or remove it, as needed.
            this.folderTableAdapter.Fill(this.rssDataSet.Folder);

        }
    }
}