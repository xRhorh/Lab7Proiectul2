using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIandModelLibrary
{
    [Serializable]
    public class PropertyReprezentation
    {
        public int Id { get; }
        private int Id_photo { get; set; }

        private string Title { get; set; }
        private string Description { get; set; }
    
        public PropertyReprezentation(int id, int id_photo, string title, string description)
        {
            this.Id = id;
            this.Id_photo = id_photo;
            this.Title = title;
            this.Description = description;
        }

        public override string ToString()
        {
            return this.Title + " - " + this.Description;
        }
    }
}
