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
            var viewModel = new RestHomeViewModel();
            viewModel.Places = new List<RestViewModel>();
            viewModel.Categories = new List<string>();
            var placeDbModels = restPlaceRepository.GetAll();
            var categoriesBdModels = restCategoryRepository.GetCategoryWithPlace();

            foreach (var place in placeDbModels) {
                var placeViewModel = mapper.Map<RestViewModel>(place);
                viewModel.Places.Add(placeViewModel);
            }

            foreach (var category in categoriesBdModels) {
                var categoryViewModel = category.CategoryName;
                viewModel.Categories.Add(categoryViewModel);
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Place(long id) {
            var dbModel = restPlaceRepository.Get(id);
            var viewModel = mapper.Map<RestPlaceViewModel>(dbModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Place(RestPlaceViewModel place) {
            var dbModel = restPlaceRepository.Get(place.Id);
            var viewModel = mapper.Map<RestPlaceViewModel>(dbModel);

            return View(viewModel);
        }
    }
}
