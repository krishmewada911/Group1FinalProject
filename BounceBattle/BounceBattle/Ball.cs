﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BounceBattle


{
    class Ball : Sprite
    {



        

        public bool restart;

        public Ball(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle screen) : base
            (texture, position, direction, speed, screen)
        {
        }

        public override void Update(GameTime gameTime)
        {
            BoundsScreen();

            base.Update(gameTime);
        }

        private void BoundsScreen()
        {
            if (position.Y < 0 || position.Y > screen.Height - texture.Height)
                direction.Y *= -1;
        }

        public void BoundsPaddle(Paddle_Player paddlePlayer, Paddle_AI paddleAI)
        {
            if (spriteBox.Intersects(paddlePlayer.spriteBox) || spriteBox.Intersects(paddleAI.spriteBox))
                direction.X *= -1;
        }

        public void ScorePaddle(Paddle_Player paddlePlayer, Paddle_AI paddleAI)
        {
            if (position.X < 0)
            {
                paddleAI.Score += 1;
                restart = true;
            }
            if (position.X > screen.Width - texture.Width)
            {
                paddlePlayer.Score += 1;
                restart = true;

            }
        }

    }
}
