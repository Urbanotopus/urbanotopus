Documenter le code source
=========================
Pour chaque méthode et classe et veillez à ce que les documentations en commentaires
restent valides et à jour si vous modifiez la signature et/ ou le corps d'une méthode ou d'une classe.


Documenter le code C# (XML)
---------------------------
Veuillez inclure les commentaires XML standards de C#. Chaque méthode doit au moins inclure un ``<summary>`` et tous
les paramètres (``<param name="something">``) ainsi qu'un ``<returns>`` si la méthode n'est ``void``.


Formatage des tags XML
++++++++++++++++++++++

1. Les tags avec une seule ligne doivent commencer et se terminer sur la même ligne.
2. Les tags sur multiples lignes doivent avoir une ligne vide après l'ouverture et avant la fermeture.
   Et ne doivent comporter une indentation.
3. Les tags imbriqués doivent avoir une indentation de 4 espaces.

Exemple :

.. code-block:: csharp

    /// <summary>This has only one line</summary>
    /// <remarks>
    /// This has multiple
    /// lines
    /// </remarks>
    /// <param name="n">
    ///     <ul>
    ///         <li>This is nested</li>
    ///     </ul>
    /// </param>


Exemple complet
+++++++++++++++

.. code-block:: csharp

    /// <summary>Class level summary documentation goes here.</summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    public class TestClass : TestInterface {
        /// <summary>Store for the name property.</summary>
        private string _name = null;

        /// <summary>The class constructor.</summary>
        public TestClass() {
            // TODO: Add Constructor Logic here.
        }

        /// <summary>Name property.</summary>
        /// <value>A value tag is used to describe the property value.</value>
        public string Name {
            get {
                if (_name == null) {
                    throw new System.Exception("Name is null");
                }
                return _name;
            }
        }

        /// <summary>Description for SomeMethod.</summary>
        /// <param name="s">Parameter description for s goes here.</param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member
        /// and the compiler will check that the reference exists.
        /// </seealso>
        public void SomeMethod(string s) {
        }

        /// <summary>Some other method.</summary>
        /// <returns>Return results are described through the returns tag.</returns>
        /// <seealso cref="SomeMethod(string)">
        /// Notice the use of the cref attribute to reference a specific method.
        /// </seealso>
        public int SomeOtherMethod() {
            return 0;
        }

        /// <summary>The entry point for the application.</summary>
        /// <param name="args">A list of command line arguments.</param>
        static int Main(System.String[] args) {
            // TODO: Add code to start application here.
            return 0;
        }
    }

    /// <summary>Documentation that describes the interface goes here.</summary>
    /// <remarks>Details about the interface go here.</remarks>
    interface TestInterface {
        /// <summary>Documentation that describes the method goes here.</summary>
        /// <param name="n">Parameter n requires an integer argument.</param>
        /// <returns>The method returns an integer.</returns>
        int InterfaceMethod(int n);
    }


Documenter le code Python avec des docstring Sphinx
---------------------------------------------------
Veuillez inclure des docstring du format Sphinx sur Python. Chaque méthode doit au moins
inclure une courte description sur ce qu'elle fait et tous
les paramètres (``:param something: it's something``) ainsi qu'un ``:returns: Blablabla``
si la méthode retourne quelque chose
(`plus d'informations <https://pythonhosted.org/an_example_pypi_project/sphinx.html#function-definitions>`_).

Formatage de la docstring
+++++++++++++++++++++++++
Veuillez noter que la description doit être sur la même ligne que sur l'ouverture de la docstring.
Par exemple :

.. code-block:: python

    """This is a good way to do.
    I'm happy.
    """

Et ne pas faire :

.. code-block:: python

    """
    This is a good way to do.
    I'm happy.
    """


Exemple complet
+++++++++++++++

.. code-block:: python

    """
    .. module:: useful_1
       :platform: Unix, Windows
       :synopsis: A useful module indeed.

    .. moduleauthor:: Andrew Carter <andrew@invalid.com>


    """

    def public_fn_with_googley_docstring(name, state=None):
        """This function does something.

        Args:
           name (str):  The name to use.

        Kwargs:
           state (bool): Current state to be in.

        Returns:
           int.  The return code::

              0 -- Success!
              1 -- No good.
              2 -- Try again.

        Raises:
           AttributeError, KeyError

        A really great idea.  A way you might use me is

        >>> print public_fn_with_googley_docstring(name='foo', state=None)
        0

        BTW, this always returns 0.  **NEVER** use with :class:`MyPublicClass`.

        """
        return 0

    def public_fn_with_sphinxy_docstring(name, state=None):
        """This function does something.

        :param name: The name to use.
        :type name: str.
        :param state: Current state to be in.
        :type state: bool.
        :returns:  int -- the return code.
        :raises: AttributeError, KeyError

        """
        return 0

    def public_fn_without_docstring():
        return True

    def _private_fn_with_docstring(foo, bar='baz', foobarbas=None):
        """I have a docstring, but won't be imported if you just use ``:members:``.
        """
        return None


    class MyPublicClass(object):
        """We use this as a public class example class.

        You never call this class before calling :func:`public_fn_with_sphinxy_docstring`.

        .. note::

           An example of intersphinx is this: you **cannot** use :mod:`pickle` on this class.

        """

        def __init__(self, foo, bar='baz'):
            """A really simple class.

            Args:
               foo (str): We all know what foo does.

            Kwargs:
               bar (str): Really, same as foo.

            """
            self._foo = foo
            self._bar = bar

        def get_foobar(self, foo, bar=True):
            """This gets the foobar

            This really should have a full function definition, but I am too lazy.

            >>> print get_foobar(10, 20)
            30
            >>> print get_foobar('a', 'b')
            ab

            Isn't that what you want?

            """
            return foo + bar

        def _get_baz(self, baz=None):
            """A private function to get baz.

            This really should have a full function definition, but I am too lazy.

            """
            return baz
