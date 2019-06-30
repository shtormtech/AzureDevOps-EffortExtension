using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.DB.Layer.Context
{
    public interface IEffortDbContextFactory
    {
        EffortDbContext CreateDbContext(string connectionString);
    }
}
