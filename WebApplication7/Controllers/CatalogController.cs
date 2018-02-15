using Library.Models.Catalog;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _asset;
        public CatalogController(ILibraryAsset asset)
        {
            _asset = asset;
        }

        public IActionResult Index()
        {
            var assetModels = _asset.GetAll();


            //This is for dependency injection 
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _asset.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _asset.GetDeweyIndex(result.Id)
                });


            var model = new AssetIndexModel
            {
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _asset.GetById(id);


        }
    }
}
