using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
namespace gymnasiearbete
{
    public class GSDecider
    {
        public enum Gamestates
        {
            menu = 0,
            grid,
            seeddecider,
            seasoncardY,
            seasoncardG,
            seasoncardR,
            seasoncardB,
            plantcard

        }
        public enum Gamemodes
        {
            undefined = -1,
            singleplayer = 0,
            multiplayer
        }

        public static Gamestates Currentstate = Gamestates.menu;
        public static Gamemodes GCurrentState = Gamemodes.undefined;

        public static bool singleplayer = false;
        public static bool multiplayer = false;

        public static void UpdateGamestates(List<Buttons> gamebuttons)
        {
            if (mousereader.LeftClick() && gamebuttons[0]._bb.Contains(mousereader.mouseState.Position) && GSDecider.Currentstate == GSDecider.Gamestates.menu)
            {
                GCurrentState = Gamemodes.singleplayer;
                Currentstate = Gamestates.grid;
                singleplayer = true;
            }
            else if (mousereader.LeftClick() && gamebuttons[1]._bb.Contains(mousereader.mouseState.Position) && GSDecider.Currentstate == GSDecider.Gamestates.menu)
            {
                GCurrentState = Gamemodes.multiplayer;
                Currentstate = Gamestates.grid;
                multiplayer = true;
            }
        }
            
    }
}
