using APIandModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWCF
{
    public class MyPhotoAPIWCF : InterfaceMyPhotosAPI
    {
        private MyPhotosAPI api_obj;
        void InterfaceMyPhotosAPI.AddPhoto(string path)
        {
            this.api_obj = new MyPhotosAPI();
            this.api_obj.AddPhoto(path);
        }

        void InterfaceMyPhotosAPI.AddProperty(int key_image, string title, string description)
        {
            this.api_obj = new MyPhotosAPI();
            this.api_obj.AddProperty(key_image, title, description);
        }

        void InterfaceMyPhotosAPI.DeletePhoto(int key_image)
        {
            this.api_obj = new MyPhotosAPI();
            this.api_obj.DeletePhoto(key_image);
        }

        void InterfaceMyPhotosAPI.DeleteProperty(int key_property)
        {
            this.api_obj = new MyPhotosAPI();
            this.api_obj.DeleteProperty(key_property);
        }

        bool InterfaceMyPhotosAPI.FileIsAvailable(int key_image)
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.FileIsAvailable(key_image);
        }

        List<string> InterfaceMyPhotosAPI.GetAllProperties()
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.GetAllProperties();
        }

        List<FileReprezentation> InterfaceMyPhotosAPI.GetPhotoNames()
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.GetPhotoNames();
        }

        List<PropertyReprezentation> InterfaceMyPhotosAPI.GetPropertyForFile(int id_file)
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.GetPropertyForFile(id_file);
        }

        void InterfaceMyPhotosAPI.OpenImage(int key_image)
        {
            this.api_obj = new MyPhotosAPI();
            this.api_obj.OpenImage(key_image);
        }

        List<FileReprezentation> InterfaceMyPhotosAPI.SearchFilesByDescription(string title, string description)
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.SearchFilesByDescription(title, description);
        }

        List<FileReprezentation> InterfaceMyPhotosAPI.SearchFilesByType(string title)
        {
            this.api_obj = new MyPhotosAPI();
            return this.api_obj.SearchFilesByType(title);
        }
    }
}
