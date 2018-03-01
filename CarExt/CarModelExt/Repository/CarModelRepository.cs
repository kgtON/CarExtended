using CarModelExt.Models;
using CarModelExt.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarModelExt.Repository
{
    public class CarModelRepository:AbstractRepository<CarModel>, ICarModelRepository
    {

    }
}