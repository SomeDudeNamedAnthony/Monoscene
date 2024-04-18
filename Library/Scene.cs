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
    public string Name { get; }

    /// <summary>
    /// A reference to a scene manager. Useful for switching scenes.
    /// </summary>
    public SceneManager SceneManager { get; }

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
    public Scene(string name, ref SceneManager sceneManager)
    {
        Name = name;
        SceneManager = sceneManager;
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
    public void Process(ref GameTime gameTime)
    {
        foreach (Actor instance in instances)
        {
            instance.Process(ref gameTime);
        }
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Draw(ref SpriteBatch spriteBatch, ref GameTime gameTime)
    {
        foreach (Actor instance in instances)
        {
            instance.Draw(ref spriteBatch, ref gameTime);
        }
    }

    /// <summary>
    /// Instantiate all of your scenes instances here.
    /// </summary>
    public virtual void Instantiate() { }
}
