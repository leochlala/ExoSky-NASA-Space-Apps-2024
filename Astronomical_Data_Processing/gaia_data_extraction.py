from astroquery.gaia import Gaia
from astropy.coordinates import SkyCoord
import astropy.units as u
from pathlib import Path
import csv
import numpy as np


# --------------------------------------------------
# 1. Retrieve stellar data from Gaia DR3
# --------------------------------------------------

query = """
SELECT TOP 800000
    source_id,
    ra,
    dec,
    phot_g_mean_mag,
    parallax
FROM gaiadr3.gaia_source
WHERE phot_g_mean_mag < 15
    AND parallax IS NOT NULL
    AND parallax > 0
ORDER BY phot_g_mean_mag ASC
"""

print("Retrieving stellar data from Gaia DR3...")

job = Gaia.launch_job_async(query)
results = job.get_results()

print(f"Retrieved {len(results)} stellar sources.")


# --------------------------------------------------
# 2. Convert equatorial to galactic coordinates
# --------------------------------------------------

def equatorial_to_galactic(ra_deg, dec_deg):
    """
    Convert ICRS equatorial coordinates (RA, Dec)
    into galactic coordinates (l, b).

    All input and output angles are in degrees.
    """

    sky_coord = SkyCoord(
        ra=ra_deg * u.degree,
        dec=dec_deg * u.degree,
        frame="icrs"
    )

    galactic_coord = sky_coord.galactic

    return galactic_coord.l.deg, galactic_coord.b.deg


# --------------------------------------------------
# 3. Process stellar data
# --------------------------------------------------

star_data = []

for row in results:

    parallax = row["parallax"]

    if np.ma.is_masked(parallax):
        continue

    parallax = float(parallax)

    if not np.isfinite(parallax) or parallax <= 0:
        continue

    source_id = row["source_id"]
    ra = float(row["ra"])
    dec = float(row["dec"])
    g_mag = float(row["phot_g_mean_mag"])

    l, b = equatorial_to_galactic(ra, dec)

    star_data.append([
        source_id,
        ra,
        dec,
        g_mag,
        l,
        b,
        parallax
    ])


# --------------------------------------------------
# 4. Export data to CSV
# --------------------------------------------------

output_directory = Path(__file__).resolve().parent

csv_output_file = output_directory / "star_data_with_parallax.csv"

with open(csv_output_file, mode="w", newline="") as file:

    writer = csv.writer(file)

    writer.writerow([
        "Star Name (Source ID)",
        "RA",
        "DEC",
        "G-band Magnitude",
        "Galactic Longitude (l)",
        "Galactic Latitude (b)",
        "Parallax (mas)"
    ])

    writer.writerows(star_data)


print(f"Successfully processed {len(star_data)} stars.")
print(f"Data saved to: {csv_output_file}")