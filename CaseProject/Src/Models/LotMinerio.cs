using System;
using Enums.StatusLote;
using DTOs;
namespace Models
{
    public class LotMinerio
    {
        public int IdLote {get; private set;}
        public string? IdMineradora {get; private set;}
        public double Teor {get;private  set;}
        public double PesoQuantidade {get;private  set;} 
        public double ValorPKilo {get;private set;}
        public string? UnidadeDeMedidaPeso {get;private  set;}
        public string? TipoMinerio {get;private set;}
        public string? Status {get;private set;}
        public DateTime DataExtracao {get;private set;}

        public LotMinerio(
           RequireLotMinerioDto requireLotMinerioDto 
        )
        {
            // Program
            bool IsNullUnidade = string.IsNullOrWhiteSpace(requireLotMinerioDto.UnidadeDeMedidaPeso);
            bool IsNullTipo = string.IsNullOrWhiteSpace(requireLotMinerioDto.TipoMinerio);
            bool IsNullStatusAndExistIndList = string.IsNullOrWhiteSpace(requireLotMinerioDto.Status) || !Enum.IsDefined(typeof(StatusLote), requireLotMinerioDto.Status.ToUpper());
            bool IsNullIdMineradora = string.IsNullOrWhiteSpace(requireLotMinerioDto.IdMineradora);

            bool IsNegativoTeor = requireLotMinerioDto.Teor <= 0;
            bool IsNegativoPesoQuantidade = requireLotMinerioDto.PesoQuantidade <=0;
            bool IsNegativoValorPKilon = requireLotMinerioDto.ValorPKilo <=0;

            bool IsNullString = IsNullUnidade || IsNullTipo || IsNullStatusAndExistIndList || IsNullIdMineradora;
            bool IsNullDouble = IsNegativoValorPKilon || IsNegativoPesoQuantidade || IsNegativoTeor;

            bool IsValidation = IsNullString || IsNullDouble;

            if (!IsValidation)
            {
                this.Teor = requireLotMinerioDto.Teor;
                this.PesoQuantidade = requireLotMinerioDto.PesoQuantidade;
                this.ValorPKilo = requireLotMinerioDto.ValorPKilo;
                this.UnidadeDeMedidaPeso = requireLotMinerioDto.UnidadeDeMedidaPeso;
                this.TipoMinerio = requireLotMinerioDto.TipoMinerio;
                this.Status = requireLotMinerioDto.Status;
                this.IdMineradora = requireLotMinerioDto.IdMineradora;
                this.DataExtracao = DateTime.UtcNow;
            }
            else
            {
                 throw new ArgumentException("os dados fornecidos são invalidos");
            }
        }
        
        // Para ficar visivel para o EF
        public void Atualizar(
            // PARAM 
            UpdateLotMinerio updateLotMinerio
        )
        {
            // Program
            bool IsNullUnidade = string.IsNullOrWhiteSpace(updateLotMinerio.UnidadeDeMedidaPeso);
            bool IsNullTipo = string.IsNullOrWhiteSpace(updateLotMinerio.TipoMinerio);
            bool IsNullStatusAndExistIndList = string.IsNullOrWhiteSpace(updateLotMinerio.Status) || !Enum.IsDefined(typeof(StatusLote), updateLotMinerio.Status.ToUpper());
            bool IsNullIdMineradora = string.IsNullOrWhiteSpace(updateLotMinerio.IdMineradora);

            bool IsNegativoTeor = updateLotMinerio.Teor <= 0;
            bool IsNegativoPesoQuantidade = updateLotMinerio.PesoQuantidade <=0;
            bool IsNegativoValorPKilon = updateLotMinerio.ValorPKilo <=0;

            bool IsNullString = IsNullUnidade || IsNullTipo || IsNullStatusAndExistIndList || IsNullIdMineradora;
            bool IsNullDouble = IsNegativoValorPKilon || IsNegativoPesoQuantidade || IsNegativoTeor;

            bool IsValidation = IsNullString || IsNullDouble;


            if (!IsValidation)
            {
                this.Teor = updateLotMinerio.Teor;
                this.PesoQuantidade = updateLotMinerio.PesoQuantidade;
                this.ValorPKilo = updateLotMinerio.ValorPKilo;
                this.UnidadeDeMedidaPeso = updateLotMinerio.UnidadeDeMedidaPeso.ToUpper();
                this.TipoMinerio = updateLotMinerio.TipoMinerio.ToUpper();
                this.Status = updateLotMinerio.Status.ToUpper();
                this.IdMineradora = updateLotMinerio.IdMineradora.ToUpper();
                this.DataExtracao = DateTime.UtcNow;

            }
            else
            {
                throw new ArgumentException("Dados invalidos");
            }
        }
        public void UpdateTrasaction(UpdateTransaction updateTransaction)
        {
        bool IsNull = string.IsNullOrWhiteSpace(updateTransaction.NewStatus) || !Enum.IsDefined(typeof(StatusLote), updateTransaction.NewStatus.ToUpper());
        bool IsNegative = updateTransaction.LotMinerio <= 0;
        bool Validation = IsNull || IsNegative;
        if (!Validation)
            {
                Status = updateTransaction.NewStatus;
                DataExtracao = DateTime.UtcNow;
            }
        else
        {
            throw new ArgumentException("dados invalidos");
        } 
        }

 protected LotMinerio() { }       
    }
    
}