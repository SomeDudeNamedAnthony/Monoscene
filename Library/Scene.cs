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
