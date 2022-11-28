using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public List<Model> Get_Model()
        {
            ModelDAL modelDAL = new ModelDAL();
            return modelDAL.Get_Model(this);
        }

        public Model Get_Model(int id)
        {
            ModelDAL modelDAL = new ModelDAL();
            return modelDAL.Get_Model(id);
        }

        public int Set_Model(Model model)
        {
            ModelDAL modelDAL = new ModelDAL();
            return modelDAL.Set_Model(model);
        }

        public int Delete_Model(int id)
        {
            ModelDAL modelDAL = new ModelDAL();
            return modelDAL.Delete_Model(id);
        }

    }
}