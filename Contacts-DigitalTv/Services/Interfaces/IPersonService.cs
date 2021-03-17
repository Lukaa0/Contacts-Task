using Contacts_DigitalTv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.Services.Interfaces
{
    public interface IPersonService:IMainService<Person>
    {
        Task<List<Person>> GetFavorites();
    }
}
