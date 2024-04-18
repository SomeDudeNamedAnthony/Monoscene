using System;

namespace Monoscene;

public class DuplicateSceneException : Exception
{
    public DuplicateSceneException(string sceneName) : base(string.Format("The scene \"{0}\" has one or more duplicates.", sceneName)) { }
}
