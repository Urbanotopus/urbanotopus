Convention de nommage
=====================

Python
++++++

1. Les variables, nom de fonctions et méthodes doivent être écrites en minuscles et les mots séparés par des underscores ;
2. Les constantes doivent être écrites en majuscules et les mots séparés par des underscores ;
3. Les noms de classes et d'objets doivent commencer par une majuscule et suivre le format ``CamelCase`` ;
4. Les méthodes et variables privées doivent commencer par un underscore.


.. code-block:: python

    CONSTANT = 'abc'

    class HelloWorld(object):
        _private_prop = 'hello'

        def __init__(self):
            pass

        def _private_method(self):
            pass

        def say_hi(self):
            pass


    def main():
        var = 123


CSharp (C#) et Javascript/ Typescript
+++++++++++++++++++++++++++++++++++++

1. Les variables, nom de fonctions et méthodes doivent commencer par une minuscles et suivre le format ``camelCase`` ;
2. Les constantes doivent être écrites en majuscules et les mots séparés par des underscores ;
3. Les noms de classes et d'objets doivent commencer par une majuscule et suivre le format ``CamelCase`` ;
4. Les méthodes et variables privées doivent commencer par un underscore.


.. code-block:: c#

    const int CONSTANT = 123;

    private class HelloWorld {
        public int somethingPublic = 123;

        private const _PRIVATE_CONSTANT = 123;
        private int _privateProp;

        HelloWorld() {
            // do something...
        }

        private int _privateMethod() {
            int variableWorld = 123;
            return variableWorld;
        }

        public void say_hi() {
            // do something...
        }
    }
