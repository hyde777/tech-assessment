# Conception et architecture de système

L'application dans son état pour le test technique n'est pas utilisable en production.

Faites une liste de l'ensemble des éléments que vous estimez devoir être corrigés et/ou améliorés pour avoir une application "prod-ready".
Pour chaque élément, proposez également un plan de remédiation.

Décrivez également comment ajouter une fonctionnalité permettant aux clients de s'inscrire par eux-même à une session de formation après l'avoir acheté auprès d'un commercial WeChooz.
Décrivez les flux d'intéraction utilisateurs, ainsi que les différents mécanismes de sécurité envisagés pour éviter les risques d'inscription frauduleuse (sans imposer aux clients de se connecter).

# Reponse

Hello, ce n'est pas un exercice que j'ai l'habitude de faire (j'ai plus l'habitude de penser a un scope intra-applicatif)
mais voici ce qui pour moi il faut pour avoir une application prod-ready
## Le build

En l'état il faut dans un premier de temps mettre a niveau l'infrastructure pour fluidifier le développement du projet:
Ajouter tous les éléments de devops pour avoir des mise en prod fluide et automatisé: CI/CD, Test d'intégration et de bout en bout, environnement de dev et de tests varié
Pour ça, le must serait de se former au devops ou d'avoir un devops attitré qui gérera tout ce pan de l'architecture sur un cloud, un multicloud ou en physique(ça dépend du besoin)

## Le Run

Pour suivre l'évolution de l'état de la prod et répondre aux divers bug qui peuvent arriver des suites d'une mise en prod il faut s'y préparer.
On peut utiliser plusieurs méthodes pour monitorer l'état de santé de l'application(Du logs et des alertes) et s'y préparer en cassant nous même nos application (ingénierie du chaos), et en les stress-testant au préalable.
Il faudra aussi ajouter des indicateurs pour se rendre compte de l'utilisation des fonctionnalités du produit, via de l'AB Testing, du feature flag et des kpis via des traqueurs

## Securité et confidentialité

De plus l'application aura besoin d'une authentification plus poussé où l'on supprime le compte admin pour avoir des compte nominatif qui auront des droits spécifique avec leurs rôle
Et pour gérer ça il faudrait se faire une api auto-sufisante qui gère les identité et la sécurité en général

De plus il faudra s'assurer de respecter la RGPD en mettant a disposition l'ensemble des information de l'utilisateurs a sa demande si besoin

## Nouvelle fonctionnalité

Le mieux a faire pour cette nouvelle fonctionnalité serait de faire un tunnel de souscription,
l'utilisateur donnerait les informations nécessaire via ce tunnel et pour s'assurer que ce soit bien une personne derrière, on lui demandera de vérifier son mail (via de l'OTP)
On pourrais aussi faire de l'OTP par SMS ou encore utiliser un capcha 