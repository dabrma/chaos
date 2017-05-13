using Chaos.Engine;
using Chaos.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosUnitTests.Unit_Tests
{
    [TestClass]
    public class MonsterActionsTests
    {
        public MonsterActions monsterActions;

        [TestMethod]
        public void IsRangeIntegerBeingRoundedDownProperly()
        {
            Gameboard mockGb = null;
            GameEngine mockEng = null;
            monsterActions = new MonsterActions(mockGb, mockEng);
            var range = 3;
            Point loc = new Point(0, 0);
            //Point t1 = new Point(1, 2);
            //Point t2 = new Point(1, 3);
            //Point t3 = new Point(1, 2);
            //Point t4 = new Point(1, 3);
            int d = 4;

            for (int i = 0; i < d; i++)
            {
                Point p1 = new Point(d, i);
                Point p2 = new Point(i, d);


                EventLogger.WriteLog("For: " + p1.ToString() +  " " + (monsterActions.isDefenderInRange(loc, p1, 0) + " " + (monsterActions.isDefenderInRange(loc, p1, 0) == (d))));
                EventLogger.WriteLog("For: " + p2.ToString() + " " + (monsterActions.isDefenderInRange(loc, p2, 0) == (d)));
            }

            System.Windows.Forms.MessageBox.Show("Test");
        }
    }
}
