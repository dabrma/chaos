using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.Engine
{
    public class MonsterGenerator
    {
        public List<Monster> Monsters = new List<Monster>();

        public MonsterGenerator()
        {
            var gameObjectStrings = Properties.Resources.Monsters.Split('\n');
            foreach (string gameObjectString in gameObjectStrings)
            {
                var deserializedGameObject = gameObjectString.Split(' ');
                GenerateMonsterFromText(deserializedGameObject);
            }

        }
        
        private void GenerateMonsterFromText(string[] deserializedGameObjectStrings)
        {
            Monster monster = new Monster(new Player("", 0));
            monster.Name = deserializedGameObjectStrings[0];
            monster.Caption = monster.Owner.Name + monster.Name;
            monster.Attack = int.Parse(deserializedGameObjectStrings[1]);
            monster.Defense = int.Parse(deserializedGameObjectStrings[4]);
            monster.Moves = int.Parse(deserializedGameObjectStrings[5]);
            monster.MovesRemaining = monster.Moves;
            monster.MagicResistance = int.Parse(deserializedGameObjectStrings[6]);
            monster.Sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject(deserializedGameObjectStrings[0]);
            
            Monsters.Add(monster);
        }
    }
}
