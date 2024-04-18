using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene;

/// <summary>
/// A base entity for a scene.
/// </summary>
public class Actor
{
    protected readonly Scene _scene;
    public ulong Id { get; }

    /// <summary>
    /// Creates a new actor. DO NOT USE THIS! Use Scene.AddActor instead.
    /// </summary>
    /// <param name="scene">A reference to a scene</param>
    public Actor(ref Scene scene)
    {
        _scene = scene;
    }

    public virtual void Enter() { }
    public virtual void Process(ref GameTime gameTime) { }
    public virtual void Draw(ref SpriteBatch spriteBatch, ref GameTime gameTime) { }
    public virtual void Exit() { }
}
