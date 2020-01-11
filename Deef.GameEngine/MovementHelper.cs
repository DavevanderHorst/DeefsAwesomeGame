namespace Deef.GameEngine
{
    public class MovementHelper
    {
        public int Top { get; set; }
        public int Left { get; set; }
        
        public bool Changed { get; set; }
        public int OldTop { get; set; }
        public int OldLeft { get; set; }

        public void MoveDown()
        {
            MoveTo(Left, Top + 1);
        }

        public void MoveUp()
        {
            MoveTo(Left, Top - 1);
        }

        public void MoveLeft()
        {
            MoveTo(Left - 1, Top);
        }

        public void MoveRight()
        {
            MoveTo(Left + 1, Top);
        }

        public void MoveTo(int newLeft, int newTop)
        {
            Changed = true;
            OldLeft = Left;
            OldTop = Top;

            Left = newLeft;
            Top = newTop;
        }

     
    }
}