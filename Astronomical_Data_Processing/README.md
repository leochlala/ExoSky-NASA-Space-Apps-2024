# ExoSky — Astronomical Data Processing

## Overview

This directory contains the Python scripts developed for the astronomical data-processing component of **ExoSky**, a project created for the NASA International Space Apps Challenge 2024.

ExoSky explores how the night sky changes when viewed from different locations in space.

The scripts retrieve stellar observations from the Gaia DR3 catalog, transform stellar positions into a new observer-centered coordinate system, and estimate which stars would be visible from that location.

The resulting data can be used to construct a three-dimensional representation of the stellar environment surrounding a hypothetical observer.

## Scientific Background

The apparent positions and brightnesses of stars depend on the observer's location.

When an observer moves to another stellar system, nearby stars can appear in different directions due to the change in viewing perspective.

ExoSky models this effect by representing stars in three-dimensional Cartesian coordinates and translating their positions relative to a selected observer.

The pipeline uses data from the European Space Agency's Gaia mission.

## Python Scripts

### 1. gaia_data_extraction.py

Retrieves stellar observations from the Gaia Data Release 3 (DR3) catalog using Astroquery.

The script requests up to **800,000 stellar sources** and extracts:

- Gaia source identifier
- Right ascension (RA)
- Declination (Dec)
- Apparent G-band magnitude
- Parallax

Stellar coordinates are converted from the International Celestial Reference System (ICRS) to Galactic coordinates using Astropy.

The resulting dataset is saved as:

`star_data_with_parallax.csv`

### 2. stellar_coordinates.py

Transforms stellar positions into a Cartesian coordinate system centered on a new observer.

First, stellar distances are estimated from parallax:

d(pc) = 1000 / p(mas)

Galactic spherical coordinates are converted into Cartesian coordinates:

x = r cos(b) cos(l)

y = r cos(b) sin(l)

z = r sin(b)

where:

- r is the stellar distance in parsecs.
- l is Galactic longitude.
- b is Galactic latitude.

The observer's position is calculated using the same coordinate system.

Each star's position relative to the observer is then determined using:

r_relative = r_star - r_observer

The transformed stellar coordinates are saved as:

`transformed_star_data.csv`

### 3. stellar_visibility.py

Estimates stellar apparent magnitudes from the new observer's location.

The calculation uses the distance-modulus relationship:

m_new = m_original + 5 log10(d_new / d_original)

where:

- m_original is the apparent G-band magnitude measured by Gaia.
- d_original is the original distance from the Solar System.
- d_new is the distance from the new observer.

Stars are filtered using an approximate naked-eye visibility threshold of magnitude 6.

The resulting dataset is saved as:

`visible_stars.csv`

## Processing Pipeline

The scripts are executed in the following order:

1. Gaia DR3 data extraction
2. Stellar coordinate transformations
3. Apparent-magnitude calculations and visibility filtering

Pipeline:

Gaia DR3
    |
    v
gaia_data_extraction.py
    |
    v
star_data_with_parallax.csv
    |
    v
stellar_coordinates.py
    |
    v
transformed_star_data.csv
    |
    v
stellar_visibility.py
    |
    v
visible_stars.csv

## Requirements

Python 3.9 or newer is recommended.

Required libraries:

- NumPy
- Astropy
- Astroquery

Install the dependencies using:

```bash
python3 -m pip install numpy astropy astroquery
```

## Usage

Run the scripts sequentially from this directory.

### Step 1 — Retrieve stellar data

```bash
python3 gaia_data_extraction.py
```

The script queries Gaia DR3 and generates the initial stellar dataset.

An internet connection is required.

For testing, reduce the Gaia query limit from 800,000 to a smaller number, such as 100.

### Step 2 — Transform stellar coordinates

```bash
python3 stellar_coordinates.py
```

Enter the Galactic longitude, latitude, and parallax defining the new observer's position.

The script generates observer-centered Cartesian coordinates.

### Step 3 — Estimate stellar visibility

```bash
python3 stellar_visibility.py
```

The script calculates approximate apparent G-band magnitudes from the new observer's location and filters stars according to the visibility threshold.

## Scientific Assumptions and Limitations

The current implementation uses several simplifying assumptions:

- Stellar distances are estimated using inverse parallax.
- Parallax uncertainties are not explicitly propagated.
- Interstellar extinction is neglected.
- Gaia G-band magnitudes are used as approximations for visual brightness.
- Stellar proper motion and radial velocity are not included.
- The Gaia query is magnitude-limited and does not provide a complete stellar catalog for every possible observer location.
- The observer-centered transformation changes the coordinate origin but does not independently define a new orientation for the coordinate axes.

These assumptions should be considered when interpreting the simulated stellar positions and brightnesses.

## Validation

The scripts have been tested using a small sample of 100 Gaia sources.

Basic mathematical tests verified:

- Galactic spherical-to-Cartesian conversion.
- Translation of stellar coordinates to a new observer.
- Apparent-magnitude calculations using the distance-modulus relationship.

Large-scale processing of the full 800,000-source query has not yet been validated.

## Project Recognition

**ExoSky** was developed for the **NASA International Space Apps Challenge 2024**.

Recognition: **Local Winner | Global Nominee**

The astronomical data-processing scripts complement the Unity/C# visualization component of the project.