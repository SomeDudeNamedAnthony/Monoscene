using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene_Test;

public class Framebuffer
{
    private readonly RenderTarget2D _target;
    public readonly GraphicsDevice GraphicsDevice;
    private Rectangle _destinationRectangle;

    public Vector2 Offset { get; set; } = Vector2.Zero;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Color Tint { get; set; } = Color.White;
    public float Angle { get; set; } = 0.0F;
    public bool HFlip { get; set; } = false;
    public bool VFlip { get; set; } = false;

    public Framebuffer(GraphicsDevice graphicsDevice, GameWindow window, int width, int height)
    {
        window.ClientSizeChanged += OnWindowResize;
        GraphicsDevice = graphicsDevice;
        _target = new(GraphicsDevice, width, height);
        ResizeRect();
    }

    private void OnWindowResize(object sender, EventArgs e)
    {
        ResizeRect();
    }


    private void ResizeRect()
    {
        var screenSize = GraphicsDevice.PresentationParameters.Bounds;

        float scaleX = (float)screenSize.Width / _target.Width;
        float scaleY = (float)screenSize.Height / _target.Height;
        float scale = Math.Min(scaleX, scaleY);

        int newWidth = (int)(_target.Width * scale);
        int newHeight = (int)(_target.Height * scale);

        int posX = (screenSize.Width - newWidth) / 2;
        int posY = (screenSize.Height - newHeight) / 2;

        _destinationRectangle = new Rectangle(posX, posY, newWidth, newHeight);
    }

    public void Begin(Color color)
    {
        GraphicsDevice.SetRenderTarget(_target);
        GraphicsDevice.Clear(color);
    }

    public void End(SpriteBatch spriteBatch, Color color)
    {
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(color);
        spriteBatch.Begin();
        spriteBatch.Draw(_target, _destinationRectangle, new Rectangle((int)Offset.X, (int)Offset.Y, _target.Width, _target.Height), Tint, Angle, Origin,
        (HFlip && VFlip) ? SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically :
        HFlip ? SpriteEffects.FlipHorizontally :
        VFlip ? SpriteEffects.FlipVertically : SpriteEffects.None,
        0.0F);
        spriteBatch.End();
    }
}

/*
Copyright (c) 2024 Anthony I. Jackson

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would be
   appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.
*/
