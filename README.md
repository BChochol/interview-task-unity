Project forked as a task for the recruiter.

My task was to implement a one-room puzzle for a horror-style first-person game. The requirement was that the puzzle focus on three elements: skulls, swords, and candles.

My contributions:
Everything from directories: Materials, Prefabs, ScriptableObjects, Scripts, Shaders and Sprites in the Assets/_Project directory.
Main scene of the project is in directory Assets/_Project/Scenes/MainScene, as it was originally, I added the player with 1st person camera using Cinemachine, controls using Unity.InputSystem as well as many prefabs and interactable elements on scene.
The player can interact with certain objects using IInteractable interface implementations. Most of the events are handled using an event manager, in which MonoBehaviors can register and deregister wanted behaviors to achieve flexibility.
I also created flame shader for torches and candles, a shader for hidden text on walls that makes it visible only when a player with lit candle approaches and a full-screen vignette shader.
  
Used packages:
- DOTween
- UniTask
- InputSystem
- Cinemachine
- TextMeshPro

Apart from that, I used 3D models and textures that were already present on scene and free sounds downloaded from https://pixabay.com.
