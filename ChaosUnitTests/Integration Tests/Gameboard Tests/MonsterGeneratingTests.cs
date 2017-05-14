using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaosUnitTests.Integration_Tests.Gameboard_Tests
{
    [TestClass]
    public class MonsterGeneratingTests
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
        public void IsAddingWizardsWorking()
        {

        }  

    }
}
