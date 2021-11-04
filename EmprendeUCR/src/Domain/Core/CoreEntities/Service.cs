using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Service
    {
        const int maxPrice = 2147483647;
        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        public int Category_ID { get; set; }
        public string Service_Name { get; set; }
        public string Service_Description { get; set; }
        public int Price_per_hour { get; set; }


        public bool setPrice(int price)
        {
            bool response = false;
            if (price >= 0 && price <= maxPrice)
            {
                response = true;
                this.Price_per_hour = price;
            }
            return response;
        }

        public int getPrice()
        {
            return this.Price_per_hour;
        }



        public bool setCodeID(int code_id)
        {
            bool response = false;
            if (code_id >= 0)
            {


                response = true;
                this.Code_ID = code_id;
            }
            return response;

        }

        public int getCodeID()
        {
            return this.Code_ID;
        }



        public bool setCategory(int cat_id)
        {
            bool response = false;
            if (cat_id >= 0)
            {


                response = true;
                this.Category_ID = cat_id;
            }
            return response;

        }

        public int getCategory()
        {
            return this.Category_ID;
        }


    }
}
