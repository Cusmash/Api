using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly GTDBContext _context;

        public TagController(GTDBContext context)
        {
            _context = context;
        }


        // GET: api/Tag
        [HttpGet]
        public  ActionResult<TagsDTO> GetTags()
        {
            PingPc pokePing = new PingPc();
            PingSql pokeSql = new PingSql();

            try
            {
                //Lista de Objetos donde se almacenaran los datos
                List<object> Monitoreo = new List<object>();

                if (pokePing.PingHost() == true)
                {
                    try
                    {
                        if (pokeSql.IsServerConnected())
                        {
                            var queryCount = _context.Tags.Count();
                            object[] consultaSql = { };

                            var guatemala = new
                            {
                                Name_Caseta = "Autopista Palin-Escuintla",
                                Data = new
                                {
                                    queryCount
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

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tags>> GetTags(long id)
        {
            var tags = await _context.Tags.FindAsync(id);

            if (tags == null)
            {
                return NotFound();
            }

            return tags;
        }

        // PUT: api/Tag/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTags(long id, Tags tags)
        //{
        //    if (id != tags.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tags).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TagsExists(id))
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

        //// POST: api/Tag
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Tags>> PostTags(Tags tags)
        //{
        //    _context.Tags.Add(tags);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTags", new { id = tags.Id }, tags);
        //}

        //// DELETE: api/Tag/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Tags>> DeleteTags(long id)
        //{
        //    var tags = await _context.Tags.FindAsync(id);
        //    if (tags == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tags.Remove(tags);
        //    await _context.SaveChangesAsync();

        //    return tags;
        //}

        //private bool TagsExists(long id)
        //{
        //    return _context.Tags.Any(e => e.Id == id);
        //}
    }
}
