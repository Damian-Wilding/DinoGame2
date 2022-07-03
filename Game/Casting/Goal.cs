using System;

namespace DinoGame2.Game.Casting
{
    public class Goal : Actor
    {
        
        public Goal()
        {
            MakeTheGoal();
        }
       
        public void MakeTheGoal()
        {
            this.SetColor(Constants.YELLOW);
            //this.SetPosition(new Point(1,0));
            this.SetText("O");
            this.SetVelocity(new Point(0,0));

        }
    }
}