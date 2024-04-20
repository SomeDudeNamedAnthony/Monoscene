# MonoScene

A scene manager with entities for Monogame.

## How?

*How to use?*  

It's quite simple to use MonoScene.
Just download a release or clone the repository and add a reference to it in your project's `.csproj` file.

```xml
...
<ItemGroup>
  <ProjectReference Include="<MonoScene Path>\Monoscene.csproj"/>
</ItemGroup>
...
```

**Steps:**
* Get.
  * Download <W.I.P
  * Clone
    * HTTPS: `git clone https://github.com/SomeDudeNamedAnthony/Monoscene.git`
    * SSH: `git clone git@github.com:SomeDudeNamedAnthony/Monoscene.git`
    * CLI: `gh repo clone SomeDudeNamedAnthony/Monoscene`
* Add reference. *e.g.* `<ItemGroup> <ProjectReference Include="<MonoScene Path>\Monoscene.csproj"/></ItemGroup>`
* Use.

**To have a better example look at the [test](https://github.com/SomeDudeNamedAnthony/Monoscene/tree/master/Test) project.**

## Why?

*Why was this library created?*  

*Summary:*  
**This is a side project and learning experiment.**

MonoScene was created just to be a side-project and learning experience for me.
This idea originally came from needing multiple *game-states* but in a *clean* form.
So naturally I decided to create a library to make re-using the same code easier... *obviously.*
There are better solutions to this but if you want a simple library to use for your game then this might
be the one for you.

## Where

*Are there any better solutions?*  

Indeed there are better solutions, an example being [MonoGame.Extended](https://www.monogameextended.net).
An open-source project community project to make MonoGame better.  
If you're building an *actual* product, please use this or another solution instead.

## License

*This project uses the zlib license.

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

*For code use:*

```cs
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
```

