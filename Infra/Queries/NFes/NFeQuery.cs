using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.NFes;
using Application.Interfaces.Queries;

namespace Infra.Queries.NFes
{
    public class NFeQuery : INFeQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public NFeQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ChaveNfeBuscaDto?> RetornarChave(Guid idFatura)
        {
            string query = @"SELECT 
                                '35' as cUF,
                                '' as CNPJ, -- Banco
                                '55' as Modelo,
                                '1' as serie, 
                                '' as numero, -- Banco
                                '1' as tpEmis,
                                '122' as codigoSeguranca
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<ChaveNfeBuscaDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<identidicacaoNFeDto?> RetornarIdentificacao(Guid idFatura)
        {
            string query = @"SELECT 
                                0 as cUF, -- Banco
                                '' as natOp, -- Banco	                                    
                                55 as mod,
                                1 as serie,
                                getdate() as dhEmi,
                                '' as dhSaiEnt,
                                1 as tpNF,        
                                5 as idDest, -- Banco | 5, 6 ou 7		
                                '' as cMunFG, -- Banco
                                '' as NFRef, -- Banco
                                1 as tpImp,
                                1 as tpEmis,
                                1 as finNFe, -- Banco | 1, se for retorno = 4,
                                0 as indFinal, -- Banco
                                9 as indPres,
                                0 as procEmi,
                                'NFe_Util_2G' as verProc,
                                '' as dhCont,
                                '' as xJust,
                                0 as indIntermed
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<identidicacaoNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<emitenteNFeDto?> RetornarEmitente(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as CNPJ, -- Banco
                                '' as CPF, 
                                '' as xNome, -- Banco
                                '' as xFant, -- Banco 
                                '' as xLgr, -- Banco 
                                '' as nro, -- Banco 
                                '' as xCpl, -- Banco 
                                '' as xBairro, -- Banco 
                                '' as cMun, -- Banco 
                                '' as xMun, -- Banco 
                                '' as d.UF, -- Banco 
                                '' as CEP, -- Banco
                                '1058' as cPais, 
                                'Brasil' as xPais, 
                                '' as fone, -- Banco 
                                '' as IE, -- Banco
                                '' as IEST, 
                                '' as d.IM, -- Banco
                                '' as d.CNAE, -- Banco
                                '3' as CRT
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<emitenteNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<destinatarioNFeDto?> RetornarDestinatario(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as CNPJ, -- Banco
                                '' as CPF, -- Banco
                                '' as idEstrangeiro,
                                '' as xNome, -- Banco
                                '' as xLgr, -- Banco
                                '' as nro, -- Banco
                                '' as xCpl, -- Banco
                                '' as xBairro, -- Banco
                                '' as cMun, -- Banco
                                '' as xMun, -- Banco
                                '' as UF, -- Banco
                                '' as CEP, -- Banco
                                '' as cPais,
                                'Brasil' as xPais,
                                '' as fone, -- Banco
                                '' as indIEDest, -- Banco
                                '' as IE, -- Banco
                                '' as ISUF, -- Banco
                                '' as IM, 
                                '' as eMail
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<destinatarioNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<entregaNFeDto?> RetornarEntrega(Guid idFatura)
        {
            string query = @"SELECT 
                                 '' as CNPJ, -- Banco
                                 '' as CPF, -- Banco
                                 '' as xLgr, -- Banco
                                 '' as nro, -- Banco
                                 '' as xCpl, -- Banco
                                 '' as xBairro, -- Banco
                                 '' as cMun, -- Banco
                                 '' as xMun, -- Banco
                                 '' as UF -- Banco                            
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<entregaNFeDto?>(query, new { IdFatura = idFatura });
            }
        }        

        public async Task<icmsTotalNFeDto?> RetornarIcmsTotal(Guid idFatura)
        {
            string query = @"NFeTotalizacao = @IdFatura";

            //f.vBC = FormatFieldDbl(dt.Rows[0]["vICMS"]) == 0 ? 0 : FormatFieldDbl(dt.Rows[0]["vBC"]);
            //f.vICMS = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(dt.Rows[0]["vICMS"]));
            //f.vBCST = FormatFieldDbl(dt.Rows[0]["vBCST"]);
            //f.vST = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(dt.Rows[0]["vST"]));
            //f.vProd = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(dt.Rows[0]["vProd"]));
            //f.vFrete = FormatFieldDbl(dt.Rows[0]["vFrete"]);
            //f.vSeg = FormatFieldDbl(dt.Rows[0]["vSeg"]);
            //f.vDesc = FormatFieldDbl(dt.Rows[0]["vDesc"]);
            //f.vII = 0;
            //f.vIPI = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(dt.Rows[0]["vIPI"]));

            //f.vPIS = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(vPIS(FormatFieldInt(dt.Rows[0]["cod_empresa"]), FormatFieldDbl(dt.Rows[0]["vPIS"]), FormatFieldDbl(dt.Rows[0]["vICMS"]), FormatFieldDbl(dt.Rows[0]["vProd"]))));
            //f.vCOFINS = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(vCOFINS(FormatFieldInt(dt.Rows[0]["cod_empresa"]), FormatFieldDbl(dt.Rows[0]["vCOFINS"]), FormatFieldDbl(dt.Rows[0]["vICMS"]), FormatFieldDbl(dt.Rows[0]["vProd"]))));

            //f.vOutro = FormatFieldDbl(dt.Rows[0]["vOutros"]);
            //f.vNF = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), FormatFieldDbl(dt.Rows[0]["vNF"]));
            //f.vTotTrib = FormatFieldDbl(dt.Rows[0]["vTotTrib"]);
            //f.vICMSDeson = 0;
            //f.vICMSUFDest_Opc = 0; //Precisa adicionar esse campo
            //f.vICMSUFDest_Opc = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), GetICMSUFDest(cod_fatura) == true ? FormatFieldDbl(dt.Rows[0]["vICMSUFDest"]) : 0);
            //f.vICMSUFRemet_Opc = VerificaValorZero(FormatFieldInt(dt.Rows[0]["zerar_valores"]), GetICMSUFDest(cod_fatura) == true ? FormatFieldDbl(dt.Rows[0]["vICMSUFRemet"]) : 0);
            //f.vFCPUFDest_Opc = FormatFieldDbl(dt.Rows[0]["vFCPUFDest"]);
            ////Novos campos versão 4.0
            //f.vFCP = FormatFieldDbl(dt.Rows[0]["VFCP"]);
            //f.vFCPST = 0;
            //f.vFCPSTRet = 0;
            //f.vIPIDevol = 0;

            //using (var connection = _dbContext.Database.GetDbConnection())
            //{
            //    return await connection.RetornarDapper<icmsTotalNFeDto?>(query, new { IdFatura = idFatura });
            //}

            return default;
        }

        public async Task<transporteNFeDto?> RetornarTransporte(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as modFrete, -- Banco 
                                '' as CFOP -- Banco                           
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<transporteNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<transportadorNFeDto?> RetornarTransportador(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as CNPJ, -- Banco
                                '' as CPF, -- Banco
                                '' as xNome, -- Banco
                                '' as IE, -- Banco												
                                '' as xEnder, -- Banco
                                '' as xMun, -- Banco
                                '' as UF, -- Banco                      
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<transportadorNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<volumeNFeDto?> RetornarVolume(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as qVol, -- Banco
                                '' as esp, -- Banco
                                '' as marca, -- Banco
                                '' as nVol, -- Banco
                                '' as pesoL, -- Banco
                                '' as pesoB, -- Banco
                                lacres = ''                     
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<volumeNFeDto?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<veiculoTransporteNFeDto?> RetornarVeiculoTransporte(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as placa, -- Banco
                                '' as UF, -- Banco
                                RNTC = ''    
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<veiculoTransporteNFeDto?>(query, new { IdFatura = idFatura });
            }
        }        

        public async Task<List<duplicataNFeDto>?> RetornarDuplicata(Guid idFatura)
        {
            string query = @"NFeParcelas = @IdFatura";

            //using (var connection = _dbContext.Database.GetDbConnection())
            //{
            //    return await connection.RetornarDapper<cobrancaNFeDto?>(query, new { IdFatura = idFatura });
            //}

            //nDup = FormatFieldStr(row["nDup"]),
            //dVenc = FormataData(row["dVenc"]),
            //vDup = FormatFieldDbl(row["vDup"])

            return default;
        }

        public async Task<cobrancaNFeDto?> RetornarCobranca(Guid idFatura)
        {
            string query = @"NFeFatura = @IdFatura";

            //using (var connection = _dbContext.Database.GetDbConnection())
            //{
            //    return await connection.RetornarDapper<cobrancaNFeDto?>(query, new { IdFatura = idFatura });
            //}

            //nFat = FormatFieldStr(dt.Rows[0]["nFat"]),
            //vOrig = FormatFieldDbl(dt.Rows[0]["vOrig"]),
            //vDesc = FormatFieldDbl(dt.Rows[0]["vDesc"]),
            //vLiq = FormatFieldDbl(dt.Rows[0]["vLiq"]),
            ////dup = FormatFieldStr(dt.Rows[0]["dup"])
            //dup = ""

            return default;
        }

        public async Task<string?> RetornarDetalhesPagamento(Guid idFatura)
        {
            string query = @"SELECT 
                                '' as tPag -- Banco
                            FROM TB_FATURA AS F
								INNER JOIN TB_EMPRESA AS E ON F.CD_EMPRESA = E.CD_EMPRESA
                            WHERE 
                                    E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND F.CD_FATURA = @IdFatura";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<string?>(query, new { IdFatura = idFatura });
            }
        }

        public async Task<informacoesAdicionaisDtoNFeDto?> RetornarInformacoesAdicionais(Guid idFatura)
        {
            string query = @"NFeTotalizacao = @IdFatura";

            //using (var connection = _dbContext.Database.GetDbConnection())
            //{
            //    return await connection.RetornarDapper<informacoesAdicionaisDtoNFeDto?>(query, new { IdFatura = idFatura });
            //}

            //infAdFisco = FormatFieldStr(dt.Rows[0]["infAdFisco"]), 
            //infCpl = FormatFieldStr(dt.Rows[0]["infCpl"]),
            //obsCont = "", //FormatFieldStr(dt.Rows[0]["obsCont"]),
            //obsFisco = "", //FormatFieldStr(dt.Rows[0]["obsFisco"]),
            //procRef = "" //FormatFieldStr(dt.Rows[0]["procRef"])

            return default;
        }
    }
}
