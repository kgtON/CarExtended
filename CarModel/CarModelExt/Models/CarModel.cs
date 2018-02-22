using CarModelExt.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarModelExt.Models
{
    public class CarModel: IBasicEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateMod { get; set; }
        public string ModPerson { get; set; }
        public string RecordAuthor { get; set; }
        public string RegNumber { get; set; }
    }
}