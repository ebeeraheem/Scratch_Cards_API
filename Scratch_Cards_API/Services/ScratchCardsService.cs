using Microsoft.EntityFrameworkCore;
using Scratch_Cards_API.Data;
using Scratch_Cards_API.Models;

namespace Scratch_Cards_API.Services;

public class ScratchCardsService : IScratchCardsService
{
    private readonly ApplicationDbContext _context;

    public ScratchCardsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScratchCard> GenerateScratchCard()
    {
        var card = new ScratchCard()
        {
            CardNumber = Guid.NewGuid().ToString(),
            IsPurchased = false,
            IsUsed = false
        };

        await _context.ScratchCards.AddAsync(card);
        await _context.SaveChangesAsync();

        return card;
    }

    public async Task<List<ScratchCard>> GetAllCards()
    {
        return await _context.ScratchCards.ToListAsync();
    }

    public async Task<ScratchCard?> GetCardById(int id)
    {
        var card = await _context.ScratchCards.FindAsync(id);

        return card;
    }

    public async Task<ScratchCard?> PurchaseCard(int id)
    {
        var card = await _context.ScratchCards.FindAsync(id);

        if (card is null)
        {
            return null;
        }

        card.IsPurchased = true;

        await _context.SaveChangesAsync();

        return card;
    }

    public async Task<ScratchCard?> UseCard(int id)
    {
        var card = await _context.ScratchCards.FindAsync(id);

        if (card is null)
        {
            return null;
        }

        card.IsUsed = true;

        await _context.SaveChangesAsync();

        return card;
    }
}
