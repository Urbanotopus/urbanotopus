.. _coding-style:

Style de codage
===============

Python
------

Suivez toujours la convention `PEP 8 <https://www.python.org/dev/peps/pep-0008/>`_ dans sa totalité
(ceci incluant la limite de 80 caractères sur une ligne).

Chaînes de caractères
+++++++++++++++++++++

Utilisez guillemets simples sauf si la chaîne est une docstring.

Les blocs de code
+++++++++++++++++

Merci de suivre le style de formatage "hanging grid". Comme suit :

.. code-block:: python

   some_dict = {
       'one': 1,
       'two': 2,
       'three': 3}

.. code-block:: python

   some_list = [
       'foo', 'bar', 'baz']

Merci d'éviter de laisser pendre des parenthèses, crochets, ou virgules. Par exemple, ne faites pas cela :

.. code-block:: python

   this_is_wrong = {
      'one': 1,
      'two': 2,
      'three': 3,
   }

Cassez les lignes de code directement après les parenthèses. Ne faites donc pas cela :

.. code-block:: python

   also_wrong('this is hard',
              'to maintain',
              'as it often needs to be realigned')

Linters
+++++++

Utilisez :

1. `isort <https://github.com/timothycrosley/isort>`_ pour maintenir une consistance dans vos imports ;
2. `pylint <https://www.pylint.org/>`_ pour détecter les erreurs dans votre code ;
3. `pycodestyle <http://pycodestyle.pycqa.org/en/latest/>`_ pour assurer que votre code respecte les conventions PEP 8 ;
4. `pydocstyle <http://pydocstyle.pycqa.org/en/latest/>`_ pour vérifier que vos docstrings sont correctement formatées ;
5. `eslint <https://eslint.org/>`_ pour vérifier votre code Javascript ;
6. `tslint <https://palantir.github.io/tslint/>`_ pour vérifier votre code Typescript.


CSharp (C#)
-----------

Les blocs de code
-----------------

Veuillez ne pas retourner à la ligne après l'ouverture d'un crochet
puis retourner à la ligne après une fermeture.

Faites :

.. code-block:: csharp

    namespace models {
        public class Employee {
            public Employee(int id) {
                if (id == 0) {
                    try {
                        id = id / 0;
                    }
                    catch(System.DivideByZeroException exc) {
                        // We did not stick `catch(...) {` to `}`.
                    }
                }
                else {
                    // We did not stick `else {` to `}`.
                }
            }
        }
    }


L'accès à l'instance courante
-----------------------------

Veuillez utiliser le mot ``this`` pour accèder à l'instance courante.

Faites :

.. code-block:: csharp

    public class Employee {
        private string _nameAlias;
        private string _name;

        public Employee(string name, string nameAlias) {
            // Use this to qualify the members of the class
            // instead of the constructor parameters.
            this._alias = name;
            this._nameAlias = nameAlias;
            System.Console.WriteLine(this._name);
        }
    }

Et non pas :

.. code-block:: csharp

    public class Employee {
        private string _nameAlias;
        private string _name;

        public Employee(string name, string nameAlias) {
            // Use this to qualify the members of the class
            // instead of the constructor parameters.
            _name = name;
            _nameAlias = nameAlias;
            System.Console.WriteLine(_name);
        }
    }
