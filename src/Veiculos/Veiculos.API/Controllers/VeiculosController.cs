﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Veiculos.API.Data.Entities;
using Veiculos.API.Extensions;
using Veiculos.API.Models.Request;
using Veiculos.API.Models.Response;

namespace Veiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {

        private readonly DbVeiculos _dbContext;

        public VeiculosController(DbVeiculos ctx)
        {
            _dbContext = ctx;
        }


        [HttpGet("{id:guid}")]
        public IActionResult ObterPeloId([FromRoute] Guid id)
        {

            var veiculo = _dbContext.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();

            if (veiculo is null)
                return NotFound("Registro não encontrado");

            var result = veiculo.Map();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string? fabricante)
        {


            IEnumerable<VeiculoResponse> result;

            if (string.IsNullOrWhiteSpace(fabricante))
            {
                result = _dbContext.Veiculos.ToList().Select(veiculo => veiculo.Map());
            }
            else
            {
                /// para buscar outros tipos de campos
                result = _dbContext.Veiculos.Where(veiculo =>
                    veiculo.Fabricante.Nome == fabricante)
                    .ToList()
                        .Select(s => s.Map());
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CriarVeiculo([FromBody] VeiculoRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.CapturaCriticas());
            //TODO:validar entrada chave estranjeira 

            var fabricante = _dbContext.Fabricantes.Where(fabricante => fabricante.Id == request.FabricanteId).FirstOrDefault();

            if (fabricante is null)
                return NotFound("Fabricante não encontrado");

            // Mapear request para Entidade de Bancos
            var veiculo = request.Map();
            _dbContext.Veiculos.Add(veiculo);
            _dbContext.SaveChanges();

            return Created(uri: string.Empty, new { id = veiculo.Id.ToString() });

        }

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute] Guid id, [FromBody] VeiculoRequest request)
        {
            ///jeito avancado de buscar ID
            var veiculo = _dbContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo is null)
                return NotFound("registro não encontrado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.CapturaCriticas());


            veiculo.AnoModelo = request.AnoModelo.Value;
            veiculo.AnoFabricacao = request.AnoFabricacao.Value;
            veiculo.Modelo = request.Modelo;
            veiculo.FabricanteId = request.FabricanteId.Value;
            veiculo.Cor = request.Cor;
            veiculo.Placa = request.Placa;
            veiculo.Tipo = request.Tipo;

            _dbContext.SaveChanges();

            return NoContent();


        }

        [HttpPatch("{id:guid}")]
        public IActionResult EditarParcial([FromRoute] Guid id, [FromBody] VeiculoPatchRequest request)
        {

            if (request is null)
                return BadRequest("Corpo da requisição inválida ou não informada");

            ///jeito avancado de buscar ID
            var veiculo = _dbContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo is null)
                return NotFound("registro não encontrado");

            // Tem valor e é diferente do que está gravado
            if (request.AnoModelo.HasValue && request.AnoModelo != veiculo.AnoModelo)
                veiculo.AnoModelo = request.AnoModelo.Value;

            if (request.AnoFabricacao.HasValue && request.AnoFabricacao != veiculo.AnoFabricacao)
            {
                veiculo.AnoFabricacao = request.AnoFabricacao.Value;
            }

            if (request.Modelo is not null && request.Modelo != veiculo.Modelo)
                veiculo.Modelo = request.Modelo;

            if (request.FabricanteId is not null && request.FabricanteId != veiculo.FabricanteId)
                veiculo.FabricanteId = request.FabricanteId.Value;

            if (request.Cor is not null && request.Cor != veiculo.Cor)
                veiculo.Cor = request.Cor;

            if (request.Placa is not null && request.Placa != veiculo.Placa)
                veiculo.Placa = request.Placa;

            if (request.Tipo is not null && request.Tipo != veiculo.Tipo)
                veiculo.Tipo = request.Tipo;

            _dbContext.SaveChanges();

            return NoContent();


        }

        [HttpDelete("{id:guid}")]
        public IActionResult Excluir([FromRoute] Guid id)
        {
            ///jeito basico de buscar ID
            var veiculo = _dbContext.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();
            if (veiculo is null)
                return NotFound("registro não encotrado");

            _dbContext.Veiculos.Remove(veiculo);
            _dbContext.SaveChanges();

            return NoContent();
        }










    }
}
