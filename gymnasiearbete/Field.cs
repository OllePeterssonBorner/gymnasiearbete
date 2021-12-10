using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gymnasiearbete
{
    public class Field
    {
        public Texture2D _img;
        public Vector2 _pos;
        protected Color _color;
        protected double _time;
        protected Vector2 _origin = Vector2.Zero;
        protected float _scale;
        public float _rotation;
        public Rectangle _bb;
        public int _cost;
        public string _name;
       





        public Field(string name, Vector2 pos, int width, int height, float scale)
        {

            this._name = name;

            this._pos = pos;
            this._scale = scale;

            this._origin = Vector2.Zero;
            this._bb = new Rectangle((int)pos.X, (int)pos.Y, (int)width, (int)height);




            this._color = Color.White;
        }

       

        public virtual void Update(int screen_width, int screen_height)
        {

            //_bb = new Rectangle(_pos.ToPoint(), new Point(img.Width, img.Height));
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

