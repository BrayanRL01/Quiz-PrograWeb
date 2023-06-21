using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private IEmpleadoDAL empleadoDAL;

        private EmpleadoModel Convertir(Empleado empleado)
        {
            return new EmpleadoModel
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        private Empleado Convertir(EmpleadoModel empleado)
        {
            return new Empleado
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        public EmpleadoController()
        {
            empleadoDAL = new EmpleadoDALImpl();

        }

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<Empleado> empleados = await empleadoDAL.GetAll();
            List<EmpleadoModel> models = new List<EmpleadoModel>();

            foreach (var empleado in empleados)
            {
                models.Add(Convertir(empleado));
            }
            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Empleado empleado = await empleadoDAL.Get(id);
            return new JsonResult(Convertir(empleado));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] EmpleadoModel empleado)
        {
            empleadoDAL.Add(Convertir(empleado));
            return new JsonResult(empleado);
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EmpleadoModel empleado)
        {
            empleadoDAL.Update(Convertir(empleado));
            return new JsonResult(empleado);
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Empleado empleado = new Empleado
            {
                EmpleadoId = id
            };
            empleadoDAL.Remove(empleado);
        }

        #endregion
    }
}
