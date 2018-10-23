Contribuer au code
==================

Ajouter et modifier du contenu dans nos projets
-----------------------------------------------
Si vous souhaitez ajouter ou modifier du code ou n'importe quel autre contenu dans nos projets,
vous devez tout d'abord commencer par **créer une issue** avant d'ouvrir une **pull request**
(sauf si le changement est vraiment très mineur, comme une ou des typos,
dans ce cas **une simple pull request est suffisante**).

L'objectif de l'ouverture d'une issue avant l'ouverture d'une *pull request* est de pouvoir discuter
du problème que vous souhaitez résoudre ou de la solution que vous proposez. Cela permet donc d'ouvrir une discussion
avant d'ouvrir une *pull request* qui risque fortement d'être refusée car non convenable et donc demandera
une ou des modifications, menant à du travail et temps supplémentaire, et cela salira l'historique ``git`` du projet.

De plus, si votre changement apporte des changements ou des ajouts graphiques, veillez à ajouter une ou des captures
d'écran ou une vidéo de démonstration.

.. warning::
    Veillez à avoir un message de commit propre et ne pas créer
    une masse de commits pour des changements mineurs.
    Quitte à réécrire ou modifier les commits afin de nettoyer
    ce que vous avez fait.
    `Plus d'informations <https://chris.beams.io/posts/git-commit/>`_.

.. note::
    Évitez de *pull* la branche ``master`` dans le but de mettre à jour
    votre branche ou afin de résoudre des conflits. Préférez plutôt
    un ``git rebase -i`` ce qui permettra de préserver un historique propre.


Comment contrôler (review) les pull requests
--------------------------------------------
Notre méthode standard afin de *review* une *pull request* est :

Première étape
++++++++++++++
Lire le code source et changements à la recherche d'erreurs (bugs ou possibles bugs et typos),
de mauvaises pratiques, de violation de convention, de complexités et de code non optimal.

.. image:: https://i.imgur.com/KScJSW6.png

Deuxième étape
++++++++++++++
Suggérer des changements si certaines choses semblent mauvaises, pourraient être améliorées ou affinées.
Le tout avec des commentaires constructifs.

.. image:: https://i.imgur.com/AGnYokS.png

Troisième étape
+++++++++++++++
Récupèrer les changements pour les tester et les vérifier localement.
Pour cela, assurez-vous que votre clone local du dépôt git a pour ``upstream remote``, la source de base du projet,
celui pour lequel la *pull request* est associée.
Pour vérifier, faites ``git remote -v``, vous devriez avoir en upstream ``fetch`` le dépôt de source, comme suit :

.. image:: https://i.imgur.com/zyFhyEz.png

Si vous avez un remote mais pas le bon, faites : ``git remote remove upstream`` ;

Si vous n'avez le remote ``upstream`` **ou vous avez supprimé l'upstream (avec la commande ci-dessus)**,
ajoutez via ``git remote add URL_DÉPÔT_SOURCE>``.
Si le projet est ``Urbanotopus``, faites ``git remote add git@github.com:Urbanotopus/urbanotopus.git``.

Vérifiez avec ``git remote -v``.

Ensuite, récupérez le contenu de la *pull request* en
faisant un ``git fetch upstream pull/ID_DE_LA_PULL_REQUEST/head:NOM_DE_BRANCH`` puis ``git checkout NOM_DE_BRANCH``.

Par exemple, si la *pull request* est ``#2``, faites
``git fetch upstream pull/2/head:test-database`` puis ``git checkout test-database``.

Testez les changements qui ont été récupérés.

Quatrième étape
+++++++++++++++
Maintenant que vous avez testé les changements, vous pouvez valider ou non les changements.
Si vous trouvez un bug ou souci à une ligne donnée ajouter un review à la ligne concernée :

.. image:: https://i.imgur.com/AGnYokS.png

Si vous avez des commentaires globaux ou vous voulez refuser ou accepter la *pull request*,
donnez votre avis via le pop-up :

.. image:: https://i.imgur.com/WkGDy2x.png
