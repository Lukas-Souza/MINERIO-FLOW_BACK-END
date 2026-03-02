using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTOs;
using Models;

using Data;
using Microsoft.AspNetCore.SignalR;
using DTOs.Response;

namespace CaseProject.Controlles
{
    [ApiController]
    [Route("/lot-minerio")]
    public class MinerioController : ControllerBase
    {
        private readonly AppDbContext Db_;
        public MinerioController(AppDbContext db) => Db_ = db;


        [HttpGet]
    public async Task<IActionResult> GetElement()
        {

            List<LotMinerio> returnAll = await Db_.LotesMinerio.ToListAsync();
            return Ok(returnAll);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            
                // SELECT * FROM WHERE id={id_variable}
                LotMinerio? loteById = await Db_.LotesMinerio.FindAsync(id);
                if (loteById == null)
                {
                    return NotFound(new {menssagen= "Registro não encontrado."});
                }
                return Ok(loteById);        
        }

        [HttpPost]
        public async Task<IActionResult> CreateMinerio([FromBody] RequireLotMinerioDto dto)
        {
            if (dto == null) return BadRequest("A requesição esta vindo invalida!!");
            else
            {
                  
                try
                {

                    LotMinerio lote = new LotMinerio(dto);
                    Db_.LotesMinerio.Add(lote);
                    await Db_.SaveChangesAsync();
                
                    var ResponseObjet = new DtoResponse
                    {
                        IdLote = lote.IdLote,
                        Teor = lote.Teor,
                        PesoQuantidade = lote.PesoQuantidade,
                        TipoMinerio = lote.TipoMinerio,
                        Status = lote.Status,
                        IdMineradora = lote.IdMineradora
                    };    
                    return StatusCode(201);

                }
                
                catch (ArgumentException err)
                {
                    return BadRequest($"Ocorreu um erro: {err}");
                }

            }}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutElementById(int id, [FromBody] UpdateLotMinerio dto)
        {
            // Id == id
            var loteResult = await Db_.LotesMinerio.FindAsync(id);
            if (loteResult == null)
            {
                return NotFound();
            }
            loteResult.Atualizar(dto);

            try
            {
             
            await Db_.SaveChangesAsync();
            return NoContent();   
            }
            catch (Exception err)
            {
                
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveElementById(int id)
        {
            var elementById = await Db_.LotesMinerio.FindAsync(id);
            if (elementById == null)
            {
                return NotFound(new {menssagen= "Registro não encontrado ou não existe."});               
            }
            else
            {

            try
            {
             
             
            Db_.Remove(elementById);
            Db_.SaveChangesAsync();

            return NoContent();   
            }
            catch (Exception err)
            {
                
                return StatusCode(500, new {erro= "Ocorreu um erro ao remover o elemento.", menssagen= err});
            }

            }
            
        }
    }
}