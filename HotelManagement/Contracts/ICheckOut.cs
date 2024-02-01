using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICheckOut
    {
        Task<Check_Out> Add(Check_Out check_Out);
    }
}
