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
        private IMapper mapper;

        public RestController(RestPlaceRepository restPlaceRepository, IMapper mapper) {
            this.restPlaceRepository = restPlaceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddPlace() {
            var placeViewModel = new RestPlaceViewModel() {
                PlaceName = "Тест",
                PlaceDescription = "Тест"
            };
            return View(placeViewModel);
        }

        [HttpPost]
        public IActionResult AddPlace(RestPlaceViewModel placeViewModel) {
            var placeModel = mapper.Map<RestPlace>(placeViewModel);
            restPlaceRepository.Save(placeModel);

            return View();
        }

        public IActionResult Place(long id) {
            var dbModel = restPlaceRepository.Get(id);
            var viewModel = mapper.Map<RestPlaceViewModel>(dbModel);

            return View(viewModel);
        }

        public IActionResult Places() {
            var viewModels = new List<RestPlaceViewModel>();
            var dbModels = restPlaceRepository.GetAll();

            foreach (var model in dbModels) {
                viewModels.Add(mapper.Map<RestPlaceViewModel>(model));
            }

            return View(viewModels);
        }
    }
}
