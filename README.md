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

Regular jumps are executed by pressing `KeyCode.Space` once. Using the jetpack is executed at double jumps or when the player is holding `KeyCode.Space`.

The jetpack has a limited amount of fuel (`Force`). However, it will automatically charge if the jetpack is not in use. If the fuel drops to 0 during the flight, the jetpack `isOverheated`. In this case, the jetpack can no longer be used until it is fully charged and the player `isGrounded`.

Using the jetpack may help you to get out of the field of view of an enemy faster.

<img alt="Gif which shows the player using the jetpack" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Jetpack.gif" width="30%" height="30%" />

### Flashlight

The flashlight is toggled via `KeyCode.F`. It is used to increase the amount of light to an enemy and thus freeze it.

<img alt="Gif which shows the player toggling the flashlight" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Flashlight.gif" width="30%" height="30%" />

### Enemy behaviour

<img alt="Gif of an enemy chasing the player" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Enemy.gif" width="30%" height="30%" />

### Luminance detection

<img alt="Gif of an enemy which is freezed because of luminance" src="https://github.com/samuelschnurr/luminance-detection/blob/master/Docs/Luminance.gif" width="30%" height="30%" />

## License

This repository is under MIT license (see <a href="https://github.com/samuelschnurr/luminance-detection/blob/master/LICENSE">LICENSE</a>).
