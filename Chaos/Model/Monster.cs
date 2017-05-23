using System.Drawing;
using Chaos.Engine;
using Chaos.Properties;

namespace Chaos.Model
{
    public class Monster : GameObject
    {
        public Monster()
        {
        }

        public Monster(Player owner)
        {
            Owner = owner;
            Caption = Owner.Name + "'s " + Name;
        }

        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int Moves { get; set; }

        public int MovesRemaining { get; set; }

        public int MagicResistance { get; set; }
        public int MaxMagicResistance { get; set; }

        public int Attack { get; set; }
        public int MaxAttack { get; set; }
        public int RangedAttack { get; set; }
        public int Range { get; set; }
        public int Defense { get; set; }

        public bool canAttack { get; set; }
        public bool canRangedAttack { get; set; }
        public bool isUndead { get; set; }
        public Point coordinates { get; set; }

        public Monster MonsterFromTemplate(MonsterTemplate template, Player owner)
        {
            var monster = new Monster();
            monster.Owner = owner;
            monster.MaxHealth = template.MaxHealth;
            monster.Sprite = template.sprite;
            monster.Caption = owner.Name + " " + template.Name;
            monster.canAttack = template.canAttack;
            monster.isUndead = template.isUndead;
            monster.Name = template.Name;
            monster.Attack = template.Attack;
            monster.MaxAttack = template.Attack;
            monster.Defense = template.Defense;
            monster.Health = template.Health;
            monster.MagicResistance = template.MagicResistance;
            monster.MaxMagicResistance = template.MagicResistance;
            monster.Moves = template.Moves;
            monster.MovesRemaining = monster.Moves;
            monster.Sprite = (Bitmap) Resources.ResourceManager.GetObject(monster.Name);

            return monster;
        }

        public override string ToString()
        {
            return $"{Name} {Owner} {MaxHealth} {Health} {MagicResistance} {MovesRemaining}";
        }
    }
}