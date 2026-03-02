namespace DTOs.Response
{
    public class DtoResponse
    {
        public int IdLote {get; set;}
        public string? IdMineradora {get; set;}
        public double Teor {get; set;}
        public double PesoQuantidade {get; set;} 
        public double ValorPKilo {get; set;}
        public string? UnidadeDeMedidaPeso {get; set;}
        public string? TipoMinerio {get; set;}
        public string? Status {get; set;}
        public DateTime DataExtracao {get; set;}   
    }
}