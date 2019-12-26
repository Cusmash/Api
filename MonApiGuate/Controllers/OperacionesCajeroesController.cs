using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonApiGuate.DTOs;
using MonApiGuate.Models;
using MonApiGuate.Services;

namespace MonApiGuate.Controllers
{
    [Route("api/Cajero")]
    [ApiController]
    public class OperacionesCajeroesController : ControllerBase
    {
        private readonly GTDBContext _context;

        public OperacionesCajeroesController(GTDBContext context)
        {
            _context = context;
        }

        // GET: api/OperacionesCajeroes
        [HttpGet]
        public ActionResult<OperacionesCajeroesDTO> GetOperacionesCajeroes()
        {
            PingPc pokePing = new PingPc();
            PingSql pokeSql = new PingSql();

            try
            {
                //Lista de Objetos donde se almacenaran los datos
                List<object> Monitoreo = new List<object>();

                //Conexion Exitosa
                if (pokePing.PingHost() == true)
                {
                    try
                    {
                        if (pokeSql.IsServerConnected())
                        {
                            var queryCajeros = _context.OperacionesCajeroes.OrderByDescending(x => x.DateToperacion).FirstOrDefault();
                            object[] consultaSql = { };

                            if (queryCajeros != null)
                            {
                                var difHoras = (DateTime.Now - queryCajeros.DateToperacion).TotalHours;
                                var statusDesfase = difHoras <= 1 ? false : true;

                                consultaSql = new object[] {
                                    queryCajeros.Concepto.ToString(),
                                    queryCajeros.DateToperacion.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                    queryCajeros.Tipo,
                                    statusDesfase
                                };
                            }
                            var guatemala = new
                            {
                                Name_Caseta = "Autopista Palin-Escuintla",
                                Data = new
                                {
                                    consultaSql
                                }
                            };
                            Monitoreo.Add(guatemala);
                            return Ok(Monitoreo);
                        }
                        else
                        {
                            var Guatemala = new
                            {
                                Name_Caseta = "Autopista Palin-Escuintla",
                                Data = "Sin Conexion Sql"
                            };
                            Monitoreo.Add(Guatemala);
                            return Ok(Monitoreo); ;
                        }
                    }
                    catch (Exception)
                    {
                        var Guatemala = new
                        {
                            Name_Caseta = "Autopista Palin-Escuintla",
                            Data = "Sin Conexion Sql"
                        };
                        Monitoreo.Add(Guatemala);
                        return Ok(Monitoreo);
                    }

                }
                else
                {
                    var Guatemala = new
                    {
                        Name_Caseta = "Autopista Palin-Escuintla",
                        Data = "Sin Conexion Pc"
                    };
                    Monitoreo.Add(Guatemala);
                    return Ok(Monitoreo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/OperacionesCajeroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacionesCajeroes>> GetOperacionesCajeroes(long id)
        {
            var operacionesCajeroes = await _context.OperacionesCajeroes.FindAsync(id);

            if (operacionesCajeroes == null)
            {
                return NotFound();
            }

            return operacionesCajeroes;
        }

        // PUT: api/OperacionesCajeroes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOperacionesCajeroes(long id, OperacionesCajeroes operacionesCajeroes)
        //{
        //    if (id != operacionesCajeroes.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(operacionesCajeroes).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OperacionesCajeroesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/OperacionesCajeroes
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<OperacionesCajeroes>> PostOperacionesCajeroes(OperacionesCajeroes operacionesCajeroes)
        //{
        //    _context.OperacionesCajeroes.Add(operacionesCajeroes);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOperacionesCajeroes", new { id = operacionesCajeroes.Id }, operacionesCajeroes);
        //}

        //// DELETE: api/OperacionesCajeroes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<OperacionesCajeroes>> DeleteOperacionesCajeroes(long id)
        //{
        //    var operacionesCajeroes = await _context.OperacionesCajeroes.FindAsync(id);
        //    if (operacionesCajeroes == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OperacionesCajeroes.Remove(operacionesCajeroes);
        //    await _context.SaveChangesAsync();

        //    return operacionesCajeroes;
        //}

        //private bool OperacionesCajeroesExists(long id)
        //{
        //    return _context.OperacionesCajeroes.Any(e => e.Id == id);
        //}
    }
}
