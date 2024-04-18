using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoscene;

/// <summary>
/// Manages all scenes. You should only have one.
/// </summary>
public class SceneManager
{
    /// <summary>
    /// All of the scenes.
    /// </summary>
    private readonly Scene[] _scenes = null;

    /// <summary>
    /// The current scene.
    /// </summary>
    private Scene _currentScene = null;

    /// <summary>
    /// Checks for duplicate scenes.
    /// </summary>
    /// <param name="scenes">A reference to a group of scenes.</param>
    private static void CheckDuplicateScenes(ref Scene[] scenes)
    {
        if (scenes.Length < 2)
        {
            return;
        }
        for (int check = 0; check < scenes.Length; check++)
        {
            for (int against = check + 1; against < scenes.Length; against++)
            {
                if (scenes[check].Name == scenes[against].Name)
                {
                    throw new DuplicateSceneException(scenes[check].Name);
                }
            }
        }
    }


    /// <summary>
    /// Creates a scene manager.
    /// </summary>
    /// <param name="scenes">A group of scenes.</param>
    /// <param name="initialScene">The name of the first scene to load.</param>
    public SceneManager(Scene[] scenes, string initialScene)
    {
        CheckDuplicateScenes(ref scenes);
        _scenes = scenes;
        Switch(initialScene);
    }

    /// <summary>
    /// Gets a scene by name.
    /// </summary>
    /// <param name="sceneName">The name of the scene to find.</param>
    /// <returns>A copy of that scene.</returns>
    private Scene GetScene(string sceneName)
    {
        foreach (Scene scene in _scenes)
        {
            if (scene.Name == sceneName)
            {
                return scene;
            }
        }
        return null;
    }

    /// <summary>
    /// Switches to a different scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to switch to.</param>
    public void Switch(string sceneName)
    {
        if (_currentScene != null)
        {
            _currentScene.Exit();
        }

        _currentScene = GetScene(sceneName);
        if (_currentScene == null)
        {
            throw new InvalidSceneException(sceneName);
        }

        _currentScene.Enter();
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Process(ref GameTime gameTime)
    {
        if (_currentScene != null)
        {
            _currentScene.Process(ref gameTime);
        }
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Draw(ref SpriteBatch spriteBatch, ref GameTime gameTime)
    {
        if (_currentScene != null)
        {
            _currentScene.Draw(ref spriteBatch, ref gameTime);
        }
    }
}
