using System.Collections.Generic;

namespace Domain
{
    public interface IATM
    {
        List<decimal> GetNotes(decimal? amount);
    }
}