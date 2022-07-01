using System;

namespace DinoGame2.Game.Casting
{
    public class Goal : Actor
    {
        
        public Goal()
        {
            this.SetColor(Constants.BLUE);
            this.SetPosition(new Point(1,0));
            this.SetText("O");
            this.SetVelocity(new Point(0,0));
        }
       
        //public void MakeTheGoal()
        //{
        //    
        //}
    }
}