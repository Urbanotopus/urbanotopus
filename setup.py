from setuptools import setup
import subprocess

subprocess.call(
    'doxygen;'
    'mkdir -p public_html/doxygen;'
    'cp -R html/* public_html/doxygen/', shell=True)


setup(
    name='urbanotopus'
)

