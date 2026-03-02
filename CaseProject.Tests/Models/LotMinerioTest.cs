using Models;
using DTOs;
using Castle.Components.DictionaryAdapter.Xml;
namespace ModelsTest
{
    public class LotMinerioTest
    {
        RequireLotMinerioDto requireLotMinerioDto; 
        [Fact]
        public void CreatedElement()
        {
            // Arange
               requireLotMinerioDto = new RequireLotMinerioDto
              {
                    Teor= 20,
                    PesoQuantidade= 220.75,
                    ValorPKilo= 35,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "NIQUEL",
                    Status= "EXTRACAO",
                    IdMineradora= "M077"
              };
            LotMinerio _lotMinerio = new LotMinerio(requireLotMinerioDto);

            // Act
            Assert.Equal(_lotMinerio.Teor, requireLotMinerioDto.Teor);
            Assert.Equal(_lotMinerio.PesoQuantidade, requireLotMinerioDto.PesoQuantidade);
            Assert.Equal(_lotMinerio.ValorPKilo, requireLotMinerioDto.ValorPKilo);
            Assert.Equal(_lotMinerio.UnidadeDeMedidaPeso, requireLotMinerioDto.UnidadeDeMedidaPeso);
            Assert.Equal(_lotMinerio.TipoMinerio, requireLotMinerioDto.TipoMinerio);
            Assert.Equal(_lotMinerio.Status, requireLotMinerioDto.Status);
            Assert.Equal(_lotMinerio.IdMineradora, requireLotMinerioDto.IdMineradora);
        }
        [Fact]
        public void TestRequireParamentsTesxtNull(){
                requireLotMinerioDto = new RequireLotMinerioDto
              {
                    Teor= 3,
                    PesoQuantidade= 3,
                    ValorPKilo= 3,
                    UnidadeDeMedidaPeso= "",
                    TipoMinerio= "",
                    Status= "",
                    IdMineradora= ""
              };
        var errro = Assert.Throws<ArgumentException>(()=>{
            new LotMinerio(requireLotMinerioDto);
        });
        Assert.Equal("os dados fornecidos são invalidos", errro.Message);
        }
    [Fact]
        public void TestRequireParamentsNumbertNull(){
                requireLotMinerioDto = new RequireLotMinerioDto
              {
                    Teor= 0,
                    PesoQuantidade= 0,
                    ValorPKilo= 0,
                    UnidadeDeMedidaPeso= "Teste",
                    TipoMinerio= "Teste",
                    Status= "EXTRACAO",
                    IdMineradora= "Teste"
              };
        var errro = Assert.Throws<ArgumentException>(()=>{
            new LotMinerio(requireLotMinerioDto);
        });
        Assert.Equal("os dados fornecidos são invalidos", errro.Message);
        }

        [Fact]
        public void TestStatusValited(){
             requireLotMinerioDto = new RequireLotMinerioDto
              {
                    Teor= 89,
                    PesoQuantidade= 55,
                    ValorPKilo= 45,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "CILICIO",
                    Status= "__",
                    IdMineradora= "ID-2500"
              };
        var errro = Assert.Throws<ArgumentException>(()=>{
            new LotMinerio(requireLotMinerioDto);
        });
        Assert.Equal("os dados fornecidos são invalidos", errro.Message);
        }   

    [Fact]
    public void UpdateLotMinerio(){
        LotMinerio _lotMinerio = new LotMinerio(
             new RequireLotMinerioDto{
                
                    Teor= 89,
                    PesoQuantidade= 55,
                    ValorPKilo= 45,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "CILICIO",
                    Status= "EXTRACAO",
                    IdMineradora= "ID-2500"
              
        });
            UpdateLotMinerio Update = new UpdateLotMinerio{
            Teor= 10,
            PesoQuantidade= 2200.75,
            ValorPKilo= 35.9,
            UnidadeDeMedidaPeso= "kg",
            TipoMinerio= "Ferro",
            Status= "EXTRACAO",
            IdMineradora= "M077"
            };
        _lotMinerio.Atualizar(Update);  
        }   
        [Theory]
        [InlineData(null, "Ferro", "EXTRACAO", "M077")]
        [InlineData("kg", null, "EXTRACAO", "M077")]
        [InlineData("kg", "Ferro", null, "M077")]
        [InlineData("kg", "Ferro", "EXTRACAO", null)]
        public void UpdateNullParamText(
        string unidade,
        string tipo,
        string status,
        string idMineradora)
        {
    // Arrange
        var lot = new LotMinerio(new RequireLotMinerioDto
        {
            Teor = 89,
            PesoQuantidade = 55,
            ValorPKilo = 45,
            UnidadeDeMedidaPeso = "TON",
            TipoMinerio = "CILICIO",
            Status = "EXTRACAO",
            IdMineradora = "ID-2500"
        });

        var update = new UpdateLotMinerio
        {
            Teor = 10,
            PesoQuantidade = 2200.75,
            ValorPKilo = 35.9,
            UnidadeDeMedidaPeso = unidade,
            TipoMinerio = tipo,
            Status = status,
            IdMineradora = idMineradora
        };

        // Act 
        var Err =Assert.Throws<ArgumentException>(() =>
        {
            lot.Atualizar(update);
        });
        Assert.Equal("Dados invalidos", Err.Message);
    }
    [Theory]
    [InlineData(null, 5.5, 4.6)]
    [InlineData(5.5, null, 4.6)]
    [InlineData(5.5, 4.6, null)]
    [InlineData(4.6, 5.5, 0)]
    [InlineData(5.5, 4.6, 0)]
    [InlineData(0, 4.6, 5.5)]
       
    public void TestParamNullNumbers(double _teor, double _pesoQuantiade, double valoPkilo){
                var lot = new LotMinerio(new RequireLotMinerioDto
        {
            Teor = 89,
            PesoQuantidade = 55,
            ValorPKilo = 45,
            UnidadeDeMedidaPeso = "TON",
            TipoMinerio = "CILICIO",
            Status = "EXTRACAO",
            IdMineradora = "ID-2500"
        });

        var update = new UpdateLotMinerio
        {
            Teor = _teor,
            PesoQuantidade = _pesoQuantiade,
            ValorPKilo = valoPkilo,
            UnidadeDeMedidaPeso = "TON",
            TipoMinerio = "TEST",
            Status = "CANCELADO",
            IdMineradora = "ID-0001"
        };
        Assert.Throws<ArgumentException>(() => {
            lot.Atualizar(update);
        });

    }  
    }
}    

