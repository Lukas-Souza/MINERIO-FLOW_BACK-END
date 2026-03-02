namespace DTOs.Response
{
    public class DtoResponseClassic
    {
        public int Id { get; set; }
        public string? Classificacao {get; set;}
        public string? IdMineradora {get;set;}
        public double Teor {get; set;}
        public string? TipoMinerio {get; set;}
        public string? Status {get; set;}
        public DateTime DataExtracao {get; set;}
  
    }
}