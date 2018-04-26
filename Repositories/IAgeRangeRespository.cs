using System;
using System.Collections.Generic;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public interface IAgeRangeRespository
    {

        IEnumerable<AgeRange> AgeRanges { get; }
    }

}
