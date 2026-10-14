import numpy as np
import csv
from pathlib import Path


# --------------------------------------------------
# 1. Galactic spherical coordinates to Cartesian
# --------------------------------------------------

def galactic_to_cartesian(b, l, r):
    """
    Convert galactic coordinates to Cartesian coordinates.

    Parameters:
        b : Galactic latitude (degrees)
        l : Galactic longitude (degrees)
        r : Distance (parsecs)

    Returns:
        NumPy array [x, y, z] in parsecs.
    """

    b_rad = np.radians(b)
    l_rad = np.radians(l)

    x = r * np.cos(b_rad) * np.cos(l_rad)
    y = r * np.cos(b_rad) * np.sin(l_rad)
    z = r * np.sin(b_rad)

    return np.array([x, y, z])


# --------------------------------------------------
# 2. Calculate distance from parallax
# --------------------------------------------------

def calculate_distance_from_parallax(parallax_mas):
    """
    Estimate distance in parsecs from parallax
    measured in milliarcseconds.
    """

    if not np.isfinite(parallax_mas) or parallax_mas <= 0:
        return None

    return 1000.0 / parallax_mas


# --------------------------------------------------
# 3. Transform coordinates to a new observer
# --------------------------------------------------

def transform_galactic_coordinates(
    b, l, r, observer_position
):
    """
    Calculate a star's Cartesian position relative
    to a new observer.

    Both positions use the same galactic
    Cartesian reference frame.
    """

    star_position = galactic_to_cartesian(b, l, r)

    relative_position = star_position - observer_position

    return relative_position


# --------------------------------------------------
# 4. Main program
# --------------------------------------------------

if __name__ == "__main__":

    print("ExoSky — Stellar Coordinate Transformation")

    new_center_b = float(
        input("Enter observer galactic latitude (degrees): ")
    )

    new_center_l = float(
        input("Enter observer galactic longitude (degrees): ")
    )

    parallax_mas = float(
        input("Enter observer parallax (mas): ")
    )

    observer_distance = calculate_distance_from_parallax(
        parallax_mas
    )

    if observer_distance is None:
        raise ValueError("Observer parallax must be positive.")

    observer_position = galactic_to_cartesian(
        new_center_b,
        new_center_l,
        observer_distance
    )

    print(f"Observer position (pc): {observer_position}")

    # Read and write files in the script's directory
    directory = Path(__file__).resolve().parent

    input_file = directory / "star_data_with_parallax.csv"

    output_file = directory / "transformed_star_data.csv"

    fieldnames = [
        "Star Name (Source ID)",
        "Original Latitude (b)",
        "Original Longitude (l)",
        "Distance (pc)",
        "Transformed x",
        "Transformed y",
        "Transformed z",
        "G-band Magnitude"
    ]

    with open(input_file, mode="r", newline="") as file:

        reader = csv.DictReader(file)

        with open(output_file, mode="w", newline="") as outfile:

            writer = csv.DictWriter(
                outfile,
                fieldnames=fieldnames
            )

            writer.writeheader()

            for row in reader:

                b = float(row["Galactic Latitude (b)"])
                l = float(row["Galactic Longitude (l)"])

                parallax = float(row["Parallax (mas)"])

                distance = calculate_distance_from_parallax(
                    parallax
                )

                if distance is None:
                    continue

                relative_position = transform_galactic_coordinates(
                    b,
                    l,
                    distance,
                    observer_position
                )

                writer.writerow({
                    "Star Name (Source ID)":
                        row["Star Name (Source ID)"],

                    "Original Latitude (b)": b,

                    "Original Longitude (l)": l,

                    "Distance (pc)": distance,

                    "Transformed x": relative_position[0],

                    "Transformed y": relative_position[1],

                    "Transformed z": relative_position[2],

                    "G-band Magnitude":
                        row["G-band Magnitude"]
                })

    print(f"Transformed star data saved to: {output_file}")