using System;

namespace DinoGame2.Game.Casting
{
    public class Enemy : Actor
    {
        int direction;
        Point velocity;
        Color color;
        string text;
        Point position;
        public Enemy()
        {
            SetupEnemy();
        }

        /// <summary>
        /// Adds the current position to the velocity to get the new position of the instance of enemy.
        /// </summary>
        public override void MoveNext()
        {
            Point position = new Point(this.GetPosition().GetX(), this.GetPosition().GetY());
            if (this.GetPosition().GetX() == 0)
            {
                this.velocity = new Point (1, 0);
            }
            if (this.GetPosition().GetY() == Constants.MAX_Y / Constants.CELL_SIZE)
            {
                this.velocity = new Point (-1, 0);
            }
            Point NewPosition = new Point(position.GetX() + velocity.GetX(), position.GetY() + velocity.GetY());
            this.SetPosition(NewPosition);
        }

        /// <summary>
        /// Randomly gets a starting velocity for the instance of enemy. (left or right)
        /// </summary>
        private Point EnemyChoosestartingDirection()
        {
            Random random = new Random();
            direction = random.Next(1, 3);
            //give the object a direction based on the direction variable
            //code for moving to the right
            if (direction == 1)
            {
                velocity = new Point (1,0);
            }
            //code for moving to the left
            else if (direction == 2)
            {
                velocity = new Point (-1,0);
            }
            return velocity;
        }

        /// <summary>
        /// Creates a random position for the enemy instance to spawn.
        /// </summary>
        private Point EnemyCreateStartPosition()
        {
            Random random = new Random();
            int EnemyStartingPositionY_Value = random.Next(Constants.Enemy_Min_Row, Constants.Enemy_Max_Row);
            return new Point (Constants.MAX_X / 2,EnemyStartingPositionY_Value * Constants.CELL_SIZE);
        }

        /// <summary>
        /// SetupEnemy sets all the values of the enemy instance.
        /// </summary>
        public void SetupEnemy()
        {   
            this.position = EnemyCreateStartPosition();
            this.velocity = EnemyChoosestartingDirection();
            this.text = "O";
            this.color = Constants.RED;
            this.SetVelocity(velocity);
            this.SetColor(color);
            this.SetText(text);
            this.SetPosition(position);
        }

















    }
}




