using Application.DTOs.Pessoas.Filtro;
using Application.Interfaces.Pessoas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.Queries;
using Application.DTOs.Pessoas.Adicionar;
using Domain.Commands.Pessoas.Adicionar;
using Application.DTOs.Pessoas.Atualizar;
using Domain.Commands.Pessoas.Atualizar;
using Domain.Commands.Pessoas.Excluir;
using Application.DTOs.Pessoas.Excluir;
using Domain.Commands.Origens.Adicionar;
using Application.DTOs.Pessoas.Origens.Adicionar;
using Domain.Commands.Origens.Atualizar;
using Application.DTOs.Pessoas.Origens.Atualizar;
using Domain.Commands.Origens.Excluir;
using Application.DTOs.Pessoas.Origens.Excluir;
using Domain.Commands.Regioes.Adicionar;
using Application.DTOs.Pessoas.Regioes.Adicionar;
using Domain.Commands.Regioes.Atualizar;
using Application.DTOs.Pessoas.Regioes.Atualizar;
using Domain.Commands.Regioes.Excluir;
using Application.DTOs.Pessoas.Regioes.Excluir;
using Domain.Commands.SegmentoClientes.Adicionar;
using Application.DTOs.Pessoas.SegmentoClientes.Adicionar;
using Domain.Commands.SegmentoClientes.Atualizar;
using Application.DTOs.Pessoas.SegmentoClientes.Atualizar;
using Domain.Commands.SegmentoClientes.Excluir;
using Application.DTOs.Pessoas.SegmentoClientes.Excluir;
using Domain.Commands.SegmentoEstrategicos.Adicionar;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Adicionar;
using Domain.Commands.SegmentoEstrategicos.Atualizar;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Atualizar;
using Domain.Commands.SegmentoEstrategicos.Excluir;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Excluir;
using Domain.Commands.Departamentos.Adicionar;
using Application.DTOs.Pessoas.Departamentos.Adicionar;
using Domain.Commands.Departamentos.Atualizar;
using Application.DTOs.Pessoas.Departamentos.Atualizar;
using Domain.Commands.Departamentos.Excluir;
using Application.DTOs.Pessoas.Departamentos.Excluir;
using Domain.Commands.Cargos.Adicionar;
using Application.DTOs.Pessoas.Cargos.Adicionar;
using Domain.Commands.Cargos.Atualizar;
using Application.DTOs.Pessoas.Cargos.Atualizar;
using Domain.Commands.Cargos.Excluir;
using Application.DTOs.Pessoas.Cargos.Excluir;
using Application.DTOs.Pessoas.ValidarCpfsCnpjs;
using Domain.Commands.ValidarCpfCnpjs.Adicionar;
using Application.DTOs.Pessoas.TipoConsumidores.Atualizar;
using Application.DTOs.Pessoas.TipoConsumidores.Filtro;
using Domain.Commands.Pessoas.TipoConsumidores.Atualizar;

namespace Application.Services.Pessoas
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IPessoaQuery _pessoaQuery;

        public PessoaService(IMapper mapper, IMediatrHandler mediatorHandler, IPessoaQuery PessoaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _pessoaQuery = PessoaQuery;
        }

        public async Task<FormularioResponse<AdicionarPessoaCommand>> Adicionar(AdicionarPessoaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarPessoaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarPessoaCommand>> Atualizar(AtualizarPessoaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPessoaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<PaginacaoResponse<PessoaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<PessoaByIdDto?> RetornarPorId(Guid id)
        {
            return await _pessoaQuery.RetornarPorId(id);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarOrigemPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRegiaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarRegiaoPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoClientePaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarSegmentoClientePaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoEstrategicoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarSegmentoEstrategicoPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarDepartamentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarDepartamentoPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCargoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarCargoPaginacao(paginacaoRequest);
        }

        public async Task<List<FormularioResponse<ExcluirPessoaCommand>>> Excluir(ExcluirPessoaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirPessoaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirPessoaCommand, ExcluirPessoaCommand>(commands);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarOrigemPorId(Guid id)
        {
            return await _pessoaQuery.RetornarOrigemPorId(id);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarRegiaoPorId(Guid id)
        {
            return await _pessoaQuery.RetornarRegiaoPorId(id);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoClientePorId(Guid id)
        {
            return await _pessoaQuery.RetornarSegmentoClientePorId(id);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoEstrategicoPorId(Guid id)
        {
            return await _pessoaQuery.RetornarSegmentoEstrategicoPorId(id);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarDepartamentoPorId(Guid id)
        {
            return await _pessoaQuery.RetornarDepartamentoPorId(id);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarCargoPorId(Guid id)
        {
            return await _pessoaQuery.RetornarCargoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarOrigemCommand>> AdicionarOrigem(AdicionarOrigemRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarOrigemCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarOrigemCommand>> AtualizarOrigem(AtualizarOrigemRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarOrigemCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirOrigemCommand>>> ExcluirOrigem(ExcluirOrigemDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirOrigemCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirOrigemCommand, ExcluirOrigemCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarRegiaoCommand>> AdicionarRegiao(AdicionarRegiaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarRegiaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarRegiaoCommand>> AtualizarRegiao(AtualizarRegiaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarRegiaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirRegiaoCommand>>> ExcluirRegiao(ExcluirRegiaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirRegiaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirRegiaoCommand, ExcluirRegiaoCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarSegmentoClienteCommand>> AdicionarSegmentoCliente(AdicionarSegmentoClienteRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarSegmentoClienteCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarSegmentoClienteCommand>> AtualizarSegmentoCliente(AtualizarSegmentoClienteRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarSegmentoClienteCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirSegmentoClienteCommand>>> ExcluirSegmentoCliente(ExcluirSegmentoClienteDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirSegmentoClienteCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirSegmentoClienteCommand, ExcluirSegmentoClienteCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarSegmentoEstrategicoCommand>> AdicionarSegmentoEstrategico(AdicionarSegmentoEstrategicoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarSegmentoEstrategicoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarSegmentoEstrategicoCommand>> AtualizarSegmentoEstrategico(AtualizarSegmentoEstrategicoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarSegmentoEstrategicoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirSegmentoEstrategicoCommand>>> ExcluirSegmentoEstrategico(ExcluirSegmentoEstrategicoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirSegmentoEstrategicoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirSegmentoEstrategicoCommand, ExcluirSegmentoEstrategicoCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarDepartamentoCommand>> AdicionarDepartamento(AdicionarDepartamentoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarDepartamentoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarDepartamentoCommand>> AtualizarDepartamento(AtualizarDepartamentoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarDepartamentoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirDepartamentoCommand>>> ExcluirDepartamento(ExcluirDepartamentoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirDepartamentoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirDepartamentoCommand, ExcluirDepartamentoCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarCargoCommand>> AdicionarCargo(AdicionarCargoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCargoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCargoCommand>> AtualizarCargo(AtualizarCargoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCargoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCargoCommand>>> ExcluirCargo(ExcluirCargoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCargoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCargoCommand, ExcluirCargoCommand>(commands);
        }

        public async Task<FormularioResponse<AdicionarValidarCpfCnpjCommand>> ValidarCpfCnpj(AdicionarValidarCpfCnpjRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarValidarCpfCnpjCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoConsumidorCommand>> AtualizarTipoConsumidor(AtualizarTipoConsumidorRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoConsumidorCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<PaginacaoResponse<TipoConsumidorFilterDto>> RetornarTipoConsumidorPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _pessoaQuery.RetornarTipoConsumidorPaginacao(paginacaoRequest);
        }

        public async Task<TipoConsumidorByCodeDto?> RetornarTipoConsumidorPorId(Guid id)
        {
            return await _pessoaQuery.RetornarTipoConsumidorPorId(id);
        }
    }
}
