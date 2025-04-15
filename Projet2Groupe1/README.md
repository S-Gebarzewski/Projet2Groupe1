# SoundTogether - Projet de Gestion d'Événements Musicaux

Ce projet a été réalisé dans le cadre d'un second projet d'étude en groupe. Il s'agit d'une application web de gestion d'événements musicaux avec différents niveaux d'accès utilisateur.


## Technologies utilisées
- **Backend** : C# (.NET Core MVC)
- **Frontend** : HTML, CSS, JavaScript
- **Base de données** : MySQL
- **ORM** : Entity Framework Core
- **Environnement de développement** : Visual Studio

## Fonctionnalités principales

### Gestion des utilisateurs
L'application propose 4 types d'utilisateurs avec des droits d'accès différents :
- **Administrateur** : Validation des événements, inscription des organisateurs, validation des sessions de jam
- **Organisateur** : Publication et gestion des événements musicaux
- **Adhérent** : Achat de billets pour les événements
- **Adhérent Premium** : Achat de billets + organisation et participation aux sessions de jam

### Gestion des événements
L'application permet de gérer différents types d'événements :
- Concerts
- Festivals
- Sessions de dédicace
- Sessions de jam (pour les adhérents premium)

### Billetterie
- Achat de billets pour les événements
- Différentes catégories de billets (Standard, VIP)
- Suivi des ventes

## Architecture du projet
- **Modèle MVC** (Model-View-Controller)
- **DataAccessLayer** (DAL) pour l'accès aux données
- **Services** spécifiques pour chaque entité (UserService, EventService, etc.)
- **ViewModels** pour la gestion des vues

## Structure de la base de données
Principales entités :
- Users (Admin, Organizer, Member, Provider)
- Events (Concert, Festival, SigningSession)
- JamSessions
- Services
- Tickets

## Installation
1. Cloner le dépôt GitHub
2. Configurer la connexion à la base de données MySQL dans `DataBaseContext.cs`
3. Exécuter les migrations Entity Framework pour créer le schéma de base de données
4. Lancer l'application depuis Visual Studio

