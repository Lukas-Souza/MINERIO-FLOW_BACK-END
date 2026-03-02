using DTOs;
using DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Services;
namespace CaseProject.Controlles
{
    [ApiController]
    [Route("/lot-minerio/classification/")]
    public class ExtraControllers: ControllerBase
    {
    ServicesLotMinerio servicesLotMinerio = new ServicesLotMinerio();
    
    private readonly AppDbContext Db_;
    public ExtraControllers(AppDbContext db) => Db_ = db;

    [HttpGet]
    public async Task<IActionResult> GetHistoryTransction()
    {
    List<LotMinerio> DatResult = await Db_.LotesMinerio.ToListAsync();
    return Ok(servicesLotMinerio.ClassificarPorQualidade(DatResult));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetHistoryTransctionById(int id)
    {
    LotMinerio DatResult = await Db_.LotesMinerio.FindAsync(id);
    List<LotMinerio> lotMinerios = new List<LotMinerio>{DatResult};
    return Ok(servicesLotMinerio.ClassificarPorQualidade(lotMinerios));
    }
  }
}