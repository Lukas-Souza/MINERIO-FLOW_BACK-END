using Models;
using DTOs;
using Castle.Components.DictionaryAdapter.Xml;
namespace ModelsTest
{
    public class TransactionTest
    {
    [Theory]
    [InlineData("PLANEJADO")]
    [InlineData("EXTRACAO")]
    [InlineData("EXTRAIDO")]
    [InlineData("PROCESSAMENTO")]
    [InlineData("PROCESSADO")]
    [InlineData("ESTOQUE")]
    [InlineData("RESERVADO")]
    [InlineData("CARREGAMENTO")]
    [InlineData("TRANSPORTE")]
    [InlineData("ENTREGUE")]
    [InlineData("FATURADO")]
    [InlineData("ENCERRADO")]
    [InlineData("BLOQUEADO")]
    [InlineData("CANCELADO")]
    public void UpdateTransaction(string status){
    var lot = new LotMinerio(
        new RequireLotMinerioDto{
                    Teor= 20,
                    PesoQuantidade= 220.75,
                    ValorPKilo= 35,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "NIQUEL",
                    Status= "EXTRACAO",
                    IdMineradora= "M077"
        }
    );

    lot.UpdateTrasaction(
        new UpdateTransaction{
            NewStatus = status,
            LotMinerio = 1
        }
    );
    Assert.Equal(status, lot.Status);
}





[Theory]
[InlineData("")]
[InlineData(null)]
public void TestTransactionNullParams(string status){
        var lot = new LotMinerio(
        new RequireLotMinerioDto{
                    Teor= 20,
                    PesoQuantidade= 220.75,
                    ValorPKilo= 35,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "NIQUEL",
                    Status= "EXTRACAO",
                    IdMineradora= "M077"
        }
    );

    Assert.Throws<ArgumentException>(()=>{

    lot.UpdateTrasaction(
        new UpdateTransaction{
            NewStatus = status,
            LotMinerio = 1
        }
    );
    });
    }

[Theory]
[InlineData("---")]
[InlineData("EXTR@")]
[InlineData("@@@@@@")]
[InlineData("xxxxx")]
[InlineData("wwwwwwww")]

public void TestTransactionStatusInvaliented(string status){
        var lot = new LotMinerio(
        new RequireLotMinerioDto{
                    Teor= 20,
                    PesoQuantidade= 220.75,
                    ValorPKilo= 35,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "NIQUEL",
                    Status= "EXTRACAO",
                    IdMineradora= "M077"
        }
    );

    Assert.Throws<ArgumentException>(()=>{

    lot.UpdateTrasaction(
        new UpdateTransaction{
            NewStatus = status,
            LotMinerio = 1
        }
    );
    });
    }
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void TestsTransactionNumberIdInvaluation(int _idLot){

                var lot = new LotMinerio(
        new RequireLotMinerioDto{
                    Teor= 20,
                    PesoQuantidade= 220.75,
                    ValorPKilo= 35,
                    UnidadeDeMedidaPeso= "TON",
                    TipoMinerio= "NIQUEL",
                    Status= "EXTRACAO",
                    IdMineradora= "M077"
            }
        );

    Assert.Throws<ArgumentException>(()=>{
        lot.UpdateTrasaction(
            new UpdateTransaction{
            NewStatus = "CANCELADO",
            LotMinerio = _idLot
        }
        );

    });
    }
}
}