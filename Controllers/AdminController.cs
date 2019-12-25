using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ishop.Models;
using Microsoft.AspNetCore.Http;
using ishop.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ishop.Controllers
{
    public class AdminController : Controller
    {

        private readonly ishopContext _context;

        public AdminController(ishopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (AuthenticateUser()) {
                return View();
            } else {
                return RedirectToAction(nameof(Login));
            }

        }

        
        //How to use this function in Helper folders
        public bool AuthenticateUser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUsername")))
            {
                return false;
            }
            ViewBag.totalCategories = _context.IshopCategory.ToList().Count();
            ViewBag.totalProducts = _context.IshopProduct.ToList().Count();
            ViewBag.activeSU = _context.IshopSystemUser.Where(abc => abc.SuStatus == true).ToList().Count();
            ViewBag.totalSU = _context.IshopSystemUser.ToList().Count();
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Login()
        {
            var iShopBusinessSetting = _context.IshopBusinessSetting.FirstOrDefault();
            ViewBag.iShopBusiness = iShopBusinessSetting;
            HttpContext.Session.SetString("SessionBusinessName", iShopBusinessSetting.BusinessName);


            return View();
        }

        public string LoginCheck(string SuUsername, string SuPassword)
        {
            if (SuUsername != "" || SuPassword != "")
            {
                IshopSystemUser su = _context.IshopSystemUser.FirstOrDefault(s => s.SuUsername == SuUsername && s.SuPassword == SuPassword);

                if (su != null)
                {
                    if (su.SuStatus == true)
                    {
                        HttpContext.Session.SetString("SessionUsername", su.SuUsername);
                        HttpContext.Session.SetString("SessionUserRole", su.SuRole);

                        return "true";
                    }
                    else { return "inactive"; }
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }



        //
        //  Categories
        //

        // GET: IshopProducts
        public async Task<IActionResult> IndexCategory()
        {
            return View(await _context.IshopCategory.ToListAsync());
        }

        // GET: IshopProducts/Details/5
        public async Task<IActionResult> DetailsCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopCategory == null)
            {
                return NotFound();
            }

            return View(ishopCategory);
        }

        // GET: IshopProducts/Create
        public IActionResult CreateCategory()
        {
            ViewBag.cateorylist = ListCategories();

            return View();
        }

        // POST: IshopProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(IshopCategory ishopCategory, IFormFile FeaturedImage, IFormFile CatImage2)
        {
            if (ishopCategory.ParentId==null) {
                ishopCategory.ParentId = 0;
            }
            if (ModelState.IsValid)
            {
                var findCatCount = _context.IshopCategory.Where(a => a.CatName == ishopCategory.CatName).Count();
                if (findCatCount > 0)
                {
                    ViewBag.messageError = "Category Aleady Exists!!!!!";
                    ViewBag.cateorylist = ListCategories();
                    return View(ishopCategory);
                }

                ishopCategory.CatFeatureImg = await HelperFtn.UploadImageCategory(FeaturedImage);
                ishopCategory.CatPic2 = await HelperFtn.UploadImageCategory(CatImage2);


                ishopCategory.AddedBy = HttpContext.Session.GetString("SessionUsername");

                ishopCategory.AddedDate = DateTime.Now;
                _context.Add(ishopCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexCategory));
            }
            ViewBag.cateorylist = ListCategories();
            return View(ishopCategory);
        }



        // GET: IshopProducts/Edit/5
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory.FindAsync(id);
            if (ishopCategory == null)
            {
                return NotFound();
            }
            return View(ishopCategory);
        }

        // POST: IshopProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, IshopCategory ishopCategory)
        {
            if (id != ishopCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopCategoryExists(ishopCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexCategory));
            }
            return View(ishopCategory);
        }

        // GET: IshopProducts/Delete/5
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopCategory == null)
            {
                return NotFound();
            }

            return View(ishopCategory);
        }

        // POST: IshopProducts/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCategory(int id)
        {
            var ishopCategory = await _context.IshopCategory.FindAsync(id);
            _context.IshopCategory.Remove(ishopCategory);
            bool x = HelperFtn.DeleteCategoryPicFromFolder(ishopCategory.CatFeatureImg);
            bool y = HelperFtn.DeleteCategoryPicFromFolder(ishopCategory.CatPic2);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexCategory));
        }

        private bool IshopCategoryExists(int id)
        {
            return _context.IshopCategory.Any(e => e.Id == id);
        }





        /// <summary>
        /// 
        /// 
        ///         Products Actions
        /// 
        /// 
        /// </summary>
        /// <returns></returns>


        // GET: IshopProducts1
        public async Task<IActionResult> IndexProduct()
        {
            return View(await _context.IshopProduct.ToListAsync());
        }

        // GET: IshopProducts1/Details/5
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopProduct == null)
            {
                return NotFound();
            }

            return View(ishopProduct);
        }

        // GET: IshopProducts1/Create
        public IActionResult CreateProduct()
        {
            ViewBag.cateorylist = ListSubCategories();
            return View();
        }

        // POST: IshopProducts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(IshopProduct ishopProduct, IFormFile FeaturedImage, IFormFile ProPic2, IFormFile[] ProdGallery)
        {
            if (ModelState.IsValid)
            {
                var findCatCount = _context.IshopProduct.Where(a => a.ProdName == ishopProduct.ProdName).Count();
                if (findCatCount > 0)
                {
                    ViewBag.messageError = "Product Aleady Exists!!!!!";
                    ViewBag.cateorylist = ListSubCategories();
                    return View(ishopProduct);
                }

                ishopProduct.ProdFeatureImg = await HelperFtn.UploadProductImage(FeaturedImage);
                ishopProduct.ProPic2 = await HelperFtn.UploadProductImage(ProPic2);

                var prodGallery = await HelperFtn.UploadGalleryProductImages(ProdGallery, HttpContext.Session.GetString("SessionUsername"));

                ishopProduct.AddedBy = HttpContext.Session.GetString("SessionUsername");
                ishopProduct.AddedDate = DateTime.Now;
                _context.Add(ishopProduct);
                await _context.SaveChangesAsync();

                if (prodGallery.Count() > 0)
                {
                    foreach (var item in prodGallery)
                    {
                        item.ProdId = ishopProduct.Id;
                    }
                    _context.AddRange(prodGallery);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(IndexProduct));
            }
            ViewBag.cateorylist = ListSubCategories();
            return View(ishopProduct);
        }

        // GET: IshopProducts1/Edit/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct.FindAsync(id);
            if (ishopProduct == null)
            {
                return NotFound();
            }
            return View(ishopProduct);
        }

        // POST: IshopProducts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, IshopProduct ishopProduct)
        {
            if (id != ishopProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopProductExists(ishopProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexProduct));
            }
            return View(ishopProduct);
        }

        // GET: IshopProducts1/Delete/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopProduct == null)
            {
                return NotFound();
            }

            return View(ishopProduct);
        }

        // POST: IshopProducts1/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedProduct(int id)
        {
            var ishopProduct = await _context.IshopProduct.FindAsync(id);
            _context.IshopProduct.Remove(ishopProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexProduct));
        }

        private bool IshopProductExists(int id)
        {
            return _context.IshopProduct.Any(e => e.Id == id);
        }


        /// <summary>
        ///     System Users
        /// </summary>
        /// <returns></returns>


        // GET: IshopSystemUsers
        public async Task<IActionResult> IndexSystemUser()
        {
            return View(await _context.IshopSystemUser.ToListAsync());
        }

        // GET: IshopSystemUsers/Details/5
        public async Task<IActionResult> DetailsSystemUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }

            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Create
        public IActionResult CreateSystemUser()
        {
            return View();
        }

        // POST: IshopSystemUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSystemUser([Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuEmail,SuProfilePic,SuRole,AddedDate,AddedBy,Extra")] IshopSystemUser ishopSystemUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ishopSystemUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSystemUser));
            }
            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Edit/5
        public async Task<IActionResult> EditSystemUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser.FindAsync(id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }
            return View(ishopSystemUser);
        }

        // POST: IshopSystemUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSystemUser(int id, [Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuEmail,SuProfilePic,SuRole,AddedDate,AddedBy,Extra")] IshopSystemUser ishopSystemUser)
        {
            if (id != ishopSystemUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopSystemUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopSystemUserExists(ishopSystemUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSystemUser));
            }
            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Delete/5
        public async Task<IActionResult> DeleteSystemUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }

            return View(ishopSystemUser);
        }

        // POST: IshopSystemUsers/Delete/5
        [HttpPost, ActionName("DeleteSystemUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSystemUser(int id)
        {
            var ishopSystemUser = await _context.IshopSystemUser.FindAsync(id);
            _context.IshopSystemUser.Remove(ishopSystemUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSystemUser));
        }

        private bool IshopSystemUserExists(int id)
        {
            return _context.IshopSystemUser.Any(e => e.Id == id);
        }










        public async Task<IshopBusinessSetting> SearchBusiness()
        {

            var ishopBusiness = await _context.IshopBusinessSetting
                .FirstOrDefaultAsync();
            
            return ishopBusiness;
        }


        public List<IshopCategory> ListSubCategories()
        {
            var data = _context.IshopCategory.Where(a => a.ParentId != 0).OrderBy(a => a.AddedDate).ToList();

            return data;
        }
        public List<IshopCategory> ListCategories()
        {
            var data = _context.IshopCategory.Where(a => a.ParentId == 0).OrderBy(a => a.AddedDate).ToList();

            return data;
        }


    }
}
