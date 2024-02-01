using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMarkDetail
    {
        Task<IEnumerable<MarkDetail>> GetMark();
        Task<MarkDetail> GetMarkById(int Id);
        Task<MarkDetail> AddMark(MarkDetail mark);
        Task<MarkDetail> UpdateMark(MarkDetail markDetail);             
    }
}
