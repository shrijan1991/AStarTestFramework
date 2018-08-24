using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// Class contains a list of maps to be experimented on.
    /// </summary>
    public class Maps
    {
        public enum MapNumber { None, Single, Multiple };
        public List<Map> MapList { get; }
        public MapNumber Numberofmaps { get; set; }
        public string mapPath { get; set; }

        public Maps(string _mapPath)
        {
            // Todo: File exists check

            MapList = new List<Map>();
            Numberofmaps = MapNumber.None;
            mapPath = _mapPath;
            if (Directory.Exists(Path.GetDirectoryName(mapPath)) && checkExtensions(mapPath))
            {
                // Don't create maps a the start
                // Store strings instead
                MapList.Add(new Map(mapPath));
            }
            else {
                mapPath += mapPath.Last() == '\\' ? "" : "\\";
                
                if (Directory.Exists(Path.GetDirectoryName(mapPath)) && String.IsNullOrEmpty(Path.GetFileName(mapPath)))
                {
                    List<string> mapFiles = Directory.GetFiles(mapPath).ToList<string>();
                    foreach (string file in mapFiles)
                    {
                        if (checkExtensions(file))
                        {
                            MapList.Add(new Map(file));
                        }
                    }

                }
            }
            Numberofmaps = (MapList.Count < 1) ? MapNumber.None : (MapList.Count == 1) ? MapNumber.Single : MapNumber.Multiple;
        }

        public bool checkExtensions(string path)
        {
            return (Path.HasExtension(path) && (Path.GetExtension(path).Contains(".map") || Path.GetExtension(path).Contains(".txt")));
        }


        // Todo: Run checks on maps to see if they adhere to standards set on https://movingai.com/benchmarks/formats.html
    }


    /// <summary>
    /// Single Map in list of maps. This represents gridmap for now. Will be abstracted later.
    /// </summary>
    public class Map
    {

        public int[,] Terrain { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string filepath { get; set; }
        public int numberOfTraversableNodes { get; set; }
        List<Coordinate> TraverserableNodes{ get; set; }
        public Dictionary<Coordinate, Coordinate> startEndPair { get; private set; }
        public Dictionary<Coordinate, Coordinate> invalidStartEndPair { get; private set; }
        bool containsDetails = true;
        bool uniqueStartEnd = true;
        public string mapName { get; private set; }

        public Map()
        {
            this.X = 50;
            this.Y = 50;

        }

        public void setUniqeStartEnd(bool _uniqueStartEnd) {
            uniqueStartEnd = _uniqueStartEnd;
        }


        // Create map from a text file
        public Map(String _filepath)
        {
            filepath = _filepath;
            numberOfTraversableNodes = 0;
            TraverserableNodes = new List<Coordinate>();
            startEndPair = new Dictionary<Coordinate, Coordinate>();
            invalidStartEndPair = new Dictionary<Coordinate, Coordinate>();
            mapName = Path.GetFileName(_filepath);
        }

        public void generateTerrain() {
            var reader = File.ReadAllLines(filepath);
            string line = "";
            if (reader[1].Contains("height"))
            {
                line = reader[1].Remove(0, 7);
                Y = int.Parse(line);
            }
            else {
                Y = reader.Count();
                containsDetails = false;
            }
            if (reader[2].Contains("width"))
            {
                line = reader[2].Remove(0, 6);
                X = int.Parse(line);
            }
            else
            {
                X = reader[2].Count();  
            }
            // Read Y =  height/rows and X = width/cols
            Terrain = new int[Y, X];
            LoadToMemory();
        }

        /// <summary>
        /// Load Terrain to memory.
        /// </summary>
        public void LoadToMemory () {
            var reader = File.ReadAllLines(filepath);
            string line = "";
            int offset = containsDetails ? 3 : -1;
            // Setup terrain bottom up
            for (int row = Y + offset; row >= 4;  row--)
            {
                line = reader[row];
                if (line.Length < X - 1)
                {
                    continue;
                }

                
                for (int col = 0; col < X; col++)
                {
                    char c = line[col];
                    if (c != ' ' && c != '.' && c != 'G')
                    {
                        Terrain[Y - row + offset, col] = 0;
                    }
                    else
                    {
                        Terrain[Y - row + offset, col] = 1;
                        numberOfTraversableNodes++;
                        // Could have array representation merged into this list to get the list non-obstacle nodes
                        TraverserableNodes.Add(new Coordinate(col, Y - row + offset));
                    }
                }
            }
        }

        /// <summary>
        /// Set the number of start and end pairs.
        /// </summary>
        /// <param name="count"> Count of start and end pairs to set</param>
        public void setStartEndPair(int count) {
            for (int i = 0; i < count; i++) {
                Coordinate[] bestSeperationPair = getRandomStartandEnd();
                startEndPair.Add(bestSeperationPair[0], bestSeperationPair[1]);
            }
        }
        /// <summary>
        /// Invalidate a start end pair if it does not have a path. 
        /// </summary>
        /// <param name="_key"></param>
        public void invalidateStartEndPair(Coordinate _key)
        {
            // Should be ok with key value because we will be using actual references in key value pair
            invalidStartEndPair.Add(_key, startEndPair[_key]);
            // Add new pair
            Coordinate[] bestSeperationPair = getRandomStartandEnd();
            startEndPair.Add(bestSeperationPair[0], bestSeperationPair[1]);
        }

        /// <summary>
        /// Get random start and end points. Farthest start and end points are selected.
        /// </summary>
        /// <returns> Array of coordinates with the size 2. First one is the start coordinate and second one is the end coordinate.</returns>
        private Coordinate[] getRandomStartandEnd() {
            List<Coordinate> nodeList = new List<Coordinate>();
            Coordinate[] bestSeperationPair = new Coordinate[2];
            // Deep copy as we will be removing nodes from nodeList to ensure same nodes are selected while randoming
            foreach (Coordinate node in TraverserableNodes) {
                nodeList.Add(new Coordinate(node));
            }
            var random = new Random();
            List<Coordinate> set1, set2;
            set1 = new List<Coordinate>();
            set2 = new List<Coordinate>();
            int index = 0;
            for (int i = 0; i < TraverserableNodes.Count / 10; i++ ) {
                index = random.Next(nodeList.Count);
                set1.Add(nodeList.ElementAt(index));
                nodeList.RemoveAt(index);
            }
            for (int i = 0; i < TraverserableNodes.Count / 10; i++)
            {
                index = random.Next(nodeList.Count);
                set2.Add(nodeList.ElementAt(index));
                nodeList.RemoveAt(index);
            }
            Heuristics<Coordinate> h = new gridHeuristics(heuristicType.EUCLIDEAN);
            double highest = 0;
            bool coordinateExists = false;
            Coordinate equivalentCoordinate = null;
            foreach (var c1 in set1) {
                coordinateExists = false;
                // Needs to be done because the current node list is a deep copy of the original list so they have different references
                // Could be done better maybe override hash
                if (uniqueStartEnd) {
                    foreach (var startPoint in startEndPair.Keys) {
                        if (startPoint.Equals(c1)) {
                            coordinateExists = true;
                            equivalentCoordinate = startPoint;
                            break;
                        }
                    }
                }
                
                foreach (var c2 in set2) {
                    // Equals compares properties so should be ok
                    if (uniqueStartEnd && coordinateExists && startEndPair[equivalentCoordinate].Equals(c2)) {
                        continue;
                    }
                    if (h.compute(c1, c2) > highest) {
                        highest = h.compute(c1, c2);
                        bestSeperationPair[0] = c1;
                        bestSeperationPair[1] = c2;
                    }
                }
            }

            Debug.WriteLine(bestSeperationPair[0]);
            Debug.WriteLine(bestSeperationPair[1]);

            return bestSeperationPair;
        }

        /// <summary>
        /// Check if the provided coordinate is valid
        /// </summary>
        /// <param name="_coordinate">Instance of the coordinate class</param>
        /// <returns>True if the coordinate is valid else false</returns>
        public bool isValid(Coordinate _coordinate)
        {
            return isValid(_coordinate.X, _coordinate.Y);
        }

        /// <summary>
        /// Check if the provided coordinate is valid
        /// </summary>
        /// <param name="_x">x coordinate</param>
        /// <param name="_y">y coordinate</param>
        /// <returns>True if the coordinate is valid else false</returns>
        public bool isValid(int _x, int _y)
        {
            if (_x > X - 1 || _y > Y - 1 || _x < 0 || _y < 0)
            {
                return false;
            }
            return (Terrain[_y, _x] >= 1);
        }

    }
}
