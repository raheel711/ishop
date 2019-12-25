using ishop.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ishop.Helpers
{
    public static class HelperFtn
    {
        //Upload Category Image
        public static async Task<string> UploadImageCategory(IFormFile FeaturedImage)
        {
            try
            {
                if (FeaturedImage != null && FeaturedImage.Length > 0)
                {
                    //var fileName = Path.GetFileName(FeaturedImage.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(FeaturedImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Categories", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await FeaturedImage.CopyToAsync(fileSteam);
                    }
                    return fileName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

        public static bool DeleteCategoryPicFromFolder(string FileName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Categories", FileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<string> UploadProductImage(IFormFile FeaturedImage)
        {
            try
            {
                if (FeaturedImage != null && FeaturedImage.Length > 0)
                {
                    //var fileName = Path.GetFileName(FeaturedImage.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(FeaturedImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Products", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await FeaturedImage.CopyToAsync(fileSteam);
                    }
                    return fileName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

        public static bool DeleteProductPicFromFolder(string FileName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Products", FileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public static async Task<List<IshopProdImgGallery>> UploadGalleryProductImages(IFormFile[] files,string sessionUser)
        {
            try
            {
                 List<IshopProdImgGallery> ListGallery = new List<IshopProdImgGallery>();


                foreach (IFormFile file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Products", fileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileSteam);
                        }
                        
                        ListGallery.Add(new IshopProdImgGallery { VariantId=0, ImgUrl=fileName, Status=true, AddedDate=DateTime.Now, AddedBy= sessionUser, });
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        var UploadStatus = files.Count().ToString() + " files uploaded successfully.";   
                    }
                }
                return ListGallery;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
   
}
