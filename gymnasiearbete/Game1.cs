using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gymnasiearbete
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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
        
        public Texture2D gamecircleYImg;
        public Texture2D gamecircleGImg;
        public Texture2D gamecircleRImg;
        public Texture2D gamecircleBImg;

        //Spellogik variabler

        public static bool HasSelectedGP = false;
        public int playercounter = 1;
        public static bool HasSelectedPlayeramount = false;
        public List<Players> playerhandler;
        
        

        //Spelareväljare

        public List<Object> playerselectorobjects;
        public Texture2D downarrowImg;
        public Texture2D uparrowImg;
        public Texture2D blacksquareImg;
       







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
            playerselectorobjects = new List<Object>();
           

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
            playerhandler.Add(new Players(gamecircleYImg, new Vector2(100, 100), 0.0f, 1.0f, 0, "", 50000, 0, 0, 0));
            playerhandler.Add(new Players(gamecircleGImg, new Vector2(100, 100), 0.0f, 1.0f, 0, "", 50000, 0, 0, 0));
            playerhandler.Add(new Players(gamecircleRImg, new Vector2(100, 100), 0.0f, 1.0f, 0, "", 50000, 0, 0, 0));
            playerhandler.Add(new Players(gamecircleBImg, new Vector2(100, 100), 0.0f, 1.0f, 0, "", 50000, 0, 0, 0));
        }

        protected override void Update(GameTime gameTime)
        {
            mousereader.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GSDecider.UpdateGamestates(gamebuttons);

            if (mousereader.LeftClick() && playercounter < 4 && playerselectorobjects[0]._bb.Contains(mousereader.mouseState.Position))

            { 
                    playercounter++;
                
          
                    
            }
            if (mousereader.LeftClick() && playercounter > 1 && playerselectorobjects[2]._bb.Contains(mousereader.mouseState.Position))
            {
                    playercounter--;
            }

            if (mousereader.keyState.IsKeyDown(Keys.Enter))
            {
                HasSelectedPlayeramount = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            

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

                case GSDecider.Gamestates.grid:
                    gamestatetextures[1].Draw(_spriteBatch);

                    switch (GSDecider.GCurrentState)
                    {
                        case GSDecider.Gamemodes.singleplayer:
                            HasSelectedGP = false;
                            break;
                        case GSDecider.Gamemodes.multiplayer:


                          

                        HasSelectedGP = false;
                        if (HasSelectedPlayeramount != true)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                playerselectorobjects[i].Draw(_spriteBatch);
                            }
                            _spriteBatch.DrawString(väljspelaretext, "Hur manga ar ni som vill spela?", new Vector2(50, 800), Color.Black);
                            _spriteBatch.DrawString(väljspelaretexträknare, +playercounter + "", new Vector2(835, 815), Color.Black);

                            

                              
                        }
                            
                            break;
                    }
                    if (HasSelectedGP == true)
                    {
                        lowerbar[0].Draw(_spriteBatch);

                        for (int i = 0; i < 4; i++)
                        {
                            gamepieces[i].Draw(_spriteBatch);
                        }

                        for (int i = 0; i < gamepieces.Count; i++)
                        {
                            if (mousereader.LeftClick() && gamepieces[i]._bb.Contains(mousereader.mouseState.Position))
                            {
                                playerhandler[i].Draw(_spriteBatch);
                            }
                        }
                        
                       
                        

                    }


                    break;

                case GSDecider.Gamestates.plantcard:
                    gamestatetextures[2].Draw(_spriteBatch);
                    for(int i = 0; i < cereal.Count; i++)
                    {
                        cereal[i].Draw(_spriteBatch);
                    }

                    break;

                case GSDecider.Gamestates.seasoncardY:
                    Seasoncards[0].Draw(_spriteBatch);

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
