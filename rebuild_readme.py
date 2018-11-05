import re
import os.path
from bs4 import BeautifulSoup

RE_HREF_LINK = re.compile(r'\shref="([^"]+)"')

ROOT_PATH = os.path.abspath(os.path.dirname(__file__))
README = os.path.join(ROOT_PATH, 'README.md')
INDEX_PAGE = os.path.join(ROOT_PATH, 'build', 'html', 'index.html')

START_INSTRUCTION = '<!-- Begin TOC -->'
END_INSTRUCTION = '<!-- End TOC -->'

EXTERNAL_URL = 'https://urbanotopus.readthedocs.io/en/latest/'


def update_link(repl):
    """Replaces a href link by an absolute link."""
    return ' href="{}"'.format(EXTERNAL_URL + repl.group(1))


def retrieve_toc():
    """Retrieve the generated sphinx TOC and replace relative links
    by absolute links"""
    # Read the compiled sphinx TOC
    with open(INDEX_PAGE) as fp:
        bs = BeautifulSoup(fp.read(), features='html5lib')

    # Retrieve the TOC
    table_of_contents = bs.select('.toctree-wrapper')
    assert table_of_contents

    # Decode the content and convert relative links to absolute
    return RE_HREF_LINK.sub(update_link, str(table_of_contents[0]))


def replace_toc():
    """Replace the old README TOC with the latest version."""
    # Retrieve the README content
    with open(README) as fp:
        readme = fp.read()

    # Search the TOC block target slicing
    start = readme.find(START_INSTRUCTION)
    end = readme.find(END_INSTRUCTION)
    assert start > 0 and end > 0

    # Replace the old TOC with the latest
    contents = (
        readme[:start + len(START_INSTRUCTION)]
        + retrieve_toc()
        + readme[end:])

    # Return the new README
    return contents


def main():
    # Retrieve the new README
    readme = replace_toc()

    # Update the old README
    with open(README, 'w') as w:
        w.write(readme)


if __name__ == '__main__':
    main()
