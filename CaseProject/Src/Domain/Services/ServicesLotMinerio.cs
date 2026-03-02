using DTOs.Response;
using Models;

namespace Services
{
    public class ServicesLotMinerio
    {

        public List<DtoResponseClassic> ClassificarPorQualidade( List<LotMinerio> listLotMinerios )
        {
            // |  PREMIUN < 99,99 
            // |  PADRÃO < 66,66
            // |  BAIXA < 33,33
         
            List<DtoResponseClassic> DtoResponseClassics_  = new List<DtoResponseClassic>();
            foreach( var item in listLotMinerios)
            {
            DtoResponseClassic dtoResponseClassic = new DtoResponseClassic();

                if (item.Teor < 33.33)
                {
                dtoResponseClassic.Classificacao = "BAIXA";
                }

                else if (item.Teor < 66.66)
                {
                dtoResponseClassic.Classificacao = "PADRÃO";
                }

                else 
                {
                dtoResponseClassic.Classificacao = "PREMIUN";
                }
                dtoResponseClassic.DataExtracao = item.DataExtracao;
                dtoResponseClassic.Id = item.IdLote;
                dtoResponseClassic.IdMineradora = item.IdMineradora;
                dtoResponseClassic.Status = item.Status;
                dtoResponseClassic.TipoMinerio = item.TipoMinerio;
                dtoResponseClassic.Teor = item.Teor;
                DtoResponseClassics_.Add(dtoResponseClassic);
            }
            return DtoResponseClassics_;
            
        }
        public List<TransctionLotMinerio> ReturOutTransaciton(List<LotMinerio> lotMinerios)
        {
            List<TransctionLotMinerio> transctionLotMinerios = new List<TransctionLotMinerio>();
            foreach (var item in lotMinerios)
            {
                transctionLotMinerios.Add(
                    new TransctionLotMinerio
                    {
                        IdLote = item.IdLote,   
                        StatusTransaction = item.Status,
                        HourTransaction = item.DataExtracao.ToString("HH:mm"),
                        DateTransaction = item.DataExtracao.ToString("dd/MM/yyyy")
                        
                    }
                );
            }
            return transctionLotMinerios;
        }

        
    }
}