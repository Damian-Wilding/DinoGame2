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
        Actor dino = new Actor();

        /// <summary>
        /// Constructs a new instance of a Dino.
        /// </summary>
        public Dino()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        //public List<Actor> GetBody()
        //{
        //    return new List<Actor>(segments.Skip(1).ToArray());
        //}

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetDino()
        {
            return dino;
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

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            dino.SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody()
        {
            //int x = Constants.MAX_X / 2;
            //int y = 10;
            Point position = Constants.DinoSpawn;
            Point velocity = new Point(0, 0);
            string text = 1 == 0 ? "8" : "#";
            Color color = 1 == 0 ? Constants.BLUE : Constants.BLUE;
            //Actor segment = new Actor();
            dino.SetPosition(position);
            dino.SetVelocity(velocity);
            dino.SetText(text);
            dino.SetColor(color);
            //segments.Add(segment);
            
        }
    }
}
