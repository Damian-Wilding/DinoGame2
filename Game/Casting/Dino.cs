using System;
using System.Collections.Generic;
using System.Linq;

namespace DinoGame2.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Dino is to move itself.</para>
    /// </summary>
    public class Dino : Actor
    {
        Color color = Constants.BLUE;
        Point position = Constants.DinoSpawn;
        string text = "D";
        Point velocity = new Point(0, 0);
        int fontSize = Constants.FONT_SIZE;
        Actor dino = new Actor();

        /// <summary>
        /// Constructs a new instance of a Dino.
        /// </summary>
        public Dino()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the dino's color
        /// </summary>
        /// <returns>the color of the dino</returns>
        public override Color GetColor()
        {
            return this.color;
        }

        /// <summary>
        /// Gets the dino's position
        /// </summary>
        /// <returns>The dino's position as a Point</returns>
        public override Point GetPosition()
        {
            return this.position;
        }

        /// <summary>
        /// Gets the dino's text
        /// </summary>
        /// <returns>The dino's text as a string value</returns>
        public override string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// Gets the dino's 
        /// </summary>
        /// <returns>The dino's </returns>
        public override int GetFontSize()
        {
            return this.fontSize;
        }

        /// <summary>
        /// Gets the dino's velocity
        /// </summary>
        /// <returns>The dino's velocity as a Point</returns>
        public override Point GetVelocity()
        {
            return velocity;
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            dino.MoveNext();
        }

        /// <summary>
        /// Prepares the Dino by setting all its attributes
        /// </summary>
        private void PrepareBody()
        {
            Point position = this.position;
            Point velocity = this.velocity;
            string text = this.text;
            Color color = this.color;
            this.SetPosition(position);
            this.SetVelocity(velocity);
            this.SetText(text);
            this.SetColor(color);
        }
    }
}
