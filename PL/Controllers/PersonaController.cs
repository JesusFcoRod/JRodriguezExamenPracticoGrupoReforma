using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PersonaController : Controller
    {

        [HttpGet]

        public ActionResult GetAll()
        {
            ML.Persona persona = new ML.Persona();
            ML.Result result = new ML.Result();

            result = BL.Persona.GetAll();

            if (result.Correct)
            {
                persona.Personas = result.Objects;
                return View(persona);
            }
            return View();

            
        }

        [HttpGet]
        public ActionResult Formulario(int? idPersona)
        {
            ML.Result result = new ML.Result();
            ML.Persona persona = new ML.Persona();

            if (idPersona != null)
            {
                result = BL.Persona.GetById(idPersona.Value);
                if (result.Correct)
                {
                    persona = (ML.Persona)result.Object;
                    return View(persona);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion de la persona";
                }
                return PartialView("Modal");
            }
            else {
                return View(persona);
            }
        }


        [HttpPost]
        public ActionResult Formulario(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            int idPersona = persona.IdPersona;

            if (idPersona > 0)
            {
                //UPDATE
                result = BL.Persona.Update(persona);
                if (result.Correct)
                {
                    ViewBag.Message = "Persona actualizada con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar los datos de la persona";
                }

            }
            else
            {
                //ADD
                result = BL.Persona.Add(persona);
                if (result.Correct)
                {
                    ViewBag.Message = "Persona registrada con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar los datos de la persona";
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int idPersona)
        {
            ML.Result result = BL.Persona.Delete(idPersona);

            if (result.Correct)
            {
                ViewBag.Message = "Persona eliminada de la base de datos";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al intentar eliminar el registro";
            }

            return PartialView("Modal");
           
        }
    }
}