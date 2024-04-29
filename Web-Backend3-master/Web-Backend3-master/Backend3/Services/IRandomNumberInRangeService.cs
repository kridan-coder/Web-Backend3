using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public interface IRandomNumberInRangeService
    {
        Int64 GenerateRandomNumberInRange(int bottomLine, int upperBound);
    }
}
