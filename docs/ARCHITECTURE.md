# BlockMotion Studio — Architecture

## 1. Architecture principles

1. The editor is a client of the engine; engine code must not depend on editor UI.
2. Scene data is independent of rendering and UI.
3. Animation data is deterministic and evaluated at an explicit time/frame.
4. Importers convert external formats into native scene/model data.
5. Project files are versioned and migrated explicitly.
6. Each milestone must build and have a runnable verification path.

## 2. High-level modules

- **Application** — startup, lifecycle, settings and command routing.
- **Editor** — workspace, panels, selection, gizmos, inspectors and shortcuts.
- **Engine Core** — math, time, transforms, object identity and events.
- **Scene** — entities, components, hierarchy and serialization.
- **Renderer** — graphics device, shaders, meshes, materials, cameras, lighting and render passes.
- **Animation** — tracks, keyframes, interpolation, curves, constraints and playback.
- **Modeling** — cube geometry, pivots, bones, skinning and model editing.
- **Asset Pipeline** — textures, models, audio and metadata import.
- **Project System** — project manifests, asset references, autosave and recovery.
- **Export** — image sequence and video output; FFmpeg integration planned.

## 3. Initial technology choices

- C# on .NET 8.
- Windows desktop first.
- OpenTK provides OpenGL bindings and the WinForms GL control. It is not the engine.
- OpenGL is the first graphics backend; renderer abstractions should avoid leaking API-specific types into scene data.
- JSON is used for human-readable project metadata in the early milestones. Binary asset formats can be introduced when justified.

## 4. Scene data model

A scene contains entities. Each entity has a stable ID, name, parent relationship and components. Initial components:

- Transform
- MeshRenderer
- Camera
- Light
- Animator (later milestone)

Transforms use local position, rotation and scale; world transforms are derived through the hierarchy.

## 5. Animation model

Animation is evaluated using integer frame positions and a project frame rate. Tracks target stable entity/component/property identifiers. Keyframes store time, value and interpolation mode. Initial interpolation modes: Step, Linear and Cubic. Timeline UI is a view/editor of this data, not its owner.

## 6. Milestones

1. **Foundation** — app shell, viewport, renderer bootstrap, camera navigation and primitive cube.
2. **Scene editing** — hierarchy, selection, transform gizmos, object creation and inspector.
3. **Animation core** — project FPS, timeline, keyframes, playback and interpolation.
4. **Minecraft assets** — cube models, texture atlas/material workflow and Blockbench importer.
5. **Character rigging** — bones, pivots, pose tools and inverse kinematics.
6. **Cinematics** — cameras, lighting, shadows, effects and audio.
7. **Export** — image sequence, video encoding and render queue.
8. **Release hardening** — performance, recovery, tests, installer and documentation.

## 7. Current scope

This first repository milestone is only the foundation. It must not claim support for complete character animation, Blockbench import, IK or final video rendering until those systems are implemented and verified.
