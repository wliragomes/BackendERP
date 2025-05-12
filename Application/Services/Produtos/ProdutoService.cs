using Application.DTOs.Produtos.Filtro;
using Application.Interfaces.Produtos;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.Queries;
using Domain.Commands.Produtos.Adicionar;
using Application.DTOs.Produtos.Atualizar;
using Domain.Commands.Produtos.Atualizar;
using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Produto.Adicionar;
using Application.DTOs.Produtos.Grupos.Adicionar;
using Application.DTOs.Produtos.Grupos.Atualizar;
using Application.DTOs.Produtos.Grupos.Excluir;
using Domain.Commands.Produtos.Grupos.Adicionar;
using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Commands.Produtos.Grupos.Excluir;
using Application.DTOs.Produtos.CodigosImportacoes.Adicionar;
using Application.DTOs.Produtos.CodigosImportacoes.Atualizar;
using Application.DTOs.Produtos.CodigosImportacoes.Excluir;
using Domain.Commands.Produtos.CodigosImportacoes.Adicionar;
using Domain.Commands.Produtos.CodigosImportacoes.Atualizar;
using Domain.Commands.Produtos.CodigosImportacoes.Excluir;
using Application.DTOs.Produtos.Setores.Adicionar;
using Application.DTOs.Produtos.Setores.Atualizar;
using Application.DTOs.Produtos.Setores.Excluir;
using Domain.Commands.Produtos.Setores.Excluir;
using Domain.Commands.Produtos.Setores.Atualizar;
using Domain.Commands.Produtos.Setores.Adicionar;
using Application.DTOs.Produtos.Ruas.Adicionar;
using Application.DTOs.Produtos.Ruas.Atualizar;
using Application.DTOs.Produtos.Ruas.Excluir;
using Domain.Commands.Produtos.Ruas.Excluir;
using Domain.Commands.Produtos.Ruas.Atualizar;
using Domain.Commands.Produtos.Ruas.Adicionar;
using Application.DTOs.Produtos.Subgrupos.Excluir;
using Application.DTOs.Produtos.Subgrupos.Atualizar;
using Application.DTOs.Produtos.Subgrupos.Adicionar;
using Domain.Commands.Produtos.Subgrupos.Adicionar;
using Domain.Commands.Produtos.Subgrupos.Atualizar;
using Domain.Commands.Produtos.Subgrupos.Excluir;
using Application.DTOs.Produtos.Prateleiras.Adicionar;
using Application.DTOs.Produtos.Prateleiras.Atualizar;
using Application.DTOs.Produtos.Prateleiras.Excluir;
using Domain.Commands.Produtos.Prateleiras.Adicionar;
using Domain.Commands.Produtos.Prateleiras.Atualizar;
using Domain.Commands.Produtos.Prateleiras.Excluir;
using Application.DTOs.Produtos.Ncms.Filtro;
using Domain.Commands.Produtos.Ncms.Excluir;
using Application.DTOs.Produtos.Ncms.Excluir;
using Domain.Commands.Produtos.Ncms.Atualizar;
using Application.DTOs.Produtos.Ncms.Atualizar;
using Domain.Commands.Produtos.Ncms.Adicionar;
using Application.DTOs.Produtos.Ncms.Adicionar;
using Application.DTOs.Produtos.Familias.Adicionar;
using Application.DTOs.Produtos.Familias.Atualizar;
using Domain.Commands.Produtos.Familias.Adicionar;
using Domain.Commands.Produtos.Familias.Atualizar;
using Domain.Commands.Produtos.Familias.Excluir;
using Application.DTOs.Produtos.Familias.Excluir;
using Application.DTOs.Produtos.TiposProdutos.Adicionar;
using Application.DTOs.Produtos.TiposProdutos.Atualizar;
using Application.DTOs.Produtos.TiposProdutos.Excluir;
using Domain.Commands.Produtos.TiposProdutos.Adicionar;
using Domain.Commands.Produtos.TiposProdutos.Atualizar;
using Domain.Commands.Produtos.TiposProdutos.Excluir;
using Application.DTOs.Produtos.TiposPrecos.Adicionar;
using Application.DTOs.Produtos.TiposPrecos.Atualizar;
using Application.DTOs.Produtos.TiposPrecos.Excluir;
using Domain.Commands.Produtos.TiposPrecos.Adicionar;
using Domain.Commands.Produtos.TiposPrecos.Atualizar;
using Domain.Commands.Produtos.TiposPrecos.Excluir;
using Application.DTOs.Produtos.SetoresDeProdutos.Adicionar;
using Application.DTOs.Produtos.SetoresDeProdutos.Atualizar;
using Application.DTOs.Produtos.SetoresDeProdutos.Excluir;
using Domain.Commands.Produtos.SetoresProdutos.Adicionar;
using Domain.Commands.Produtos.SetoresProdutos.Atualizar;
using Domain.Commands.Produtos.SetoresProdutos.Excluir;
using Application.DTOs.Produtos.OrigemMateriais.Excluir;
using Application.DTOs.Produtos.OrigemMateriais.Atualizar;
using Application.DTOs.Produtos.OrigemMateriais.Adicionar;
using Domain.Commands.Produtos.OrigemMateriais.Adicionar;
using Domain.Commands.Produtos.OrigemMateriais.Excluir;
using Application.DTOs.Produtos.SetorProduto.Filtro;
using Domain.Commands.Produtos.Excluir;
using Application.DTOs.Produto.Excluir;
using Application.DTOs.Produtos.UnidadesMedidas.Filtro;
using Application.DTOs.Produtos.UnidadesMedidas.Excluir;
using Application.DTOs.Produtos.UnidadesMedidas.Atualizar;
using Application.DTOs.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.UnidadesMedidas.Atualizar;
using Domain.Commands.Produtos.UnidadesMedidas.Excluir;
using Application.DTOs.Produtos.ClasseReajustes.Filtro;
using Application.DTOs.Produtos.DesgastePolimentos.Filtro;
using Domain.Commands.Produtos.ClasseReajustes.Adicionar;
using Application.DTOs.Produtos.ClasseReajustes.Adicionar;
using Domain.Commands.Produtos.ClasseReajustes.Atualizar;
using Application.DTOs.Produtos.ClasseReajustes.Atualizar;
using Domain.Commands.Produtos.ClasseReajustes.Excluir;
using Application.DTOs.Produtos.ClasseReajustes.Excluir;
using Domain.Commands.Produtos.DesgastePolimentos.Adicionar;
using Application.DTOs.Produtos.DesgastePolimentos.Adicionar;
using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Application.DTOs.Produtos.DesgastePolimentos.Atualizar;
using Domain.Commands.Produtos.DesgastePolimentos.Excluir;
using Application.DTOs.Produtos.DesgastePolimentos.Excluir;
using Application.DTOs.Produtos;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;

namespace Application.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IProdutoQuery _produtoQuery;

        public ProdutoService(IMapper mapper, IMediatrHandler mediatorHandler, IProdutoQuery produtoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _produtoQuery = produtoQuery;
        }

        public async Task<FormularioResponse<AdicionarProdutoCommand>> Adicionar(AdicionarProdutoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarProdutoCommand>> Atualizar(AtualizarProdutoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarProdutoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirProdutoCommand>>> Excluir(ExcluirProdutoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirProdutoCommand, ExcluirProdutoCommand>(commands);
        }

        public async Task<PaginacaoResponse<ProdutoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarPaginacao(paginacaoRequest);
        }

        //public async Task<PaginacaoResponse<ProdutoOrdemFabricacaoFilterDto>> RetornarProdutoOrdemFabricacaoPaginacao(PaginacaoRequest paginacaoRequest)
        //{
        //    return await _produtoQuery.RetornarProdutoOrdemFabricacaoPaginacao(paginacaoRequest);
        //}

        public async Task<List<ProdutoOrdemFabricacaoFilterDto?>> RetornarProdutoPorVendaPaginacao(Guid idVenda)
        {
            return await _produtoQuery.RetornarProdutoPorVendaPaginacao(idVenda);
        }


        public async Task<ProdutoByIdDto?> RetornarPorId(Guid id)
        {
            return await _produtoQuery.RetornarPorId(id);
        }

        public async Task<FormularioResponse<AdicionarTipoProdutoCommand>> AdicionarTipoProduto(AdicionarTipoProdutoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarTipoProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoProdutoCommand>> AtualizarTipoProduto(AtualizarTipoProdutoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoProdutoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirTipoProdutoCommand>>> Excluir(ExcluirTipoProdutoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirTipoProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirTipoProdutoCommand, ExcluirTipoProdutoCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoProdutoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarTipoProdutoPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarTipoProdutoPorId(Guid id)
        {
            return await _produtoQuery.RetornarTipoProdutoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarGrupoCommand>> AdicionarGrupo(AdicionarGrupoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarGrupoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarGrupoCommand>> AtualizarGrupo(AtualizarGrupoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarGrupoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirGrupoCommand>>> Excluir(ExcluirGrupoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirGrupoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirGrupoCommand, ExcluirGrupoCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarGrupoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarGrupoPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarGrupoPorId(Guid id)
        {
            return await _produtoQuery.RetornarGrupoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarCodigoImportacaoCommand>> AdicionarCodigoImportacao(AdicionarCodigoImportacaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCodigoImportacaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCodigoImportacaoCommand>> AtualizarCodigoImportacao(AtualizarCodigoImportacaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCodigoImportacaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCodigoImportacaoCommand>>> Excluir(ExcluirCodigoImportacaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCodigoImportacaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCodigoImportacaoCommand, ExcluirCodigoImportacaoCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCodigoImportacaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarCodigoImportacaoPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarCodigoImportacaoPorId(Guid id)
        {
            return await _produtoQuery.RetornarCodigoImportacaoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarSubgrupoCommand>> AdicionarSubgrupo(AdicionarSubgrupoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarSubgrupoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarSubgrupoCommand>> AtualizarSubgrupo(AtualizarSubgrupoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarSubgrupoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirSubgrupoCommand>>> Excluir(ExcluirSubgrupoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirSubgrupoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirSubgrupoCommand, ExcluirSubgrupoCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSubgrupoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarSubgrupoPaginacao(paginacaoRequest);
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarSubgrupoPorId(Guid id)
        {
            return await _produtoQuery.RetornarSubgrupoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarFamiliaCommand>> AdicionarFamilia(AdicionarFamiliaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFamiliaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFamiliaCommand>> AtualizarFamilia(AtualizarFamiliaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFamiliaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFamiliaCommand>>> Excluir(ExcluirFamiliaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFamiliaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFamiliaCommand, ExcluirFamiliaCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarFamiliaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarFamiliaPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarFamiliaPorId(Guid id)
        {
            return await _produtoQuery.RetornarFamiliaPorId(id);
        }

        public async Task<FormularioResponse<AdicionarSetorCommand>> AdicionarSetor(AdicionarSetorRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarSetorCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarSetorCommand>> AtualizarSetor(AtualizarSetorRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarSetorCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirSetorCommand>>> Excluir(ExcluirSetorDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirSetorCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirSetorCommand, ExcluirSetorCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSetorPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarSetorPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarSetorPorId(Guid id)
        {
            return await _produtoQuery.RetornarSetorPorId(id);
        }

        public async Task<FormularioResponse<AdicionarPrateleiraCommand>> AdicionarPrateleira(AdicionarPrateleiraRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarPrateleiraCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarPrateleiraCommand>> AtualizarPrateleira(AtualizarPrateleiraRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPrateleiraCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirPrateleiraCommand>>> Excluir(ExcluirPrateleiraDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirPrateleiraCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirPrateleiraCommand, ExcluirPrateleiraCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPrateleiraPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarPrateleiraPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarPrateleiraPorId(Guid id)
        {
            return await _produtoQuery.RetornarPrateleiraPorId(id);
        }

        public async Task<FormularioResponse<AdicionarRuaCommand>> AdicionarRua(AdicionarRuaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarRuaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarRuaCommand>> AtualizarRua(AtualizarRuaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarRuaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirRuaCommand>>> Excluir(ExcluirRuaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirRuaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirRuaCommand, ExcluirRuaCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRuaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarRuaPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarRuaPorId(Guid id)
        {
            return await _produtoQuery.RetornarRuaPorId(id);
        }
               
        public async Task<FormularioResponse<AdicionarNcmCommand>> AdicionarNcm(AdicionarNcmRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarNcmCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarNcmCommand>> AtualizarNcm(AtualizarNcmRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarNcmCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirNcmCommand>>> Excluir(ExcluirNcmDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirNcmCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirNcmCommand, ExcluirNcmCommand>(commands);
        }

        public async Task<PaginacaoResponse<NcmByCodeDto>> RetornarNcmPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarNcmPaginacao(paginacaoRequest);
        }

        public async Task<List<NcmByProdutoDto?>> RetornarNcmPorProduto(Guid id)
        {
            return await _produtoQuery.RetornarNcmPorProduto(id);
        }

        public async Task<NcmByCodeDto?> RetornarNcmPorId(Guid id)
        {
            return await _produtoQuery.RetornarNcmPorId(id);
        }

        public async Task<FormularioResponse<AdicionarOrigemMaterialCommand>> AdicionarOrigemMaterial(AdicionarOrigemMaterialRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarOrigemMaterialCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarOrigemMaterialCommand>> AtualizarOrigemMaterial(AtualizarOrigemMaterialRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarOrigemMaterialCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirOrigemMaterialCommand>>> Excluir(ExcluirOrigemMaterialDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirOrigemMaterialCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirOrigemMaterialCommand, ExcluirOrigemMaterialCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarOrigemMaterialPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarOrigemMaterialPorId(Guid id)
        {
            return await _produtoQuery.RetornarOrigemMaterialPorId(id);
        }

        public async Task<FormularioResponse<AdicionarTipoPrecoCommand>> AdicionarTipoPreco(AdicionarTipoPrecoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarTipoPrecoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoPrecoCommand>> AtualizarTipoPreco(AtualizarTipoPrecoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoPrecoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirTipoPrecoCommand>>> Excluir(ExcluirTipoPrecoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirTipoPrecoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirTipoPrecoCommand, ExcluirTipoPrecoCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoPrecoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarTipoPrecoPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarTipoPrecoPorId(Guid id)
        {
            return await _produtoQuery.RetornarTipoPrecoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarSetorProdutoCommand>> AdicionarSetorProduto(AdicionarSetorProdutoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarSetorProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarSetorProdutoCommand>> AtualizarSetorProduto(AtualizarSetorProdutoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarSetorProdutoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirSetorProdutoCommand>>> Excluir(ExcluirSetorProdutoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirSetorProdutoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirSetorProdutoCommand, ExcluirSetorProdutoCommand>(commands);
        }

        public async Task<PaginacaoResponse<SetorProdutoByCodeDto>> RetornarSetorProdutoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarSetorProdutoPaginacao(paginacaoRequest);
        }

        public async Task<SetorProdutoByCodeDto?> RetornarSetorProdutoPorId(Guid id)
        {
            return await _produtoQuery.RetornarSetorProdutoPorId(id);
        }

        public async Task<List<SetorProdutoFilterDto?>> RetornarSetorProdutoPorCadastro(bool mostrarCadastro)
        {
            return await _produtoQuery.RetornarSetorProdutoPorCadastro(mostrarCadastro);
        }

        public async Task<FormularioResponse<AdicionarClasseReajusteCommand>> AdicionarClasseReajuste(AdicionarClasseReajusteRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarClasseReajusteCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }
        public async Task<FormularioResponse<AtualizarClasseReajusteCommand>> AtualizarClasseReajuste(AtualizarClasseReajusteRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarClasseReajusteCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }
        public async Task<List<FormularioResponse<ExcluirClasseReajusteCommand>>> ExcluirClasseReajuste(ExcluirClasseReajusteDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirClasseReajusteCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirClasseReajusteCommand, ExcluirClasseReajusteCommand>(commands);
        }
        public async Task<PaginacaoResponse<ClasseReajusteByCodeDto>> RetornarClasseReajustePaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarClasseReajustePaginacao(paginacaoRequest);
        }
        public async Task<ClasseReajusteByCodeDto?> RetornarClasseReajustePorId(Guid id)
        {
            return await _produtoQuery.RetornarClasseReajustePorId(id);
        }

        public async Task<FormularioResponse<AdicionarDesgastePolimentoCommand>> AdicionarDesgastePolimento(AdicionarDesgastePolimentoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarDesgastePolimentoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }
        public async Task<FormularioResponse<AtualizarDesgastePolimentoCommand>> AtualizarDesgastePolimento(AtualizarDesgastePolimentoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarDesgastePolimentoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }
        public async Task<List<FormularioResponse<ExcluirDesgastePolimentoCommand>>> ExcluirDesgastePolimento(ExcluirDesgastePolimentoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirDesgastePolimentoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirDesgastePolimentoCommand, ExcluirDesgastePolimentoCommand>(commands);
        }
        public async Task<PaginacaoResponse<DesgastePolimentoFilterDto>> RetornarDesgastePolimentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarDesgastePolimentoPaginacao(paginacaoRequest);
        }
        public async Task<DesgastePolimentoByCodeDto?> RetornarDesgastePolimentoPorId(Guid id)
        {
            return await _produtoQuery.RetornarDesgastePolimentoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarUnidadeMedidaCommand>> AdicionarUnidadeMedida(AdicionarUnidadeMedidaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarUnidadeMedidaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarUnidadeMedidaCommand>> AtualizarUnidadeMedida(AtualizarUnidadeMedidaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarUnidadeMedidaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirUnidadeMedidaCommand>>> Excluir(ExcluirUnidadeMedidaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirUnidadeMedidaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirUnidadeMedidaCommand, ExcluirUnidadeMedidaCommand>(commands);
        }        

        public async Task<PaginacaoResponse<UnidadeMedidaByCodeDto>> RetornarUnidadeMedidaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _produtoQuery.RetornarUnidadeMedidaPaginacao(paginacaoRequest);
        }

        public async Task<UnidadeMedidaByCodeDto?> RetornarUnidadeMedidaPorId(Guid id)
        {
            return await _produtoQuery.RetornarUnidadeMedidaPorId(id);
        }
    }
}





