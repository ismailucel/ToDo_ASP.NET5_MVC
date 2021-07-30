using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Models
{
    public class ToDo //Tablo
    {
        //satırlar
        [Key]

        public int Id { get; set; }

        [Required]
        [DisplayName("To Do")]
        public string Todo { get; set; }

    }
}
