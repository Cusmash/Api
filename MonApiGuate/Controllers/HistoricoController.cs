using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonApiGuate.Models;
using MonApiGuate.DTOs;
using MonApiGuate.Services;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Globalization;

namespace MonApiGuate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {



        private readonly GTDBContext _context;

        public HistoricoController(GTDBContext context)
        {
            _context = context;
        }



        // GET: api/Historicoes
        [HttpGet]
        public ActionResult<HistoricoDTO> GetHistorico()
        {
            PingPc pokePing = new PingPc();
            PingSql pokeSql = new PingSql();

            try
            {
                //Lista de Objetos donde se almacenaran los datos
                List<object> Monitoreo = new List<object>();

                //Conexion Exitosa
                if (pokePing.PingHost())
                {
                    try
                    {
                        if (pokeSql.IsServerConnected())
                        {
                            var queryHistorico = _context.Historico.OrderByDescending(x => x.Fecha).FirstOrDefault();
                            object[] consultaSql = { };

                            if(queryHistorico != null)
                            {
                                var difHoras = (DateTime.Now - queryHistorico.Fecha).TotalHours;

                                var statusDesfase = difHoras <= 1 ? false : true;

                                consultaSql = new object[] {
                                    queryHistorico.Delegacion.ToString(),
                                    queryHistorico.Fecha.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), 
                                    queryHistorico.Evento, 
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


        // GET: api/Historicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historico>> GetHistorico(int id)
        {
            var historico = await _context.Historico.FindAsync(id);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        // PUT: api/Historicoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHistorico(int id, Historico historico)
        //{
        //    if (id != historico.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(historico).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HistoricoExists(id))
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

        // POST: api/Historicoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Historico>> PostHistorico(Historico historico)
        //{
        //    _context.Historico.Add(historico);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHistorico", new { id = historico.Id }, historico);
        //}

        //// DELETE: api/Historicoes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Historico>> DeleteHistorico(int id)
        //{
        //    var historico = await _context.Historico.FindAsync(id);
        //    if (historico == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Historico.Remove(historico);
        //    await _context.SaveChangesAsync();

        //    return historico;
        //}

        //private bool HistoricoExists(int id)
        //{
        //    return _context.Historico.Any(e => e.Id == id);
        //}
    }
}
