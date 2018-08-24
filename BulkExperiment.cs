using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace AStarTestFramework
{
    public class BulkExperiment
    {
        public Maps maps { get; private set; }
        public int experimentCount {get; private set;}
        public MoveDir moveDirections { get; private set; }
        public heuristicType heuristics { get; private set; }
        public List<string> algorithms { get; private set; }
        public string BulkExperimentID;
        public List<ResultRecord> results { get; private set; }


        public BulkExperiment(Maps _maps, int _experimentCount, MoveDir _moveDirections, heuristicType _heuristics, List<string> _algorithms) {
            maps = _maps;
            experimentCount = _experimentCount;
            moveDirections = _moveDirections;
            heuristics = _heuristics;
            algorithms = _algorithms;
            // Todo: Use GUID later maybe
            BulkExperimentID = DateTime.Now.ToString("yyMMddHHmmssff");
            results = new List<ResultRecord>();
        }

        public void runAllExperiments() {
            foreach (Map m in maps.MapList) {
                m.generateTerrain();
                m.setStartEndPair(experimentCount);
            }
            // Parallelize this could be better - too many repetitions
            foreach (var algorithm in algorithms) {
                if (algorithm == FrameworkGUI.ASTARSEARCH) {
                    foreach (Map m in maps.MapList)
                    {
                        foreach (Coordinate start in m.startEndPair.Keys) {
                            AStar astar = new AStar(m, start, m.startEndPair[start], heuristics, moveDirections);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            AStarGridNode aStarResult = astar.runAStar();
                            sw.Stop();
                            if (aStarResult == null)
                            {
                                results.Add(new ResultRecord());
                                m.invalidateStartEndPair(start);
                            }
                            else {
                                results.Add(new ResultRecord(start, m.startEndPair[start], astar.reopenedNodeCount, astar.openList.Count, astar.closedList.Count, aStarResult, sw.Elapsed, m));
                            }
                        }
                    }
                } else if (algorithm == FrameworkGUI.BFS) {
                    foreach (Map m in maps.MapList)
                    {
                        foreach (Coordinate start in m.startEndPair.Keys)
                        {
                            if (m.invalidStartEndPair.ContainsKey(start)) {
                                continue;
                            }
                            BreadthFirstSearch bfs = new BreadthFirstSearch(m, start, m.startEndPair[start], moveDirections);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            BFSGridNode BFSResult = bfs.runBFS();
                            sw.Stop();
                            if (BFSResult == null)
                            {
                                results.Add(new ResultRecord());
                            }
                            else
                            {
                                results.Add(new ResultRecord(start, m.startEndPair[start], 0, bfs.openList.Count, bfs.closedList.Count, BFSResult, sw.Elapsed, m));
                            }
                        }
                    }
                } else if (algorithm == FrameworkGUI.DIJKSTRAS) {
                    foreach (Map m in maps.MapList)
                    {
                        foreach (Coordinate start in m.startEndPair.Keys)
                        {
                            if (m.invalidStartEndPair.ContainsKey(start))
                            {
                                continue;
                            }
                            Dijkstras dij = new Dijkstras(m, start, m.startEndPair[start], moveDirections);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            DijkstrasGridNode dijResult = dij.runDijkstras();
                            sw.Stop();
                            if (dijResult == null)
                            {
                                results.Add(new ResultRecord());
                            }
                            else
                            {
                                results.Add(new ResultRecord(start, m.startEndPair[start], dij.reopenedNodeCount, dij.frontier.Count, dij.exploredNodes.Count, dijResult, sw.Elapsed, m));
                            }
                        }
                    }
                }
            }
            // Add to csv
            var csvwriter = new StringBuilder();
            csvwriter.AppendLine("ResultRecordID, Map Name, Number of Traverserable nodes, Algorithm, Start Coordinate, End Coordinate, Experiment Success,  Path Length, Optimal cost path, Openlist size, Closedlist size, Nodes Reexpanded, Time Taken");
            foreach (var result in results) {
                csvwriter.Append(result.ToString());
            }
            File.WriteAllText(Path.GetDirectoryName(maps.MapList[0].filepath) + "\\Experiment_" +BulkExperimentID + ".csv" , csvwriter.ToString());

        }
    }
}
