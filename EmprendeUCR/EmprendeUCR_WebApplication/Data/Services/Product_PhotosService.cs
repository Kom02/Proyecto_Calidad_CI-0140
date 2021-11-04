using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using BlazorInputFile;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Product_PhotosService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;
        public Product_PhotosService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public bool savePhotoToDb (Product_Photos p_p)
        {
            _context.Product_Photos.Add(p_p);
            _context.SaveChanges();
            return true;
        }

        public List<Product_Photos> loadAllPhotos()
        {
            return _context.Product_Photos.ToList();
        }

        public List<Product_Photos> loadPhotosByID(int Code_ID)
        { 
            return _context.Product_Photos.Where(p => p.Code_ID == Code_ID).ToList();
        }

        public string convertImageDisplay(byte[] image)
        {
            if (image != null)
            {
                var base64 = Convert.ToBase64String(image);
                var fs = string.Format("data:image/jpg;base64,{0}", base64);
                return fs;
            }
            return "";
        }
        
        public Product_Photos loadProductPhoto(int productID)
        {
            return _context.Product_Photos.FirstOrDefault(photo => String.Equals(photo.Code_ID, productID));
        }

    }
}
