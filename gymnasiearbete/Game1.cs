using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;


namespace gymnasiearbete
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Color javariabel = Color.Black;
        public List<Object> gamestatetextures;
        public Texture2D gridImg;
        public Texture2D menuImg;
        public Texture2D plantcardImg;

        // Lista och texturer för säsongskorten
        public List<Object> Seasoncards;
        public Texture2D seasoncardSpringImg;
        public Texture2D seasoncardSummerImg;
        public Texture2D seasoncardAutumnImg;
        public Texture2D seasoncardWinterImg;

        // Lista och texturer för säden
        public List<Object> cereal;
        public Texture2D beetplantImg;
        public Texture2D potatoplantImg;
        public Texture2D carrotplantImg;
        public Texture2D wheatplantImg;

        //Texturer för buttons
        public List<Buttons> gamebuttons;
        public Texture2D mainmenubutton1Img;
        public Texture2D mainmenubutton2Img;

        public SpriteFont enspelarlagetext;
        public SpriteFont flerspelarlagetext;
        public SpriteFont väljspelaretext;
        public SpriteFont väljspelaretexträknare;
        public SpriteFont väljspelarefärg;
        public SpriteFont seasontexts;

        public static List<String> seasonYtexts;
        public static List<String> seasonGtexts;
        public static List<String> seasonRtexts;
        public static List<String> seasonBtexts;

        //Lista och texturer lower bar
        public List<Buttons> lowerbar;
        public Texture2D selectgamepiecelowerbarImg;


        //Lista och texturer för game player

        public List<Object> gplayer;

        //Lista och texturer för spelpjäser
        public List<Object> gamepieces;
        public Texture2D gamepieceYImg;
        public Texture2D gamepieceGImg;
        public Texture2D gamepieceRImg;
        public Texture2D gamepieceBImg;


        public List<Object> gamecircle;

        public Texture2D gamecircleYImg;
        public Texture2D gamecircleGImg;
        public Texture2D gamecircleRImg;
        public Texture2D gamecircleBImg;

        //Spellogik variabler

        public static bool HasSelectedGP = false;
        public static int playercounter = 1;
        public bool HasSelectedPlayeramount = false;
        public static List<Players> playerhandler;
        public static bool[] availablecolor;
        public static bool[] tts;


        public static bool seasoncallerbool = false;

        public static Random r = new Random();

        public static bool timetodraw = false;

        public int selectedsingleplayercolor;

        public static bool tsornot = false;

        public static bool pressingdie = false;

     

        public static bool nhps = false;

        public static bool bondebfgplz = false;



        System.Timers.Timer stopwatch = new System.Timers.Timer(5000);

        //Spelareväljare

        public List<Object> playerselectorobjects;
        public Texture2D downarrowImg;
        public Texture2D uparrowImg;
        public Texture2D blacksquareImg;

        public static List<Houses> houses = new List<Houses>();
        public Texture2D Torp1;
        public Texture2D Torp2;
        public Texture2D Torp3;
        public Texture2D Torp4;
        public Texture2D Bondgård1;
        public Texture2D Bondgård2;
        public Texture2D Bondgård3;
        public Texture2D Herrgård1;
        public Texture2D Herrgård2;
        public Texture2D Slott;

        //tärning
        public static List<Object> dice = new List<Object>();
        public Texture2D die1;
        public Texture2D die2;
        public Texture2D die3;
        public Texture2D die4;
        public Texture2D die5;
        public Texture2D die6;
        public static int[] dtd = new int[6];



        public static List<Rectangle> hitboxes = new List<Rectangle>();

        public static List<int> redboxes = new List<int>() { 7, 12, 19, 24, 31, 35, 40, 51, 56, 61, 68, 73, 80, 85, 90 };


        public static void BuildGameBoardHitboxes()
        {
            int startX1 = 60;
            int startY1 = 740;

            int blockWidth1 = 33;
            int blockHeight1 = 25;

            int startX2 = 978;
            int startY2 = 46;



            int startX3 = 46;
            int startY3 = 20;



            int startX4 = 20;
            int startY4 = 60;




            for (int i = 0; i < 26; i++)
            {
                hitboxes.Add(new Rectangle(startX1 + i * blockWidth1 + i, startY1, blockWidth1, blockHeight1));
            }
            for (int i = 19; i > 0; i--)
            {
                hitboxes.Add(new Rectangle(startX2, startY2 + i * blockWidth1 + i, blockHeight1, blockWidth1));
            }
            for (int i = 26; i > 0; i--)
            {
                hitboxes.Add(new Rectangle(startX3 + i * blockWidth1 + i, startY3, blockWidth1, blockHeight1));
            }
            for (int i = 0; i < 19; i++)
            {
                hitboxes.Add(new Rectangle(startX4, startY4 + i * blockWidth1 + i, blockHeight1, blockWidth1));
            }
        }




        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = gamehandler.screen_width;
            _graphics.PreferredBackBufferHeight = gamehandler.screen_height;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Currentstate = Gamestates.menu;

            Seasoncards = new List<Object>();
            gamestatetextures = new List<Object>();
            gplayer = new List<Object>();
            cereal = new List<Object>();
            gamebuttons = new List<Buttons>();
            lowerbar = new List<Buttons>();
            gamepieces = new List<Object>();

            gamecircle = new List<Object>();
            playerselectorobjects = new List<Object>();
            playerhandler = new List<Players>();
            houses = new List<Houses>();

            seasonYtexts = new List<String>();
            seasonGtexts = new List<String>();
            seasonRtexts = new List<String>();
            seasonBtexts = new List<String>();



            dice = new List<Object>();

            dtd = new int[6];


            BuildGameBoardHitboxes();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Textrutor
            enspelarlagetext = Content.Load<SpriteFont>("sptext");
            flerspelarlagetext = Content.Load<SpriteFont>("sptext");
            väljspelaretext = Content.Load<SpriteFont>("sptext");
            väljspelaretexträknare = Content.Load<SpriteFont>("sptext");
            väljspelarefärg = Content.Load<SpriteFont>("sptext");

            gridImg = Content.Load<Texture2D>("bondespelet spelplan");
            menuImg = Content.Load<Texture2D>("mainmenu flat");
            plantcardImg = Content.Load<Texture2D>("plantcard screen");

            gamestatetextures.Add(new Object(menuImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));
            gamestatetextures.Add(new Object(gridImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));
            gamestatetextures.Add(new Object(plantcardImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));

            //seasoncard textures
            seasoncardSpringImg = Content.Load<Texture2D>("seasoncard vår");
            seasoncardSummerImg = Content.Load<Texture2D>("seasoncard sommar");
            seasoncardAutumnImg = Content.Load<Texture2D>("seasoncard höst");
            seasoncardWinterImg = Content.Load<Texture2D>("seasoncard vinter");

            Seasoncards.Add(new Object(seasoncardSpringImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));
            Seasoncards.Add(new Object(seasoncardSummerImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));
            Seasoncards.Add(new Object(seasoncardAutumnImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));
            Seasoncards.Add(new Object(seasoncardWinterImg, new Vector2(0, 0), new Vector2(0, 0), 0.0f, 0, 1.0f, 0));

            // plantcard cerealtextures
            beetplantImg = Content.Load<Texture2D>("t beta");
            potatoplantImg = Content.Load<Texture2D>("t potatis");
            carrotplantImg = Content.Load<Texture2D>("t morot");
            wheatplantImg = Content.Load<Texture2D>("t säd");

            cereal.Add(new Object(beetplantImg, new Vector2(524, 147), new Vector2(0, 0), 0.0f, 0, 0.305f, 0));
            cereal.Add(new Object(potatoplantImg, new Vector2(428, 143), new Vector2(0, 0), 0.0f, 0, 0.305f, 0));
            cereal.Add(new Object(carrotplantImg, new Vector2(325, 147), new Vector2(0, 0), 0.0f, 0, 0.27f, 0));
            cereal.Add(new Object(wheatplantImg, new Vector2(229, 144), new Vector2(0, 0), 0.0f, 0, 0.255f, 0));

            // main menu options
            mainmenubutton1Img = Content.Load<Texture2D>("mainmenu buttontemplate");
            mainmenubutton2Img = Content.Load<Texture2D>("mainmenu button 2");

            gamebuttons.Add(new Buttons(mainmenubutton2Img, new Vector2(286, 50), 1.0f));
            gamebuttons.Add(new Buttons(mainmenubutton2Img, new Vector2(286, 200), 1.0f));

            //lowerbar textures
            selectgamepiecelowerbarImg = Content.Load<Texture2D>("lower bar template");

            lowerbar.Add(new Buttons(selectgamepiecelowerbarImg, new Vector2(0, 785), 1.0f));

            //spelpjästexturer

            //gamepieceYImg = Content.Load<Texture2D>("");
            gamepieceYImg = Content.Load<Texture2D>("spelpjäs gul t");
            gamepieceGImg = Content.Load<Texture2D>("spelpjäs grön t");
            gamepieceRImg = Content.Load<Texture2D>("spelpjäs röd t");
            gamepieceBImg = Content.Load<Texture2D>("spelpjäs blå t");

            gamepieces.Add(new Object(gamepieceYImg, new Vector2(500, 796), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            gamepieces.Add(new Object(gamepieceGImg, new Vector2(600, 796), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            gamepieces.Add(new Object(gamepieceRImg, new Vector2(700, 796), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            gamepieces.Add(new Object(gamepieceBImg, new Vector2(800, 796), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));

            //spelareväljare
            downarrowImg = Content.Load<Texture2D>("pil nedåt");
            uparrowImg = Content.Load<Texture2D>("pil uppåt");
            blacksquareImg = Content.Load<Texture2D>("välj spelare ruta");


            playerselectorobjects.Add(new Object(uparrowImg, new Vector2(980, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));
            playerselectorobjects.Add(new Object(blacksquareImg, new Vector2(800, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            playerselectorobjects.Add(new Object(downarrowImg, new Vector2(760, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));

            //förbestämda spelare


            gamecircleYImg = Content.Load<Texture2D>("cirkel gul t");
            gamecircleGImg = Content.Load<Texture2D>("cirkel grön t");
            gamecircleRImg = Content.Load<Texture2D>("cirkel röd t");
            gamecircleBImg = Content.Load<Texture2D>("cirkel blå t");

            gamecircle.Add(new Object(gamecircleYImg, new Vector2(980, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));
            gamecircle.Add(new Object(gamecircleGImg, new Vector2(980, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));
            gamecircle.Add(new Object(gamecircleRImg, new Vector2(980, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));
            gamecircle.Add(new Object(gamecircleBImg, new Vector2(980, 800), new Vector2(0, 0), 0.0f, 1.58f, 1.0f, 0));


            playerhandler.Add(new Players(gamecircleYImg, new Vector2(20, 700), 1.0f, "Pog 1", 50000, 1, 0, 0, -1, 0, 0, 0, 0, false));
            playerhandler.Add(new Players(gamecircleGImg, new Vector2(20, 700), 1.0f, "Pog 2", 50000, 1, 0, 0, -1, 0, 0, 0, 0, false));
            playerhandler.Add(new Players(gamecircleRImg, new Vector2(20, 700), 1.0f, "Pog 3", 50000, 1, 0, 0, -1, 0, 0, 0, 0, false));
            playerhandler.Add(new Players(gamecircleBImg, new Vector2(20, 700), 1.0f, "Pog 4", 50000, 1, 0, 0, -1, 0, 0, 0, 0, false));

            //tärning

            die1 = Content.Load<Texture2D>("tärning ett");
            die2 = Content.Load<Texture2D>("tärning två");
            die3 = Content.Load<Texture2D>("tärning tre");
            die4 = Content.Load<Texture2D>("tärning fyra");
            die5 = Content.Load<Texture2D>("tärning fem");
            die6 = Content.Load<Texture2D>("tärning sex");

            dice.Add(new Object(die1, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            dice.Add(new Object(die2, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            dice.Add(new Object(die3, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            dice.Add(new Object(die4, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            dice.Add(new Object(die5, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));
            dice.Add(new Object(die6, new Vector2(400, 800), new Vector2(0, 0), 0.0f, 0.0f, 1.0f, 0));


            seasontexts = Content.Load<SpriteFont>("seasonYtexts");

            seasonYtexts.Add("Hola! Kommer sno din veckopeng bror! \n \n -10 kr");
            seasonYtexts.Add("Hola! Du gloemde ge bibolek bok! \n \n -299 kr");
            seasonYtexts.Add("Hola! Du gloemde pausa VOI, surprise faktura! \n \n -1000 kr");
            seasonYtexts.Add("Hola! Du foerlorade inkomst; ortengaeng snodde sockerbetan! \n \n -100 kr");
            seasonYtexts.Add("Hola! Du slangade bensin fraan grannen, han gav dig \n \n 19 kr");
            seasonYtexts.Add("Hola! Din faster gick bort, tragiskt. Begravningsomkostnaderna landar paa dig \n \n -1800 kr");
            seasonYtexts.Add("Hola! Din faster gick bort, tragiskt. Hon laemnade ett ansenligt arv \n \n 200000 kr");

            

            houses.Add(new Houses("Torp1", new Vector2(739, 560), 119, 33, 1.0f, 50000));
            houses.Add(new Houses("Torp2", new Vector2(118, 400), 83, 54, 1.0f, 50000));
            houses.Add(new Houses("Torp3", new Vector2(424, 150), 87, 63, 1.0f, 50000));
            houses.Add(new Houses("Torp4", new Vector2(168, 194), 55, 66, 1.0f, 50000));

            houses.Add(new Houses("Bondgaard1", new Vector2(69, 117), 96, 73, 1.0f, 200000));
            houses.Add(new Houses("Bondgaard2", new Vector2(867, 89), 103, 93, 1.0f, 200000));
            houses.Add(new Houses("Bondgaard3", new Vector2(408, 631), 119, 87, 1.0f, 200000));

            houses.Add(new Houses("Herrgaard1", new Vector2(771, 221), 110, 92, 1.0f, 750000));
            houses.Add(new Houses("Herrgaard2", new Vector2(70, 626), 119, 104, 1.0f, 750000));

            houses.Add(new Houses("Slott", new Vector2(405, 298), 182, 208, 1.0f, 2750000));






        }




        protected override void Update(GameTime gameTime)
        {
            mousereader.Update();



            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GSDecider.UpdateGamestates(gamebuttons);

            if (mousereader.LeftClick() && playercounter < 4 && playerselectorobjects[0]._bb.Contains(mousereader.mouseState.Position) && GSDecider.Currentstate == GSDecider.Gamestates.grid && !HasSelectedGP)

            {

                playercounter++;



            }

            //if (GSDecider)
            if (mousereader.LeftClick() && playercounter > 1 && playerselectorobjects[2]._bb.Contains(mousereader.mouseState.Position) && GSDecider.Currentstate == GSDecider.Gamestates.grid && !HasSelectedGP)
            {
                playercounter--;
            }


            if (mousereader.LeftClick())
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i]._bb.Contains(mousereader.mouseState.Position) &&  GSDecider.Currentstate == GSDecider.Gamestates.grid && playerhandler[playercounter - 1]._done == true)
                    {

                        pressingdie = true;



                    }
                }

            }

            if (mousereader.LeftClick() && HasSelectedPlayeramount && (playerhandler[whoseturn + 1]._beetA + playerhandler[whoseturn + 1]._potaA + playerhandler[whoseturn + 1]._carrA + playerhandler[whoseturn + 1]._wheaA) <= 2)
            {

                if (cereal[0]._bb.Contains(mousereader.mouseState.Position))
                {
                    playerhandler[whoseturn + 1]._beetA += 1;
                }
                else if (cereal[1]._bb.Contains(mousereader.mouseState.Position))
                {
                    playerhandler[whoseturn + 1]._potaA += 1;
                }
                else if (cereal[2]._bb.Contains(mousereader.mouseState.Position))
                {
                    playerhandler[whoseturn + 1]._carrA += 1;
                }
                else if (cereal[3]._bb.Contains(mousereader.mouseState.Position))
                {
                    playerhandler[whoseturn + 1]._wheaA += 1;
                }

                
               
            }
            //
            if (GSDecider.Currentstate == GSDecider.Gamestates.seeddecider)
            {
                if (mousereader.LeftClick())
                {

                    for (int i = 0; i < houses.Count; i++)
                    {
                        if (houses[i]._bb.Contains(mousereader.mouseState.Position))
                        {
                            playerhandler[whoseturn + 1]._selectedfarm = i;



                        }
                    }


                }
                if ((whoseturn + 2) <= playercounter && playerhandler[playercounter - 1]._selectedfarm == 0 && mousereader.KeyPressed(Keys.Enter))
                {
                    playerhandler[whoseturn + 1]._done = true;
                    WhoseTurnReloop();

                }

                else if (playerhandler[playercounter - 1]._selectedfarm != 0 && GSDecider.Currentstate == GSDecider.Gamestates.seeddecider)
                {
                    nhps = true;
                    whoseturn = 0;
                    GSDecider.Currentstate = GSDecider.Gamestates.grid;
                }
            }
          

            //
            if (mousereader.keyState.IsKeyDown(Keys.Enter) && ((playerhandler[whoseturn + 1]._beetA + playerhandler[whoseturn + 1]._potaA + playerhandler[whoseturn + 1]._carrA + playerhandler[whoseturn + 1]._wheaA) >= 3))
            {
                

                if ((whoseturn + 2) <= playercounter)
                {
                    playerhandler[whoseturn + 1]._done = true;
                    WhoseTurnReloop();
                  
                }

                            
            }

            if (playerhandler[playercounter - 1]._done == true && GSDecider.Currentstate == GSDecider.Gamestates.plantcard)
            {
                nhps = true;
                whoseturn = 0;
                GSDecider.Currentstate = GSDecider.Gamestates.grid;
            }


            // playerhandler[whoseturn]._gamepiececolor = 2;


            if (mousereader.keyState.IsKeyDown(Keys.Enter) && HasSelectedPlayeramount != true)
            {

                HasSelectedPlayeramount = true;

            }
            if (mousereader.keyState.IsKeyDown(Keys.Enter) && seasoncallerbool == true)
            {



                GSDecider.Currentstate = GSDecider.Gamestates.grid;
                seasoncallerbool = false;

            }

            

            



            if (GSDecider.singleplayer == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (mousereader.LeftClick() && gamepieces[i]._bb.Contains(mousereader.mouseState.Position))
                    {
                        HasSelectedGP = true;
                        selectedsingleplayercolor = i;
                    }
                }
            }



            base.Update(gameTime);



        }
        public static int whoseturn = -1;
        public static int fun = 0;
        public static int SeasonCardCaller(Players player, int moneyinflux)
        {

            seasoncallerbool = true;

            fun = r.Next(0, seasonYtexts.Count);

            if (player._squareposition <= 26)
            {
                GSDecider.Currentstate = GSDecider.Gamestates.seasoncardY;
            }
            else if (player._squareposition >= 27 && player._squareposition <= 45)
            {
                GSDecider.Currentstate = GSDecider.Gamestates.seasoncardG;
            }
            else if (player._squareposition >= 46 && player._squareposition <= 71)
            {
                GSDecider.Currentstate = GSDecider.Gamestates.seasoncardR;
            }
            else if (player._squareposition >= 72)
            {
                GSDecider.Currentstate = GSDecider.Gamestates.seasoncardB;
            }

            string[] splitted = seasonYtexts[fun].Split(' ');
            player._netvalue += Convert.ToInt32(splitted[splitted.Length - 2]);

            return moneyinflux;
        }


        public static int WhoseTurnReloop()
        {
            if (whoseturn == playercounter - 2)
            {
                whoseturn = -1;
            }
            else
            {
                whoseturn++;
            }

            return whoseturn;
        }

        static double futureTimestamp = 0.1;
        static int currentDie = 1;

        static int AbsoluteDrawer(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;



            if (futureTimestamp < currentTime && newGT > currentTime)
            {
                futureTimestamp = currentTime + 0.1;
                currentDie = r.Next(1, 7);



            }
            else if (newGT < currentTime && futureTimestamp > currentTime)
            {
                if (playerhandler[whoseturn + 1]._squareposition <= 89)
                {
                    playerhandler[whoseturn + 1]._squareposition += currentDie;
                }
                else if (playerhandler[whoseturn + 1]._squareposition == 90)
                {
                    playerhandler[whoseturn + 1]._squareposition = (playerhandler[whoseturn + 1]._squareposition + currentDie) - 90;
                }
               

                foreach (int o in redboxes)
                {
                    try
                    {
                        if (playerhandler[whoseturn + 1]._squareposition + 1 == o)
                        {
                            SeasonCardCaller(playerhandler[whoseturn + 1], 1);
                        }
                    }
                    catch
                    {

                    }
                }
              

                playerhandler[whoseturn+ 1]._pos.X = hitboxes[playerhandler[whoseturn+ 1]._squareposition].X;
                playerhandler[whoseturn + 1]._pos.Y = hitboxes[playerhandler[whoseturn +1]._squareposition].Y;



            }








            return currentDie;



        }

        public static double newGT = 0;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            Random r = new Random();







            switch (GSDecider.Currentstate)
            {
                case GSDecider.Gamestates.menu:
                    gamestatetextures[0].Draw(_spriteBatch);
                    for (int i = 0; i < gamebuttons.Count; i++)
                    {
                        gamebuttons[i].Draw(_spriteBatch);
                    }
                    _spriteBatch.DrawString(enspelarlagetext, "Enspelarlage", new Vector2(390, 80), Color.PaleTurquoise);
                    _spriteBatch.DrawString(flerspelarlagetext, "Flerspelarlage", new Vector2(390, 220), Color.PaleTurquoise);


                    break;




                case GSDecider.Gamestates.seeddecider:

                   
                        gamestatetextures[1].Draw(_spriteBatch);

                    _spriteBatch.DrawString(enspelarlagetext, playerhandler[whoseturn + 1]._playername + "tur att vaelja gaard, tryck enter foer att laasa ditt val", new Vector2(50, 800), Color.PaleTurquoise);

                 
                    if (playerhandler[playercounter - 1]._selectedfarm != 0)
                    {
                        GSDecider.Currentstate = GSDecider.Gamestates.plantcard;
                    }
                  
                       
                    

                    break;



                case GSDecider.Gamestates.grid:
                    gamestatetextures[1].Draw(_spriteBatch);

                    switch (GSDecider.GCurrentState) // Single/multi-player avgörande
                    {

                        //Singlelayerutritning

                        case GSDecider.Gamemodes.singleplayer:

                            HasSelectedPlayeramount = true;

                            if (!HasSelectedGP)
                            {
                                _spriteBatch.DrawString(väljspelarefärg, "Valj farg:", new Vector2(50, 815), Color.Black);

                                for (int i = 0; i < 4; i++)
                                {
                                    gamepieces[i].Draw(_spriteBatch);
                                }
                            }
                            else if (HasSelectedGP)
                            {
                                playerhandler[selectedsingleplayercolor].Draw(_spriteBatch);
                            }







                            break;


                        //Multiplayerutritning

                        case GSDecider.Gamemodes.multiplayer:


                            AbsoluteDrawer(gameTime, _spriteBatch);

                            if (nhps == true)
                            {
                                dice[currentDie - 1].Draw(_spriteBatch);
                            }


                            if (!HasSelectedPlayeramount)
                            {

                                for (int i = 0; i < 3; i++)
                                {
                                    playerselectorobjects[i].Draw(_spriteBatch);
                                }

                                _spriteBatch.DrawString(väljspelaretext, "Hur manga ar ni som vill spela?", new Vector2(50, 800), Color.Black);
                                _spriteBatch.DrawString(väljspelaretexträknare, +playercounter + "", new Vector2(835, 815), Color.Black);






                            }

                            else if (HasSelectedPlayeramount)
                            {
                                if (pressingdie == true)
                                {
                                    WhoseTurnReloop();
                                    newGT = gameTime.TotalGameTime.TotalSeconds + 2;
                                    pressingdie = false;
                                }

                                if (nhps == false && playerhandler[playercounter - 1]._done == false)
                                {
                                    GSDecider.Currentstate = GSDecider.Gamestates.seeddecider;
                                }




                                if (nhps != false)
                                {
                                    for (int i = 0; i < playercounter; i++)
                                    {
                                        if (playerhandler[i] == playerhandler[whoseturn + 1])
                                        {
                                            _spriteBatch.DrawString(väljspelaretext, playerhandler[i]._playername, new Vector2(50, 780), Color.Red);
                                            _spriteBatch.DrawString(väljspelaretext, +playerhandler[i]._netvalue + " SEK", new Vector2(50, 820), Color.Black);
                                            _spriteBatch.DrawString(väljspelaretext, houses[playerhandler[2]._selectedfarm]._name + "", new Vector2(50, 840), Color.Black);
                                        }
                                        else
                                        {
                                            _spriteBatch.DrawString(seasontexts, playerhandler[i]._playername, new Vector2(580 + i * 100, 800), Color.Black);
                                            _spriteBatch.DrawString(seasontexts, +playerhandler[i]._netvalue + " SEK", new Vector2(580 + i * 100, 820), Color.Black);


                                            _spriteBatch.DrawString(seasontexts, houses[playerhandler[2]._selectedfarm]._name + "", new Vector2(580 + i * 100, 840), Color.Black);

                                            gamecircle[i]._pos = new Vector2(660 + i * 100, 787);

                                            gamepieces[i]._pos = new Vector2(houses[playerhandler[i]._selectedfarm]._pos.X, houses[playerhandler[i]._selectedfarm]._pos.Y);

                                            gamecircle[i].Draw(_spriteBatch);
                                        }
                                       

                                        
                                    }



                                   





                                    for (int i = 0; i < playercounter; i++)
                                    {
                                        playerhandler[i].Draw(_spriteBatch);
                                    }
                                }
                               




                            }




                            break;
                    }

                    //for (int i = 0; i < hitboxes.Count; i++)
                    //{
                    //    _spriteBatch.Draw(blacksquareImg, hitboxes[i], Color.White);

                    //    //_spriteBatch.DrawString(väljspelaretext, + (i + 1) + "", new Vector2(hitboxes[i].X, hitboxes[i].Y), Color.Black);
                    //}






                    //if (HasSelectedGP == false && HasSelectedPlayeramount == true)
                    //{


                    //    lowerbar[0].Draw(_spriteBatch);

                    //        for (int i = 0; i < playercounter; i++)
                    //        {
                    //            if (availablecolor[i] == true)
                    //            {
                    //                gamepieces[i].Draw(_spriteBatch);
                    //            }

                    //        }














                    //}

                    break;







                case GSDecider.Gamestates.plantcard:

                    if (nhps == false)
                    {
                        gamestatetextures[2].Draw(_spriteBatch);
                        for (int i = 0; i < cereal.Count; i++)
                        {
                            cereal[i].Draw(_spriteBatch);
                        }

                        _spriteBatch.DrawString(enspelarlagetext, playerhandler[whoseturn + 1]._playername + "tur att vaelja saedeslag, tryck enter", new Vector2(390, 80), Color.PaleTurquoise);
                     
                        _spriteBatch.DrawString(enspelarlagetext, "vaelj saedeslag genom att trycka på bilderna, du ska trycka 3 gaanger ", new Vector2(390, 80), Color.PaleTurquoise);

                        _spriteBatch.DrawString(väljspelaretext, +playerhandler[whoseturn + 1]._wheaA + " st", new Vector2(50, 820), Color.Black);
                        _spriteBatch.DrawString(väljspelaretext, +playerhandler[whoseturn + 1]._carrA + " st", new Vector2(150, 820), Color.Black);
                        _spriteBatch.DrawString(väljspelaretext, +playerhandler[whoseturn + 1]._potaA + " st", new Vector2(250, 820), Color.Black);
                        _spriteBatch.DrawString(väljspelaretext, +playerhandler[whoseturn + 1]._beetA + " st", new Vector2(350, 820), Color.Black);

                        _spriteBatch.DrawString(väljspelaretext, playerhandler[whoseturn + 1]._playername, new Vector2(600, 780), Color.Black);
                    }
                   



                    //for (int i = 0; i < playercounter;)
                    //{
                    //    _spriteBatch.DrawString(väljspelaretext, playerhandler[whoseturn + 1]._playername + "tur att vaelja", new Vector2(230, 780), Color.Black);







                    //}




                    break;

                case GSDecider.Gamestates.seasoncardY:
                    Seasoncards[0].Draw(_spriteBatch);
                   
                    _spriteBatch.DrawString(seasontexts, seasonYtexts[fun], new Vector2(60, 200), Color.Black);
                    _spriteBatch.DrawString(väljspelaretext, playerhandler[whoseturn + 1]._playername, new Vector2(50, 780), Color.Red);


                    break;

                case GSDecider.Gamestates.seasoncardG:
                    Seasoncards[1].Draw(_spriteBatch);


                    break;

                case GSDecider.Gamestates.seasoncardR:
                    Seasoncards[2].Draw(_spriteBatch);

                    break;

                case GSDecider.Gamestates.seasoncardB:
                    Seasoncards[3].Draw(_spriteBatch);

                    break;
            }


           

                
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
