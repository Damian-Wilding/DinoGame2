using System;

namespace DinoGame2.Game.Casting
{
    public class Enemy : Actor
    {
        int direction;
        Point velocity = new Point(0,0);
        public Enemy()
        {
            Random random = new Random();
            direction = random.Next(1, 3);
            //this.SetColor(Constants.RED);     //not needed for now since this is handled in the collision class
        }

        //program the enemies movements
        public override void MoveNext()
        {
//______________________________________________________ put in something here later to make the velocitoes change when the enemies touch the side of the screen.
            Point NewPosition;
            
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




