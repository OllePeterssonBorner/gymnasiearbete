using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gymnasiearbete
{
    public class Buttons
    {
        public Texture2D _img;
        public Vector2 _pos;
        protected Color _color;
        protected Vector2 _origin = Vector2.Zero;
        protected float _scale;
        public Rectangle _bb;



        public Buttons(Texture2D img, Vector2 pos, float scale)
        {

            Random r = new Random();

            this._img = img;
            this._pos = pos;
            this._origin = Vector2.Zero;
            this._bb = new Rectangle((int)pos.X, (int)pos.Y, img.Width, img.Height);
            this._scale = scale;
            this._color = Color.White;
        }


        public virtual void Update(int screen_width, int screen_height)
        {

            //_bb = new Rectangle(_pos.ToPoint(), new Point(img.Width, img.Height));
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(_img, _pos, null, _color, 0, _origin, _scale, SpriteEffects.None, 0.0f);
        }

        public bool Hit(Rectangle otherbb)
        {


            if (_bb.Intersects(otherbb))
            {

                return true;


            }
            return false;






        }





    }

}

