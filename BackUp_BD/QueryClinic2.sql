SELECT     facturation.id, facturation.numero_facture, facturation.designation AS desi_article, facturation.pu, facturation.quantite, ISNULL(personne.nom, '') 
                      + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, paiement.date AS date_paiement, paiement.avance, paiement.montantpaye
FROM         sortieexterne RIGHT OUTER JOIN
                      malade INNER JOIN
                      etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id INNER JOIN
                      facturation ON malade.id = facturation.id_malade INNER JOIN
                      personne ON malade.id_personne = personne.id RIGHT OUTER JOIN
                      dossierpreconsultation ON malade.id = dossierpreconsultation.id_malade ON sortieexterne.id_malade = malade.id LEFT OUTER JOIN
                      sortie ON malade.id = sortie.id_malade LEFT OUTER JOIN
                      subit ON malade.id = subit.id_malade LEFT OUTER JOIN
                      operation_laboratoire ON malade.id = operation_laboratoire.id_malade LEFT OUTER JOIN
                      hospitalisation ON malade.id = hospitalisation.id_malade LEFT OUTER JOIN
                      consultation ON malade.id = consultation.id_malade LEFT OUTER JOIN
                      dossierconsultationprenatale ON malade.id = dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                      dossierconsultationpostnatal ON malade.id = dossierconsultationpostnatal.id_malade RIGHT OUTER JOIN
                      paiement ON subit.id = paiement.id_subit AND consultation.id = paiement.id_consultation AND 
                      dossierconsultationpostnatal.id = paiement.id_dossierconsultationpostnatal AND dossierconsultationprenatale.id = paiement.id_dossierconsultationprenatale AND 
                      dossierpreconsultation.id = paiement.id_dossierpreconsultation AND hospitalisation.id = paiement.id_hospitalisation AND malade.id = paiement.id_malade AND 
                      operation_laboratoire.id = paiement.id_operation_laboratoire AND sortie.id = paiement.id_sortie AND sortieexterne.id = paiement.id_sortieexterne LEFT OUTER JOIN
                      accouchement ON paiement.id_accouchement = accouchement.id










--SELECT     airsante.designation AS air_sante, categoriemalade.designation AS categorie, etablissementpriseencharge.denomination, facturation.designation AS Article, 
--                      facturation.pu, facturation.quantite, profession.designation AS profession, ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') 
--                      + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, paiement.date AS date_paiement, paiement.montantpaye
--FROM         airsante INNER JOIN
--                      article ON airsante.id = article.id INNER JOIN
--                      autrefraie ON airsante.id = autrefraie.id INNER JOIN
--                      categoriemalade ON airsante.id = categoriemalade.id INNER JOIN
--                      consultation ON airsante.id = consultation.id INNER JOIN
--                      consultationprenatal ON airsante.id = consultationprenatal.id INNER JOIN
--                      dossierconsultationpostnatal ON airsante.id = dossierconsultationpostnatal.id INNER JOIN
--                      dossierconsultationprenatale ON consultationprenatal.id_dossierconsultationprenatale = dossierconsultationprenatale.id INNER JOIN
--                      dossierpreconsultation ON airsante.id = dossierpreconsultation.id INNER JOIN
--                      etablissementpriseencharge ON airsante.id = etablissementpriseencharge.id INNER JOIN
--                      examen ON airsante.id = examen.id INNER JOIN
--                      facturation ON airsante.id = facturation.id INNER JOIN
--                      hospitalisation ON airsante.id = hospitalisation.id INNER JOIN
--                      intervention ON airsante.id = intervention.id INNER JOIN
--                      malade ON airsante.id = malade.id_airsante AND categoriemalade.id = malade.id_categoriemalade AND consultation.id_malade = malade.id AND 
--                      dossierconsultationpostnatal.id_malade = malade.id AND dossierconsultationprenatale.id_malade = malade.id AND dossierpreconsultation.id_malade = malade.id AND
--                       etablissementpriseencharge.id = malade.id_etablissement AND facturation.id_malade = malade.id AND hospitalisation.id_malade = malade.id INNER JOIN
--                      maladeenconsultationpostnatal ON dossierconsultationpostnatal.id = maladeenconsultationpostnatal.id_dossierconsultationpostnatal AND 
--                      malade.id = maladeenconsultationpostnatal.id_malade INNER JOIN
--                      maladegrosse ON consultationprenatal.id_maladeGrosse = maladegrosse.id AND malade.id = maladegrosse.id_malade INNER JOIN
--                      paiement ON consultation.id = paiement.id_consultation AND dossierconsultationpostnatal.id = paiement.id_dossierconsultationpostnatal AND 
--                      dossierconsultationprenatale.id = paiement.id_dossierconsultationprenatale AND dossierpreconsultation.id = paiement.id_dossierpreconsultation AND 
--                      hospitalisation.id = paiement.id_hospitalisation AND malade.id = paiement.id_malade INNER JOIN
--                      personne ON malade.id_personne = personne.id INNER JOIN
--                      preconsultation ON dossierpreconsultation.id = preconsultation.id_dossierpreconsultation INNER JOIN
--                      subit ON intervention.id = subit.id_intervention AND malade.id = subit.id_malade INNER JOIN
--                      profession ON malade.id_profession = profession.id