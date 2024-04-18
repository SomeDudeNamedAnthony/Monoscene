using System;

namespace Monoscene;

public class InvalidSceneException : Exception
{
    public InvalidSceneException(string sceneName) : base(string.Format("The scene \"{0}\" doesn't exist.", sceneName)) { }
}
