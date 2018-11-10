Charger des scènes
==================

Pour charger des scènes, vous devez utiliser ``Managers.InternalScenesManager.LoadScene(name: string)``
afin de correctement prendre en charge les longues étapes de chargement, et non pas geler l'écran de l'utilisateur.
Voici la définition :

.. class:: Managers.InternalScenesManager

    .. py:attribute:: MainMenu = "MainMenuScene";

        Le nom de la scène du menu principal.

    .. py:attribute:: Office = "OfficeScene";

        Le nom de la scène du bureau de l'urbaniste.

    .. py:attribute:: VisualNovel = "VisualNovelScene";

        Le nom de la scène du bureau de visual novel.

    .. method:: LoadScene(name: string)

        :param name: Le nom de la scène à charger.
