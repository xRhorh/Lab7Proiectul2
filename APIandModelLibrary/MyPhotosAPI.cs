using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APIandModelLibrary
{
    public class MyPhotosAPI
    {
        private bool ExistListOfMedia()
        {
            //used to make sure we have item in the MadiaList table
            using (var contextDB = new DatabadeModelContainer())
            {
                return contextDB.MediaLists.Any();
            }
        }

        private void InitListOfMedia()
        {
            //init the item that represents the user and conects him to the rest of his files
            using (var contextDB = new DatabadeModelContainer())
            {
                if (!contextDB.MediaLists.Any()) {
                    var media_list = new MediaList()
                    {
                        NrFilme = 0,
                        NrImagini = 0
                    };
                    contextDB.MediaLists.Add(media_list);
                    contextDB.SaveChanges();
                }
            }
        }

        public void AddPhoto(string path)
        {
            if(!ExistListOfMedia())
            {
                InitListOfMedia();
                Console.WriteLine("We had to init the listofmedia first! Try again now");
                return;
            }

            /*if(!File.Exists(path))
            {
                Console.WriteLine("You got to give a valid file path!");
                return;
            }*/

            using (var contextDB = new DatabadeModelContainer())
            {
                var user_table = contextDB.MediaLists.First();
                var user_photo = new Imagine()
                {
                    //FullPath = Path.GetFullPath(path),
                    FullPath = path,
                    Available = 1,
                    MediaList = user_table
                };

                contextDB.Imagines.Add(user_photo);
                contextDB.SaveChanges();
            }
        }

        public void AddProperty(int key_image, string title, string description)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var image_key = contextDB.Imagines.Find(key_image);
                if(image_key == null)
                {
                    Console.WriteLine("You don't have an image with that key in your database!");
                    return;
                }

                if(title == "")
                {
                    Console.WriteLine("No title for your property, you waste my time??");
                    return;
                }

                var desc_property = new ProprietateImagine()
                {
                    Title = title,
                    Description = description,
                    Imagine = image_key
                };
                contextDB.ProprietateImagines.Add(desc_property);
                contextDB.SaveChanges();
            }
        }

        public void DeletePhoto(int key_image)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var image_entity = contextDB.Imagines.Find(key_image);
                if (image_entity == null)
                {
                    Console.WriteLine("You don't have an image with that key in your database!");
                    return;
                }

                DeleteAllPropertyForImage(key_image);
                contextDB.Imagines.Remove(image_entity);
                contextDB.SaveChanges();
            }
        }

        public void DeleteProperty(int key_property)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var the_property = contextDB.ProprietateImagines.Find(key_property);
                if (the_property == null)
                {
                    Console.WriteLine("There is no property to be deleted with that id!");
                    return;
                }
                contextDB.ProprietateImagines.Remove(the_property);
                contextDB.SaveChanges();
            }
        }

        private void DeleteAllPropertyForImage(int key_image)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var all_properties = contextDB.ProprietateImagines.Where(c => c.ImagineId == key_image);
                if (all_properties == null)
                {
                    Console.WriteLine("There are no properties to be deleted!");
                    return;
                }

                foreach(var property in all_properties)
                {
                    contextDB.ProprietateImagines.Remove(property);
                }
                contextDB.SaveChanges();
            }
        }

        public List<FileReprezentation> GetPhotoNames()
        {
            List<FileReprezentation> result_list = new List<FileReprezentation>();

            using (var contextDB = new DatabadeModelContainer())
            {
                var images = contextDB.Imagines;

                foreach(var img in images)
                {
                    if(img.Available != 0)
                    {
                        result_list.Add(new FileReprezentation(img.Id, img.FullPath));
                    }
                }
            }

            return result_list;
        }

        public List<PropertyReprezentation> GetPropertyForFile(int id_file)
        {
            List<PropertyReprezentation> result_list = new List<PropertyReprezentation>();
            using (var contextDB = new DatabadeModelContainer())
            {
                var all_properties = contextDB.ProprietateImagines.Where(c => c.ImagineId == id_file);
                foreach(var property in all_properties)
                {
                    result_list.Add(
                        new PropertyReprezentation(property.Id, id_file, property.Title, property.Description)
                        );
                }
            }

            return result_list;
        }

        public void OpenImage(int key_image)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var image_entity = contextDB.Imagines.Find(key_image);
                if (image_entity == null)
                {
                    Console.WriteLine("You don't have an image with that key in your database!");
                    return;
                }

                if(image_entity.Available == 0)
                {
                    Console.WriteLine("Your file in no longer available at that path!");
                    return;
                }

                try {
                    System.Diagnostics.Process.Start(image_entity.FullPath);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        
        public bool FileIsAvailable(int key_image)
        {
            using (var contextDB = new DatabadeModelContainer())
            {
                var image = contextDB.Imagines.Find(key_image);
                if(image != null)
                {
                    if (File.Exists(image.FullPath))
                    {
                        image.Available = 1;
                        return true;
                    } else
                    {
                        image.Available = 0;
                    }
                }
            }
            return false;
        }

        public List<FileReprezentation> SearchFilesByDescription(string title, string description)
        {
            List<FileReprezentation> result_list = new List<FileReprezentation>();

            using (var contextDB = new DatabadeModelContainer())
            {
                var all_properties = contextDB.ProprietateImagines;

                foreach(var property in all_properties)
                {
                    if (property.Title.Contains(title))
                    {
                        if (property.Description.Contains(description))
                        {
                            var imagine = contextDB.Imagines.Find(property.ImagineId);
                            result_list.Add(new FileReprezentation(imagine.Id, imagine.FullPath));
                        }
                    }
                }
            }

            return result_list;
        }

        public List<FileReprezentation> SearchFilesByType(string title)
        {
            List<FileReprezentation> result_list = new List<FileReprezentation>();

            using (var contextDB = new DatabadeModelContainer())
            {
                var all_properties = contextDB.ProprietateImagines;

                foreach (var property in all_properties)
                {
                    if (property.Title.Contains(title))
                    {
                        var imagine = contextDB.Imagines.Find(property.ImagineId);
                        result_list.Add(new FileReprezentation(imagine.Id, imagine.FullPath));
                    }
                }
            }

            return result_list;
        }

        public List<String> GetAllProperties()
        {
            SortedSet<string> result_set = new SortedSet<string>();

            using (var contextDB = new DatabadeModelContainer())
            {
                var all_properties = contextDB.ProprietateImagines;
                foreach (var property in all_properties)
                {
                    result_set.Add(property.Title);
                }
            }

            List<String> result = new List<String>();
            foreach (var property in result_set)
            {
                result.Add(property);
            }

            return result;
        }
    }
}
