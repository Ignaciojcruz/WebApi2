using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Type> Get_Type()
        {
            TypeDAL typeDAL = new TypeDAL();
            return typeDAL.Get_Type(this);
        }

        public Type Get_Type(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            return typeDAL.Get_Type(id);
        }

        public int Set_Type(Type type)
        {
            TypeDAL typeDAL = new TypeDAL();
            return typeDAL.Set_Type(type);
        }

        public int Delete_Type(int id)
        {
            TypeDAL typeDAL = new TypeDAL();
            return typeDAL.Delete_Type(id);
        }

    }
}