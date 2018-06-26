using System;
using System.Collections.Generic;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public interface IAgeRangeRepository
    {

        IEnumerable<AgeRange> AgeRanges { get; }
    }

}
