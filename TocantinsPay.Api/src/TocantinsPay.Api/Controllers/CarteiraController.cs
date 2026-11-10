using Microsoft.AspNetCore.Mvc;
using TocantinsPay.Core.Interfaces.Notifications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Api.Controllers
{
    public class CarteiraController(
        ICarteiraRepository carteiraRepository,
        INotifier notifier
    ) : MainController(notifier)
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorIdAsync([FromRoute] Guid id)
        {
            var carteira = await carteiraRepository.BuscarPorIdAsync(id);

            if (carteira is null)
            {
                return NotFound();
            }

            return Ok(new CarteiraViewModel(
                carteira.Id,
                carteira.ClienteId,
                carteira.Saldo,
                carteira.Conta,
                carteira.Agencia
            ));
        }
    }
}
