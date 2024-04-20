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
                if (scenes[check].Name() == scenes[against].Name())
                {
                    throw new DuplicateSceneException(scenes[check].Name());
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

        foreach (Scene scene in _scenes)
        {
            scene.SetSceneManager(this);
        }

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
            if (scene.Name() == sceneName)
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
    public void Process(GameTime gameTime)
    {
        if (_currentScene != null)
        {
            _currentScene.Process(gameTime);
        }
    }

    /// <summary>
    /// Processes all scene entities.
    /// </summary>
    /// <param name="gameTime">N/A</param>
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (_currentScene != null)
        {
            _currentScene.Draw(spriteBatch, gameTime);
        }
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
