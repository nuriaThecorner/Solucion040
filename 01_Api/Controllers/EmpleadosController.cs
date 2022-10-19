using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using _04_Data.Data;
using _02_Services.EmpleadosServices;

namespace _01_Api.Controllers
{
    public class EmpleadosController : ApiController
    {
        private NorthWindTuneadoDbContext db = new NorthWindTuneadoDbContext();

        //Aquí mostramos la List completa
        // GET: api/Empleados
        public IList<Empleado> GetEmpleado()
        {
            IList<Empleado> empleados = null;
            EmpleadosService service = null;
            service = new EmpleadosService();
            empleados = service.ListApi(null, null);
            return empleados;
        }

        //Aquí mostramos la List de los Registros
        //que pertenecen al Registro de la Madre cuya id es id
        //Por eso devuelve un IList<Empleado>
        //ESTE NO LO VAMOS A UTILIZAR:
        // GET: api/Empleados
        public IList<Empleado> GetEmpleado(int? id, string madre)
        {
            IList<Empleado> empleados = null;
            EmpleadosService service = null;
            service = new EmpleadosService();
            empleados = service.ListApi(id, madre);
            return empleados;
        }

        //Aquí mostramos la List completa
        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id)
        {
            Empleado empleado = null;
            EmpleadosService service = null;
            service = new EmpleadosService();
            empleado = service.DetailApi(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int? id, int? siguiente)
        {
            Empleado empleado = null;
            if (siguiente == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            else
            {
                if (siguiente.Value == 1)
                {
                    empleado = db.Empleado.Where(x => x.EmployeeID > id.Value).FirstOrDefault();
                }
                else
                {
                    IList<Empleado> empleados = db.Empleado.Where(x => x.EmployeeID < id.Value).ToList();
                    if (empleados != null && empleados.Count() > 0)
                    {
                        int? idEmpleado = empleados.Max(x => x.EmployeeID);
                        empleado = db.Empleado.Where(x => x.EmployeeID == idEmpleado.Value).FirstOrDefault();
                    }
                }
            }
            if (empleado == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            Empleado empleadoTabla = new Empleado();
            empleadoTabla.EmployeeID = empleado.EmployeeID;
            empleadoTabla.LastName = empleado.LastName;
            empleadoTabla.FirstName = empleado.FirstName;
            empleadoTabla.birthDate = empleado.birthDate;
            empleadoTabla.Photo = empleado.Photo;
            empleadoTabla.Notes = empleado.Notes;

            return Ok(empleadoTabla);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleado.Add(empleado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleado.EmployeeID }, empleado);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleado.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.Empleado.Count(e => e.EmployeeID == id) > 0;
        }
    }
}