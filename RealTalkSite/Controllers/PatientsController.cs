using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using RealTalkWeb.Models;

namespace RealTalkWeb.Controllers
{
  public class PatientsController : ApiController
  {
    private static readonly List<Patient> PatientList = new List<Patient>
    {
      new Patient
      {
        PatientId = 1,
        FirstName = "Brandon",
        LastName = "Kacsmaryk",
        HomeAreaCode = "919",
        HomeLocalNumber = "1234567",
        City = "Raliegh",
        Street1 = "123 Main St",
        StateOrProvince = "NC",
        PostalCode = "27615"
      },
      new Patient
      {
        PatientId = 2,
        FirstName = "Jason",
        LastName = "Mallon",
        HomeAreaCode = "123",
        HomeLocalNumber = "9193456",
        City = "Somewherevilee",
        Street1 = "987 Market St",
        StateOrProvince = "NC",
        PostalCode = "27619"
      }
    };

    public IEnumerable<Patient> GetAllPatients()
    {
      return PatientList.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
    }

    [ResponseType(typeof (Patient))]
    public IHttpActionResult GetPatient(long id)
    {
      var patient = PatientList.SingleOrDefault(x => x.PatientId == id);
      if (patient == null) return NotFound();
      return Ok(patient);
    }
  }
}

