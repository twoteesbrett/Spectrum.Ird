using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Ird
{
    internal class BranchRangeSet
    {
        public int Bank { get; set; }
        public BranchRange[] BranchRanges { get; set; }

        public BranchRangeSet(int bank, BranchRange[] range)
        {
            Bank = bank;
            BranchRanges = range;
        }
    }

    internal class BranchRange
    {
        public int Start { get; set; }
        public int End { get; set; }

        public BranchRange(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
