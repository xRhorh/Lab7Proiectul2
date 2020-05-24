using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private InterfaceMyPhotosAPIClient mpc = new InterfaceMyPhotosAPIClient();

        public List<String> index_Properties { get; set; }

        [BindProperty]
        public String search_string { get; set; }

        public List<FileReprezentation> files_list;
        public List<List<PropertyReprezentation>> properties_list;

        public IndexModel()
        {
            index_Properties = new List<String>();
            files_list = new List<FileReprezentation>();
            properties_list = new List<List<PropertyReprezentation>>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            index_Properties = await mpc.GetAllPropertiesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //index_Properties = await mpc.GetAllPropertiesAsync();
            if(this.search_string != "") { 
                files_list = await mpc.SearchFilesByTypeAsync(this.search_string);
            }
            int nr_of_files = 0;
            foreach(var file in files_list)
            {
                properties_list.Add(new List<PropertyReprezentation>());
                properties_list[nr_of_files] = await mpc.GetPropertyForFileAsync(file.Idk__BackingField);
                nr_of_files++;
            }

            return Page();
        }
    }
}