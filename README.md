# 2022 3DGED GDApp & GD Engine

## Overview ##
This repository contains code for the game engine

## Table of Contents ##
| Topic | Description | See (Source Code) | Additional Reading |
| :---------------- | :--------------- | :--------------- | :--------------- | 
|||||


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
- [ ] Add camera types and finish 1st Person Camera
- [ ] Add ActionType enum to support turning Update and Draw on/off during gameplay (hint: use when menu is shown) for specific GameObject and Scene
- [ ] Add support for cloning GameObjects
- [ ] Practice extension of a class (see Extensions)
- [ ] Add Integer2 for use with screen resolution to prevent need to typecast - see InitializeGraphics()


 
