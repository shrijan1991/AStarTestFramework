using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// Class which has results of the experiments
    /// </summary>
    public class ResultRecord
    {
        public int nodesReExpanded { get; private set; }
        public int openListSize { get; private set; }
        public int closedListSize { get; private set; }
        public int pathLength { get; private set; }
        public double optimalPathCost { get; private set; }
        public TimeSpan timetaken { get; private set; }
        public string ResultRecordID { get; private set; }
        public string mapName { get; private set; }
        public int numberofTraverserableNodes { get; private set; }
        public bool experimentOutcome { get; private set; }
        public string algorithmUsed { get; private set; }
        public Coordinate startCoordinate { get; set; }
        public Coordinate endCoordinate { get; set; }

        /// <summary>
        /// Record of the result
        /// </summary>
        /// <param name="_nodesReExpanded">Number of nodes reexpanded</param>
        /// <param name="_openListSize">Size of open list</param>
        /// <param name="_closedListSize">Size of closed list</param>
        /// <param name="resultNode">Result of the experiment</param>
        /// <param name="_timetaken">Time taken for the full experiment</param>
        /// <param name="_map">Map the experiment was run on</param>
        // Todo: Add path taken later from here
        public ResultRecord(Coordinate _startCoordinate, Coordinate _endcoordinate, int _nodesReExpanded, int _openListSize, int _closedListSize ,gridState resultNode, TimeSpan _timetaken,
            Map _map) {

            startCoordinate = _startCoordinate;
            endCoordinate = _endcoordinate;
            nodesReExpanded = _nodesReExpanded;
            openListSize = _openListSize;
            closedListSize = _closedListSize;
            experimentOutcome = true;
            ResultRecordID = DateTime.Now.ToString("yyMMddHHmmssff");
            //Could be done better
            if (resultNode.GetType() == typeof(AStarGridNode))
            {
                var temp = 0;
                AStarGridNode res = ((AStarGridNode)resultNode);
                optimalPathCost = res.f;
                while (res != null)
                {
                    res = res.parent;
                    temp++;
                }
                pathLength = temp - 1;
                algorithmUsed = FrameworkGUI.ASTARSEARCH;
            } else if (resultNode.GetType() == typeof(BFSGridNode)) {
                var temp = 0.0;
                BFSGridNode res = ((BFSGridNode)resultNode);
                pathLength = res.depth;
                while (res != null)
                {
                    if (res.parent != null) {
                        temp += (Math.Abs(res.currentState.X - res.parent.currentState.X) == Math.Abs(res.currentState.Y - res.parent.currentState.Y)) ? 1.2 : 1.0;
                    }
                    res = res.parent;
                }
                optimalPathCost = temp;
                algorithmUsed = FrameworkGUI.BFS;
            }
            else if (resultNode.GetType() == typeof(DijkstrasGridNode)) {
                var temp = 0;
                DijkstrasGridNode res = ((DijkstrasGridNode)resultNode);
                optimalPathCost = res.cost;
                while (res != null)
                {
                    res = res.parent;
                    temp++;
                }
                pathLength = temp - 1;
                algorithmUsed = FrameworkGUI.DIJKSTRAS;
            }
            mapName = _map.mapName;
            numberofTraverserableNodes = _map.numberOfTraversableNodes;
        }
        /// <summary>
        /// Default constructor to fail the experiment
        /// </summary>
        public ResultRecord()
        {
            ResultRecordID = DateTime.Now.ToString("yyMMddHHmmssff");
            experimentOutcome = false;
        }

        public override string ToString()
        {
            return experimentOutcome ?
                String.Format("{0}, {1}, {2}, {3},\" {4}\",\" {5}\", {6}, {7}, {8}, {9}, {10}, {11}, {12}\n",
                    ResultRecordID, mapName, numberofTraverserableNodes, algorithmUsed, startCoordinate, endCoordinate, experimentOutcome,  pathLength, optimalPathCost, openListSize, closedListSize, nodesReExpanded, timetaken.ToString())
                    : " , , , , , , false, , , , , , \n" ;
        }
    }

    


}
