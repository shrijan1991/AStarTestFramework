using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    public enum heuristicType
    {
        MANHATTAN = 0,
        EUCLIDEAN = 1
    }
    public abstract class Heuristics<T>
    {
        public abstract double compute(T currentNode, T goalNode);
    }

    class gridHeuristics : Heuristics<Coordinate>
    {
        heuristicType heuristic { get; set; }

        public gridHeuristics(heuristicType _heuristicType) {
            heuristic = _heuristicType;
        }


        public override double compute(Coordinate currentNode, Coordinate goalNode)
        {
            //Todo: 
            int dx = currentNode.X - goalNode.X;
            int dy = currentNode.Y - goalNode.Y;
            switch (heuristic) {
                case heuristicType.MANHATTAN:
                    return Math.Abs(dx) + Math.Abs(dy);
                case heuristicType.EUCLIDEAN:
                    return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                default:
                    return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            }
        }
    }
}
