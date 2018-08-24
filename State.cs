using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// State class represents any state in the graph/map.
    /// </summary>
    /// <typeparam name="T">Generic type parameter for state</typeparam>
    public abstract class State<T>
    {
        public T currentState { get; set; }
        /// <summary>
        /// Generate a successor state when an operator is applied to current state.
        /// </summary>
        /// <param name="Operator">Operator to be applied to current state.</param>
        /// <returns>Successor of same type as the current state</returns>
        public abstract T generateSuccessor(T Operator);
    }
    /// <summary>
    /// A state in grid-based map.
    /// </summary>
    public class gridState : State<Coordinate>
    {
        public gridState(Coordinate _newCoordinate) {
            currentState = _newCoordinate;
        }

        public gridState(int _x, int _y)
        {
            currentState = new Coordinate(_x, _y);
        }

        /// <summary>
        /// Generate a new coordinate based on one of the directions from current state in the grid.
        /// </summary>
        /// <param name="Operator">Direction to move in.</param>
        /// <returns>New coordinate for the successor</returns>
        public override Coordinate generateSuccessor(Coordinate Operator)
        {
            return new Coordinate(currentState.X + Operator.X, currentState.Y + Operator.Y);
        }
    }

    class AStarGridNode : gridState {
        public double f { get; set; }
        public double g { get; set; }
        public double h { get; set; }
        public AStarGridNode parent { get; set; }
        public AStarGridNode(Coordinate newCoordinate, double heuristicCost, AStarGridNode prevNode ,double currentCost) : base(newCoordinate) {
            h = heuristicCost;
            g = currentCost;
            f = g + h;
            parent = prevNode;
        }

        public bool Equals(Coordinate newCoordinate) {
            return currentState.Equals(newCoordinate);
        }
    }

    class BFSGridNode : gridState
    {
        public int depth { get; set; }
        public BFSGridNode parent { get; set; }
        public BFSGridNode(Coordinate newCoordinate, BFSGridNode prevNode, int _depth) : base(newCoordinate)
        {
            depth = _depth;
            parent = prevNode;
        }

        public bool Equals(Coordinate newCoordinate)
        {
            return currentState.Equals(newCoordinate);
        }
    }

    class DijkstrasGridNode : gridState
    {
        public double cost { get; set; }
        public DijkstrasGridNode parent { get; set; }
        public DijkstrasGridNode(Coordinate newCoordinate, DijkstrasGridNode prevNode, double _initialCost) : base(newCoordinate)
        {
            cost = _initialCost;
            parent = prevNode;
        }

        public bool Equals(Coordinate newCoordinate)
        {
            return currentState.Equals(newCoordinate);
        }
    }




}
