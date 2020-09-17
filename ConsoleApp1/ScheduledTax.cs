using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{

    public class ScheduledTaxContext : DbContext
    {
        public DbSet<ScheduledTax> ScheduledTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Taxes.db");
    }

    public class ScheduledTax
    {
        public Guid ScheduledTaxId {get; set;}

        public string Municipality { get; set;}

        public double Rate { get; set; }

        public string TaxType  { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }

}
