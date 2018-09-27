using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GestionClinic_LIB
{
    public class clsDoTraitement
    {
        private static clsDoTraitement Fact;
        private static string fileNamePostGres = "utilisateur.par";
        private static string fileNameSQLServer = "utilisateur.par";
        private static string fileParamRepertoire = "parametreRepertoire.par";
        private static string fileParamAide = "parametreAide.par";
        private static string fileParamTempData = "parametreTemp.par";
        public static List<int> lstIdMaladieUpdate = new List<int>();

        //Variable permettant de donner accès à l'ajout de la photo par repertoir :1
        //par webcam:2 et mis à jour normale:3 .En sachant qu'il s'agit de la modification
        public static int accepte_updatepicture = 0;
        public static string pathPhotoLoad = "";
        public static string pathAide = "";

        //Variable recuperant l'action lors d'une MAJ d'un item de tarif pour les formulaires des dossiers au niveau du paiement à la caise
        public static bool MAJ_fiche = false;
        public static bool MAJ_consultation = false;
        public static bool MAJ_CPN = false;
        public static bool MAJ_CPOS = false;
        public static bool MAJ_Labo = false;
        public static bool MAJ_Interventions = false;
        public static bool MAJ_consultationGyn = false;
        public static bool MAJ_Acouchement = false;
        public static bool MAJ_Echographie = false;
        public static bool MAJ_Soins = false;
        public static bool MAJ_Nursing = false;
        public static bool MAJ_Chambre = false;

        public static int etat_modification_user = -1;//Variable permettant de prendre le statut pour modification du user (User seul, Mot passe seul ou les deux)
        public static string oldUser = "";
        public static string newUser = "";
        public static string oldPassword = "";
        public static string newPassword = "";
        public static bool activationUser = false;
        public static int nombre_droit = 0;//Variable permettant de récupérer le nombre total des droits de l'utilisateur

        //Variables public pour avance
        public static double dblMontant = 0;
        public static double dblOldValeurChoisie = 0;//Variable public recuperant l'ancienne valeur du montant de tarif pour le tarif choisi 
        public static double dblNewValeurChoisie = 0;
        public static int intIdentifiantTarif = 0;
        public static int intIdentifiantFiche = 0;
        public static int intIdentifiantDossier = 0;
        public static double dblAvance = 0;
        public static int intIdAvance = 0;
        public static int intIdDossierAvance = 0;

        //Variable recupérant le numéro du malade deja existant
        public static string numeroMalade = "";

        public void unloadData(BindingSource bsrc, DataGridView dgv)
        {
            bsrc.Dispose();
            dgv.Dispose();
        }

        public void unloadData(BindingSource bsrc, DataGridView dgv, ComboBox cbo)
        {
            bsrc.Dispose();
            dgv.Dispose();
            cbo.Dispose();
        }

        public void unloadData(BindingSource[] bsrc, DataGridView[] dgv, ComboBox[] cbo)
        {
            foreach (BindingSource b in bsrc) b.Dispose();
            foreach (DataGridView b in dgv) b.Dispose();
            foreach (ComboBox b in cbo) b.Dispose();
        }

        public void unloadData(BindingSource[] bsrc, ComboBox[] cbo)
        {
            foreach (BindingSource b in bsrc) b.Dispose();
            foreach (ComboBox b in cbo) b.Dispose();
        }

        public void unloadData(ComboBox[] cbo)
        {
            foreach (ComboBox b in cbo) b.Dispose();
        }

        public void unloadData(BindingSource[] bsrc)
        {
            foreach (BindingSource b in bsrc) b.Dispose();
        }

        public void unloadData(BindingSource[] bsrc, DataGridView[] dgv)
        {
            foreach (BindingSource b in bsrc) b.Dispose();
            foreach (DataGridView b in dgv) b.Dispose();
        }

        public void unloadData(DataGridView[] dgv)
        {
            foreach (DataGridView b in dgv) b.Dispose();
        }

        public static void reinitialiseValue()
        {
            clsDoTraitement.doubleclic_categorie_malade = "";
            clsDoTraitement.doubleclic_nom_malade = "";
            clsDoTraitement.doubleclic_entreprise = "";
            clsDoTraitement.doubleclic_taux = 0;
        }

        //Variable publique récupérant les information du malade (Personne) lors du double clic sur une ligne du DataGrid du formulaire FrmRecherchePersonne
        public static string doubleclic_categorie_malade = "";
        public static string doubleclic_nom_malade = "";
        public static string doubleclic_entreprise = "";
        public static double doubleclic_taux = 0;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur consultationPreNatal
        public static bool doubleclicExamenGynecoObstetriqueDg = false;
        public static bool doubleclicAntecedentMedicauxObstetriqueDg = false;
        public static bool doubleclicConcellingEtTestRapideDg = false;

        //Variable permettant de récuperer la quantité à retourner en stock
        public static int? quantinteretour;

        //Variable pour utilisateur Administrateur ou autres valeurs
        public static bool isAdmin = false;
        public static List<string> valueUser = new List<string>();//Liste qi contient les droits de l'utilisateur connecté
        public static int id_Agent_Connecte = -1;

        //Variable recuperant la valeur du stock sur l'interface graphique pour modification
        public static double oldValueStockModifie = 0;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur Accouchemnt
        public static bool doubleclicEnfantFemmeDg = false;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur maladeEnConsultationPostNatal
        public static bool doubleclicVaccinationDg = false;
        public static bool doubleclicRendezvousDg = false;
        public static bool doubleclicSuivicroissanceDg = false;
        public static bool doubleclicPriseVitamineDg = false;
        public static bool doubleclicAttentionSpecialeDg = false;
        public static bool doubleclicConsultationFicheDg = false;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur Malade
        public static bool doubleclicInterventionDg = false;
        public static bool doubleclicAutresFraisDg = false;
        public static bool doubleclicMouvementHospitalisationDg = false;
        public static bool doubleclicMedicamentDg = false;

        //Variable pour l'Hospitalisation
        public static int id_sortie_medicaments = 0;
        public static int id_sortieExterne_medicaments = 0;
        public static int idMalade_hospitalisation = 0;
        public static int id_hospitalisation = 0;
        public static int id_hospitalisation_consomme = 0;
        public static int id_hospitalisation_mvt = 0;
        public static int idMalade_Intervention = 0;
        public static bool blnConsomationActivate = false;
        public static bool blnMvtHospitalisationActivate = false;
        public static bool blnAutresFraisActivate = false;
        public static bool blnBloc = false;
        public static bool blnService = false;
        public static int idIntervention = 0;
        public static int idAutresFrais = 0;
        public static int idMouvementHospitalisation = 0;
        public static int idMedicament = 0;
        public static int idAgent = 0;
        public static int idMaladeDossierPre = 0;
        private static int idPaiementArchive = 0;

        //Variable recuperant l'Id de la personne ainsi que la date pour laquelle on veut avoir le certificat d'aptitude physique
        public static DateTime dateCerticifat;
        public static int id_personne_certificat;

        public static int idPersonne = -1;//Id de la personne

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur maladeGrosse (CPN)
        public static bool doubleclicAvortementDg = false;
        public static bool doubleclicDelivranceDg = false;
        public static bool doubleclicAccouchementDg = false;
        public static bool doubleclicCPNDg = false;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur consultationPreNatal
        public static int idExamenGynecoObstetriqueDg = 0;
        public static int idAntecedentMedicauxObstetriqueDg = 0;
        public static int idConcellingEtTestRapideDg = 0;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur consultationPreNatal
        public static int idEnfantFemmeDg = 0;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur consultationNormal
        public static bool doubleclicElementConsultNormalDg = false;

        //Variable recuperant l'action lors du double clic sur une ligne du DataGrid sur Examination
        public static bool doubleclicExamenDg = false;
        public static bool doubleclicMaladieDg = false;

        //Variables permettant de récupérer le statut lors du double clic sur le DataGrid pour personne
        public static bool doubleclicRecherchePersonneFournisseurDg = false;
        public static bool doubleclicRecherchePersonneMaladeDg = false;
        public static bool doubleclicRecherchePersonneAgentDg = false;
        public static bool doubleclicRecherchePersonneDg = false;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur maladeEnConsultationPostNatal
        public static int idVaccinationDg = 0;
        public static int idRendezvousDg = 0;
        public static int idSuivicroissanceDg = 0;
        public static int idPriseVitamineDg = 0;
        public static int idConsultationFicheDg = 0;
        public static int idAttentionSpecialeDg = 0;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur maladeGrosse (CPN)
        public static int idDelivranceDg = 0;
        public static int idAvortementDg = 0;
        public static int idAccouchementDg = 0;
        public static int idCPNDg = 0;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur Examination
        public static int idExamenDg = 0;
        public static int idMaladieDg = 0;

        //Variable recuperant l'ID lors du double clic sur une ligne du DataGrid sur consultationNormal
        public static int idElementConsultNormalDg = 0;

        private static bool enterForFormQualification = false;
        private static bool enterForFormGroupesanguin = false;
        private static bool enterForFormConditionnement = false;
        private static bool enterFormFormExamen = false;
        private static bool enterForFormFonction = false;
        private static bool enterForFormService = false;
        private static bool enterForFormAllergie = false;
        private static bool enterFormCategorie = false;
        private static bool enterFormEtablissementExterne = false;
        private static bool enterFormPersonne = false;
        private static bool enterFormMaladie = false;
        private static bool enterFormMaladieGynecologique = false;
        private static bool enterFormCategorieAbonne = false;
        private static bool enterFormEtablissement = false;
        private static bool enterFormAireSante = false;
        private static bool enterFormProvince = false;
        private static bool enterFormDistrictville = false;
        private static bool enterFormTerritoirecommune = false;
        private static bool enterFormCollectivitequartier = false;
        private static bool enterFormFormProfession = false;
        private static bool enterFormVitamine = false;
        private static bool enterFormVaccin = false;
        private static bool enterFormPeriodeVaccination = false;
        private static bool enterFormPriseVitamine = false;
        private static bool enterFormPeriodeVitamine = false;
        private static bool enterForCritere = false;
        private static bool enterFormSuiviCroissance = false;
        private static bool enterFormRendezVous = false;
        private static bool enterFormMalEnConsPostNatale = false;
        private static bool enterFormVaccination = false;
        private static bool enterForFormTypeExamen = false;
        private static bool enterFormConsultationFiche = false;
        private static bool enterFormAttentionSpeciale = false;
        private static bool enterFormAttention = false;
        private static bool enterFormDelivrance = false;
        private static bool enterFormAvortement = false;
        private static bool enterFormAcouchement = false;
        private static bool enterFormTypeAcouchement = false;
        private static bool enterFormConsultationPreNatale = false;
        private static bool enterForFormCategorieAgent = false;
        private static bool enterFormArticle = false;
        private static bool enterFormArticle1 = false;
        private static bool enterFormIntervention = false;

        //private static bool enterFormTypeSysteme = false;
        private static bool enterForFormConsultationPrenatale = false;

        private static int idEnfant = -1;//Id du malade en consultation Post Natale
        private static int idPassationExamen = -1;//Id de la passation d'examen
        private static int idMaladie = -1;//Id de la maladie
        private static int idMalade = -1;//Id du malade pour examination
        private static int id_Medicament = -1;//Id du médicament
        private static int idOutilMedical = -1;//Id de outil médical
        private static int idExamen = -1;//Id de l'examen pour l'examination
        private static int idConsultationNormale = -1;//Id de la consultation Normale
        private static int idFemmeEnceinte = -1;//Id de la femme enceinte
        private static int idExamenGynecoObstetric = -1;//Id de la consultation ExamenGynecoObstetric
        private static int idAntecedentMedicoObstetric = -1;//Id de la antecedent MedicoObstetric
        private static int idConsellingEtTestRapide = -1;//Id de la conselling et Testrapide  
        private static int idConsultationPreNatal = -1;//Id de la consultation PreNatale
        private static int idEnfantFemme = -1;//Id de l'Enfant(s) de la femme enceinte
        private static int idAccouchement = -1;//Id de l'Accouchement

        //Valeurs pour Fournisseur
        private static int identifiant_Personne = -1;//Id de la personne

        private static int identifiant_Fournisseur = -1;//Id du fournisseur
        private static string fullNamePersonne = "";//Nom complet de la personne      
        private static string nomPersonne = "";//Nom de la personne      
        private static string postnomPersonne = "";//PostNom de la personne
        private static string prenomPersonne = "";//prénom de la personne
        private static string sexePersonne = "";//sexe de la personne
        private static DateTime? datenaissancePersonne = null;//Date de naissance de la personne       
        private static string etatCivPersonne = "";//Etat civil de la personne   
        private static string telPersonne = "";//Numero de téléphone de la personne
        private static string adressePersonne = "";//Adresse de la personne
        private static string numero_du_fournisseur = "";//Numero du Fournisseur

        //Valeur pour agent
        private static int identifiant_Agent = -1;//Identifiant de l'agent
        private static int id_Fonction_Agent = -1;//Identifiant de la Fonction de l'agent
        private static int id_Service_Agent = -1;//Identifiant du service de l'agent
        private static DateTime? dateengagementAgent = null;//Date d'engagement de l'agent
        private static string matriculePersonne = "";//Numero matricule de l'agent
        private static string inss_Agent = "";//Numero INSS de l'agent
        private static string gradeAgent = "";//Grade de l'agent

        public clsDoTraitement()
        {
        }
        public static clsDoTraitement GetInstance()
        {
            if (Fact == null)
                Fact = new clsDoTraitement();
            return Fact;
        }

        #region ACTION SUR REPERTOIRE
        /// <summary>
        ///Permet d'enregistrer le chemin d'acces complet pour la sauvegarde des photos prises par le WebCam
        /// </summary>
        public void saveParamRepertoire(string cheminAcces)
        {
            if (!string.IsNullOrEmpty(cheminAcces))
            {
                using (StreamWriter srw = new StreamWriter(updateCreateDirectory("gestionclinic") + @"\" + fileParamRepertoire, false))
                {
                    string chaine = string.Format("{0}", cheminAcces);
                    //On crypte la chaine a sauvegarde
                    srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(chaine));
                    srw.Close();
                }
            }
            else throw new Exception("Le chemin d'accès spécifié est invalide");
        }

        /// <summary>
        /// Permet de charger le chemin d'acces complet pour la sauvegarde des photos prise par le WebCam
        /// </summary>
        /// <returns>retourne un string</returns>
        public string loadParamRepertoire()
        {
            string str = "";
            if (File.Exists(updateCreateDirectory("gestionclinic") + @"\" + fileParamRepertoire))
            {
                using (StreamReader sr = new StreamReader(updateCreateDirectory("gestionclinic") + @"\" + fileParamRepertoire))
                {
                    if (!sr.EndOfStream)
                    {
                        str = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(sr.ReadLine());
                        sr.Close();
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// Permet de supprimer tous le contenu d'un dossier 
        /// </summary>
        /// <param name="cheminAcces">Chemin d'acces du dossier</param>
        public void deleteAllItemToDirectory()
        {
            string[] fileNames = Directory.GetFiles(this.loadParamRepertoire(), "*.*", SearchOption.TopDirectoryOnly);
            foreach (string fileName in fileNames)
            {
                File.Delete(fileName);
            }
        }

        /// <summary>
        ///Permet d'enregistrer le chemin d'acces complet pour la sauvegarde des photos prises par le WebCam
        /// </summary>
        public void saveParamTemporaire(string cheminAcces)
        {
            if (!string.IsNullOrEmpty(cheminAcces))
            {
                using (StreamWriter srw = new StreamWriter(updateCreateDirectory("gestionclinic") + @"\" + fileParamTempData, false))
                {
                    string chaine = string.Format("{0}", cheminAcces);
                    //On crypte la chaine a sauvegarde
                    srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(chaine));
                    srw.Close();
                }
            }
            else throw new Exception("Le chemin d'accès spécifié est invalide");
        }

        /// <summary>
        /// Permet de charger lemin d'acces complet pour la sauvegarde des photos prise par le WebCam
        /// </summary>
        /// <returns>retourne un string</returns>
        public string loadParamTemporaire()
        {
            string str = "";
            if (File.Exists(updateCreateDirectory("gestionclinic") + @"\" + fileParamTempData))
            {
                using (StreamReader sr = new StreamReader(updateCreateDirectory("gestionclinic") + @"\" + fileParamTempData))
                {
                    if (!sr.EndOfStream)
                    {
                        str = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(sr.ReadLine());
                        sr.Close();
                    }
                }
            }
            return str;
        }
        #endregion

        #region ACTION SUR CHEMIN ACCES CONNECTION
        public static string updateCreateDirectory(string nomRepertoire)
        {
            //ParametersProgramms
            string cheminAccesRepertoire = "";
            //Recuperation du nom du lecteur dans lequel le projet se trouve
            string lecteur = Environment.CurrentDirectory.ToString().Substring(0, 2);
            DirectoryInfo directory = new DirectoryInfo(lecteur + @"\" + nomRepertoire);
            if (!directory.Exists)
            {
                //Creation du repertoire
                directory.Create();
                directory.Attributes = FileAttributes.Hidden;
                cheminAccesRepertoire = directory.FullName;
                //Console.WriteLine("directory.FullName = " + directory.FullName);
            }
            else
            {
                //Dossier existant
                cheminAccesRepertoire = directory.FullName;
                //throw new Exception("Echec de la céeation du répertoire");
            }
            return cheminAccesRepertoire;
        }

        //public Document FileToByteArray(string fileName)
        //{
        //    Document doc = null;
        //    byte[] fileContent = null;

        //    System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        //    System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);

        //    long byteLength = new System.IO.FileInfo(fileName).Length;
        //    fileContent = binaryReader.ReadBytes((Int32)byteLength);
        //    fs.Close();
        //    fs.Dispose();
        //    binaryReader.Close();
        //    doc = new Document();
        //    doc.DocName = fileName;
        //    doc.DocContent = fileContent;
        //    return doc;
        //}

        //private void ShowDocument(string fileName, byte[] fileContent)
        //{
        //    //Split the string by character . to get file extension type
        //    string[] stringParts = fileName.Split(new char[] { '.' });
        //    string strType = stringParts[1];
        //    Response.Clear();
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        //    //Set the content type as file extension type
        //    Response.ContentType = strType;

        //    //Write the file content
        //    this.Response.BinaryWrite(fileContent);
        //    this.Response.End();
        //}

        public byte[] convertFileToByteArray(string pathFile)
        {
            byte[] myByte = null;
            if (string.IsNullOrEmpty(pathFile)) throw new Exception("le fichier choisi est invalide");
            else if (!File.Exists(pathFile)) throw new Exception("le fichier choisi n'existe pas");
            else File.WriteAllBytes(pathFile, myByte);
            return myByte;
        }

        public static void copyFileToDirectory(string nomCompletFichier)
        {
            //nomServeur = @"\\ILaboPC-PC\Deployment";
            //Recuperation du nom du lecteur dans lequel le projet se trouve
            //string lecteur = Environment.CurrentDirectory.ToString().Substring(0, 2);
            //DirectoryInfo directory = new DirectoryInfo(lecteur + @"\gestionclinic");
            if (!verifieFileExtension(nomCompletFichier)) throw new Exception("le format du fichier choisie n'est pas valide, veuillez charger un fichier au format rft svp !");
            else
            {
                DirectoryInfo directory = new DirectoryInfo(@"\\" + clsDoTraitement.GetInstance().loadParamFileAide() + @"\Deployment");
                clsDoTraitement.pathAide = nomCompletFichier;
                if (!directory.Exists)
                {
                    //Si le repertoire n'existe pas, on leve une Exception
                    throw new Exception("Veuillez contacter l'Administrateur du système pour se rassurer que toutes les configurations de l'application sont bonne");
                }
                else
                {
                    //Dossier existant

                    if (File.Exists(nomCompletFichier))
                    {
                        //On se rassure que le fichier n'a jamais été copié, sino on retourne un message
                        //if (File.Exists(lecteur + @"\gestionclinic\Aide.rtf"))
                        if (File.Exists(@"\\" + clsDoTraitement.GetInstance().loadParamFileAide() + @"\Deployment\Aide.rtf"))
                        {
                            throw new Exception("Le fichier existe déjà");
                        }
                        else
                        {
                            //Copie du fichier specifier dans le repertoire Deployment du serveur
                            File.Copy(nomCompletFichier, @"\\" + clsDoTraitement.GetInstance().loadParamFileAide() + @"\Deployment\Aide.rtf");
                        }
                    }
                }
            }
        }
        /// <summary>
        ///Permet d'enregistrer la chaîne de connexion pour une base des donnée PostGresSQL dans un fichier texte 
        /// </summary>
        public void saveParamConnection(string serveur, string bd, string userName, string port, int valueBD,string version)
        {
            if (valueBD == 0)
            {
                //PostGresSQL
                using (StreamWriter srw = new StreamWriter(updateCreateDirectory("gestionclinic") + @"\" + fileNamePostGres, false))
                {
                    string chaine = string.Format("{0};{1};{2};{3}", serveur, bd, userName, port);
                    //On crypte la chaine a sauvegarde
                    //srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(chaine));//Ici j'enlève le cryptaeg
                    srw.WriteLine("{0}", chaine);//Ici j'enlève le cryptage
                    srw.Close();
                }
            }
            else if (valueBD == 1)
            {
                //Sql serveur
                using (StreamWriter srw = new StreamWriter(updateCreateDirectory("gestionclinic") + @"\" + fileNameSQLServer, false))
                {
                    //string chaine = string.Format("{0};{1};{2}", serveur, bd, userName);
                    string chaine = string.Format("{0};{1};{2}", serveur, bd,version);
                    //On crypte la chaine a sauvegarde
                    //srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(chaine));//Ici j'enlève le cryptaeg
                    srw.WriteLine("{0}", chaine);//Ici j'enlève le cryptage
                    srw.Close();
                }
                ////using (StreamWriter srw = new StreamWriter(updateCreateDirectory("gestionclinic") + @"\" + fileParamAide, false))
                ////{
                ////    string chaine = string.Format("{0}", serveur);//Recuperation du nom du serveur pour aide
                ////    char caractere = Convert.ToChar(@"\");
                ////    string[] goodChaine = chaine.Split(caractere);
                ////    //On crypte la chaine a sauvegarde
                ////    //srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(chaine));//Ici j'enlève le cryptaeg
                ////    srw.WriteLine("{0}", chaine);//Ici j'enlève le cryptage  //Enregistrement du nom du serveur dans le fichier
                ////    //srw.WriteLine("{0}", CryptageJosam_LIB.clsMetier.GetInstance().doCrypte(goodChaine[0]));//Enregistrement du nom du serveur dans le fichier
                ////    srw.Close();
                ////}
            }
        }

        /// <summary>
        /// Permet de charger la chaîne de connection à partir d'un fichier texte pour une Base PostGresSql et retourne un tableau
        /// contenant ces différentes valeurs (Serveur, Base de données, Nom d'utilisateur et numero de port)
        /// </summary>
        /// <returns>retourne un tableau</returns>
        public List<string> loadParam(int valueDB)
        {
            List<string> listValues = new List<string>();
            if (valueDB == 0)
            {
                //PostGresSQL
                if (File.Exists(updateCreateDirectory("gestionclinic") + @"\" + fileNamePostGres))
                {
                    using (StreamReader sr = new StreamReader(updateCreateDirectory("gestionclinic") + @"\" + fileNamePostGres))
                    {
                        if (!sr.EndOfStream)
                        {
                            string str = sr.ReadLine();//Je désactive le cryptage pour les changer en cas de changement de machine pour une première connexion
                            //string str = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(sr.ReadLine());
                            string[] value = str.Split(new char[] { ';' });
                            foreach (string str1 in value) listValues.Add(str1);
                            sr.Close();
                        }
                    }
                }
            }
            else if (valueDB == 1)
            {
                //SQLServer
                if (File.Exists(updateCreateDirectory("GestionClinic") + @"\" + fileNameSQLServer))
                {
                    using (StreamReader sr = new StreamReader(updateCreateDirectory("GestionClinic") + @"\" + fileNameSQLServer))
                    {
                        if (!sr.EndOfStream)
                        {
                            string str = sr.ReadLine();//Je désactive le cryptage pour les changer en cas de changement de machine pour une première connexion
                            //string str = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(sr.ReadLine());
                            string[] value = str.Split(new char[] { ';' });
                            foreach (string str1 in value) listValues.Add(str1);
                            sr.Close();
                        }
                    }
                }
                else
                { 
                }
            }
            return listValues;
        }

        public string loadParamFileAide()
        {
            string strValue = "";
            if (File.Exists(updateCreateDirectory("GestionClinic") + @"\" + fileParamAide))
            {
                using (StreamReader sr = new StreamReader(updateCreateDirectory("GestionClinic") + @"\" + fileParamAide))
                {
                    if (!sr.EndOfStream)
                    {
                        strValue = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(sr.ReadLine());
                        sr.Close();
                    }
                }
            }
            return strValue;
        }
        #endregion

        #region ACTION SUR LA PHOTO ET FICHIER
        /// <summary>
        /// Permet de verifier l'extension du fchier Image (JPG ou PNGseulement autorise)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool verifiePhotoExtension(string fileName)
        {
            bool ok = false;
            string strReverse = "";
            for (int i = 0, j = fileName.Length - 1; i < fileName.Length; i++, j--) strReverse = strReverse + fileName[j];

            if (strReverse[0].ToString().ToLower() == 'g'.ToString() && strReverse[1].ToString().ToLower() == 'p'.ToString()
            && strReverse[2].ToString().ToLower() == 'j'.ToString() && strReverse[3].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else if (strReverse[0].ToString() == 'g'.ToString() && strReverse[1].ToString() == 'e'.ToString()
            && strReverse[2].ToString() == 'p'.ToString() && strReverse[3].ToString() == 'j'.ToString()
            && strReverse[4].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else if (strReverse[0].ToString().ToLower() == 'g'.ToString() && strReverse[1].ToString().ToLower() == 'n'.ToString()
            && strReverse[2].ToString().ToLower() == 'p'.ToString() && strReverse[3].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else throw new Exception("le format de la photo n'est pas valide, veuillez charger une photo au format jpg ou png svp !");
            return ok;
        }

        public static bool verifieFileExtension(string fileName)
        {
            bool ok = false;
            string strReverse = "";
            for (int i = 0, j = fileName.Length - 1; i < fileName.Length; i++, j--) strReverse = strReverse + fileName[j];

            if (strReverse[0].ToString().ToLower() == 'f'.ToString() && strReverse[1].ToString().ToLower() == 't'.ToString()
            && strReverse[2].ToString().ToLower() == 'r'.ToString() && strReverse[3].ToString() == '.'.ToString())
                //Fifhier rft
                ok = true;
            else throw new Exception("le format du fichier choisie n'est pas valide, veuillez charger un fichier au format rft svp !");
            return ok;
        }

        public Bitmap getImageFromByte(byte[] byteArray)
        {
            Bitmap image;
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                image = new Bitmap(stream);
            } return image;
        }

        public string getFileFromByte(byte[] byteArray)
        {
            string fpath = System.IO.Path.GetTempPath() + DateTime.Today.ToString("yyyyMMdd") + ".jpg";

            using (System.IO.FileStream f = new System.IO.FileStream(fpath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                f.Write(byteArray, 0, byteArray.Length);
            }
            return fpath;
        }

        public byte[] getFileToByte(string file)
        {
            byte[] b;
            using (System.IO.FileStream f = System.IO.File.OpenRead(file))
            {
                int size = Convert.ToInt32(f.Length);
                b = new byte[size];
                f.Read(b, 0, size);
            }
            return b;
        }

        ///// <summary>
        ///// Permet de convertire l'image en données binaires
        ///// </summary>
        ///// <param name="filePath">Chemin de l'image</param>
        ///// <returns>L'image sous forme de byte[]</returns>
        //public byte[] GetImage(string cheminFichier)
        //{
        //    FileStream fs = new FileStream(cheminFichier, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    byte[] img = br.ReadBytes((int)fs.Length);
        //    br.Close();
        //    fs.Close();
        //    return img;
        //}
        #endregion

        #region Valeur pour actualisation des comboBox de form ouvert sur le form principal

        public static bool EnterFormAttentionSpeciale
        {
            get { return clsDoTraitement.enterFormAttentionSpeciale; }
            set { clsDoTraitement.enterFormAttentionSpeciale = value; }
        }

        public static bool EnterFormEtablissementExterne
        {
            get { return enterFormEtablissementExterne; }
            set { enterFormEtablissementExterne = value; }
        }

        public static bool EnterForFormGroupesanguin
        {
            get { return clsDoTraitement.enterForFormGroupesanguin; }
            set { clsDoTraitement.enterForFormGroupesanguin = value; }
        }

        public static bool EnterForFormConditionnement
        {
            get { return clsDoTraitement.enterForFormConditionnement; }
            set { clsDoTraitement.enterForFormConditionnement = value; }
        }

        public static bool EnterFormConsultationFiche
        {
            get { return clsDoTraitement.enterFormConsultationFiche; }
            set { clsDoTraitement.enterFormConsultationFiche = value; }
        }

        public static bool EnterFormArticle1
        {
            get { return clsDoTraitement.enterFormArticle1; }
            set { clsDoTraitement.enterFormArticle1 = value; }
        }

        public static bool EnterFormVaccination
        {
            get { return clsDoTraitement.enterFormVaccination; }
            set { clsDoTraitement.enterFormVaccination = value; }
        }

        public static bool EnterFormDelivrance
        {
            get { return clsDoTraitement.enterFormDelivrance; }
            set { clsDoTraitement.enterFormDelivrance = value; }
        }

        public static bool EnterForFormCategorieAgent
        {
            get { return clsDoTraitement.enterForFormCategorieAgent; }
            set { clsDoTraitement.enterForFormCategorieAgent = value; }
        }

        public static bool EnterFormArticle
        {
            get { return clsDoTraitement.enterFormArticle; }
            set { clsDoTraitement.enterFormArticle = value; }
        }

        public static bool EnterFormAvortement
        {
            get { return clsDoTraitement.enterFormAvortement; }
            set { clsDoTraitement.enterFormAvortement = value; }
        }

        public static bool EnterFormAcouchement
        {
            get { return clsDoTraitement.enterFormAcouchement; }
            set { clsDoTraitement.enterFormAcouchement = value; }
        }

        public static bool EnterFormPriseVitamine
        {
            get { return clsDoTraitement.enterFormPriseVitamine; }
            set { clsDoTraitement.enterFormPriseVitamine = value; }
        }

        public static int IdAccouchement
        {
            get { return clsDoTraitement.idAccouchement; }
            set { clsDoTraitement.idAccouchement = value; }
        }

        public static bool EnterFormIntervention
        {
            get { return clsDoTraitement.enterFormIntervention; }
            set { clsDoTraitement.enterFormIntervention = value; }
        }

        //public static bool EnterFormTypeSysteme
        //{
        //    get { return clsDoTraitement.enterFormTypeSysteme; }
        //    set { clsDoTraitement.enterFormTypeSysteme = value; }
        //}

        public static int IdEnfant
        {
            get { return clsDoTraitement.idEnfant; }
            set { clsDoTraitement.idEnfant = value; }
        }

        public static int IdPassationExamen
        {
            get { return clsDoTraitement.idPassationExamen; }
            set { clsDoTraitement.idPassationExamen = value; }
        }

        public static int Id_Medicament
        {
            get { return clsDoTraitement.id_Medicament; }
            set { clsDoTraitement.id_Medicament = value; }
        }

        public static int IdOutilMedical
        {
            get { return clsDoTraitement.idOutilMedical; }
            set { clsDoTraitement.idOutilMedical = value; }
        }

        public static int IdMaladie
        {
            get { return clsDoTraitement.idMaladie; }
            set { clsDoTraitement.idMaladie = value; }
        }

        public static int IdFemmeEnceinte
        {
            get { return clsDoTraitement.idFemmeEnceinte; }
            set { clsDoTraitement.idFemmeEnceinte = value; }
        }

        public static int IdMalade
        {
            get { return clsDoTraitement.idMalade; }
            set { clsDoTraitement.idMalade = value; }
        }

        public static int IdExamen
        {
            get { return clsDoTraitement.idExamen; }
            set { clsDoTraitement.idExamen = value; }
        }

        public static int IdConsultationNormale
        {
            get { return clsDoTraitement.idConsultationNormale; }
            set { clsDoTraitement.idConsultationNormale = value; }
        }

        public static int IdExamenGynecoObstetric
        {
            get { return clsDoTraitement.idExamenGynecoObstetric; }
            set { clsDoTraitement.idExamenGynecoObstetric = value; }
        }

        public static int IdConsultationPreNatal
        {
            get { return clsDoTraitement.idConsultationPreNatal; }
            set { clsDoTraitement.idConsultationPreNatal = value; }
        }

        public static int IdEnfantFemme
        {
            get { return clsDoTraitement.idEnfantFemme; }
            set { clsDoTraitement.idEnfantFemme = value; }
        }

        public static int IdAntecedentMedicoObstetric
        {
            get { return clsDoTraitement.idAntecedentMedicoObstetric; }
            set { clsDoTraitement.idAntecedentMedicoObstetric = value; }
        }

        public static int IdConsellingEtTestRapide
        {
            get { return clsDoTraitement.idConsellingEtTestRapide; }
            set { clsDoTraitement.idConsellingEtTestRapide = value; }
        }

        public static bool EnterFormMalEnConsPostNatale
        {
            get { return enterFormMalEnConsPostNatale; }
            set { enterFormMalEnConsPostNatale = value; }
        }

        public static bool EnterFormConsultationPreNatale
        {
            get { return clsDoTraitement.enterFormConsultationPreNatale; }
            set { clsDoTraitement.enterFormConsultationPreNatale = value; }
        }

        public static int IdPaiementArchive
        {
            get { return clsDoTraitement.idPaiementArchive; }
            set { clsDoTraitement.idPaiementArchive = value; }
        }

        public static bool EnterFormAireSante
        {
            get { return enterFormAireSante; }
            set { enterFormAireSante = value; }
        }

        public static bool EnterFormProvince
        {
            get { return enterFormProvince; }
            set { enterFormProvince = value; }
        }

        public static bool EnterFormDistrictville
        {
            get { return enterFormDistrictville; }
            set { enterFormDistrictville = value; }
        }

        public static bool EnterFormTerritoirecommune
        {
            get { return enterFormTerritoirecommune; }
            set { enterFormTerritoirecommune = value; }
        }

        public static bool EnterFormCollectivitequartier
        {
            get { return enterFormCollectivitequartier; }
            set { enterFormCollectivitequartier = value; }
        }

        public static bool EnterFormEtablissement
        {
            get { return enterFormEtablissement; }
            set { enterFormEtablissement = value; }
        }

        public static bool EnterFormCategorie
        {
            get { return enterFormCategorie; }
            set { enterFormCategorie = value; }
        }

        public static bool EnterFormPersonne
        {
            get { return enterFormPersonne; }
            set { enterFormPersonne = value; }
        }

        public static bool EnterFormMaladie
        {
            get { return enterFormMaladie; }
            set { enterFormMaladie = value; }
        }

        public static bool EnterFormMaladieGynecologique
        {
            get { return enterFormMaladieGynecologique; }
            set { enterFormMaladieGynecologique = value; }
        }

        public static bool EnterFormCategorieAbonne
        {
            get { return enterFormCategorieAbonne; }
            set { enterFormCategorieAbonne = value; }
        }

        public static bool EnterForFormQualification
        {
            get { return enterForFormQualification; }
            set { enterForFormQualification = value; }
        }

        public static bool EnterForFormExamen
        {
            get { return enterFormFormExamen; }
            set { enterFormFormExamen = value; }
        }

        public static bool EnterForFormFonction
        {
            get { return enterForFormFonction; }
            set { enterForFormFonction = value; }
        }

        public static bool EnterForFormService
        {
            get { return enterForFormService; }
            set { enterForFormService = value; }
        }

        public static bool EnterForFormAllergie
        {
            get { return enterForFormAllergie; }
            set { enterForFormAllergie = value; }
        }

        public static bool EnterForFormProfession
        {
            get { return enterFormFormProfession; }
            set { enterFormFormProfession = value; }
        }

        public static bool EnterForFormVitamine
        {
            get { return enterFormVitamine; }
            set { enterFormVitamine = value; }
        }

        public static bool EnterForFormAttention
        {
            get { return enterFormAttention; }
            set { enterFormAttention = value; }
        }

        public static bool EnterForFormPeriodeVitamine
        {
            get { return enterFormPeriodeVitamine; }
            set { enterFormPeriodeVitamine = value; }
        }

        public static bool EnterForCritere
        {
            get { return enterForCritere; }
            set { enterForCritere = value; }
        }

        public static bool EnterForFormVaccin
        {
            get { return enterFormVaccin; }
            set { enterFormVaccin = value; }
        }

        public static bool EnterForFormPeriodeVaccination
        {
            get { return enterFormPeriodeVaccination; }
            set { enterFormPeriodeVaccination = value; }
        }

        public static bool EnterForFormSuiviCroissance
        {
            get { return enterFormSuiviCroissance; }
            set { enterFormSuiviCroissance = value; }
        }

        public static bool EnterForFormRendezVous
        {
            get { return enterFormRendezVous; }
            set { enterFormRendezVous = value; }
        }

        public static bool EnterForFormTypeExamen
        {
            get { return clsDoTraitement.enterForFormTypeExamen; }
            set { clsDoTraitement.enterForFormTypeExamen = value; }
        }

        public static bool EnterForFormConsultationPrenatale
        {
            get { return clsDoTraitement.enterForFormConsultationPrenatale; }
            set { clsDoTraitement.enterForFormConsultationPrenatale = value; }
        }

        public static bool EnterFormTypeAcouchement
        {
            get { return clsDoTraitement.enterFormTypeAcouchement; }
            set { clsDoTraitement.enterFormTypeAcouchement = value; }
        }
        #endregion

        #region Valeurs pour recupération des éléments chargé par petit formulaire de recherche (Fournisseur,Agent)
        public static int Identifiant_Personne
        {
            get { return clsDoTraitement.identifiant_Personne; }
            set { clsDoTraitement.identifiant_Personne = value; }
        }
        public static int Identifiant_Fournisseur
        {
            get { return clsDoTraitement.identifiant_Fournisseur; }
            set { clsDoTraitement.identifiant_Fournisseur = value; }
        }
        public static string FullNamePersonne
        {
            get { return clsDoTraitement.fullNamePersonne; }
            set { clsDoTraitement.fullNamePersonne = value; }
        }
        public static string NomPersonne
        {
            get { return clsDoTraitement.nomPersonne; }
            set { clsDoTraitement.nomPersonne = value; }
        }
        public static string PostnomPersonne
        {
            get { return clsDoTraitement.postnomPersonne; }
            set { clsDoTraitement.postnomPersonne = value; }
        }
        public static string PrenomPersonne
        {
            get { return clsDoTraitement.prenomPersonne; }
            set { clsDoTraitement.prenomPersonne = value; }
        }
        public static string SexePersonne
        {
            get { return clsDoTraitement.sexePersonne; }
            set { clsDoTraitement.sexePersonne = value; }
        }
        public static DateTime? DatenaissancePersonne
        {
            get { return clsDoTraitement.datenaissancePersonne; }
            set { clsDoTraitement.datenaissancePersonne = value; }
        }
        public static string EtatCivPersonne
        {
            get { return clsDoTraitement.etatCivPersonne; }
            set { clsDoTraitement.etatCivPersonne = value; }
        }
        public static string TelPersonne
        {
            get { return clsDoTraitement.telPersonne; }
            set { clsDoTraitement.telPersonne = value; }
        }
        public static string AdressePersonne
        {
            get { return clsDoTraitement.adressePersonne; }
            set { clsDoTraitement.adressePersonne = value; }
        }
        public static string Numero_du_fournisseur
        {
            get { return clsDoTraitement.numero_du_fournisseur; }
            set { clsDoTraitement.numero_du_fournisseur = value; }
        }
        public static int Identifiant_Agent
        {
            get { return clsDoTraitement.identifiant_Agent; }
            set { clsDoTraitement.identifiant_Agent = value; }
        }
        public static int Id_Fonction_Agent
        {
            get { return clsDoTraitement.id_Fonction_Agent; }
            set { clsDoTraitement.id_Fonction_Agent = value; }
        }
        public static int Id_Service_Agent
        {
            get { return clsDoTraitement.id_Service_Agent; }
            set { clsDoTraitement.id_Service_Agent = value; }
        }
        public static DateTime? DateengagementAgent
        {
            get { return clsDoTraitement.dateengagementAgent; }
            set { clsDoTraitement.dateengagementAgent = value; }
        }
        public static string MatriculePersonne
        {
            get { return clsDoTraitement.matriculePersonne; }
            set { clsDoTraitement.matriculePersonne = value; }
        }
        public static string Inss_Agent
        {
            get { return clsDoTraitement.inss_Agent; }
            set { clsDoTraitement.inss_Agent = value; }
        }
        public static string GradeAgent
        {
            get { return clsDoTraitement.gradeAgent; }
            set { clsDoTraitement.gradeAgent = value; }
        }

        #endregion

        #region creation des parametres
        public void createParamString(string ParamName, string value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamInt(string ParamName, int value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamDate(string ParamName, DateTime value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamDate(string ParamName, DateTime? value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamDouble(string ParamName, Double value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamBool(string ParamName, bool value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamByteTable(string ParamName, byte[] value, IDbCommand cmd)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamInt(string ParamName, int value, SqlCommand cmd)
        {
            SqlParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamDate(string ParamName, DateTime value, SqlCommand cmd)
        {
            SqlParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        public void createParamDouble(string ParamName, Double value, SqlCommand cmd)
        {
            SqlParameter param = cmd.CreateParameter();
            param.ParameterName = ParamName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        #endregion

        //public Image getImageFromByte(string file)
        //{
        //    Image image;
        //    using (FileStream fs = new FileStream(file, FileMode.Open))
        //    {
        //        image = Image.FromStream(fs);
        //    }
        //    return image;
        //}

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    try
        //    {
        //        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    }
        //    catch { }
        //    ms.Close();
        //    return ms.ToArray();
        //}

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    //Image returnImage = Image.FromStream(ms);
        //    Bitmap bmp = new Bitmap(ms);
        //    ms.Close();
        //    return bmp;
        //}

        /// <summary>
        /// Permet la reduction de l'utilisation de la mémoire vive
        /// </summary>
        /// <param name="hProcess">Pointeur</param>
        /// <param name="dwMinimumWorkingSetSize">Entier</param>
        /// <param name="dwMaximumWorkingSetSize">Entier</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
    }
}
