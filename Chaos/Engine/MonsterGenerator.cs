using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    public class MonsterGenerator
    {
        public List<Monster> Monsters = new List<Monster>();

        public MonsterGenerator()
        {
            var gameObjectStrings = Resources.Monsters.Split('\n');
            foreach (var gameObjectString in gameObjectStrings)
            {
                var deserializedGameObject = gameObjectString.Split(' ');
                GenerateMonsterFromText(deserializedGameObject);
            }

            Monsters = Monsters.OrderBy(x => x.Name).ToList();
        }



        public Monster GetMonsterByName(string name)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.Name == name)
                    return monster;
            }
            throw new NullReferenceException();
        }

        private void GenerateMonsterFromText(string[] deserializedGameObjectStrings)
        {
            var monster = new Monster(new Player("", 0));
            monster.Name = deserializedGameObjectStrings[0];
            monster.Caption = monster.Owner.Name + monster.Name;

            monster.Health = int.Parse(deserializedGameObjectStrings[1]);
            monster.MagicResistance = int.Parse(deserializedGameObjectStrings[2]);
            monster.Attack = int.Parse(deserializedGameObjectStrings[3]);
            monster.Moves = int.Parse(deserializedGameObjectStrings[4]);
            monster.isUndead = int.Parse(deserializedGameObjectStrings[5]) == 0 ? false : true;
            monster.canAttack = true;
            monster.MovesRemaining = monster.Moves;
            monster.Sprite = (Bitmap) Resources.ResourceManager.GetObject(deserializedGameObjectStrings[0]);

            Monsters.Add(monster);
        }
    }
}