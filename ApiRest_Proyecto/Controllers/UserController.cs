using ApiRest_Proyecto.Data;
using ApiRest_Proyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AdministracionContext _dbContext;
        public UserController(AdministracionContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _dbContext.Recibos.ToList();
                Console.WriteLine("entre aqui");
                if(users.Count == 0)
                {
                    return StatusCode(404, "Not user found");
                }

                return Ok(users);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has ocurred!!!");
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] UserRequest request)
        {
            Recibos user = new Recibos();
            user.Proveedor = request.Proveedor;
            user.Monto = request.Monto;
            user.Moneda = request.Moneda;
            user.Fecha = request.Fecha;
            user.Comentario = request.Comentario;

            try
            {
                _dbContext.Recibos.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error has ocurred");
            }
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] UserRequest request)
        {
            try
            {
                var user = _dbContext.Recibos.FirstOrDefault(x => x.Id == request.Id);
                if(user == null)
                {
                    return StatusCode(404, "Not user found");
                }

                user.Proveedor = request.Proveedor;
                user.Monto = request.Monto;
                user.Moneda = request.Moneda;
                user.Fecha = request.Fecha;
                user.Comentario = request.Comentario;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error has ocurred");
            }

            var users = _dbContext.Recibos.ToList();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{Id}")]
        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {
                var user = _dbContext.Recibos.FirstOrDefault(x => x.Id == Id);
                if (user == null)
                {
                    return StatusCode(404, "Not user found");
                }

                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error has ocurred");
            }

            var users = _dbContext.Recibos.ToList();
            return Ok(users);
        }
    }
}
