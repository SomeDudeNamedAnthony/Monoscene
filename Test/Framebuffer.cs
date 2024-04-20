using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene_Test;

/// <summary>
/// ...
/// </summary>
public class Framebuffer
{
    private readonly RenderTarget2D _target;
    private Rectangle _destinationRectangle;

    public readonly GraphicsDevice GraphicsDevice;

    /// <summary>
    /// The scale of the buffer.
    /// </summary>
    public float Scale { get; set; } = 1.0F;

    /// <summary>
    /// The offset of the buffer from the top-left of the screen.
    /// </summary>
    public Vector2 Offset { get; set; } = Vector2.Zero;

    /// <summary>
    /// Only important when offseting the buffer.
    /// </summary>
    public Vector2 Origin { get; set; } = Vector2.Zero;

    /// <summary>
    /// The tint of the buffer.
    /// </summary>
    public Color Tint { get; set; } = Color.White;

    /// <summary>
    /// The rotation of the buffer in radians.
    /// </summary>
    public float Angle { get; set; } = 0.0F;

    /// <summary>
    /// Wether to flip the buffer horizontally.
    /// </summary>
    public bool HFlip { get; set; } = false;

    /// <summary>
    /// Wether to flip the buffer vertically.
    /// </summary>
    public bool VFlip { get; set; } = false;

    /// <summary>
    /// Creates a new framebuffer.
    /// </summary>
    /// <param name="graphicsDevice">A reference to a graphic device.</param>
    /// <param name="window">A reference to a game window.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
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
        Rectangle screenSize = GraphicsDevice.PresentationParameters.Bounds;
        float scale = Math.Min((float)screenSize.Width / _target.Width, (float)screenSize.Height / _target.Height);
        int newWidth = (int)(_target.Width * scale);
        int newHeight = (int)(_target.Height * scale);
        _destinationRectangle = new Rectangle((screenSize.Width - newWidth) / 2, (screenSize.Height - newHeight) / 2, newWidth, newHeight);
    }

    /// <summary>
    /// Enables the buffer.
    /// </summary>
    /// <param name="color">The color to clear the framebuffer.</param>
    public void Begin(Color color)
    {
        GraphicsDevice.SetRenderTarget(_target);
        GraphicsDevice.Clear(color);
    }

    /// <summary>
    /// Disables the buffer and draws it.
    /// </summary>
    /// <param name="spriteBatch">A reference to a sprite batch.</param>
    /// <param name="color">The color of the border.</param>
    public void End(SpriteBatch spriteBatch, Color color)
    {
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(color);
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
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
