using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeTask.Models;

namespace DanskeTask.Extentions
{
    public class RecordsComparer : IEqualityComparer<Record>
    {
        public bool Equals(Record? a, Record? b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            if (a.Smac == b.Smac && a.Start == b.Start && a.Shost == b.Shost &&
                a.Rt == b.Rt && a.Dmac == b.Dmac)
                return true;
            else
                return false;
        }

        public int GetHashCode(Record value)
        {
            if (ReferenceEquals(value, null))
                return 0;

            int hashsmac = value.Smac == null ? 0 : value.Smac.GetHashCode();
            int hashstart = value.Start == null ? 0 : value.Start.GetHashCode();
            int hashshost = value.Shost == null ? 0 : value.Shost.GetHashCode();
            int hashrt = value.Rt == null ? 0 : value.Rt.GetHashCode();
            int hashdmac = value.Dmac == null ? 0 : value.Dmac.GetHashCode();

            return hashsmac ^ hashstart ^ hashshost ^ hashrt ^ hashdmac;
        }
    }
}

