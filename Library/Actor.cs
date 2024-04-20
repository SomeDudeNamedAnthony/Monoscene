using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene;

/// <summary>
/// A base entity for a scene.
/// </summary>
public class Actor
{
    protected Scene Scene = null;
    public int ID { get; private set; }

    /// <summary>
    /// Creates a new actor. Use AddToScene to add it to a scene.
    /// </summary>
    public Actor() { }

    public void AddToScene(Scene scene)
    {
        Scene = scene;
        scene.AddActor(this);
        ID = scene.GetInstanceCount() + 1;
    }

    public virtual void Enter() { }
    public virtual void Process(GameTime gameTime) { }
    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) { }
    public virtual void Exit() { }
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
