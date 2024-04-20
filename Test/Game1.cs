using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monoscene;

namespace Monoscene_Test;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SceneManager sceneManager;
    private AssetManager assetManager = AssetManager.Instance;
    private readonly Vector2 RESOLUTION = new Vector2(320, 200);
    private Framebuffer framebuffer;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = (int)RESOLUTION.X,
            PreferredBackBufferHeight = (int)RESOLUTION.Y
        };

        Window.AllowUserResizing = true;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        framebuffer = new Framebuffer(GraphicsDevice, Window, (int)RESOLUTION.X, (int)RESOLUTION.Y);

        assetManager.Load(Content);

        sceneManager = new SceneManager(new Scene[]{
            new DebugScene( ),
        }, "DebugScene");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();



        sceneManager.Process(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        framebuffer.Begin(Color.SteelBlue);
        _spriteBatch.Begin();
        sceneManager.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();
        framebuffer.End(_spriteBatch, Color.Black);

        base.Draw(gameTime);
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
