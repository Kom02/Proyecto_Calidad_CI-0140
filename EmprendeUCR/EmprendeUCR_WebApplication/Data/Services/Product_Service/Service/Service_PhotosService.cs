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
    public class Service_PhotosService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;
        public Service_PhotosService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public bool savePhotoToDb(Service_Photos s_p)
        {
            _context.Service_Photos.Add(s_p);
            _context.SaveChanges();
            return true;
        }

        public List<Service_Photos> loadAllPhotos()
        {
            return _context.Service_Photos.ToList();
        }

        public List<Service_Photos> loadPhotosByID(int Code_ID)
        {
            return _context.Service_Photos.Where(p => p.Code_ID == Code_ID).ToList();
        }

        public string convertServiceImageDisplay(byte[] image)
        {
            if (image != null)
            {
                var base64 = Convert.ToBase64String(image);
                var fs = string.Format("data:image/jpg;base64,{0}", base64);
                return fs;
            }
            return "";
        }

        public Service_Photos loadServicePhoto(int serviceID)
        {
            return _context.Service_Photos.FirstOrDefault(photo => String.Equals(photo.Code_ID, serviceID));
        }

    }
}
