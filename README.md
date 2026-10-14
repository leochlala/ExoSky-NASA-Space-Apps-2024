# ExoSky 🌌

### NASA International Space Apps Challenge 2024

**🏆 Local Winner | 🌍 Global Nominee**

---

## Overview

ExoSky is an interactive astronomical simulation developed using Unity and C# for the NASA International Space Apps Challenge 2024.

The project explores a fundamental astronomical question:

**How would the night sky appear if we observed it from another planet?**

The familiar constellations visible from Earth depend on our position within the Milky Way. From sufficiently different locations in space, the apparent arrangement of stars changes, potentially producing entirely different constellation patterns.

ExoSky explores this phenomenon through an interactive three-dimensional environment, combining astronomical data, computational geometry, and scientific visualization.

The project was recognized as a **Local Winner and Global Nominee** at the NASA International Space Apps Challenge 2024.

---

## 🎬 Videos & Demonstrations

Explore ExoSky through the following demonstrations, created for the NASA International Space Apps Challenge 2024.

### 🌌 ExoSky — 30-Second Demo

A short demonstration highlighting ExoSky's interactive astronomical environment and visualization features.

[![ExoSky 30-Second Demo](https://img.youtube.com/vi/I2kBzjhZP_w/hqdefault.jpg)](https://youtu.be/I2kBzjhZP_w)

**[▶ Watch the 30-Second Demo](https://youtu.be/I2kBzjhZP_w)**

### 🚀 ExoSky — 3-Minute Project Presentation

The official project presentation introducing ExoSky's concept, scientific background, development approach, and interactive simulation.

[![ExoSky 3-Minute Presentation](https://img.youtube.com/vi/JSTMxLjUSl8/hqdefault.jpg)](https://youtu.be/JSTMxLjUSl8)

**[▶ Watch the Full Project Presentation](https://youtu.be/JSTMxLjUSl8)**

---

## Technical Report

The original technical report developed by Team Ad Astra for the
NASA International Space Apps Challenge 2024 is available below.

The report documents the project's scientific methodology,
astronomical coordinate transformations, stellar magnitude
calculations, Unity implementation, and application features.

📄 **[Read the Full Technical Report (PDF)](Documentation/ExoSky_Technical_Report_2024.pdf)**

---

## Scientific Background

### 1. Observing the Universe from Different Locations

The apparent positions of stars depend on the observer's location.

Stars that appear close together in Earth's night sky may actually be separated by enormous distances in three-dimensional space.

Changing the observer's position can therefore change the apparent angular separation between stars, producing different constellation patterns.

This phenomenon is related to stellar parallax and the three-dimensional distribution of stars throughout the Milky Way.

ExoSky explores this concept by representing astronomical objects within a three-dimensional simulation.

### 2. Astronomical Coordinate Transformations

During the development of ExoSky, astronomical coordinate processing was used to prepare stellar positions for visualization from alternative observational perspectives.

The underlying geometric principle involves calculating the position of a star relative to an observer.

Given a stellar position vector:

$begin:math:display$
\\mathbf\{r\}\_\{star\} \= \(x\_s\, y\_s\, z\_s\)
$end:math:display$

And an observer position vector:

$begin:math:display$
\\mathbf\{r\}\_\{observer\} \= \(x\_o\, y\_o\, z\_o\)
$end:math:display$

The relative position is:

$begin:math:display$
\\mathbf\{r\}\_\{relative\} \=
\\mathbf\{r\}\_\{star\} \- \\mathbf\{r\}\_\{observer\}
$end:math:display$

The apparent direction of the star can then be determined from the normalized relative position vector:

$begin:math:display$
\\hat\{\\mathbf\{n\}\} \=
\\frac\{\\mathbf\{r\}\_\{relative\}\}
\{\|\\mathbf\{r\}\_\{relative\}\|\}
$end:math:display$

These geometric relationships provide the mathematical foundation for studying how stellar arrangements change with observer location.

### 3. Stellar Distance Estimation

Stellar distances can be estimated from parallax measurements.

For a measured parallax $begin:math:text$p$end:math:text$, expressed in milliarcseconds:

$begin:math:display$
d \= \\frac\{1000\}\{p\}
$end:math:display$

where:

- $begin:math:text$d$end:math:text$ is the estimated distance in parsecs.
- $begin:math:text$p$end:math:text$ is the measured parallax in milliarcseconds.

This relationship provides a simple distance estimate for stars with positive parallaxes.

However, direct inversion of parallax measurements becomes unreliable when relative measurement uncertainties are large.

### 4. Stellar Visibility from Different Locations

A star's apparent brightness depends on its distance from the observer.

Neglecting extinction and assuming constant intrinsic luminosity, the apparent magnitude at a new distance can be estimated using:

$begin:math:display$
m\_\{new\} \=
m\_\{original\}
\+
5\\log\_\{10\}
\\left\(
\\frac\{d\_\{new\}\}\{d\_\{original\}\}
\\right\)
$end:math:display$

where:

- $begin:math:text$m\_\{original\}$end:math:text$ is the apparent magnitude from the original observing location.
- $begin:math:text$d\_\{original\}$end:math:text$ is the original distance to the star.
- $begin:math:text$d\_\{new\}$end:math:text$ is the distance from the new observer.
- $begin:math:text$m\_\{new\}$end:math:text$ is the estimated apparent magnitude from the new location.

This relationship allows us to estimate which stars may become brighter or fainter when the observer changes position.

---

## Features

### 1. Interactive Constellation Creation

ExoSky allows users to create custom constellations by selecting stars within the simulated astronomical environment.

Implemented functionality includes:

- Interactive star selection using Unity raycasting.
- Connecting selected stars using `LineRenderer` components.
- Naming and saving custom constellations during a session.
- Creating up to five custom constellations.
- Displaying or hiding saved constellation patterns.
- Dynamically generated interface controls.

The system uses three-dimensional vectors to record the positions of selected stars.

**Relevant Unity script:** `ConstellationCreator.cs`

### 2. Elliptical Orbit Visualization

The application includes a system for visualizing elliptical trajectories.

Orbital paths are generated using the parametric equations:

$begin:math:display$
x\(t\) \= a\\cos\(\\omega t\)
$end:math:display$

$begin:math:display$
z\(t\) \= b\\sin\(\\omega t\)
$end:math:display$

where:

- $begin:math:text$a$end:math:text$ represents the semi-major axis.
- $begin:math:text$b$end:math:text$ represents the semi-minor axis.
- $begin:math:text$\\omega$end:math:text$ controls the animation rate.
- $begin:math:text$t$end:math:text$ represents elapsed simulation time.

The system supports:

- Adjustable orbital dimensions.
- Configurable animation speed.
- Real-time orbital animation.
- Interactive start and stop controls.

**Scientific note:** This component provides a geometric visualization of elliptical motion rather than a complete gravitational simulation based on Newton's equations or Kepler's laws.

**Relevant Unity script:** `EllipticalOrbit.cs`

### 3. Interactive Astronomical Observation

ExoSky includes a camera-control system that allows users to explore the simulated astronomical environment.

Features include:

- Horizontal and vertical camera rotation.
- Keyboard-controlled viewing direction.
- Adjustable camera sensitivity.
- Camera orientation reset.
- Dynamic ground visibility.
- Integration with Unity's user interface.

Camera orientation is controlled using Euler angles.

**Relevant Unity script:** `CameraAndGroundController.cs`

### 4. Interactive User Interface

The application incorporates interface components for interacting with the simulation.

The available Unity source files include scripts for:

- Menu management.
- Scene switching.
- Constellation interface management.
- Telescope interaction.
- Music controls.
- Visual effects.

---

## Astronomical Data Processing Pipeline

The repository includes Python scripts for astronomical data extraction, coordinate transformations, and stellar visibility calculations.

These scripts are located in:

`Astronomical_Data_Processing/`

The pipeline consists of three stages.

### Stage 1 — Gaia DR3 Data Extraction

**Script:** `gaia_data_extraction.py`

This script retrieves astronomical measurements from the European Space Agency's Gaia Data Release 3 catalog.

The extraction process includes:

- Querying Gaia DR3 using Astroquery.
- Retrieving stellar right ascension and declination.
- Retrieving parallax measurements.
- Retrieving Gaia G-band apparent magnitudes.
- Converting equatorial coordinates into Galactic coordinates using Astropy.

The query is configured with an upper limit of 800,000 sources.

This limit represents the maximum requested number of catalog entries, not a guarantee that the final dataset will contain exactly 800,000 stars.

**Output:**

`star_data_with_parallax.csv`

### Stage 2 — Stellar Coordinate Transformations

**Script:** `stellar_coordinates.py`

This script transforms stellar coordinates into a three-dimensional Cartesian representation.

The calculations include:

1. Estimating stellar distances from parallax.
2. Converting Galactic longitude and latitude into Cartesian coordinates.
3. Defining an alternative observer position.
4. Calculating each star's position relative to the new observer.

For Galactic longitude $begin:math:text$l$end:math:text$, latitude $begin:math:text$b$end:math:text$, and distance $begin:math:text$d$end:math:text$:

$begin:math:display$
x \= d\\cos\(b\)\\cos\(l\)
$end:math:display$

$begin:math:display$
y \= d\\cos\(b\)\\sin\(l\)
$end:math:display$

$begin:math:display$
z \= d\\sin\(b\)
$end:math:display$

The relative stellar position is then calculated using:

$begin:math:display$
\\mathbf\{r\}\_\{relative\} \=
\\mathbf\{r\}\_\{star\} \-
\\mathbf\{r\}\_\{observer\}
$end:math:display$

**Output:**

`transformed_star_data.csv`

### Stage 3 — Stellar Visibility Calculations

**Script:** `stellar_visibility.py`

This script estimates how stellar apparent magnitudes change when viewed from a different location.

It calculates new apparent magnitudes using the distance modulus relationship and applies a limiting magnitude to identify potentially visible stars.

The current implementation uses a limiting magnitude of approximately:

$begin:math:display$
m\_G \\leq 6
$end:math:display$

This provides a simplified visibility criterion based on Gaia G-band apparent magnitude.

**Output:**

`visible_stars.csv`

### Scientific Limitations

The Python pipeline is intended as a simplified astronomical modeling and visualization workflow.

Its current limitations include:

- Distances are estimated using direct inverse parallax.
- Parallax measurement uncertainties are not propagated.
- Interstellar extinction is not modeled.
- Gaia G-band magnitudes are used rather than standard Johnson V-band magnitudes.
- Stellar proper motion is not included.
- Catalog selection effects and incompleteness are not corrected.
- The observer-centered transformation does not independently rotate the coordinate axes.
- Full-scale scientific validation has not yet been completed.

The scripts have undergone basic functional testing.

The Python pipeline is included as supporting astronomical processing code. Its integration with the Unity application has not yet been independently verified.

For additional implementation details, see:

**[Astronomical Data Processing Documentation](Astronomical_Data_Processing/README.md)**

---

## Technologies Used

### Application Development

- Unity Engine 2022.3.46f1
- C#
- Unity UI
- TextMeshPro

### Astronomical Data Processing

- Python
- Astropy
- Astroquery
- NumPy
- Gaia Data Release 3 (DR3)

### Computational and Mathematical Concepts

- Three-dimensional vector geometry
- Astronomical coordinate systems
- Equatorial-to-Galactic coordinate transformations
- Stellar parallax
- Cartesian coordinate transformations
- Distance modulus
- Apparent stellar magnitude
- Parametric equations
- Elliptical geometry
- Raycasting
- Euler-angle rotations
- Scientific visualization

---

## Project Structure

```text
ExoSky-NASA-Space-Apps-2024/
│
├── Assets/
│   └── Assets11/
│       ├── Scenes/
│       │   ├── MAIN SCENES/
│       │   ├── EXO SCENES/
│       │   └── OVERVIEW SCENES/
│       └── ...
│
├── Astronomical_Data_Processing/
│   ├── gaia_data_extraction.py
│   ├── stellar_coordinates.py
│   ├── stellar_visibility.py
│   └── README.md
│
├── Packages/
│   └── manifest.json
│
├── ProjectSettings/
│   ├── ProjectVersion.txt
│   └── EditorBuildSettings.asset
│
├── README.md
│
└── .gitignore
```

### Directory Descriptions

**Assets/**

Contains the Unity application's scripts, scenes, materials, audio, and other resources.

**Astronomical_Data_Processing/**

Contains the Python scripts responsible for astronomical catalog extraction, coordinate transformations, and simplified stellar visibility calculations.

**Packages/**

Contains the Unity package configuration.

**ProjectSettings/**

Contains the Unity project configuration.

---

## Download ExoSky for macOS

A prebuilt macOS version of ExoSky is available through GitHub Releases.

### Download

**[Download ExoSky for macOS](https://github.com/leochlala/ExoSky-NASA-Space-Apps-2024/releases/latest)**

### Installation

1. Open the GitHub Releases page using the link above.
2. Download the ZIP file containing the macOS application.
3. Extract the downloaded ZIP file.
4. Open `ExoSky.app` to launch the simulation.

The prebuilt application does not require Unity to be installed.

### macOS Compatibility

The application has been tested successfully on the developer's Mac.

Compatibility with other macOS versions and hardware configurations has not yet been independently verified.

If macOS prevents the application from opening because it is from an unidentified developer, users may need to authorize it through:

**System Settings → Privacy & Security → Open Anyway**

Users should only bypass this warning if they trust the downloaded application.

---

## Opening the Unity Source Project

### Unity Requirements

- Unity Hub
- **Unity Editor 2022.3.46f1 (Unity 2022 LTS)**

The project was developed using Unity Editor version **2022.3.46f1**.

Using the same editor version is recommended to minimize compatibility issues.

The version is recorded in:

`ProjectSettings/ProjectVersion.txt`

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/leochlala/ExoSky-NASA-Space-Apps-2024.git
```

**2. Open Unity Hub**

Launch Unity Hub on your computer.

**3. Import the project**

Select:

`Add project from disk`

Navigate to the cloned repository.

**4. Open the project**

Use Unity Editor 2022.3.46f1.

Allow Unity to import the assets and resolve the packages listed in:

`Packages/manifest.json`

**5. Launch the simulation**

Open the following scene:

`Assets/Assets11/Scenes/MAIN SCENES/WelcomeScreen.unity`

Press **Play**.

### Unity Scenes

The Unity project contains 22 application scenes enabled in its build configuration.

These include:

- 1 welcome screen.
- 1 main menu.
- 10 exoplanet observation scenes.
- 10 stellar-system overview scenes.

The configured startup scene is:

`WelcomeScreen.unity`

All 22 scenes are enabled in:

`ProjectSettings/EditorBuildSettings.asset`

The project also contains TextMesh Pro example scenes that are not part of the application's configured build.

**Note:** The Unity project files and build configuration have been inspected, but the project has not been independently reopened and compiled during the current repository review.

---

## Running the Python Astronomical Pipeline

### Requirements

The Python scripts require:

- Python 3
- NumPy
- Astropy
- Astroquery

Additional dependencies may be required depending on the installed versions of these libraries.

### Install Dependencies

From a Python environment, install the required packages:

```bash
python -m pip install numpy astropy astroquery
```

### Run the Scripts

Navigate to the astronomical processing directory:

```bash
cd Astronomical_Data_Processing
```

Run the scripts in the following order.

**1. Extract Gaia DR3 stellar data**

```bash
python gaia_data_extraction.py
```

This step requires an internet connection to access the Gaia archive.

**2. Transform stellar coordinates**

```bash
python stellar_coordinates.py
```

Follow the prompts to define the observer's position.

**3. Calculate stellar visibility**

```bash
python stellar_visibility.py
```

The pipeline produces CSV files containing the processed astronomical data.

Generated datasets are excluded from version control through `.gitignore`.

**Note:** The full 800,000-source query has not been independently tested as part of the current repository review.

---

## Project Status

This repository contains the Unity source project developed for the NASA International Space Apps Challenge 2024, together with Python scripts for astronomical data processing.

### Unity Application

The available Unity source code includes:

- Interactive constellation creation.
- Elliptical orbit visualization.
- Camera controls.
- User interface functionality.
- Exoplanet observation scenes.
- Stellar-system overview scenes.

The repository contains the project's Unity source files, scenes, assets, package declarations, and build configuration.

The prebuilt macOS application has been successfully launched and tested on the developer's Mac.

### Astronomical Data Processing

The Python scripts provide:

- Gaia DR3 data extraction.
- Stellar coordinate transformations.
- Observer-relative stellar positions.
- Simplified stellar visibility calculations.

The Python pipeline has undergone basic functional testing, including syntax checks and tests of its underlying coordinate and magnitude calculations.

Full-scale scientific validation and integration with the Unity application have not yet been independently verified.

---

## NASA Space Apps Challenge 2024

ExoSky was developed during the NASA International Space Apps Challenge 2024.

### Achievements

🏆 **Local Winner**

🌍 **Global Nominee**

The project combined astronomy, computational methods, and interactive visualization to explore alternative perspectives of the night sky.

---

## Team and Contributions

ExoSky was developed as a collaborative project during the NASA International Space Apps Challenge 2024.

### Team Members

Team member names and individual contributions will be added following confirmation.

### Leo-Georges Chlala

Individual contributions to the project will be documented following confirmation.

---

## Acknowledgments

Developed for the NASA International Space Apps Challenge 2024.

Astronomical data processing utilizes measurements from the European Space Agency's Gaia mission, particularly Gaia Data Release 3.

The project uses open-source astronomical software, including Astropy and Astroquery.

Special thanks to the organizers, mentors, and contributors who supported the project.

---

## Future Improvements

Potential future developments include:

- Improved stellar distance estimation incorporating measurement uncertainties.
- More detailed modeling of stellar apparent magnitudes.
- Interstellar extinction corrections.
- Validation of astronomical transformations against established reference calculations.
- Improved integration between astronomical data processing and Unity visualization.
- Additional observing locations and visualization features.
- Expanded scientific documentation and reproducibility testing.

---

## License

No software license has been specified for this repository.

A license may be added after confirming the appropriate permissions and agreement of the project contributors.
