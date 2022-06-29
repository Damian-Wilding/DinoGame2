using System;
using System.Collections.Generic;
using System.Linq;

namespace DinoGame2.Game.Casting
{
    /// <summary>
    /// <para> A Cool Dinosaur that you play as.</para>
    /// <para>The responsibility of Dino is to move itself and shoot his gun (if we get to that).</para>
    /// </summary>
    public class Dino : Actor
    {
        
        /// <summary>
        /// Constructs a new instance of a Dino.
        /// </summary>
        public Dino()
        {
            //they have prepare body here. idk if we will need that or not
        }

        public override void MoveNext()
        {
            player.MoveNext();
        }

        private void PrepareDino()
        {

        }






    }
}