from setuptools import setup
import subprocess
import os

subprocess.call(
    'doxygen;'
    'mkdir -p doxygens/doxygens;'
    'cp -R html/* doxygens/doxygens/', shell=True)


setup(
    name='urbanotopus'
)

