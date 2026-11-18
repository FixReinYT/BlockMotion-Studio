# BlockMotion Studio

**BlockMotion Studio** is an independent 3D animation editor focused on Minecraft-style block characters, rigs, scenes and cinematic rendering.

> Early development — foundation stage. This repository does not yet contain a production-ready animation editor.

## Project goals

- A custom 3D engine and scene graph.
- A professional, approachable desktop workflow.
- Block-based model and texture support, including Blockbench interchange.
- Keyframe animation, timeline, curves and reusable poses.
- Cameras, lighting, materials, audio and video export.

## Technology direction

- C# / .NET 8
- Windows desktop application (initial target)
- OpenGL through OpenTK as the initial graphics API
- Engine and editor kept in separate modules
- FFmpeg integration planned for final video export

OpenTK is a low-level graphics/windowing dependency, not a prebuilt 3D engine. Rendering, scene management, animation and editor systems are implemented by BlockMotion Studio itself.

## Repository layout

```
docs/                         Architecture and development notes
src/BlockMotionStudio/        Desktop editor application
  Engine/                     Runtime, scene and rendering systems
  Editor/                     Editor UI and interaction
  Program.cs                  Application entry point
```

## Development

Install the .NET 8 SDK and build the solution/project on Windows:

```powershell
dotnet restore src/BlockMotionStudio/BlockMotionStudio.csproj
dotnet build src/BlockMotionStudio/BlockMotionStudio.csproj
dotnet run --project src/BlockMotionStudio/BlockMotionStudio.csproj
```

## Status

The current milestone is the application foundation: project structure, editor shell, viewport integration and a first custom-renderer prototype. Animation and import features will be added only after the foundation is testable.

## Disclaimer

BlockMotion Studio is an independent project and is not affiliated with, endorsed by, or sponsored by Mojang or Microsoft. Minecraft is a trademark of Mojang Synergies AB / Microsoft.
