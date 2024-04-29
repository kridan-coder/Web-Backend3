using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public class RandomNumberInRangeService : IRandomNumberInRangeService
    {
        private Random random = new Random();
        public Int64 GenerateRandomNumberInRange(int bottomLine, int upperBound) => random.Next(upperBound) + bottomLine;
    }
}
