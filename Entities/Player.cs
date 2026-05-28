using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Graphics;

namespace The_Sound.Entities
{
    public class Player : MovingEntity
    {
        public Player()
        {
            Sprite = Sprites.Player;
        }

        public int Lives { get; set; } = 3;

        public void TakeDamage(int damage)
        {
            Lives -= damage;
        }
    }
}
