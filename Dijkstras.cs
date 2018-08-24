using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// Dijstra's algorithm or Uniform Cost search.
    /// Algorithm implemented from pseudocode in https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Practical_optimizations_and_infinite_graphs
    /// </summary>
    class Dijkstras
    {
        Operator<Coordinate> op;
        Map searchSpace;
        public List<DijkstrasGridNode> frontier { get; set; }
        public List<DijkstrasGridNode> exploredNodes { get; set; }
        public Coordinate goal { get; set; }
        public Coordinate start { get; set; }
        public int reopenedNodeCount { get; set; }
        public Dijkstras(Map _map, Coordinate _start, Coordinate _goal, MoveDir _moveDirections)
        {
            searchSpace = _map;
            op = new gridBasedOperator(_moveDirections);
            frontier = new List<DijkstrasGridNode>();
            exploredNodes = new List<DijkstrasGridNode>();
            start = new Coordinate(_start);
            goal = new Coordinate(_goal);
            reopenedNodeCount = 0;
        }

        public DijkstrasGridNode runDijkstras()
        {
            // Start
            DijkstrasGridNode current = new DijkstrasGridNode(start, null, 0);
            // Add current to open list
            frontier.Add(current);
            //Either do until open list is empty or until we find a goall
            while (frontier.Count > 0)
            {
                // set smallest value as  infinity
                double smallest = 1000000f;

                foreach (DijkstrasGridNode entry in frontier)
                {
                    if (entry.cost < smallest)
                    {

                        smallest = entry.cost;
                        current = entry;
                    }
                }
                if (current.Equals(goal))
                {
                    return current;
                }
                frontier.Remove(current);
                exploredNodes.Add(current);
                //if (Convert.ToInt32(current.g) % 10 == 0) {
                //    Debug.WriteLine("The g value is, " + current.g + "  frontier size: " + frontier.Count +"  exploredNodes size: " +  exploredNodes.Count);
                //}
                expand(current);

            }
            return current;
            // Add current to frontier
            // While openset is not empty
            // Add current as node with lowest f value
            // if goal reconstruct path

            // Remove from frontier 
            // Add to closed list

            // Expand open node
            // Do until all nodes in frontier have lower value than open list



        }




        public void expand(DijkstrasGridNode currentNode)
        {
            Coordinate childCoordinate;
            double newCost;
            bool nodeAlreadyExists = false;
            DijkstrasGridNode existentNode = null;
            foreach (var operations in op.Operations)
            {
                childCoordinate = currentNode.generateSuccessor(operations.Key);
                if (!searchSpace.isValid(childCoordinate.X, childCoordinate.Y))
                {
                    continue;
                }

                newCost = currentNode.cost + operations.Value;
                nodeAlreadyExists = false;
                existentNode = null;
                // If child is in closed list ignore
                foreach (DijkstrasGridNode entry in exploredNodes)
                {
                    if (entry.Equals(childCoordinate))
                    {
                        if (entry.cost > newCost)
                        {
                            // Update child in closed list
                            //h score doesn't and shouldn't change
                            entry.cost = newCost;
                            entry.parent = currentNode;
                            // If new path has a better g value only then re-open this node
                            existentNode = entry;
                        }
                        nodeAlreadyExists = true;
                        break;
                    }
                }


                if (nodeAlreadyExists)
                {
                    // Reopen a closed node
                    if (existentNode != null)
                    {
                        reopenedNodeCount++;
                        exploredNodes.Remove(existentNode);
                        frontier.Add(existentNode);
                    }
                }
                else
                {
                    // Check if the child is in the open list
                    foreach (DijkstrasGridNode entry in frontier)
                    {
                        if (entry.Equals(childCoordinate))
                        {
                            if (entry.cost > newCost)
                            {
                                // Update child in frontier
                                entry.cost = newCost;
                                entry.parent = currentNode;
                            }
                            nodeAlreadyExists = true;
                            break;
                        }
                    }
                }

                // Create new child node and add to open list if node doesn't already exist
                if (!nodeAlreadyExists)
                {
                    frontier.Add(new DijkstrasGridNode(childCoordinate, currentNode, newCost));
                }

            }

        }
    }
}
