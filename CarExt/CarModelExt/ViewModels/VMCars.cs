using CarModelExt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarModelExt.ViewModels
{
    public class VMCars
    {
        public CarModel Car { get; set; }
        public List<CarModel> CarList {get; set;}
        public bool ShowIfAuth { get; set;}

    }
}