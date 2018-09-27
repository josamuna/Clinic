using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GestionClinic_LIB;
using Microsoft.VisualBasic;

namespace GestionClinic_WIN
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private const int WS_EX_STATICEDGE = 0x00020000;
        private const int WS_SIZEBOX = 0x00040000;

        int t, t1 = 1;

        #region MANAGE DESIGN Frm
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams CP = base.CreateParams;
                CP.ExStyle = WS_EX_STATICEDGE;
                CP.Style = WS_SIZEBOX;
                return CP;
            }
        }

        private void bindingNavigator1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void bindingNavigator1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void bindingNavigator1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(this.WindowState == FormWindowState.Maximized))
            {

                this.WindowState = FormWindowState.Maximized;
                toolStripButton1.Image = global::GestionClinic_WIN.Properties.Resources.UploadAction_2;
                toolStripButton1.ToolTipText = "Minimiser";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                toolStripButton1.Image = global::GestionClinic_WIN.Properties.Resources.UploadAction;
                toolStripButton1.ToolTipText = "Agrandir";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!(this.WindowState == FormWindowState.Maximized))
            {
                this.WindowState = FormWindowState.Maximized;
                toolStripButton1.Image = global::GestionClinic_WIN.Properties.Resources.UploadAction_2;
                toolStripButton1.ToolTipText = "Minimiser";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                toolStripButton1.Image = global::GestionClinic_WIN.Properties.Resources.UploadAction;
                toolStripButton1.ToolTipText = "Agrandir";
            }
        }

        private void bindingNavigator1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
         
        private void bindingNavigator1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MenuStripTest.Hide();
            }
        }
        #endregion

        public void desabledMenu(string str)
        {
            //Agent
            mnAgent.Enabled = false;

            //Triage   
            mnPersonne.Enabled = false;
            mnAptitudePhysique.Enabled = false;
            mnTriage.Enabled = false;
            smMalade.Enabled = false;
            smPreconsultation.Enabled = false;
            smRapportsPreconsultation.Enabled = false;

            //Consultation
            mnConsultation.Enabled = false;
            smConsultationNormale.Enabled = false;
            smCPN.Enabled = false;
            smCPOS.Enabled = false;
            smConsultationGyn.Enabled = false;

            //Laboratoire
            mnLabo.Enabled = false;
            smExamen.Enabled = false;
            smRapportsLabo.Enabled = false;

            //Hospitalisation
            mnHospitalisation.Enabled = false;
            smHospitalisationIntervention.Enabled = false;
            smIntervention.Enabled = false;
            smRapportsHospitalisation.Enabled = false;

            //Pharmacie
            mnPharmacie.Enabled = false;
            smFournisseur.Enabled = false;
            smApprovisionnement.Enabled = false;
            smSortieArtPharmacie.Enabled = false;
            smRapportsPharmacie.Enabled = false;

            //Caisse
            mnCaisse.Enabled = false;
            smPaiement.Enabled = false;
            smSortieArtCaisse.Enabled = false;
            smTarifs.Enabled = false;
            smAvance.Enabled = false;
            smRapportsCaisse.Enabled = false;

            //ToolBox
            btnBackUp.Enabled = false;
            btnParametre.Enabled = false;

            //Menu
            mnGestionUtilisateur.Enabled = false;
            smSauvegardeBD.Enabled = false;
            smRestaurationBD.Enabled = false;
            lblAffiche.Text = str;
            mnParamAide.Enabled = false;
        }

        public void enabledMenuAdmin()
        {
            //Agent
            mnAgent.Enabled = true;

            //Triage   
            mnPersonne.Enabled = true;
            mnAptitudePhysique.Enabled = true;
            mnTriage.Enabled = true;
            smMalade.Enabled = true;
            smPreconsultation.Enabled = true;
            smRapportsPreconsultation.Enabled = true;

            //Consultation
            mnConsultation.Enabled = true;
            smConsultationNormale.Enabled = true;
            smCPN.Enabled = false;
            smCPOS.Enabled = false;
            smConsultationGyn.Enabled = true;

            //Laboratoire
            mnLabo.Enabled = true;
            smExamen.Enabled = true;
            smRapportsLabo.Enabled = true;

            //Hospitalisation
            mnHospitalisation.Enabled = true;
            smHospitalisationIntervention.Enabled = true;
            smIntervention.Enabled = true;
            smRapportsHospitalisation.Enabled = false;

            //Pharmacie
            mnPharmacie.Enabled = true;
            smFournisseur.Enabled = true;
            smApprovisionnement.Enabled = true;
            smSortieArtPharmacie.Enabled = true;
            smRapportsPharmacie.Enabled = true;

            //Caisse
            mnCaisse.Enabled = true;
            smPaiement.Enabled = true;
            smSortieArtCaisse.Enabled = true;
            smTarifs.Enabled = true;
            smAvance.Enabled = true;
            smRapportsCaisse.Enabled = false;

            //ToolBox
            btnBackUp.Enabled = true;
            btnParametre.Enabled = true;

            //Menu
            mnGestionUtilisateur.Enabled = true;
            smSauvegardeBD.Enabled = true;
            smRestaurationBD.Enabled = true;
            mnParamAide.Enabled = true;
        }

        public void enabledMenuMedecin()
        {
            //Triage   
            mnPersonne.Enabled = true;
            mnAptitudePhysique.Enabled = true;
            mnTriage.Enabled = true;
            smMalade.Enabled = true;
            smPreconsultation.Enabled = true;
            smRapportsPreconsultation.Enabled = true;

            //Consultation
            mnConsultation.Enabled = true;
            smConsultationNormale.Enabled = true;

            //Hospitalisation
            mnHospitalisation.Enabled = true;
            smHospitalisationIntervention.Enabled = true;
            smIntervention.Enabled = true;
            smRapportsHospitalisation.Enabled = false;
        }

        public void enabledMenuInfirmier()
        {
            //Triage   
            mnPersonne.Enabled = true;
            mnAptitudePhysique.Enabled = true;
            mnTriage.Enabled = true;
            smMalade.Enabled = true;
            smPreconsultation.Enabled = true;
            smRapportsPreconsultation.Enabled = true;
        }

        public void enabledMenuPharmacie()
        {
            //Pharmacie
            mnPharmacie.Enabled = true;
            smFournisseur.Enabled = true;
            smApprovisionnement.Enabled = true;
            smSortieArtPharmacie.Enabled = true;
            smRapportsPharmacie.Enabled = true;
        }

        public void enabledMenuLaborantin()
        {
            //Laboratoire
            mnLabo.Enabled = true;
            smExamen.Enabled = true;
            smRapportsLabo.Enabled = true;
        }

        public void enabledMenuCaisse()
        {
            //Caisse
            mnCaisse.Enabled = true;
            smPaiement.Enabled = true;
            smSortieArtCaisse.Enabled = true;
            smTarifs.Enabled = true;
            smAvance.Enabled = true;
            smRapportsCaisse.Enabled = false;
        }

        public void enabledMenuMedecinGynecologue()
        {
            //Triage   
            mnPersonne.Enabled = true;
            mnAptitudePhysique.Enabled = true;
            mnTriage.Enabled = true;
            smMalade.Enabled = true;

            //Consultation
            mnConsultation.Enabled = true;
            smConsultationNormale.Enabled = false;
            smConsultationGyn.Enabled = true;

            //Hospitalisation
            mnHospitalisation.Enabled = true;
            smHospitalisationIntervention.Enabled = true;
            smIntervention.Enabled = true;
            smRapportsHospitalisation.Enabled = false;
        }

        public void enabledMenuService()
        {
            //Pharmacie
            mnPharmacie.Enabled = true;
            smSortieArtPharmacie.Enabled = true;
        }

        public void enabledMenu(bool bln, string str)
        {
            foreach (string str_groupe in clsDoTraitement.valueUser)
            {
                if (str_groupe.Equals("Administrateur")) enabledMenuAdmin();
                else if (str_groupe.Equals("Médecin")) enabledMenuMedecin();
                else if (str_groupe.Equals("Infirmier")) enabledMenuInfirmier();
                else if (str_groupe.Equals("Laborantin")) enabledMenuLaborantin();
                else if (str_groupe.Equals("Pharmacien")) enabledMenuPharmacie();
                else if (str_groupe.Equals("Caissier")) enabledMenuCaisse();
                else if (str_groupe.Equals("Médecin gynéco.")) enabledMenuMedecinGynecologue();
                else if (str_groupe.Equals("Service")) enabledMenuService();
            }

            lblAffiche.Text = str;
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Connection frm = new Connection();
            frm.FrmMainMenu = this;
            frm.ShowDialog();
            //enabledMenu();
        }

        private void btnParametre_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            UtilisateurFrm frm = new UtilisateurFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void mnConnection_Click(object sender, EventArgs e)
        {
            Connection c = new Connection();
            c.FrmMainMenu = this;
            c.ShowDialog();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            dlgFile.Title = "Veuillez sélectionner l'emplacement de sauvegarde";

            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                string cheminAccesBd = dlgFile.FileName;
                try
                {
                    string lecteur = Interaction.InputBox("Veuillez saisir la lettre du lecteur sur lequel vous aller éffectuer la sauvegarde", "Lecteur de sauvegarde", "C", 300, 300);
                    string message = clsMetier.GetInstance().BackupLocalDataBase(cheminAccesBd, lecteur);
                    MessageBox.Show("Sauvegarde éffectuée avec succès dans l'emplacement | " + message + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de la sauvegarde dans l'emplacement | " + cheminAccesBd + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void smSauvegardeBD_Click(object sender, EventArgs e)
        {
            dlgFile.Title = "Veuillez sélectionner l'emplacement de sauvegarde";

            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                string cheminAccesBd = dlgFile.FileName;
                try
                {
                    string lecteur = Interaction.InputBox("Veuillez saisir la lettre du lecteur sur lequel vous aller éffectuer la sauvegarde", "Lecteur de sauvegarde", "C", 300, 300);
                    string message = clsMetier.GetInstance().BackupLocalDataBase(cheminAccesBd, lecteur);
                    MessageBox.Show("Sauvegarde éffectuée avec succès dans l'emplacement | " + message + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de la sauvegarde dans l'emplacement | " + cheminAccesBd + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void smRestaurationBD_Click(object sender, EventArgs e)
        {
            dlgOpen.Title = "Veuillez sélectionner le fichier pour la restauration";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                string cheminAccesBd = dlgOpen.FileName;
                try
                {
                    string msg = clsMetier.GetInstance().RestoreDataBase(cheminAccesBd, null);
                    MessageBox.Show("Restauration éffectuée avec succès à partir de l'emplacement | " + cheminAccesBd + " |", "Restauration de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de la restauration à partir de l'emplacement | " + cheminAccesBd + " |", "Restauration de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #region UPDATE APPLICATION

        private void UpdateApp()
        {
            ApplicationDeployment updater = ApplicationDeployment.CurrentDeployment;
            bool verDepServer = updater.CheckForUpdate();

            if (verDepServer) // Update disponible
            {
                DialogResult res = MessageBox.Show(
                                   String.Format("Une nouvelle version est disponible{0}Mettre à jour maintenant ?",
                                                 Environment.NewLine),
                                   "Mise à jour",
                                   MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    updater.Update();

                    MessageBox.Show("Attention, l'application va redémarrer", "Redémarrage",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Pas de nouvelle version disponible");
            }
        }

        #endregion

        private void miseÀJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.UpdateApp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'essaie de mise à jour de l'application, " + ex.Message,"Pas de nouvelle version disponible",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == (t1 * 180))
            {
                t1++;
                Console.WriteLine("Rafraichissement avec t={0} et t1={1}", t, t1);
                try
                {
                    clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
                }
                catch { }
                Console.WriteLine("La valeur actuelle de t = " + t);
            }
        }

        private void contenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            AideFrm frm = new AideFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void btnAide_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            AideFrm frm = new AideFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Appliction Clinic pour la gestion de l'hôpital, conçu par CPG (Conceptors and Programmers Group) \n© 2015 - Tous droits reservés.", "Clinic Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnParamAide_Click(object sender, EventArgs e)
        {
            string serveur = "";
            try
            {
                if (string.IsNullOrEmpty(clsDoTraitement.GetInstance().loadParamFileAide()))
                {
                    serveur = Interaction.InputBox("Veuillez saisir Le nom du serveur ou son adresse IP", "Serveur de base des données", "127.0.0.1", 300, 300);
                    
                    if (dlgOpen2.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Exportation du fichier d'aide dans le dossier de parametre de l'application (Dossier GestionClinic)
                            //clsDoTraitement.nomServeur = @"\\" + serveur + @"\Deployment";
                            clsDoTraitement.copyFileToDirectory(dlgOpen2.FileName);
                            MessageBox.Show("Fichier exporté avec succès", "Exportation fichier d'aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Impossible de charger le fichier", "Fichier invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Fichier invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else MessageBox.Show("Opération annulée", "Parametrage aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dlgOpen2.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Exportation du fichier d'aide dans le dossier de parametre de l'application (Dossier GestionClinic)
                            //clsDoTraitement.nomServeur = @"\\" + clsDoTraitement.GetInstance().loadParamFileAide() + @"\Deployment";
                            clsDoTraitement.copyFileToDirectory(dlgOpen2.FileName);
                            MessageBox.Show("Fichier exporté avec succès", "Exportation fichier d'aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Impossible de charger le fichier", "Fichier invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Fichier invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else MessageBox.Show("Opération annulée", "Parametrage aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur inattendue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnPersonne_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            PersonneFrm frm = new PersonneFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void mnAptitudePhysique_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            FrmAptitudePhysique frm = new FrmAptitudePhysique();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void mnAgent_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            AgentFrm frm = new AgentFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smMalade_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            MaladeFrm frm = new MaladeFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smPreconsultation_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            PreconsultationFrm frm = new PreconsultationFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smRapportsPreconsultation_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            FicheMaladeFrm frm = new FicheMaladeFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smConsultationNormale_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            ConsultationMedecinFrm frm = new ConsultationMedecinFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smCPN_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            //}
            //catch { }

            //FrmConsultationPrenataleUser frm = new FrmConsultationPrenataleUser();
            //frm.MdiParent = this;
            //frm.setFormPrincipal(this);
            //frm.Icon = this.Icon;
            //frm.Show();
        }

        private void smCPOS_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            //}
            //catch { }

            //FrmMaladeConsultationPostNatalUser frm = new FrmMaladeConsultationPostNatalUser();
            //frm.MdiParent = this;
            //frm.setFormPrincipal(this);
            //frm.Icon = this.Icon;
            //frm.Show();
        }

        private void smConsultationGyn_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            ConsultationGynecoFrm frm = new ConsultationGynecoFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smExamen_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            LaboFrm frm = new LaboFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smRapportsLabo_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            ReportLaboratoireFrm frm = new ReportLaboratoireFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smIntervention_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            PasserIntervetionFrm frm = new PasserIntervetionFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smFournisseur_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            FournisseurFrm frm = new FournisseurFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Show();
        }

        private void smApprovisionnement_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { };

            ApprovisionementArticleFrm frm = new ApprovisionementArticleFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Show();
        }

        private void smSortieArtPharmacie_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            SortieArticleFrm frm = new SortieArticleFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Show();
        }

        private void smRapportsPharmacie_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            ReportPharmacieFrm frm = new ReportPharmacieFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Show();
        }

        private void smPaiement_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            PaimentFrm frm = new PaimentFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smSortieArtCaisse_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            SortieArticleCaisseFrm frm = new SortieArticleCaisseFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smTarifs_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            TarifsFrm frm = new TarifsFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smAvance_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            AvanceFrm frm = new AvanceFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void smRapportsCaisse_Click(object sender, EventArgs e)
        {

        }

        private void smRapportsHospitalisation_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void mnQuitter_Click(object sender, EventArgs e)
        {
            try
            {
                //Fermeture de toutes les connexion actives
                clsMetier.GetInstance().closeConnexion();
            }
            catch (Exception) { }
            Application.ExitThread();
        }

        private void mnDeconnexion_Click(object sender, EventArgs e)
        {
            try
            {
                //Fermeture de toutes les connexion actives
                clsMetier.GetInstance().closeConnexion();
                desabledMenu("Interface Principale");
            }
            catch (Exception) { }
        }

        private void smHospitalisationIntervention_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            HospitalisationFrm frm = new HospitalisationFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void mnGestionUtilisateur_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }

            UtilisateurFrm frm = new UtilisateurFrm();
            frm.MdiParent = this;
            frm.setFormPrincipal(this);
            frm.Icon = this.Icon;
            frm.Show();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            desabledMenu("Interface Principale");
            //lblImagePrincipale.Image = GestionClinic_WIN.Properties.Resources.background;
        }
    }
}
