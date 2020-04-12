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

namespace GUIApp
{
    public partial class Form1 : Form
    {
        private MyPhotosAPI api_object;

        public Form1()
        {
            InitializeComponent();
            api_object = new MyPhotosAPI();
            api_object.InitListOfMedia();

            FilesBox.BeginUpdate();
            foreach (var file in api_object.GetPhotoNames())
            {
                FilesBox.Items.Add(file);
            }
            FilesBox.EndUpdate();
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
                this.api_object.AddPhoto(FullPathImageTextBox.Text);
                FullPathImageTextBox.Text = "";
            }

            FilesBox.Items.Clear();
            foreach (var file in api_object.GetPhotoNames())
            {
                if (!api_object.FileIsAvailable(file.Id))
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
                api_object.AddProperty(selected_file.Id, TitlePropertyTextBox.Text, DescriptionTextBox.Text);
                PropertiesBox.Items.Clear();
                foreach (var property in api_object.GetPropertyForFile(selected_file.Id))
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
            foreach (var file in api_object.GetPhotoNames())
            {
                if (!api_object.FileIsAvailable(file.Id)) 
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
                var properties = api_object.GetPropertyForFile(selected_file.Id);
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
                api_object.OpenImage(selected_file.Id);
            FilesBox.ClearSelected();
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            FileReprezentation selected_file = (FileReprezentation)FilesBox.SelectedItem;
            if (selected_file != null)
            {
                api_object.DeletePhoto(selected_file.Id);
                FilesBox.Items.Remove(FilesBox.SelectedItem);
            }
            FilesBox.ClearSelected();
        }

        private void DeletePropertyButton_Click(object sender, EventArgs e)
        {
            PropertyReprezentation selected_property = (PropertyReprezentation)PropertiesBox.SelectedItem;
            if (selected_property != null)
            {
                api_object.DeleteProperty(selected_property.Id);
                PropertiesBox.Items.Remove(PropertiesBox.SelectedItem);
            }
            PropertiesBox.ClearSelected();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(TitlePropertyTextBox.Text != "")
            {
                List<FileReprezentation> search_files;
                if(DescriptionTextBox.Text != "")
                {
                    search_files = api_object.SearchFilesByDescription(TitlePropertyTextBox.Text, DescriptionTextBox.Text);
                } else
                {
                    search_files = api_object.SearchFilesByType(TitlePropertyTextBox.Text);
                }

                FilesBox.Items.Clear();
                PropertiesBox.Items.Clear();
                foreach (var file in search_files)
                {
                    if (!api_object.FileIsAvailable(file.Id))
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
