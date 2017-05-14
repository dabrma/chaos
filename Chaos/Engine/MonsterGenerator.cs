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
        public List<MonsterTemplate> MonsterTemplates = new List<MonsterTemplate>();

        public MonsterGenerator()
        {
            var gameObjectStrings = Resources.Monsters.Split('\n');
            foreach (var gameObjectString in gameObjectStrings)
            {
                var deserializedGameObject = gameObjectString.Split(' ');
                GenerateMonsterFromText(deserializedGameObject);
            }

            MonsterTemplates = MonsterTemplates.OrderBy(x => x.Name).ToList();
        }


        public Monster GetMonsterByName(string name, Player owner)
        {
            foreach (MonsterTemplate monsterTemplate in MonsterTemplates)
            {
                if (monsterTemplate.Name == name)
                {
                    return new Monster().MonsterFromTemplate(monsterTemplate, owner);
                }

            }
            throw new NullReferenceException();
        }

        private void GenerateMonsterFromText(string[] deserializedGameObjectStrings)
        {
            var monsterTemplate = new MonsterTemplate();
            monsterTemplate.Name = deserializedGameObjectStrings[0];

            monsterTemplate.Health = int.Parse(deserializedGameObjectStrings[1]);
            monsterTemplate.MaxHealth = monsterTemplate.Health;
            monsterTemplate.MagicResistance = int.Parse(deserializedGameObjectStrings[2]);
            monsterTemplate.Attack = int.Parse(deserializedGameObjectStrings[3]);
            monsterTemplate.Moves = int.Parse(deserializedGameObjectStrings[4]);
            monsterTemplate.isUndead = int.Parse(deserializedGameObjectStrings[5]) == 0 ? false : true;
            monsterTemplate.canAttack = true;
            monsterTemplate.sprite = (Bitmap) Resources.ResourceManager.GetObject(deserializedGameObjectStrings[0]);

            MonsterTemplates.Add(monsterTemplate);
        }
    }
}