using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// Breadh First Search.
    /// Algorithm implemented from, https://en.wikipedia.org/wiki/Breadth-first_search#Pseudocode
    /// </summary>
    class BreadthFirstSearch
    {
        Map searchSpace;
        private Operator<Coordinate> op;
        public Queue openList { get; set; }
        public List<BFSGridNode> closedList { get; set; }
        public Coordinate goal { get; set; }
        public Coordinate start { get; set; }
        public BreadthFirstSearch(Map _map, Coordinate _start, Coordinate _goal, MoveDir _moveDirections)
        {
            searchSpace = _map;
            openList = new Queue();
            closedList = new List<BFSGridNode>();
            start = new Coordinate(_start);
            goal = new Coordinate(_goal);
            op = new gridBasedOperator(_moveDirections);
        }
          
        public BFSGridNode runBFS()
        {
            BFSGridNode current = new BFSGridNode(start, null, 0);
            openList.Enqueue(current);
            while (openList.Count > 0)
            {
                // set smallest value as  infinity
                BFSGridNode newRoot = (BFSGridNode)openList.Dequeue();

                if (newRoot.Equals(goal))
                {
                    return newRoot;
                }

                closedList.Add(newRoot);
                expand(newRoot);

            }
            return current;


        }

        public void expand(BFSGridNode currentNode)
        {
            Coordinate childCoordinate;
            int newDepth = currentNode.depth  + 1;
            bool nodeAlreadyExists = false;
            BFSGridNode existentNode = null;
            foreach (var operations in op.Operations)
            {
                childCoordinate = currentNode.generateSuccessor(operations.Key);
                if (!searchSpace.isValid(childCoordinate.X, childCoordinate.Y))
                {
                    continue;
                }

                
                nodeAlreadyExists = false;
                existentNode = null;
                // If child is in closed list ignore
                foreach (BFSGridNode entry in closedList)
                {
                    if (entry.Equals(childCoordinate))
                    {
                        //if (entry.depth > newDepth)
                        //{
                        //    // Update child in closed list
                        //    //h score doesn't and shouldn't change
                        //    entry.f = newg + newh;
                        //    entry.parent = currentNode;
                        //    // If new path has a better g value only then re-open this node
                        //    existentNode = entry;
                        //}
                        nodeAlreadyExists = true;
                        break;
                    }
                }


                if (!nodeAlreadyExists)
                {
                    // Check if the child is in the open list
                    foreach (BFSGridNode entry in openList)
                    {
                        if (entry.Equals(childCoordinate))
                        {
                            if (entry.depth > newDepth)
                            {
                                // Update child in openlist
                                existentNode = entry;
                            }
                            nodeAlreadyExists = true;
                            break;
                        }
                    }
                }

                // Create new child node and add to open list if node doesn't already exist
                if (!nodeAlreadyExists)
                {
                    openList.Enqueue(new BFSGridNode(childCoordinate, currentNode, newDepth));
                }

            }

        }
    }
}
