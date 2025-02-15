﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Context
{
    public class GarageManagerDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> configureDbContext;

        public GarageManagerDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            this.configureDbContext = configureDbContext;
        }

        public GarageManagerDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<GarageManagerDbContext> options = new DbContextOptionsBuilder<GarageManagerDbContext>();

            configureDbContext(options);

            return new GarageManagerDbContext(options.Options);
        }
    }
}
