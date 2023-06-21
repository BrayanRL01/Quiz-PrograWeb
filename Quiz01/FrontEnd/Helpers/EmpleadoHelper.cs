using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class EmpleadoHelper
    {
        ServiceRepository repository;

        public EmpleadoHelper()
        {
            repository = new ServiceRepository();
        }

        #region GetAll
        public List<EmpleadoViewModel> GetAll()
        {
            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Empleado/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(content);

            }
            return lista;
        }
        #endregion

        #region GetByID
        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmpleadoViewModel GetByID(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Empleado/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);

            return empleado;
        }
        #endregion

        #region Update
        public EmpleadoViewModel Edit(EmpleadoViewModel empleado)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/empleado/", empleado);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmpleadoViewModel empleadoAPI = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            return empleadoAPI;
        }
        #endregion

        #region Add
        public EmpleadoViewModel Add(EmpleadoViewModel empleado)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Empleado/", empleado);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmpleadoViewModel empleadoAPI = JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            return empleadoAPI;
        }
        #endregion

        #region Delete
        public EmpleadoViewModel Delete(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Empleado/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            return empleado;
        }
        #endregion

    }
}

