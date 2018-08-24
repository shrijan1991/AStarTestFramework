using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace AStarTestFramework
{
    public partial class FrameworkGUI : Form
    {
        public const string ASTARSEARCH = "A* search";
        public const string BFS = "Breadth First Search";
        public const string DIJKSTRAS = "Dijkstras";

        public FrameworkGUI()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Maps mapList = new Maps(@"C:\Users\Administrator\Downloads\map\den000d.map");
        //    string mapNames = "";
        //    foreach (Map m in mapList.MapList)
        //    {
        //        mapNames += m.filepath + "\n";
        //        m.generateTerrain();
        //        Coordinate[] startend = m.getRandomStartandEnd();
        //        Coordinate start = startend[0];
        //        Coordinate end = startend[1];
        //        if (m.isValid(start.X, start.Y) && m.isValid(end.X, end.Y))
        //        {
        //            int nodesTraversed = 0;
        //            Stopwatch sw = new Stopwatch();



        //            // BFS
        //            sw.Reset();
        //            sw.Start();
        //            BreadthFirstSearch testBFS = new BreadthFirstSearch(m, start, end, MoveDir.EightDirections);
        //            //if(m.isValid(newc))
        //            BFSGridNode bfsResult = testBFS.runBFS();
        //            sw.Stop();
        //            mapNames += "___________________BFS___________________\n";

        //            mapNames += "Time elapsed = " + sw.Elapsed + "\n";
        //            mapNames += "Size of open list = " + testBFS.openList.Count + "\n";
        //            mapNames += "Size of closed list = " + testBFS.closedList.Count + "\n";
        //            mapNames += "Length of optimal path = " + bfsResult.depth + "\n\n";

        //            sw.Reset();
        //            //Dijkstras
        //            nodesTraversed = 0;
        //            sw.Start();
        //            Dijkstras testDijkstras = new Dijkstras(m, start, end, MoveDir.EightDirections);
        //            //if(m.isValid(newc))
        //            DijkstrasGridNode dijResult = testDijkstras.runDijkstras();
        //            sw.Stop();
        //            mapNames += "___________________Dijkstras___________________\n";

        //            mapNames += "Time elapsed = " + sw.Elapsed + "\n";
        //            mapNames += "cost of path found = " + dijResult.cost + "\n";
        //            mapNames += "Number of frontier nodes = " + testDijkstras.frontier.Count + "\n";
        //            mapNames += "Number of explored nodes = " + testDijkstras.exploredNodes.Count + "\n";
        //            while (dijResult != null)
        //            {
        //                dijResult = dijResult.parent;
        //                nodesTraversed++;
        //            }
        //            mapNames += "Number of rexpanded nodes = " + testDijkstras.reopenedNodeCount + "\n";
        //            mapNames += "Length of optimal path = " + (nodesTraversed - 1) + "\n";

        //            sw.Reset();

        //            nodesTraversed = 0;
        //            sw.Start();
        //            AStar testAstar = new AStar(m, start, end, heuristicType.MANHATTAN, MoveDir.EightDirections);
        //            //if(m.isValid(newc))
        //            AStarGridNode result = testAstar.runAStar();
        //            sw.Stop();
        //            mapNames += "\n___________________A* search___________________\n";
        //            mapNames += "f = " + result.f + "\n";
        //            mapNames += "g = " + result.g + "\n";
        //            mapNames += "h = " + result.h + "\n";
        //            mapNames += "Time elapsed = " + sw.Elapsed + "\n";
        //            mapNames += "Size of open list = " + testAstar.openList.Count + "\n";
        //            mapNames += "Size of closed list = " + testAstar.closedList.Count + "\n";
        //            while (result != null)
        //            {
        //                result = result.parent;
        //                nodesTraversed++;
        //            }
        //            mapNames += "Number of rexpanded nodes = " + testAstar.reopenedNodeCount + "\n";
        //            // Cost of optimal path is number of nodes traversed - 1 = number of edges
        //            mapNames += "Length of optimal path = " + (nodesTraversed - 1) + "\n\n";
        //        }
        //        else
        //        {
        //            mapNames += "Invalid start or end node" + "\n";
        //        }

        //    }
        //    mapNames += "\n";

            
        //    MapTextBox.Text = string.Join(" ", mapNames);



        //}

        private void MapVis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
       

        private void AlgorithmsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AlgorithmsListBox.SelectedItem) {
                case DIJKSTRAS:
                case BFS:
                    heuristicLabel.Visible = false;
                    heuristicsCombo.Visible = false;
                    break;
                default:
                    heuristicLabel.Visible = true;
                    heuristicsCombo.Visible = true;
                    break;

            }
        }

        private void FrameworkGUI_Load(object sender, EventArgs e)
        {
            AlgorithmsListBox.Items.Add(ASTARSEARCH);
            AlgorithmsListBox.Items.Add(DIJKSTRAS);
            AlgorithmsListBox.Items.Add(BFS);
            AlgorithmsListBox.SelectedItem = ASTARSEARCH;
            moveDirectionsCombo.DataSource = Enum.GetValues(typeof(MoveDir));
            heuristicsCombo.DataSource = Enum.GetValues(typeof(heuristicType));
        }

        private void RunExperiments_Click(object sender, EventArgs e)
        {
            List<string> mapPaths = MapListBox.CheckedItems.OfType<string>().ToList();
            List<string> algorithms = AlgorithmsListBox.CheckedItems.OfType<string>().ToList();
            Maps newMaps = new Maps(pathText.Text);
            newMaps.MapList.Clear();
            foreach (string mapPath in mapPaths) {
                newMaps.MapList.Add(new Map(mapPath));
            }
            BulkExperiment experiments = new BulkExperiment(newMaps, Convert.ToInt32(experimentsCountNumericUD.Value), 
                (MoveDir) moveDirectionsCombo.SelectedItem, (heuristicType) heuristicsCombo.SelectedItem, algorithms);
            experiments.runAllExperiments();
        }

        /// <summary>
        /// Add maps to maps list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMaps_Click(object sender, EventArgs e)
        {
            MapListBox.Items.Clear();
            //Using maplist because check for path details is written here
            Maps mapList = new Maps(pathText.Text);
            // There should be something that removes from list when change is made in listbox items
            foreach (Map m in mapList.MapList)
            {
                MapListBox.Items.Add(m.filepath, true);
            }
        }
    }
}
