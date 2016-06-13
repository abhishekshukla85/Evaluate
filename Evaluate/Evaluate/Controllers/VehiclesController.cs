﻿using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Evaluate.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiclesController : ApiController
    {
        private readonly InMemoryVehicleRepository _inMemoryVehicleRepository;

        public VehiclesController()
        {
            _inMemoryVehicleRepository = InMemoryVehicleRepository.Instance;
        }

        // GET api/vehicles
        public IEnumerable<Vehicle> Get()
        {
            return _inMemoryVehicleRepository.Get();
        }

        // GET api/vehicles/5
        public Vehicle Get(int id)
        {
            return _inMemoryVehicleRepository[id];
        }

        // POST api/vehicles
        public void Post([FromBody]Vehicle vehicle)
        {
            _inMemoryVehicleRepository.Add(vehicle);
        }

        // PUT api/vehicles/5
        public void Put(int id, [FromBody]Vehicle vehicle)
        {
            if (id == 0 || (vehicle.Id != 0 && vehicle.Id != id))
            {
                throw new ArgumentOutOfRangeException("id");
            }
            vehicle = vehicle.CloneWith(id);
            _inMemoryVehicleRepository.Add(vehicle);
        }

        // DELETE api/vehicles/5
        public void Delete(int id)
        {
            _inMemoryVehicleRepository.Remove(id);
        }
    }
}
