using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene;

public class Scene
{
    /// <summary>
    /// Purely for looking-up a specific scene.
    /// </summary>
    /// <value></value>
    private readonly string _name;

    /// <summary>
    /// A reference to a scene manager. Useful for switching scenes.
    /// </summary>
    private SceneManager _sceneManager;

    /// <summary>
    /// All of the instances in the scene.
    /// </summary>
    private List<Actor> instances;


    /// <summary>
    /// Creates a new scene.
    /// </summary>
    /// <param name="name">The name of the scene.</param>
    /// <param name="actorRegistry">A reference to your actor registry.</param>
    /// <param name="sceneManager">A reference to your scene manager.</param>
    public Scene(string name)
    {
        _name = name;
    }

    internal void SetSceneManager(SceneManager sceneManager)
    {
        _sceneManager = sceneManager;
    }

    public string Name()
    {
        return _name;
    }

    public SceneManager SceneManager()
    {
        return _sceneManager;
    }

    public int GetInstanceCount()
    {
        return instances.Count;
    }

    public void AddActor(Actor actor)
    {
        instances.Add(actor);
    }

    /// <summary>
    /// Called after this scene has been switched to.
    /// </summary>
    public void Enter()
    {
        instances = new List<Actor>();
        Instantiate();

        foreach (Actor instance in instances)
        {
            instance.Enter();
        }
    }

    /// <summary>
    /// Called prior to a scene switching.
    /// </summary>
    public void Exit()
    {
        foreach (Actor instance in instances)
        {
            instance.Exit();
        }
        instances.Clear();
        instances = null;
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Process(GameTime gameTime)
    {
        foreach (Actor instance in instances)
        {
            instance.Process(gameTime);
        }
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        foreach (Actor instance in instances)
        {
            instance.Draw(spriteBatch, gameTime);
        }
    }

    /// <summary>
    /// Instantiate all of your scenes instances here.
    /// </summary>
    public virtual void Instantiate() { }
}
