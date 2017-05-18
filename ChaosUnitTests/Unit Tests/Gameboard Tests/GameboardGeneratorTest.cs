using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaos;
using System.Windows.Forms;

namespace ChaosUnitTests.GameboardTests
{
    [TestClass]
    public class GameboardGeneratorTest
    {
        private Chaos.Engine.Gameboard InitializeGameboardClassWithMockPanels()
        {
            Panel mockPanel = new Panel();
            Label mockLabel = new Label();
            int[] testCases = new int[] { 0, 12, 50 };
            int[] testResults = new int[testCases.Length];
            Chaos.Engine.Gameboard gameboard = new Chaos.Engine.Gameboard(mockPanel, mockLabel, mockLabel);

            return gameboard;
        }

        [TestMethod]
        public void IsFieldsCountOnMatrixCorrect()
        {
            Panel mockPanel = new Panel();
            Label mockLabel = new Label();
            int[] testCases = new int[] { 0, 12, 50 };
            int[] testResults = new int[testCases.Length];

            for (int i = 0; i < testCases.Length; i++)
            {
                Chaos.Engine.Gameboard gameboard = new Chaos.Engine.Gameboard(mockPanel, mockLabel, mockLabel, testCases[i]);
                testResults[i] = gameboard.GetElementsCollection().ToArray().Length;

                // Size of a gameboard should always be equal to SIZE * SIZE
                Assert.AreEqual(testCases[i] * testCases[i], testResults[i]);
            }
         }
        [TestMethod]
        public void IsGameboardInitializedWithNothingness()
        {
            Chaos.Engine.Gameboard gameboard = InitializeGameboardClassWithMockPanels();
            var tiles = gameboard.GetElementsCollection();
            foreach(Chaos.Engine.Tile Tile in tiles)
            {
                var typeOfTile = Tile.GetOccupant().GetType();
                Assert.AreEqual(typeof(Chaos.Engine.Nothing), typeOfTile);
            }
        }
    }

}

