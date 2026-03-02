# Sistema de gerenciamento de lote de minerio (back-end)
Esta API tem como objetivo realizar o gerenciamento completo dos lotes de minério no contexto de uma mineradora, permitindo o controle integrado das informações operacionais, financeiras e logísticas associadas a cada lote, possibilitando o cadastro, a consulta, a atualização e a exclusão (CRUD), bem como o acompanhamento do fluxo de status que representa as etapas do processo produtivo, desde o planejamento até a entrega e o encerramento do lote.
</br>

# Entidades do negiocio
As entidades do sistema foram definidas considerando o cenário de uma mineradora, com o objetivo de possibilitar o gerenciamento e o controle das movimentações de entrada e saída de mercadorias, representadas por lotes de minério. Abaixo estão listadas as propriedades de um lote.
## Lote de minerio
### Propriedades

- **IdLote** – Identificador único do lote.  
- **IdMineradora** – Identificador da mineradora responsável.  
- **Teor** – Grau de pureza do minério.  
- **PesoQuantidade** – Quantidade total em peso do lote.  
- **ValorPKilo** – Valor monetário por quilo do minério.  
- **UnidadeDeMedidaPeso** – Unidade de medida utilizada (kg, t, etc).  
- **TipoMinerio** – Tipo de minério (ferro, ouro, cobre, etc).  
- **Status** – Status atual do lote no processo operacional.  
- **DataExtracao** – Data em que o minério foi extraído.

## Fluxo de operação do status do lote
### Status do Lote
| Ordem  | Status        | Descrição                                                |
|--------| ------------- | -------------------------------------------------------- |
|    1º   | PLANEJADO     | Lote registrado no sistema, ainda não iniciado.          |
|       2º | EXTRACAO      | Minério está sendo extraído da mina.                     |
|        3º| EXTRAIDO      | Minério já foi retirado, aguardando processamento.       |
|      4º  | PROCESSAMENTO | Está passando por beneficiamento.                        |
|       5º | PROCESSADO    | Já foi beneficiado tecnicamente.                         |
|       6º| ESTOQUE       | Armazenado no pátio ou silo.                             |
|       7º | RESERVADO     | Vinculado a uma venda ou cliente.                        |
|       8º | CARREGAMENTO  | Em processo de embarque.                                 |
|       9º | TRANSPORTE    | Em deslocamento até o destino.                           |
|       10º | ENTREGUE      | Recebido pelo cliente.                                   |
|        11º| FATURADO      | Nota fiscal emitida.                                     |
|        12º| ENCERRADO     | Processo totalmente finalizado.                          |
|    ***    | BLOQUEADO     | Impedido por problemas técnicos, legais ou de qualidade. |
|    ***    | CANCELADO     | Lote ou operação cancelada.                              |

</br>

# Controlles / Endpoints  
## Route transaction
Endpoint responsável por examinar o processo logístico de um lote de minério, aplicando as regras de negócio estabelecidas na tabela de status do lote.
```bash
http://[name-host]/transactions
```
## Controlles transaction
- ### GET
    ```bash
    http://[name-host]/lot-minerio/transactions
    ```
    <hr>
- ### GET BY ID
    ```bash
    http://[name-host]/lot-minerio/transactions/{id}
    ```
    <hr>
- ### PUT BY ID
    #### URL
    ```bash
    http://localhost:5167/lot-minerio/transactions
    ```
    #### Json require
    ```json
    {
        
        "NewStatus": "CANCELADO", // status lote
        "LotMinerio": 3 // id lote
    }
    ```
    <hr>
    <br>
## Router lot-minerio
Esta rota permite manipular e visualizar os dados dos lotes armazenados no banco de dados, com acesso individual aos registros por meio das operações CRUD. 
```bash
http://[host-name]/lot-minerio/
```
## Controller lote minerio
- ### GET
    ```bash
    http://[host-minerio]/lot-minerio/
    ```
    <hr>
- ### GET BY ID
    ```bash
    http://localhost:5167/lot-minerio/{id}
    ```
    <hr>
- ### POST LOTE 
    #### URL
    ```bash
    http://localhost:5167/lot-minerio/
    ```
    #### Json require
    ```json
    {
        "Teor": 20,
        "PesoQuantidade": 220.75,
        "ValorPKilo": 35,
        "UnidadeDeMedidaPeso": "TON",
        "TipoMinerio": "NIQUEL",
        "Status": "EXTRACAO",
        "IdMineradora": "M077"
    }
    ```
    <hr>

- ### PUT LOTE BY ID 
    #### URL
    ```bash
    http://localhost:5167/lot-minerio/{id}
    ```
    #### Json require
    ```Json
    {
        "Teor": 10, 
        "PesoQuantidade": 2200.75,
        "ValorPKilo": 35.9,
        "UnidadeDeMedidaPeso": "kg",
        "TipoMinerio": "Ferro",
        "Status": "EXTRACAO",
        "IdMineradora": "M077"
    }
    ```
    <hr>

- ### DELETE BY ID
    ```bash
    http://localhost:5167/lot-minerio/{id}
    ```
     <hr>

## Route Classification
Rota responsável por classificar um lote de minério com base no <b>teor</b> informado, retornando uma das seguintes categorias: <b>PREMIUM, PADRÃO ou BAIXA</b>.
## Controller classification
- ### GET 
    ```bash
    http://localhost:5167/lot-minerio/classification/
    ```
    <hr>
- ### GET BY ID
    ```bash
    http://localhost:5167/lot-minerio/classification/{id}
    ```
    <hr>
## Considerções finais

### Codigo de criação de entiade em sql
```sql
CREATE TABLE public.lot_minerio (
    id_lote SERIAL4 PRIMARY KEY,
    unidade_medida VARCHAR(8) NOT NULL,
    tipo_minerio VARCHAR(10) NOT NULL,
    status VARCHAR(10) NOT NULL,
    data_extracao TIMESTAMP,
    valor_p_kilo NUMERIC(10,2) NOT NULL,
    peso_quantidade NUMERIC(12,2)NOT NULL,
    teor NUMERIC(5,2) NOT NULL,
    id_mineradora VARCHAR(4)
);
```
### GET START
#### Glone repository
```bash
git clone https://github.com/Lukas-Souza/DELOITTE_BOOTCAMP.git
```
#### Entrar no diretorio
```bash
cd cd "./DELOITTE_BOOTCAMP/dia-06 (Project Api)/CaseProject/"
```
#### Runner project
```bash
dotnet run  
```
<center><i>Create project by <b>&copy; Luccas Henrique</b></i></center>



