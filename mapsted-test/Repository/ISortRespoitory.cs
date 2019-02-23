using MapstedTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapstedTest.Repository
{
    public interface ISortRespoitory
    {
        /// <summary>
        /// Sorts a list and returns snapshots of each sort stage
        /// </summary>
        List<List<int>> SortList(SortTask<int> sContext);

        /// <summary>
        /// Sorts a list and returns snapshots of each sort stage
        /// </summary>
        List<List<double>> SortList(SortTask<double> sContext);
    }
}
