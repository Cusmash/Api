using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonApiGuate.Models;
using MonApiGuate.Services;

namespace MonApiGuate.Controllers
{
    [Route("api/LSTBINT")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        LaUsurpadora mi_laUsurpadora = new LaUsurpadora();

        [HttpGet]
        public ActionResult<LaUsurpadora> GetAction()
        {
            
            return Ok( mi_laUsurpadora.Entra());
        }


        //[HttpGet]
        //public async Task<ActionResult<GTDBContext>> GetActionAsync()
        //{

        //    var historico = _context.Historico.OrderByDescending(x => x.Fecha).FirstOrDefaultAsync();
        //    var Cajeroes = _context.OperacionesCajeroes.OrderByDescending(x => x.DateToperacion).FirstOrDefaultAsync();



        //    //return await _context.Historico.ToListAsync();

        //    return await Cajeroes;

        //}
    }
}