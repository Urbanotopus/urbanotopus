<p align='center'>
  <a href='https://urbanotopus.vanille.bid/'>
    <img alt='logo' src='source/sphinx_static/images/octopus.png'/>
  </a>
</p>

<h1 align='center'>Urbanotopus Game and Docs</h1>
<p align='center'>Game sources and documentation for Urbanotopus.</p>


## How does this repository works
1. Pull requests are created to write changes to master;
1. They get accepted and merged;
1. Travis builds the documentation and deploys it to the `gh-pages` branch;
1. GitHub builds the pages and the changes get published to [urbanotopus.vanille.bid](https://urbanotopus.vanille.bid).


## Development

1. Install Unity 2018 [for Windows](https://netstorage.unity3d.com/unity/38bd7dec5000/UnityDownloadAssistant-2018.2.11f1.exe) 
| [for MacOS](https://netstorage.unity3d.com/unity/38bd7dec5000/UnityDownloadAssistant-2018.2.11f1.dmg)
| [for others](https://unity.com/);
1. Install [Python 3.7](https://www.python.org/downloads/release/python-337/);
1. Create and activate a [python virtual environment](https://docs.python.org/3/library/venv.html);
1. Install the requirements through `pip install -r requirements.txt`;
1. Edit the files under the [docs](docs/) folder;
1. Build or rebuild the docs by running `make html`;
1. Open your web-browser to `build/html/index.html`.


## How to build the docs
Reminder: to build or rebuild the docs, 
**run `make html` from the project's root directory**.


## Resources
- [**How to document a project using Sphinx**](https://pythonhosted.org/an_example_pypi_project/sphinx.html#restructured-text-rest-resources);
- [**How to use the `venv` Python module to create and manage virtual environments**](https://docs.python.org/3/library/venv.html).
- [Appveyor CI documentation to build the project on Windows](https://www.appveyor.com/docs/);
- [Travis CI documentation to build the project on Linux and Mac OS](https://docs.travis-ci.com/).
