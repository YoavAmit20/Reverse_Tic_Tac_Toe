using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;


namespace GameGui
{
    internal class PlayButton : Button
    {

        private readonly Coordinate r_ButtonPosition;

        public PlayButton(int i_XPosition, int i_YPosition) : base()
        {
            r_ButtonPosition = new Coordinate(i_XPosition, i_YPosition);
        }

        public Coordinate ButtonPosition { get { return r_ButtonPosition; } }
    }
}
