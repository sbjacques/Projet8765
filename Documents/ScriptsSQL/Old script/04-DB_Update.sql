use Form115

ALTER TABLE Produits ADD CONSTRAINT fk_produits_sejours FOREIGN KEY ( IdSejour ) REFERENCES Sejours( IdSejour ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Sejours ADD CONSTRAINT fk_sejours_hotels FOREIGN KEY ( IdHotel ) REFERENCES Hotels ( IdHotel ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Reservations ADD CONSTRAINT fk_reservations_produits FOREIGN KEY ( IdProduit ) REFERENCES Produits ( IdProduit ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Hotels ADD CONSTRAINT Hotels_Villes_fk FOREIGN KEY (IdVille)  REFERENCES dbo.Villes (IdVille) ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE dbo.Reservations ADD CONSTRAINT Reservations_Utilisateurs_fk FOREIGN KEY (IdUtilisateur) REFERENCES dbo.Utilisateurs (IdUtilisateur) ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE dbo.Hotels ADD CONSTRAINT Hotels_Categories_fk FOREIGN KEY (Categorie) REFERENCES dbo.Categories (IdCategorie) ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE dbo.Sejours ADD CONSTRAINT ak_Sejour UNIQUE (IdHotel,Duree);

ALTER TABLE dbo.Produits ADD CONSTRAINT ak_Produit UNIQUE (IdProduit,DateDepart);
