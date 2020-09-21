using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Ird
{
    public partial class NZBankAccount
    {
        internal static readonly BranchRangeSet[] BranchRangeSets = new[]
        {
            new BranchRangeSet(1, new BranchRange[]
            {
                new BranchRange(1, 999),
                new BranchRange(1100, 1199),
                new BranchRange(1800, 1899),
            }),
            new BranchRangeSet(2, new BranchRange[]
            {
                new BranchRange(1, 999),
                new BranchRange(1200, 1299),
            }),
            new BranchRangeSet(3, new BranchRange[]
            {
                new BranchRange(1, 999),
                new BranchRange(1300, 1399),
                new BranchRange(1500, 1599),
                new BranchRange(1700, 1799),
                new BranchRange(1900, 1999),
                new BranchRange(7350, 7399),
            }),
            new BranchRangeSet(4, new BranchRange[]
            {
                new BranchRange(2020, 2024),
            }),
            new BranchRangeSet(6, new BranchRange[]
            {
                new BranchRange(1, 999),
                new BranchRange(1400, 1499),
            }),
            new BranchRangeSet(8, new BranchRange[]
            {
                new BranchRange(6500, 6599),
            }),
            new BranchRangeSet(9, new BranchRange[]
            {
                new BranchRange(0, 0),
            }),
            new BranchRangeSet(10, new BranchRange[]
            {
                new BranchRange(5165, 5169),
            }),
            new BranchRangeSet(11, new BranchRange[]
            {
                new BranchRange(5000, 6499),
                new BranchRange(6600, 8999),
            }),
            new BranchRangeSet(12, new BranchRange[]
            {
                new BranchRange(3000, 3299),
                new BranchRange(3400, 3499),
                new BranchRange(3600, 3699),
            }),
            new BranchRangeSet(13, new BranchRange[]
            {
                new BranchRange(4900, 4999),
            }),
            new BranchRangeSet(14, new BranchRange[]
            {
                new BranchRange(4700, 4799),
            }),
            new BranchRangeSet(15, new BranchRange[]
            {
                new BranchRange(3900, 3999),
            }),
            new BranchRangeSet(16, new BranchRange[]
            {
                new BranchRange(4400, 4499),
            }),
            new BranchRangeSet(17, new BranchRange[]
            {
                new BranchRange(3300, 3399),
            }),
            new BranchRangeSet(18, new BranchRange[]
            {
                new BranchRange(3500, 3599),
            }),
            new BranchRangeSet(19, new BranchRange[]
            {
                new BranchRange(4600, 4649),
            }),
            new BranchRangeSet(20, new BranchRange[]
            {
                new BranchRange(4100, 4199),
            }),
            new BranchRangeSet(21, new BranchRange[]
            {
                new BranchRange(4800, 4899),
            }),
            new BranchRangeSet(22, new BranchRange[]
            {
                new BranchRange(4000, 4049),
            }),
            new BranchRangeSet(23, new BranchRange[]
            {
                new BranchRange(3700, 3799),
            }),
            new BranchRangeSet(24, new BranchRange[]
            {
                new BranchRange(4300, 4349),
            }),
            new BranchRangeSet(25, new BranchRange[]
            {
                new BranchRange(2500, 2599),
            }),
            new BranchRangeSet(26, new BranchRange[]
            {
                new BranchRange(2600, 2699),
            }),
            new BranchRangeSet(27, new BranchRange[]
            {
                new BranchRange(3800, 3849),
            }),
            new BranchRangeSet(28, new BranchRange[]
            {
                new BranchRange(2100, 2149),
            }),
            new BranchRangeSet(29, new BranchRange[]
            {
                new BranchRange(2150, 2299),
            }),
            new BranchRangeSet(30, new BranchRange[]
            {
                new BranchRange(2900, 2949),
            }),
            new BranchRangeSet(31, new BranchRange[]
            {
                new BranchRange(2800, 2849),
            }),
            new BranchRangeSet(33, new BranchRange[]
            {
                new BranchRange(6700, 6799),
            }),
            new BranchRangeSet(35, new BranchRange[]
            {
                new BranchRange(2400, 2499),
            }),
            new BranchRangeSet(38, new BranchRange[]
            {
                new BranchRange(9000, 9499),
            }),
        };
    }
}
