# ExoSky 🌌
### NASA International Space Apps Challenge 2024
**Local Winner | Global Nominee**

## Overview

ExoSky is an interactive astronomical simulation developed using Unity
and C# for the NASA International Space Apps Challenge 2024.

The project explores a fundamental astronomical question:

**How would the night sky appear if we observed it from another planet?**

The familiar constellations visible from Earth depend on our position
within the Milky Way. From sufficiently different locations in space,
the apparent arrangement of stars changes.

ExoSky was developed to explore this phenomenon through an interactive
three-dimensional environment, combining astronomical data,
computational geometry, and scientific visualization.

The project was recognized as a Local Winner and Global Nominee
at NASA Space Apps Challenge 2024.

---

## Scientific Background

### Observing the Universe from Different Locations

The apparent positions of stars depend on the observer's location.

Stars that appear close together in Earth's night sky may actually
be separated by enormous distances in three-dimensional space.

Changing the observer's position can therefore change the apparent
angular separation between stars, producing different constellation
patterns.

ExoSky explores this concept by representing astronomical objects
within a three-dimensional simulation.

### Astronomical Coordinate Transformations

During the development of ExoSky, astronomical coordinate processing
was used to prepare stellar positions for visualization from
alternative observational perspectives.

The underlying geometric principle involves calculating the position
of a star relative to an observer.

Given a stellar position vector:

r_star = (x_s, y_s, z_s)

And an observer position vector:

r_observer = (x_o, y_o, z_o)

The relative position is:

r_relative = r_star - r_observer

The apparent direction of the star can then be determined from
the normalized relative position vector.

These geometric relationships provide the mathematical foundation
for studying how stellar arrangements change with observer location.

**Note:** The original external scripts used for astronomical
coordinate preprocessing are not currently included in this
repository.

---

## Features

### 1. Interactive Constellation Creation

ExoSky allows users to create custom constellations by selecting
stars within the simulated astronomical environment.

Implemented functionality includes:

- Interactive star selection using Unity raycasting.
- Connecting selected stars using LineRenderer components.
- Naming and saving custom constellations during a session.
- Creating up to five custom constellations.
- Displaying or hiding saved constellation patterns.
- Dynamically generated interface controls.

The system uses three-dimensional vectors to record the positions
of selected stars.

Relevant script:
`ConstellationCreator.cs`

### 2. Elliptical Orbit Visualization

The application includes a system for visualizing elliptical
trajectories.

Orbital paths are generated using the parametric equations:

x(t) = a cos(ωt)

z(t) = b sin(ωt)

Where:

- a represents the semi-major axis.
- b represents the semi-minor axis.
- ω controls the animation rate.
- t represents elapsed simulation time.

The system supports:

- Adjustable orbital dimensions.
- Configurable animation speed.
- Real-time orbital animation.
- Interactive start and stop controls.

This component provides a geometric visualization of elliptical
motion rather than a complete gravitational simulation.

Relevant script:
`EllipticalOrbit.cs`

### 3. Interactive Astronomical Observation

ExoSky includes a camera-control system that allows users to
explore the simulated environment.

Features include:

- Horizontal and vertical camera rotation.
- Keyboard-controlled viewing direction.
- Adjustable camera sensitivity.
- Camera orientation reset.
- Dynamic ground visibility.
- Integration with Unity's user interface.

Camera orientation is controlled using Euler angles.

Relevant script:
`CameraAndGroundController.cs`

### 4. Interactive User Interface

The application incorporates interface components for interacting
with the simulation.

The available Unity source files include scripts for:

- Menu management.
- Scene switching.
- Constellation interface management.
- Telescope interaction.
- Music controls.
- Visual effects.

---

## Technologies Used

### Development

- Unity Engine
- C#
- Unity UI
- TextMeshPro

### Computational and Mathematical Concepts

- Three-dimensional vector geometry
- Astronomical coordinate transformations
- Parametric equations
- Elliptical geometry
- Raycasting
- Euler-angle rotations
- Scientific visualization

---

## Project Structure

The repository contains the original Unity project.

```text
ExoSky-NASA-Space-Apps-2024/
│
├── Assets/
│   ├── Scripts/
│   └── ...
│
├── Packages/
│
├── ProjectSettings/
│
├── README.md
│
└── .gitignore
```

The Assets directory contains the application's scripts,
scenes, materials, and other Unity resources.

Packages contains the Unity package configuration.

ProjectSettings contains the Unity project configuration.

---

## Installation and Usage

### Requirements

- Unity Hub
- A compatible version of the Unity Editor

### Installation

1. Clone the repository:

   git clone https://github.com/USERNAME/ExoSky-NASA-Space-Apps-2024.git

2. Open Unity Hub.

3. Select "Add project from disk."

4. Navigate to the downloaded project directory.

5. Open the project using a compatible Unity Editor version.

6. Open the appropriate scene and press Play.

**Note:** The exact Unity Editor version and startup scene
should be verified before running the project.

---

## Project Status

This repository contains the available Unity source project
developed for NASA Space Apps Challenge 2024.

The original external scripts used for astronomical coordinate
preprocessing are not currently included.

The available Unity source code includes the interactive
constellation system, orbital visualization, camera controls,
and other application components.

---

## NASA Space Apps Challenge 2024

ExoSky was developed during the NASA International Space Apps
Challenge 2024.

### Achievements

🏆 Local Winner

🌍 Global Nominee

The project combined astronomy, computational methods, and
interactive visualization to explore alternative perspectives
of the night sky.

---

## Team and Contributions

ExoSky was developed as a collaborative project during
NASA Space Apps Challenge 2024.

**Team Members:**

[Add team member names]

**Leo-Georges Chlala**

[Add a description of individual contributions.]

---

## Acknowledgments

Developed for the NASA International Space Apps Challenge 2024.

Special thanks to the organizers, mentors, and contributors
who supported the project.
