using Dapper;
using netCoreAPI.Domain.DTOModels;
using netCoreAPI.Domain.Interfaces;
using netCoreAPI.Structure.Contexts;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace netCoreAPI.Structure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseDTO
    {
        private MainContext dbContext = new MainContext();

        public BaseRepository()
        {
            dbContext = new MainContext();
        }

        public BaseRepository(MainContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<T> GetAll()
        {
            List<T> listModel = dbContext.dbConnection.Query<T>(string.Format("@{0}GetAll", this.GetType().Name), null, commandType: CommandType.StoredProcedure).ToList();
            return listModel;
        }

        public T GetById(int id)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("Id", id);

            T model = dbContext.dbConnection.Query<T>(string.Format("@{0}GetById", this.GetType().Name), vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return model;
        }

        public IList<T> Select(T model)
        {
            List<T> listModel = dbContext.dbConnection.Query<T>(string.Format("@{0}Select", this.GetType().Name), null, commandType: CommandType.StoredProcedure).ToList();
            return listModel;
        }

        public T Insert(T model)
        {
            DynamicParameters vParams = GetAllParameters(model);
            model = dbContext.dbConnection.Query<T>(string.Format("@{0}Insert", this.GetType()), vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return model;
        }

        public T Update(T model)
        {
            DynamicParameters vParams = GetAllParameters(model);
            model = dbContext.dbConnection.Query<T>(string.Format("@{0}Update", this.GetType()), vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return model;
        }

        public bool Delete(int id)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("Id", id);

            bool result = dbContext.dbConnection.Query<bool>(string.Format("@{0}Delete", this.GetType().Name), vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        private DynamicParameters GetAllParameters(T model)
        {
            DynamicParameters vParams = new DynamicParameters();

            PropertyInfo[] properties = model.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                vParams.Add(string.Format("@{0}", property.Name), model.GetType().GetProperty(property.Name).GetValue(model, null));
            }

            return vParams;
        }
    }
}