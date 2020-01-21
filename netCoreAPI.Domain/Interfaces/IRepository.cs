using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreAPI.Domain.Interfaces
{
    public interface IRepository<BaseDTO> where BaseDTO : class
    {
        IList<BaseDTO> GetAll();

        BaseDTO GetById(int id);

        IList<BaseDTO> Select(BaseDTO model);

        BaseDTO Insert(BaseDTO model);

        BaseDTO Update(BaseDTO model);

        bool Delete(int id);
    }
}
