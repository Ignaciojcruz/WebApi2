using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public bool IsDeleted { get; set; }

        public List<Brand> Get_Brand()
        {
            BrandDAL brandDAL = new BrandDAL();
            return brandDAL.Get_Brand(this);
        }

        public Brand Get_Brand(int id)
        {
            BrandDAL brandDAL = new BrandDAL();
            return brandDAL.Get_Brand(id);
        }

        public int Set_Brand(Brand brand)
        {
            BrandDAL brandDAL = new BrandDAL();
            return brandDAL.Set_Brand(brand);
        }

        public int Delete_Brand(int id)
        {
            BrandDAL brandDAL = new BrandDAL();
            return brandDAL.Delete_Brand(id);
        }

    }
}