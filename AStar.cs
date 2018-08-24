using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AStarTestFramework
{
    /// <summary>
    /// A* search algorithm.
    /// Algorithm implemented from pseudocode in  https://en.wikipedia.org/wiki/A*_search_algorithm#Pseudocode
    /// </summary>
    class AStar
    {
        private Heuristics<Coordinate> heuristics;
        Operator<Coordinate> op;
        Map searchSpace;
        public List<AStarGridNode> openList { get; set; }
        public List<AStarGridNode> closedList { get; set; }
        public Coordinate goal { get; set; }
        public Coordinate start { get; set; }
        public int reopenedNodeCount { get; set; }
        public AStar(Map _map, Coordinate _start, Coordinate _goal, heuristicType _heuristicType, MoveDir _moveDirections) {
            searchSpace = _map;
            //searchSpace.generateTerrain();
            heuristics = new gridHeuristics(_heuristicType);
            op = new gridBasedOperator(_moveDirections);
            openList = new List<AStarGridNode>();
            closedList = new List<AStarGridNode>();
            start = new Coordinate(_start);
            goal = new Coordinate(_goal);
            reopenedNodeCount = 0;
        }

        public AStarGridNode runAStar(){
            // Start
            AStarGridNode current = new AStarGridNode(start, heuristics.compute(start, goal), null, 0);
            // Add current to open list
            openList.Add(current);
            //Either do until open list is empty or until we find a goall
            while (openList.Count > 0) {
                // set smallest value as  infinity
                double smallest = 1000000f;

                foreach (AStarGridNode entry in openList)
                {
                    if (entry.f < smallest)
                    {
                        
                        smallest = entry.f;
                        current = entry;
                    }
                }
                if (current.Equals(goal))
                {
                    return current;
                }
                //Stop condition maybe change the one for no of reopened nodes
                if ((openList.Count + closedList.Count) > searchSpace.numberOfTraversableNodes || reopenedNodeCount > (2 * searchSpace.numberOfTraversableNodes)) {
                    return null;
                } 
                
                openList.Remove(current);
                closedList.Add(current);
                expand(current);
                
            }
            return current;
            }

        public void expand(AStarGridNode currentNode) {
            Coordinate childCoordinate;
            double newg, newh;
            bool nodeExists = false;
            AStarGridNode existentNode = null;
            foreach (var operations in op.Operations)
            {
                childCoordinate = currentNode.generateSuccessor(operations.Key);
                if (!searchSpace.isValid(childCoordinate.X, childCoordinate.Y)) {
                    continue;
                }
       
                newh = heuristics.compute(childCoordinate, goal);
                newg = currentNode.g + operations.Value;
                nodeExists = false;
                existentNode = null;
                // If child is in closed list ignore
                foreach (AStarGridNode entry in closedList)
                {
                    if (entry.Equals(childCoordinate))
                    {
                        if (entry.g > newg)
                        {
                            // Update child in closed list
                            entry.g = newg;
                            //h score doesn't and shouldn't change
                            entry.f = newg + newh;
                            entry.parent = currentNode;
                            // If new path has a better g value only then re-open this node
                            existentNode = entry;
                        }
                        nodeExists = true;
                        break;
                    }
                }

               
                if (nodeExists)
                {
                    // Reopen a closed node
                    if (existentNode != null) {
                        reopenedNodeCount++;
                        closedList.Remove(existentNode);
                        openList.Add(existentNode);
                    }
                }
                else
                {
                    // Check if the child is in the open list
                    foreach (AStarGridNode entry in openList)
                    {
                        if (entry.Equals(childCoordinate))
                        {
                            if (entry.g > newg)
                            {
                                // Update child in openlist
                                entry.g = newg;
                                //h score doesn't  and shouldn't change
                                entry.f = newg + newh;
                                entry.parent = currentNode;
                            }
                            nodeExists = true;
                            break;
                        }
                    }
                }
               
                // Create new child node and add to open list if node doesn't already exist
                if (!nodeExists) {
                    openList.Add(new AStarGridNode(childCoordinate,newh, currentNode, newg));
                }

            }

        }

    }
}
