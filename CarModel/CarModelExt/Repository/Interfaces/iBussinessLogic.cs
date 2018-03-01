using CarModelExt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExt.Repository.Interfaces
{
    public interface IBussinessLogic
    {
        string GetUserName();
        bool IsLogged();

    }
}
