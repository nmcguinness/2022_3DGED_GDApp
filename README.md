# 2022 3DGED GDApp & GD Engine

## Overview ##
This repository contains code for the game engine

## Table of Contents ##
| Topic | See (Source Code) | Additional Reading |
| :---------------- | :--------------- | :--------------- | :--------------- | 
| Encapsulating translation, rotation, and scale of an object|Transform|None|
| Encapsulating View and Projection |Camera|[Basic Matrices](http://rbwhitaker.wikidot.com/monogame-basic-matrices)|
| Representing drawn objects and non-drawn objects |GameObject, Component|None|
| Encapsulating vertex and index data |Mesh, Renderer|[Rendering from Vertex and Index Buffers](https://learn.microsoft.com/en-us/windows/win32/direct3d9/rendering-from-vertex-and-index-buffers)|
| Supporting the addition of components to a GameObject |GameObject, Component|None|
| Storing 3D rendered object's surface properties in a material | Material |None|
| Rendering FBX models and integrating into Mesh hierarchy |Mesh, ModelMesh|None|
| Using AppData to remove hard-coded magic numbers from our code |AppData|(Static Classes & Static Members)[https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members]|
| Adding behaviours (no user-input) and controllers (user-input) as components of a GameObject |RotationBehaviour, FirstPersonController |None|
| Storing drawn GameObjects in a list in the Scene class |Scene |[C# - List](https://www.tutorialsteacher.com/csharp/csharp-list)|
| Storing static (i.e. exist for all of gameplay) and dynamic (i.e. added/removed during gameplay) drawn GameObjects in a GameObjectList |GameObjectList, ObjectType |None|
| Using enums to de-mystify crytic parameters |ObjectType, RenderType |(C# - Enums)[https://www.tutorialsteacher.com/csharp/csharp-enum]|
| Re-factoring Scene to store opaque and transparent GameObjectLists |Scene, RenderType |None|
| Adding utility and extension classes to include useful secondary functionality (e.g. Vector3::Round) |Vector3Extension, PerfUtility, SerializationUtility |None|
| Adding support for multiple scenes and multiple cameras | CameraManager, SceneManager |None|
| Create behaviours (i.e. GameObject components) to add simple camera types | SecurityCameraBehaviour, CurveBehaviour, Curve|None|


### To Do - Week 5
- [x] Explain two project setup (one app, one engine)
- [x] Explain Camera, Transform, Component
- [x] Explain abstract classes and methods
- [x] Explain Mesh
- [x] Explain GameObject, Component
- [x] Create QuadMesh
- [x] Explain Material, IEffect, Renderer
- [x] Add RotationBehaviour on Quad
- [x] Add simple (first pass) FirstPersonCameraController for camera
- [x] Added AppData to abstract and centralise hard-coded magic numbers and improve readability
- [x] Added skybox and grass plane
- [x] Tidied Main::Initialize
- [x] Added SamplerState setting to remove artifacts between skybox planes
- [x] Explain how to extend a class (see Extensions)
- [x] Finish CubeMesh

### To Do - Week 6
- [x] Added Scene to store List<GameObject>
- [x] Added GameObjectList to support splitting GameObjects into two lists - static (persists for game duration) and dynamic (add/remove during gameplay)
- [x] Refactored Scene to support opaque and transparent GameObjectLists
- [x] Added ObjectType and RenderType enums to GameObject to prevent passing in two hard-to-understand booleans
- [x] Added Add, Remove, Find, Size, Clear to Scene and GameObjectList
- [x] Added ModelMesh to support loading FBX meshes
- [x] Refactored Mesh, CubeMesh, QuadMesh and ModelMesh to solve constructor problem with model == null
- [x] Added SceneManager to support switching between scenes
- [x] Added Color and Viewport extensions for future use
- [x] Added Perf, Serialization, and String -Utility classes
- [x] Added ContentDictionary
- [x] Added methods in Scene to support transparent game objects
- [x] Added Curve classes for camera controller

### To Do - Week 7
- [x] Added pre-processor directives (i.e. #if...) to set HIRES and DEMO in Main and AppData
- [ ] Refactor SecurityCameraBehaviour and RotationBehaviour 
- [ ] Add camera types and finish 1st Person Camera
- [ ] Add ActionType enum to support turning Update and Draw on/off during gameplay (hint: use when menu is shown) for specific GameObject and Scene
- [ ] Add support for cloning GameObjects
- [ ] Practice extension of a class (see Extensions)
- [ ] Add Integer2 for use with screen resolution to prevent need to typecast - see InitializeGraphics()


 
