using ConsultorioLegal.api.Application.Services.Interfaces.Clientes;
using ConsultorioLegal.api.UI.ModelViews.Cliente;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;
using src.api.Domain.Entities;

namespace src.api.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClientesController> logger;

        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            this.clienteManager = clienteManager;
            this.logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados na base.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
        }

        /// <summary>
        /// Retorna um cliente consultado pelo id.
        /// </summary>
        /// <param name="id" exemplo="123">Id do cliente.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteByIdAsync(id));
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NovoCliente novoCliente)
        {
            logger.LogInformation("Objeto recebido {@novoCliente}", novoCliente);
            Cliente clienteInserido;
            using (Operation.Time("Tempo de adição de um novo cliente."))
            {
                logger.LogInformation("Foi requisitada a inserção de um novo cliente.");
                clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            }
            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
        }

        /// <summary>
        /// Altera um cliente.
        /// </summary>
        /// <param name="alteraCliente"></param>
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] AlteraCliente alteraCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alteraCliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id" exemple="123"></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
