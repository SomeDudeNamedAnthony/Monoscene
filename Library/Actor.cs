using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene;

/// <summary>
/// A base entity for a scene.
/// </summary>
public class Actor
{
    private Scene _scene = null;
    private int _id = -1;

    /// <summary>
    /// Creates a new actor. Use AddToScene to add it to a scene.
    /// </summary>
    public Actor()
    {
    }

    public Scene Scene()
    {
        return _scene;
    }

    public int Id()
    {
        return _id;
    }

    public void AddToScene(Scene scene)
    {
        _scene = scene;
        scene.AddActor(this);
        _id = scene.GetInstanceCount() + 1;
    }

    public virtual void Enter() { }
    public virtual void Process(GameTime gameTime) { }
    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) { }
    public virtual void Exit() { }
}
