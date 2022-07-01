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
            //return new List<Actor>(segments.Skip(1).ToArray());
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
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        //public List<Actor> GetSegments()
        //{
        //    return segments;
        //}

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        //public void GrowTail(int numberOfSegments)
        //{
        //    for (int i = 0; i < numberOfSegments; i++)
        //    {
        //        Actor tail = segments.Last<Actor>();
        //        Point velocity = tail.GetVelocity();
        //        Point offset = velocity.Reverse();
        //        Point position = tail.GetPosition().Add(offset);

        //        Actor segment = new Actor();
        //        segment.SetPosition(position);
        //        segment.SetVelocity(velocity);
        //        segment.SetText("#");
        //        segment.SetColor(Constants.BLUE);
        //        segments.Add(segment);
        //    }
        //}

        /// <inheritdoc/>
        public override void MoveNext()
        {
            dino.MoveNext();

            //for (int i = segments.Count - 1; i > 0; i--)
            //{
            //    Actor trailing = segments[i];
            //    Actor previous = segments[i - 1];
            //    Point velocity = previous.GetVelocity();
            //    trailing.SetVelocity(velocity);
            //}
        }

        ///////////////////////////////////////////// <summary>
        ///////////////////////////////////////////// Turns the head of the snake in the given direction.
        ///////////////////////////////////////////// </summary>
        ///////////////////////////////////////////// <param name="velocity">The given direction.</param>
        //////////////////////////////////////////public void TurnHead(Point direction)
        //////////////////////////////////////////{
        //////////////////////////////////////////    dino.SetVelocity(direction);
        //////////////////////////////////////////}

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody()
        {
            //int x = Constants.MAX_X / 2;
            //int y = 10;
            
            Point position = this.position;
            Point velocity = this.velocity;
            string text = this.text;
            Color color = this.color;
            //Actor segment = new Actor();
            this.SetPosition(position);
            this.SetVelocity(velocity);
            this.SetText(text);
            this.SetColor(color);
            //segments.Add(segment);
            
        }
    }
}
