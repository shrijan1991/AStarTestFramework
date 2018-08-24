using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    public enum MoveDir
    {
        FourDirections = 0,
        EightDirections = 1
    }
    /// <summary>
    /// Operator class is an abstract class that sets the template for all operators to be used in this framework
    /// </summary>
    /// <typeparam name="T"> Generic type parameter for operations based on the type of search space</typeparam>
    public abstract class Operator<T> {
        /// <summary>
        /// List of operations that can be performed on a state
        /// </summary>
        public Dictionary<T, double> Operations { get; set; }
        public Operator() {
            Operations = new Dictionary<T, double>();
        }
        /// <summary>
        /// Generate list of possible operations
        /// </summary>
        public abstract void generate_Operations();
    }
    /// <summary>
    /// Operator class for grid based pathfinding. Uses coordinate system to represent state space and operations i.e. movements in 4 or 8 directions
    /// </summary>
    class gridBasedOperator : Operator<Coordinate>
    {
        MoveDir directions;
        /// <summary>
        /// Constructor to current type of operator class
        /// </summary>
        /// <param name="_directions">Based on enum MoveDir for traversing the grid. It can be cardinal movements or cardinal + diagonal movements</param>
        public gridBasedOperator(MoveDir _directions): base() {
            directions = _directions;
            generate_Operations();
        }
        /// <summary>
        /// Generate 4 possible coordinates for cardinal movements or 8 possible coordinates for cardinal +  diagonal 
        /// </summary>
        public override void generate_Operations()
        {
            // Todo: Re-check accuracy of code
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (directions == MoveDir.EightDirections)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        Operations.Add(new Coordinate(i, j), (Math.Abs(i) == Math.Abs(j)) ? 1.20f : 1.00f);
                    } else if (directions == MoveDir.FourDirections) {
                        if (Math.Abs(i) == Math.Abs(j)) {
                            continue;
                        }
                        Operations.Add(new Coordinate(i, j), 1.0f);
                    }
                }
            }
        }
        
    }
}
