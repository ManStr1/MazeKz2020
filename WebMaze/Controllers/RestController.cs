using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model.Rest;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Rest;

namespace WebMaze.Controllers {
    public class RestController : Controller {
        private RestPlaceRepository restPlaceRepository;
        private RestCategoryRepository restCategoryRepository;
        private RestPhotoRepository restPhotoRepository;
        private RestEventRepository restEventRepository;
        private IMapper mapper;

        public RestController(RestPlaceRepository restPlaceRepository, IMapper mapper, RestCategoryRepository restCategoryRepository, RestPhotoRepository restPhotoRepository, RestEventRepository restEventRepository) {
            this.restPlaceRepository = restPlaceRepository;
            this.mapper = mapper;
            this.restCategoryRepository = restCategoryRepository;
            this.restPhotoRepository = restPhotoRepository;
            this.restEventRepository = restEventRepository;
        }

        //[HttpGet]
        //public IActionResult AddPlace() {
        //    var placeViewModel = new RestPlaceViewModel() {
        //        PlaceName = "Тест",
        //        PlaceDescription = "Тест"
        //    };
        //    return View(placeViewModel);
        //}

        //[HttpPost]
        //public IActionResult AddPlace(RestPlaceViewModel placeViewModel) {
        //    var placeModel = mapper.Map<RestPlace>(placeViewModel);
        //    restPlaceRepository.Save(placeModel);

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Place(RestPlaceViewModel restPlaceViewModel) {
        //    var dbModel = mapper.Map<RestPlace>(restPlaceViewModel);
        //    restPlaceRepository.Save(dbModel);

        //    return View(restPlaceViewModel);
        //}

        //public IActionResult Places() {
        //    var viewModels = new List<RestPlaceViewModel>();
        //    var dbModels = restPlaceRepository.GetAll();

        //    foreach (var model in dbModels) {
        //        viewModels.Add(mapper.Map<RestPlaceViewModel>(model));
        //    }

        //    return View(viewModels);
        //}

        //[HttpGet]
        //public IActionResult AddCategory(long id) {
        //    var dbModel = restCategoryRepository.Get(id);
        //    var viewModel = mapper.Map<RestCategoryViewModel>(dbModel);

        //    return View(viewModel);
        //}

        //public IActionResult Categories() {
        //    var viewModels = new List<RestCategoryViewModel>();
        //    var dbModels = restCategoryRepository.GetCategoryWithPlace().ToList();

        //    foreach (var model in dbModels) {
        //        viewModels.Add(mapper.Map<RestCategoryViewModel>(model));
        //    }

        //    return View(viewModels);
        //}

        [HttpGet]
        public IActionResult Home() {
            var viewModels = new List<RestHomeViewModel>();
            var dbModels = restPlaceRepository.GetAll();
            var categories = restCategoryRepository.GetCategoryWithPlace();

            foreach (var model in dbModels) {

                var view = new RestHomeViewModel() {
                    Id = model.Id.ToString(),
                    PlaceName = model.PlaceName,
                    PlaceDescription = model.PlaceDescription,
                    RestPhotoUrl = model.RestPhotos[0].PhotoUrl
                };

                view.Categories = new List<string>();
                foreach (var category in categories) {
                    view.Categories.Add(category.CategoryName);
                }

                viewModels.Add(view);
            }

            return View(viewModels);
        }

        //[HttpPost]
        //public IActionResult Home(long id) {

        //    return RedirectToAction("Place", "Rest", 0);
        //}

        [HttpPost]
        public IActionResult Place(RestPlaceViewModel place) {
            var dbModel = restPlaceRepository.Get(Convert.ToInt64(place.Id));
            var viewModel = mapper.Map<RestPlaceViewModel>(dbModel);

            return View(viewModel);
        }
    }
}
