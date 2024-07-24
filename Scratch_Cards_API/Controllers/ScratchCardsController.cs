using Microsoft.AspNetCore.Mvc;
using Scratch_Cards_API.Services;

namespace Scratch_Cards_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ScratchCardsController : ControllerBase
{
    private readonly IScratchCardsService _cardsService;

    public ScratchCardsController(IScratchCardsService cardsService)
    {
        _cardsService = cardsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await _cardsService.GetAllCards();

        return Ok(cards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCardById(int id)
    {
        var card = await _cardsService.GetCardById(id);

        if (card is null)
        {
            return NotFound("Card not found.");
        }

        return Ok(card);
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateCard()
    {
        try
        {
            var card = await _cardsService.GenerateScratchCard();

            return CreatedAtAction(nameof(GetCardById), new { id = card.Id }, card);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Card creation failed.");
        }
    }

    [HttpPost("purchase/{id}")]
    public async Task<IActionResult> PurchaseCard(int id)
    {
        var card = await _cardsService.PurchaseCard(id);

        if (card is null)
        {
            return BadRequest("Card is not available for purchase");
        }

        return NoContent();
    }

    [HttpPost("use/{id}")]
    public async Task<IActionResult> UseCard(int id)
    {
        var card = await _cardsService.UseCard(id);

        if (card is null)
        {
            return BadRequest("Card cannot be used.");
        }

        return NoContent();
    }
}
