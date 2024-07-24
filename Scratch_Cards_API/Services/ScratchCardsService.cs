using Scratch_Cards_API.Data;

namespace Scratch_Cards_API.Services;

public class ScratchCardsService
{
    private readonly ApplicationDbContext _context;

    public ScratchCardsService(ApplicationDbContext context)
    {
        _context = context;
    }
}
