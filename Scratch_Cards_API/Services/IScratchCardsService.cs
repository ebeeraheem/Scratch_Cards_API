using Scratch_Cards_API.Models;

namespace Scratch_Cards_API.Services;
public interface IScratchCardsService
{
    Task<ScratchCard> GenerateScratchCard();
    Task<List<ScratchCard>> GetAllCards();
    Task<ScratchCard?> GetCardById(int id);
    Task<ScratchCard?> PurchaseCard(int id);
    Task<ScratchCard?> UseCard(int id);
}