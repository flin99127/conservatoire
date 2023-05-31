-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : lun. 29 mai 2023 à 13:46
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `musique`
--

-- --------------------------------------------------------

--
-- Structure de la table `co`
--

CREATE TABLE `co` (
  `login` varchar(32) DEFAULT NULL,
  `mdp` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `co`
--

INSERT INTO `co` (`login`, `mdp`) VALUES
('franck.admin', 'aa36dc6e81e2ac7ad03e12fedcb6a2c0'),
('franck.admin', '34dc82b7f1d20eda372a04fe70a74cfa');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE `eleve` (
  `IDELEVE` int(11) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `BOURSE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`IDELEVE`, `NIVEAU`, `BOURSE`) VALUES
(5, 1, 0),
(6, 1, 1),
(7, 1, 0),
(8, 1, 1),
(9, 2, 0),
(10, 2, 1),
(11, 2, 0),
(12, 2, 1),
(13, 3, 0),
(14, 3, 1),
(50, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `heure`
--

CREATE TABLE `heure` (
  `TRANCHE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `heure`
--

INSERT INTO `heure` (`TRANCHE`) VALUES
('10h-12h');

-- --------------------------------------------------------

--
-- Structure de la table `inscription`
--

CREATE TABLE `inscription` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `DATEINSCRIPTION` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `inscription`
--

INSERT INTO `inscription` (`IDPROF`, `IDELEVE`, `NUMSEANCE`, `DATEINSCRIPTION`) VALUES
(1, 5, 1, '2023-02-21'),
(1, 6, 1, '2023-02-21'),
(1, 7, 1, '2023-02-21'),
(1, 8, 1, '2023-02-21'),
(1, 9, 2, '2023-02-21'),
(1, 10, 2, '2023-02-21'),
(1, 11, 2, '2023-02-21'),
(1, 12, 2, '2023-02-21'),
(1, 50, 1, '2023-05-23'),
(2, 5, 3, '2023-02-21'),
(2, 6, 3, '2023-02-21'),
(2, 7, 3, '2023-02-21'),
(2, 8, 3, '2023-02-21'),
(2, 9, 4, '2023-02-21'),
(2, 10, 4, '2023-02-21'),
(2, 11, 4, '2023-02-21'),
(2, 12, 4, '2023-02-21'),
(3, 13, 5, '2023-02-21'),
(3, 13, 6, '2023-02-21'),
(3, 14, 5, '2023-02-21'),
(3, 14, 6, '2023-02-21'),
(4, 13, 7, '2023-02-21'),
(4, 13, 8, '2023-02-21'),
(4, 14, 7, '2023-02-21'),
(4, 14, 8, '2023-02-21');

-- --------------------------------------------------------

--
-- Structure de la table `instrument`
--

CREATE TABLE `instrument` (
  `LIBELLE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `instrument`
--

INSERT INTO `instrument` (`LIBELLE`) VALUES
('Accordéon'),
('Basse'),
('Batterie'),
('Flûte'),
('Guitare'),
('Harpe'),
('Piano'),
('Saxophone'),
('Trompette'),
('Violon');

-- --------------------------------------------------------

--
-- Structure de la table `jour`
--

CREATE TABLE `jour` (
  `JOUR` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `jour`
--

INSERT INTO `jour` (`JOUR`) VALUES
('Jeudi'),
('Mardi'),
('Mercredi'),
('Vendredi');

-- --------------------------------------------------------

--
-- Structure de la table `niveau`
--

CREATE TABLE `niveau` (
  `NIVEAU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `niveau`
--

INSERT INTO `niveau` (`NIVEAU`) VALUES
(1),
(2),
(3);

-- --------------------------------------------------------

--
-- Structure de la table `payer`
--

CREATE TABLE `payer` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `LIBELLE` char(32) NOT NULL,
  `DATEPAIEMENT` date DEFAULT NULL,
  `PAYE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `payer`
--

INSERT INTO `payer` (`IDPROF`, `IDELEVE`, `NUMSEANCE`, `LIBELLE`, `DATEPAIEMENT`, `PAYE`) VALUES
(1, 5, 1, 'avril-juin', '2023-05-05', 1),
(1, 5, 1, 'janvier-avril', '2023-02-21', 1),
(1, 5, 1, 'septembre-décembre', '2022-11-21', 1);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `ID` int(11) NOT NULL,
  `NOM` char(32) DEFAULT NULL,
  `PRENOM` char(32) DEFAULT NULL,
  `TEL` varchar(14) DEFAULT NULL,
  `MAIL` char(32) DEFAULT NULL,
  `ADRESSE` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`ID`, `NOM`, `PRENOM`, `TEL`, `MAIL`, `ADRESSE`) VALUES
(1, 'Dupont', 'Jean', '0123456789', 'jean.dupont@example.com', '12 rue de la Paix'),
(2, 'Martin', 'Marie', '0234567890', 'marie.martin@example.com', '24 avenue des Champs-Élysées'),
(3, 'Durand', 'Pierre', '0345678901', 'pierre.durand@example.com', '36 rue du Faubourg Saint-Honoré'),
(4, 'Lefebvre', 'Sophie', '0456789012', 'sophie.lefebvre@example.com', '48 boulevard Haussmann'),
(5, 'Leroy', 'Antoine', '0567890123', 'antoine.leroy@example.com', '60 avenue Montaigne'),
(6, 'Moreau', 'Isabelle', '0678901234', 'isabelle.moreau@example.com', '72 rue de Rivoli'),
(7, 'Petit', 'François', '0789012345', 'francois.petit@example.com', '84 boulevard des Invalides'),
(8, 'Roux', 'Émilie', '0890123456', 'emilie.roux@example.com', '96 rue de la Pompe'),
(9, 'Sauvage', 'Thierry', '0901234567', 'thierry.sauvage@example.com', '108 avenue des Ternes'),
(10, 'Simon', 'Camille', '0123456789', 'camille.simon@example.com', '120 rue de la Roquette'),
(11, 'Tanguy', 'Lucie', '0234567890', 'lucie.tanguy@example.com', '132 avenue des Gobelins'),
(12, 'Thomas', 'Guillaume', '0345678901', 'guillaume.thomas@example.com', '144 rue Saint-Antoine'),
(13, 'Vidal', 'Caroline', '0456789012', 'caroline.vidal@example.com', '156 boulevard Saint-Germain'),
(14, 'Boucher', 'Alexandre', '0567890123', 'alexandre.boucher@example.com', '168 avenue de Clichy'),
(36, 'yo', 'yo', '03232', '@', 'RUE'),
(37, 'yo', 'yo', '041', '@', 'RUE'),
(38, 'yo', 'yoyo', '077', '@', 'rue'),
(41, 'yo', 'yoo', '58394', '@', 'rue'),
(42, '', '', '', '', ''),
(43, 'yo', 'yoo', '55555', '@', 'rue'),
(44, 'yo', 'yoo', '55555', '@', 'rue'),
(45, 'yo', 'yoo', '55555', '@', 'rue'),
(46, 'yo', 'yoo', '55555', '@', 'rue'),
(47, 'yo', 'yoo', '55555', '@', 'rue'),
(48, 'yo', 'yo', '55555', '@', 'rue'),
(49, 'yo', 'yoo', '58394', '@', 'rue'),
(50, 'yo', 'yo', '56', '@', 'rue');

-- --------------------------------------------------------

--
-- Structure de la table `prof`
--

CREATE TABLE `prof` (
  `IDPROF` int(11) NOT NULL,
  `INSTRUMENT` char(32) NOT NULL,
  `SALAIRE` double(5,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `prof`
--

INSERT INTO `prof` (`IDPROF`, `INSTRUMENT`, `SALAIRE`) VALUES
(1, 'Piano', 900.00),
(2, 'Flûte', 950.00),
(3, 'Violon', 800.00),
(4, 'Guitare', 800.00),
(38, 'Guitare', 800.00);

-- --------------------------------------------------------

--
-- Structure de la table `seance`
--

CREATE TABLE `seance` (
  `IDPROF` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `TRANCHE` char(32) NOT NULL,
  `JOUR` char(32) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `CAPACITE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `seance`
--

INSERT INTO `seance` (`IDPROF`, `NUMSEANCE`, `TRANCHE`, `JOUR`, `NIVEAU`, `CAPACITE`) VALUES
(1, 1, '10h-12h', 'Mardi', 1, 4),
(1, 2, '10h-12h', 'Jeudi', 2, 4),
(2, 3, '10h-12h', 'Mardi', 1, 4),
(2, 4, '10h-12h', 'Jeudi', 2, 4),
(3, 5, '10h-12h', 'Mercredi', 3, 2),
(3, 6, '10h-12h', 'Vendredi', 3, 2),
(4, 7, '10h-12h', 'Mercredi', 3, 2),
(4, 8, '10h-12h', 'Vendredi', 3, 2),
(38, 9, '10h-12h', 'Mardi', 2, 3),
(38, 10, '10h-12h', 'Mercredi', 2, 3);

-- --------------------------------------------------------

--
-- Structure de la table `trim`
--

CREATE TABLE `trim` (
  `LIBELLE` char(32) NOT NULL,
  `DATEFIN` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `trim`
--

INSERT INTO `trim` (`LIBELLE`, `DATEFIN`) VALUES
('avril-juin', '2023-06-21'),
('janvier-avril', '2023-04-23'),
('septembre-décembre', '2022-12-17');

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `veleve`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `veleve` (
`id` int(11)
,`nom` char(32)
,`prenom` char(32)
,`tel` varchar(14)
,`mail` char(32)
,`adresse` char(32)
,`niveau` int(11)
,`bourse` int(11)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vprof`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vprof` (
`id` int(11)
,`nom` char(32)
,`prenom` char(32)
,`tel` varchar(14)
,`mail` char(32)
,`adresse` char(32)
,`instrument` char(32)
,`salaire` double(5,2)
);

-- --------------------------------------------------------

--
-- Structure de la vue `veleve`
--
DROP TABLE IF EXISTS `veleve`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `veleve`  AS SELECT `personne`.`ID` AS `id`, `personne`.`NOM` AS `nom`, `personne`.`PRENOM` AS `prenom`, `personne`.`TEL` AS `tel`, `personne`.`MAIL` AS `mail`, `personne`.`ADRESSE` AS `adresse`, `eleve`.`NIVEAU` AS `niveau`, `eleve`.`BOURSE` AS `bourse` FROM (`personne` join `eleve` on(`personne`.`ID` = `eleve`.`IDELEVE`))  ;

-- --------------------------------------------------------

--
-- Structure de la vue `vprof`
--
DROP TABLE IF EXISTS `vprof`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vprof`  AS SELECT `personne`.`ID` AS `id`, `personne`.`NOM` AS `nom`, `personne`.`PRENOM` AS `prenom`, `personne`.`TEL` AS `tel`, `personne`.`MAIL` AS `mail`, `personne`.`ADRESSE` AS `adresse`, `prof`.`INSTRUMENT` AS `instrument`, `prof`.`SALAIRE` AS `salaire` FROM (`personne` join `prof` on(`personne`.`ID` = `prof`.`IDPROF`))  ;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD PRIMARY KEY (`IDELEVE`),
  ADD KEY `I_FK_ELEVE_NIVEAU` (`NIVEAU`);

--
-- Index pour la table `heure`
--
ALTER TABLE `heure`
  ADD PRIMARY KEY (`TRANCHE`);

--
-- Index pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_INSCRIPTION_ELEVE` (`IDELEVE`),
  ADD KEY `I_FK_INSCRIPTION_SEANCE` (`IDPROF`,`NUMSEANCE`),
  ADD KEY `fk_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `instrument`
--
ALTER TABLE `instrument`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- Index pour la table `jour`
--
ALTER TABLE `jour`
  ADD PRIMARY KEY (`JOUR`);

--
-- Index pour la table `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NIVEAU`),
  ADD KEY `NIVEAU` (`NIVEAU`);

--
-- Index pour la table `payer`
--
ALTER TABLE `payer`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`,`LIBELLE`),
  ADD KEY `I_FK_PAYER_INSCRIPTION` (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_PAYER_TRIM` (`LIBELLE`),
  ADD KEY `fk_paye_eleve` (`IDELEVE`),
  ADD KEY `fk_paye_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `prof`
--
ALTER TABLE `prof`
  ADD PRIMARY KEY (`IDPROF`),
  ADD KEY `I_FK_PROF_INSTRUMENT` (`INSTRUMENT`);

--
-- Index pour la table `seance`
--
ALTER TABLE `seance`
  ADD PRIMARY KEY (`IDPROF`,`NUMSEANCE`),
  ADD KEY `I_FK_SEANCE_JOUR` (`JOUR`),
  ADD KEY `I_FK_SEANCE_NIVEAU` (`NIVEAU`),
  ADD KEY `I_FK_SEANCE_PROF` (`IDPROF`),
  ADD KEY `fk_tranche` (`TRANCHE`),
  ADD KEY `NUMSEANCE` (`NUMSEANCE`);

--
-- Index pour la table `trim`
--
ALTER TABLE `trim`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT pour la table `seance`
--
ALTER TABLE `seance`
  MODIFY `NUMSEANCE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `fk_idEleve` FOREIGN KEY (`IDELEVE`) REFERENCES `personne` (`ID`),
  ADD CONSTRAINT `fk_niveau` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);

--
-- Contraintes pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD CONSTRAINT `fk_insc_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_inscr_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_inscr_seance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `payer`
--
ALTER TABLE `payer`
  ADD CONSTRAINT `fk_paye_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_paye_lib` FOREIGN KEY (`LIBELLE`) REFERENCES `trim` (`LIBELLE`),
  ADD CONSTRAINT `fk_paye_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_paye_seance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `prof`
--
ALTER TABLE `prof`
  ADD CONSTRAINT `fk_idProf` FOREIGN KEY (`IDPROF`) REFERENCES `personne` (`ID`),
  ADD CONSTRAINT `fk_refInstrument` FOREIGN KEY (`INSTRUMENT`) REFERENCES `instrument` (`LIBELLE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `seance`
--
ALTER TABLE `seance`
  ADD CONSTRAINT `fk_jour` FOREIGN KEY (`JOUR`) REFERENCES `jour` (`JOUR`),
  ADD CONSTRAINT `fk_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_tranche` FOREIGN KEY (`TRANCHE`) REFERENCES `heure` (`TRANCHE`),
  ADD CONSTRAINT `seance_ibfk_1` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
