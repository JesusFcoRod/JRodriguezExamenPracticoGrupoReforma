using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Persona
    {
        public static ML.Result Add(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRodriguezExamenGrupoReformaEntities contex = new DL.JRodriguezExamenGrupoReformaEntities())
                {
                    var query = contex.PersonaAdd(persona.Nombre, persona.Direccion,persona.Edad,persona.Correo,persona.HabilidadPrimaria,persona.HabilidadSecundaria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;

        }

        public static ML.Result Update (ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRodriguezExamenGrupoReformaEntities contex = new DL.JRodriguezExamenGrupoReformaEntities())
                {
                    var query = contex.PersonaUpdate(persona.IdPersona,persona.Nombre, persona.Direccion, persona.Edad, persona.Correo, persona.HabilidadPrimaria, persona.HabilidadSecundaria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int idPersona)
        {
            ML.Result result = new ML.Result ();

            try
            {
                using (DL.JRodriguezExamenGrupoReformaEntities contex = new DL.JRodriguezExamenGrupoReformaEntities())
                {
                    var query = contex.PersonaDelete(idPersona);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenGrupoReformaEntities contex = new DL.JRodriguezExamenGrupoReformaEntities())
                {
                    var query = contex.PersonaGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Persona persona = new ML.Persona();
                            persona.IdPersona = item.idPersona;
                            persona.Nombre = item.Nombre;
                            persona.Direccion = item.direccion;
                            persona.Edad = item.edad.Value;
                            persona.Correo = item.correo;
                            persona.HabilidadPrimaria = item.habilidadPrimaria;
                            persona.HabilidadSecundaria = item.habilidadSecundaria;
                            persona.idTipo = item.idTipo.Value;

                            result.Objects.Add(persona);
                            result.Correct = true;

                        }
                    }
                }

            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetById(int idPersona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenGrupoReformaEntities contex = new DL.JRodriguezExamenGrupoReformaEntities())
                {
                    var query = contex.PersonaGetById(idPersona).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Persona persona = new ML.Persona();
                        persona.IdPersona = query.idPersona;
                        persona.Nombre = query.Nombre;
                        persona.Direccion = query.direccion;
                        persona.Edad = query.edad.Value;
                        persona.Correo= query.correo;
                        persona.HabilidadPrimaria = query.habilidadPrimaria;
                        persona.HabilidadSecundaria = query.habilidadSecundaria;
                        persona.idTipo = query.idTipo.Value;

                        result.Object = persona;
                        result.Correct = true;

                    }
                }
            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
