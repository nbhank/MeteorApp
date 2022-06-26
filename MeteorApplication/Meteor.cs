using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MeteorApplication
{
    public class Meteor : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        //more attributes coming...

        Rectangle destRect;

        public float Rotation { get; set; } = 0f;
        private float rotationChange = 0.03f;

        public float Scale { get; set; } = 1;
        private float scaleChange = 0.03f;

        private Rectangle srcRect;
        private Vector2 origin;

        private const float MAX_SCALE = 3.0F;
        private const float MIN_SCALE = 0.1f;



        public Meteor(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position): base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;

            destRect = new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);

            srcRect = new Rectangle(0, 0, tex.Width/2, tex.Height/2);
            //origin = Vector2.Zero;
            origin = new Vector2(tex.Width/2, tex.Height/2);

        }

        public override void Update(GameTime gameTime)
        {
            Rotation += rotationChange;
            Scale += scaleChange;

            if (Scale > MAX_SCALE || Scale < MIN_SCALE)
            {
                scaleChange = -scaleChange;
            }

            Console.WriteLine("Rotation: " + Rotation);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //version 2
            //spriteBatch.Draw(tex, position, Color.Red);

            //version 1
            //spriteBatch.Draw(tex, destRect, Color.White);

            //Version 6
            spriteBatch.Draw(tex, position, srcRect, Color.White, Rotation, origin, Scale,
                SpriteEffects.FlipVertically, 0);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
