import numpy as np
import csv
from pathlib import Path


# --------------------------------------------------
# 1. Calculate apparent magnitude from new observer
# --------------------------------------------------

def calculate_apparent_magnitude(
    original_apparent_magnitude,
    original_distance,
    new_distance
):
    """
    Calculate a star's apparent G-band magnitude
    from a new observation point.

    Parameters:
        original_apparent_magnitude:
            Gaia apparent G-band magnitude.

        original_distance:
            Distance from the Sun to the star (parsecs).

        new_distance:
            Distance from the new observer to the star
            (parsecs).

    Assumes negligible interstellar extinction.
    """

    if original_distance <= 0 or new_distance <= 0:
        return None

    return (
        original_apparent_magnitude
        + 5 * np.log10(new_distance / original_distance)
    )


# --------------------------------------------------
# 2. Determine stellar visibility
# --------------------------------------------------

def is_visible(apparent_magnitude, magnitude_limit=6.0):
    """
    Check whether a star is potentially visible
    to the naked eye.

    A magnitude limit of approximately 6 is used
    for excellent dark-sky conditions.

    Gaia G-band magnitude is used as an approximation
    rather than a visual V-band magnitude.
    """

    return apparent_magnitude <= magnitude_limit


# --------------------------------------------------
# 3. Calculate distance from Cartesian coordinates
# --------------------------------------------------

def calculate_distance_from_cartesian(x, y, z):
    """
    Calculate Euclidean distance from the observer
    to a star, using relative Cartesian coordinates.
    """

    return np.sqrt(x**2 + y**2 + z**2)


# --------------------------------------------------
# 4. Main program
# --------------------------------------------------

def main():

    directory = Path(__file__).resolve().parent

    input_file = directory / "transformed_star_data.csv"

    output_file = directory / "visible_stars.csv"

    results = []

    with open(input_file, mode="r", newline="") as infile:

        reader = csv.DictReader(infile)

        for row in reader:

            x = float(row["Transformed x"])
            y = float(row["Transformed y"])
            z = float(row["Transformed z"])

            original_magnitude = float(
                row["G-band Magnitude"]
            )

            original_distance = float(
                row["Distance (pc)"]
            )

            new_distance = calculate_distance_from_cartesian(
                x, y, z
            )

            apparent_magnitude = calculate_apparent_magnitude(
                original_magnitude,
                original_distance,
                new_distance
            )

            if apparent_magnitude is None:
                continue

            if is_visible(apparent_magnitude):

                results.append([
                    row["Star Name (Source ID)"],
                    x,
                    y,
                    z,
                    original_magnitude,
                    original_distance,
                    new_distance,
                    apparent_magnitude
                ])

    with open(output_file, mode="w", newline="") as outfile:

        writer = csv.writer(outfile)

        writer.writerow([
            "source_id",
            "x",
            "y",
            "z",
            "original_g_magnitude",
            "original_distance_pc",
            "new_distance_pc",
            "new_apparent_g_magnitude"
        ])

        writer.writerows(results)

    print(f"Found {len(results)} potentially visible stars.")
    print(f"Visible stars saved to: {output_file}")


if __name__ == "__main__":
    main()