using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using APIandModelLibrary;

namespace ObjectWCF
{
    [ServiceContract]
    interface InterfaceMyPhotosAPI
    {
        [OperationContract]
        void AddPhoto(string path);

        [OperationContract]
        void AddProperty(int key_image, string title, string description);

        [OperationContract]
        void DeletePhoto(int key_image);

        [OperationContract]
        void DeleteProperty(int key_property);

        [OperationContract]
        List<FileReprezentation> GetPhotoNames();

        [OperationContract]
        List<PropertyReprezentation> GetPropertyForFile(int id_file);

        [OperationContract]
        void OpenImage(int key_image);

        [OperationContract]
        bool FileIsAvailable(int key_image);

        [OperationContract]
        List<FileReprezentation> SearchFilesByDescription(string title, string description);

        [OperationContract]
        List<FileReprezentation> SearchFilesByType(string title);

        [OperationContract]
        List<String> GetAllProperties();
    }
}
