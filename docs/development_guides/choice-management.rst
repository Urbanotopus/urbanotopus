Gestion des décisions
=====================

.. _metadata-chapters:

Répertoriage des choix possibles
--------------------------------
Afin de permettre une consistance simple et efficace des choix possibles
entre les scripts Yarn et les bases de données côté serveur, nous utilisons
un mécanisme de répertoriage de ces derniers.

.. topic:: Méta-données d'un chapitre

    Dans un fichier, ``Assets/ChapterData/<chapter_id>/questions.json``,
    vous retrouverez et respecterez la structure suivante :

    .. code-block:: json
        :linenos:
        :caption: ``Assets/ChapterData/<chapter_id>/questions.json``

        {
            "<question_id>": {
                "<answer_id>": {
                    "description": "something"
                }
            }
        }


Sauvegarde et propagation d'une décision
----------------------------------------
Lorsque le joueur prend une décision,
elle doit être annoncée en accordance avec les :ref:`méta-données d'un chapitre <metadata-chapters>`
par le biais de l'instruction Yarn suivante :

.. code-block:: text

    << register_choice Globals <chapter_id> <question_id> <answer_id> >>

Le jeu se chargera ensuite de la serialisation et
de la communication avec le serveur distant (en tâche asynchrone).

.. note::

    Veillez à ce que le *prefab* ``Globals`` soit disponible dans votre scène.
