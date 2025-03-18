using Microsoft.EntityFrameworkCore;

namespace server.Data;

public abstract class SaveChangesDb
{
    protected async Task Save(DbContext context)
    {
        await context.SaveChangesAsync();
    }
}