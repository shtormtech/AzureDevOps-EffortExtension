using Effort.DB.Layer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.DB.Layer.Repository
{
    public class BaseRepository
    {
        protected string ConnectionString { get; }
        protected IEffortDbContextFactory ContextFactory { get; }
        public BaseRepository(string connectionString, IEffortDbContextFactory contextFactory)
        {
            ConnectionString = connectionString;
            ContextFactory = contextFactory;
        }
    }
}
