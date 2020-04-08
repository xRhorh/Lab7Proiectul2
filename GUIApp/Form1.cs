using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APIandModelLibrary;

using System.ServiceProcess;

namespace GUIApp
{
    public partial class Form1 : Form
    {
        private InterfaceMyPhotosAPIClient api_client;

        public Form1()
        {
            InitializeComponent();
            api_client = new InterfaceMyPhotosAPIClient();

            try
            {
                FilesBox.BeginUpdate();
                foreach (var file in api_client.GetPhotoNames())
                {
                    FilesBox.Items.Add(file);
                }
                FilesBox.EndUpdate();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(1);
            }
        }

        ~Form1()
        {
            api_client.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddImageButton_Click(object sender, EventArgs e)
        {
            if (FullPathImageTextBox.Text != "")
            {
                this.api_client.AddPhoto(FullPathImageTextBox.Text);
                FullPathImageTextBox.Text = "";
            }

            FilesBox.Items.Clear();
            foreach (var file in api_client.GetPhotoNames())
            {
                if (!api_client.FileIsAvailable(file.Idk__BackingField))
                {
                    FilesBox.ForeColor = Color.DarkRed;
                }
                else
                {
                    FilesBox.ResetForeColor();
                }

                FilesBox.Items.Add(file);
            }
        }

        private void AddPropertyButton_Click(object sender, EventArgs e)
        {
            FileReprezentation selected_file = (FileReprezentation)FilesBox.SelectedItem;
            if (selected_file != null)
            {
                api_client.AddProperty(selected_file.Idk__BackingField, TitlePropertyTextBox.Text, DescriptionTextBox.Text);
                PropertiesBox.Items.Clear();
                foreach (var property in api_client.GetPropertyForFile(selected_file.Idk__BackingField))
                {
                    PropertiesBox.Items.Add(property);
                }
            }
            TitlePropertyTextBox.Text = "";
            DescriptionTextBox.Text = "";
        }

        private void ResetFilesButton_Click(object sender, EventArgs e)
        {
            FilesBox.Items.Clear();
            foreach (var file in api_client.GetPhotoNames())
            {
                if (!api_client.FileIsAvailable(file.Idk__BackingField)) 
                {
                    FilesBox.ForeColor = Color.DarkRed;
                } 
                else
                {
                    FilesBox.ResetForeColor();
                }

                FilesBox.Items.Add(file);
            }
        }

        private void FilesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilesBox.Items.Add("You changed something??!");
        }

        private void FilesBox_MouseClick(object sender, EventArgs e)
        {
            PropertiesBox.Items.Clear();
            FileReprezentation selected_file = (FileReprezentation)FilesBox.SelectedItem;
            if (selected_file != null)
            {
                var properties = api_client.GetPropertyForFile(selected_file.Idk__BackingField);
                foreach(var property in properties)
                {
                    PropertiesBox.Items.Add(property);
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            FileReprezentation selected_file = (FileReprezentation)FilesBox.SelectedItem;
            if(selected_file != null)
                api_client.OpenImage(selected_file.Idk__BackingField);
            FilesBox.ClearSelected();
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            FileReprezentation selected_file = (FileReprezentation)FilesBox.SelectedItem;
            if (selected_file != null)
            {
                api_client.DeletePhoto(selected_file.Idk__BackingField);
                FilesBox.Items.Remove(FilesBox.SelectedItem);
            }
            FilesBox.ClearSelected();
        }

        private void DeletePropertyButton_Click(object sender, EventArgs e)
        {
            PropertyReprezentation selected_property = (PropertyReprezentation)PropertiesBox.SelectedItem;
            if (selected_property != null)
            {
                api_client.DeleteProperty(selected_property.Idk__BackingField);
                PropertiesBox.Items.Remove(PropertiesBox.SelectedItem);
            }
            PropertiesBox.ClearSelected();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(TitlePropertyTextBox.Text != "")
            {
                FileReprezentation[] search_files;
                if(DescriptionTextBox.Text != "")
                {
                       search_files = api_client.SearchFilesByDescription(TitlePropertyTextBox.Text, DescriptionTextBox.Text);
                } else
                {
                    search_files = api_client.SearchFilesByType(TitlePropertyTextBox.Text);
                }

                FilesBox.Items.Clear();
                PropertiesBox.Items.Clear();
                foreach (var file in search_files)
                {
                    if (!api_client.FileIsAvailable(file.Idk__BackingField))
                    {
                        FilesBox.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        FilesBox.ResetForeColor();
                    }

                    FilesBox.Items.Add(file);
                }
            }
        }
    }
}
