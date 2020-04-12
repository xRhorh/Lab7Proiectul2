using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIandModelLibrary
{
    [Serializable]
    public class FileReprezentation
    {
        public int Id { get; }
        private string Path { get; set; }

        public FileReprezentation(int id, string path)
        {
            this.Id = id;
            this.Path = path;
        }

        public override string ToString() 
        {
            return this.Path;
        }
    }
}
