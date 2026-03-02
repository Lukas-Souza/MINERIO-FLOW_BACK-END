// | MICROSOFT MVC ASPNET
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;
using DTOs;
using Services;
using Models;

namespace CaseProject.Controlles
{

 [ApiController]
 [Route("/lot-minerio/transactions")]
 public class TransactionControllers: ControllerBase
 {
    ServicesLotMinerio servicesLotMinerio = new ServicesLotMinerio();

    private readonly AppDbContext Db_;
    // Expressoão lambda
    public TransactionControllers(AppDbContext db) => Db_ = db;


    [HttpGet]
    public async Task<IActionResult> GetAllClassification()
    {
        var ReturnAllClassification = await Db_.LotesMinerio.ToListAsync();

        return Ok(servicesLotMinerio.ReturOutTransaciton(ReturnAllClassification));    
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> classiscElementId(int id)
        {  
            LotMinerio? LotMinerio_ = await Db_.LotesMinerio.FindAsync(id);
            if (LotMinerio_ == null)
            {
                return NotFound(new {Menssagen= "VALOR NÂO ENCONTRADO"});
            }
            List<LotMinerio> ListLot = new List<LotMinerio>{LotMinerio_};
            
            return Ok(servicesLotMinerio.ClassificarPorQualidade(ListLot));
        }
    

    [HttpPut]
    public async Task<IActionResult> UpdateStatus( [FromBody] UpdateTransaction updateTransaction)
    {
        var ResultPost = await Db_.LotesMinerio.FindAsync(updateTransaction.LotMinerio);
        
        ResultPost.UpdateTrasaction(updateTransaction); 
        
        await Db_.SaveChangesAsync();
        
        return StatusCode(201); 
    }



 }

}