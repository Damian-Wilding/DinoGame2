using System;

namespace DinoGame2.Game.Casting
{
    public class Enemy : Actor
    {
        int direction; 
        public Enemy()
        {
            Random random = new Random();
            direction = random.Next(1, 3);
        }

        //program the enemies movements
        public override void MoveNext()
        {

            Point NewPosition;
            Point velocity;
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
            Point position = new Point(this.GetPosition().GetX(), this.GetPosition().GetY());
            NewPosition = new Point(position.GetX() + velocity.GetX(), position.GetY() + velocity.GetY());
            this.SetPosition(NewPosition);
        }


















    }
}




