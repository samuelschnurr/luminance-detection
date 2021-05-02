# Luminance Detection in Unity3D

This repository provides a prototypical implementation of a luminance detector in Unity3D and is used for evaluation and as a showcase. The main functionalities are listed below. A detailed description can be found in the chapter <a href="https://github.com/samuelschnurr/luminance-detection#Demonstration">Demonstration</a>.

- Player handling
    - Input, camera, movement
- Enemy handling
    - Vision, navMesh movement
    - Detecting, following and forgetting the player 
- Jetpack with limited but charging fuel
- Flashlight to put luminance on elements
- Luminance detection

## Before you start
- Install a compatible version of Unity (this repository is developed with <a href="https://unity3d.com/unity/qa/lts-releases?version=2019.4">Unity 2019.4.x</a>)
- Notice that you may show Gizmos to easilier understand enemy behaviour

## Demonstration

### Jetpack

Regular jumps are executed by pressing `KeyCode.Space` once. Using the jetpack is executed at double jumps if the player is holding `KeyCode.Space`.

The jetpack has a limited amount of fuel (`Force`). However, it will automatically charge if the jetpack is not in use. If the fuel drops to 0 during the flight, the jetpack `isOverheated`. In this case, the jetpack can no longer be used until it is fully charged and the player `isGrounded`.

Using the jetpack may help you to get out of the field of view of an enemy faster.

<img alt="Gif which shows the player using the jetpack" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Jetpack.gif" width="30%" height="30%" />

### Flashlight

The flashlight is toggled via `KeyCode.F`. It is used to increase the amount of light to an enemy and thus freeze it.

<img alt="Gif which shows the player toggling the flashlight" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Flashlight.gif" width="30%" height="30%" />

### Enemy behaviour

With gizmos you can easily understand the behavior of the opponents.

The enemy has a `MaxDetectionRadius` within he can become aware of the player (inner yellow line). 

The player's pursuit is started as soon as he has entered `MaxVisionAngle` (blue lines) inside the `MaxDetectionRadius`. 

The enemy will follow the player until he leaves its `MaxReminderRadius` (outer yellow line). When the pursuit is abandoned, the `MaxReminderRadius` is disabled and the player can approach the enemy again up to the `MaxDetectionRadius`.

<img alt="Gif of an enemy chasing the player" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Enemy.gif" width="30%" height="30%" />

### Luminance detection

In the graphic below you can see the enemy is illuminated by the flashlight. The amount of light emitted to him has exceeded the `MaxLightLevel`. He `IsFreezed` and can't move.

Gradually, the player moves the flashlight away from the enemy. The amount of light is reduced. Although some of the light of the falls on the enemy, the `MaxLightLevel` has been undercut. He is not `IsFreezed` and can move again.

With the MaxLightLevel limit, it is important to note that all light sources are taken into account. This results in a different total amount of light if, for example, the enemy is in the shadow and is not hit by the directional light.

The total amount of light on the enemy is calculated using a `DetectLightTexture`. In collaboration with the `EnemyCamera`, it measures all incoming light sources. For this purpose, the <a href="https://en.wikipedia.org/wiki/Luma_(video)">relative luminance</a> is calculated using the pixels captured by the `EnemyCamera` using the following formula:

`Y = 0.2126R + 0.7152G + 0.0722B`

<img alt="Gif of an enemy which is freezed because of luminance" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Luminance.gif" width="30%" height="30%" />

## License

This repository is under MIT license (see <a href="https://github.com/samuelschnurr/luminance-detection/blob/master/LICENSE">LICENSE</a>).
