using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DirectX.Capture;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class PersonneFrm : Form
    {
        public PersonneFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clspersonne personne = new clspersonne();
        private BindingSource bsrc = new BindingSource();
        //private string pathPhotoLoad = null;
        private bool bln = false;

        #region ITEMS POUR WEBCAM
        //Class et objects pour WebCam
        private Filters InputOptions = null;
        private Filter VideoInput = null;
        private Filter AudioInput = null;
        private Capture CaptureInfo = null;

        private void chargementWebCam()
        {
            InputOptions = new Filters();
            cmdAppliquer.Enabled = false;
            foreach (Filter f in InputOptions.VideoInputDevices)
            {
                cboVideoSource.Items.Add(f.Name);
            }
            if (cboVideoSource.Items.Count > 0)
            {
                cmdAppliquer.Enabled = true;
                cboVideoSource.SelectedIndex = 0;
            }
            foreach (Filter f in InputOptions.AudioInputDevices)
            {
                cboAudioSource.Items.Add(f.Name);
            }
            if (cboAudioSource.Items.Count > 0) cboAudioSource.SelectedIndex = 0;
        }

        /// <summary>
        /// Configure les option d'entree
        /// </summary>
        private void Configure()
        {
            if (cboVideoSource.Items.Count < 1)
                throw new Exception();
            cboVideoSource.Enabled = false;
            cboAudioSource.Enabled = false;
            this.cmdAppliquer.Enabled = true;
            this.VideoInput = this.InputOptions.VideoInputDevices[cboVideoSource.SelectedIndex];
            if (cboAudioSource.Items.Count > 0)
                this.AudioInput = this.InputOptions.AudioInputDevices[cboAudioSource.SelectedIndex];
            this.CaptureInfo = new Capture(this.VideoInput, this.AudioInput);
            this.CaptureInfo.PreviewWindow = picturePreview;
            this.CaptureInfo.RenderPreview();
            this.CaptureInfo.FrameCaptureComplete += new Capture.FrameCapHandler(CaptureInfo_FrameCaptureComplete);
            this.cmdCapturer.Enabled = true;
            this.cmdAppliquer.Enabled = false;
        }

        /// <summary>
        /// Est effectue lorsque la capture a reussie
        /// </summary>
        /// <param name="Frame">cette photo est generee</param>
        void CaptureInfo_FrameCaptureComplete(PictureBox Frame)
        {
            pbCapture.Image = Frame.Image;
        }

        private void ErrorMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Test du Webcam", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void FrmPersonne_Load(object sender, EventArgs e)
        {
            rdLocalPicture.Checked = true;
            lblLoadPhoto.Enabled = true;
            gpWebCam.Enabled = false;
            cmdEnregistrer.Enabled = false;
            cmdArreter.Enabled = false;
            cmdEffacer.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            ChargementCombo();

            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement du formulaire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                this.chargementWebCam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des paramètres du WebCam, " + ex.Message, "Chargement paramètres WebCam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Si l'utilisateur est un Super Administrateur ou un Administrateur,
            //il a le droit de créer le repertoire de sauvegarde temporaire des photo prises

            foreach (string str_groupe in clsDoTraitement.valueUser)
            {
                if (str_groupe.Equals("Administrateur"))
                {
                    cmdRepertoire.Enabled = true;//L'Utilisateur est un SuperAdministrateur ou un Administrateur
                    gpSupprimerRepertoire.Enabled = true;
                    break;
                }
                else
                {
                    cmdRepertoire.Enabled = false;
                    gpSupprimerRepertoire.Enabled = false;
                }
            }

            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtNom, txtPNom, txtPrenom, txtTelephone, txtDateNaissance, cboSexe, cboEtatCiv,txtAdresse };
            clearforbinding(tbcontrols);

            setbindingcls(txtNom, "Nom", 0);
            setbindingcls(txtPNom, "Postnom", 0);
            setbindingcls(txtPrenom, "Prenom", 0);
            setbindingcls(txtDateNaissance, "Datenaissance", 0);
            setbindingcls(txtAdresse, "Adresse", 0);
            setbindingcls(txtTelephone, "Telephone", 0);
            setbindingcls(cboEtatCiv, "Etatcivil", 0);
            setbindingcls(cboSexe, "Sexe", 0);
            bingImg(pbPhotoPersonne, personne, "Image", "Photo");
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtNom, txtPNom, txtPrenom, txtTelephone, txtDateNaissance, cboSexe, cboEtatCiv,txtAdresse };
            clearforbinding(tbcontrols);

            setbindinglst(txtNom, "Nom", 0);
            setbindinglst(txtPNom, "Postnom", 0);
            setbindinglst(txtPrenom, "Prenom", 0);
            setbindinglst(txtDateNaissance, "Datenaissance", 0);
            setbindinglst(txtTelephone, "Telephone", 0);
            setbindinglst(txtAdresse, "Adresse", 0);
            setbindinglst(cboEtatCiv, "Etatcivil", 0);
            setbindinglst(cboSexe, "Sexe", 0);
            bingImg(pbPhotoPersonne, bsrc, "Image", "Photo");
        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", personne, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", personne, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", personne, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", personne, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            personne = new clspersonne();
            bln = false;
            bindingcls();
            cboSexe.SelectedIndex = 0;
            cboEtatCiv.SelectedIndex = 1;
            btnSave.Enabled = true;
            //txtDateNaissance.Text = DateTime.Today.ToString();    
        }

        private void bingImg(PictureBox pb, Object src, string ctrProp, string obj)
        {
            pb.DataBindings.Clear();
            Binding binding = new Binding(ctrProp, src, obj, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += new ConvertEventHandler(binding_Format);
            pb.DataBindings.Add(binding);
        }

        void binding_Format(object sender, ConvertEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    Bitmap bb = new Bitmap(pbPhotoPersonne.Size.Width, pbPhotoPersonne.Size.Height);
                    bb = (new clsDoTraitement()).getImageFromByte((byte[])e.Value);
                    e.Value = bb;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Erreur dans la zone d'affichage, Actualisez pour un affichage correcte", "Erreur d'affichage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refresh()
        {
            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            cboSexe.SelectedIndex = 0;
            cboEtatCiv.SelectedIndex = 1;
            pbPhotoPersonne.Image = null;
            btnDelete.Enabled = false;
            txtNom.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClspersonneDt(-100);
                dgv.DataSource = bsrc;
            }
            catch (Exception) { }
        }

        private void ChargementCombo()
        {
            cboSexe.Items.Add("M");
            cboSexe.Items.Add("F");

            cboEtatCiv.Items.Add("Marié");
            cboEtatCiv.Items.Add("Celibataire");
            cboEtatCiv.Items.Add("Divorcé");
            cboEtatCiv.Items.Add("Veuf");
            cboEtatCiv.SelectedIndex = 1;
            cboSexe.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    if (gpWebCam.Enabled) personne.Photo = clsDoTraitement.GetInstance().getFileToByte(clsDoTraitement.GetInstance().loadParamTemporaire());
                    personne.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        if (clsDoTraitement.accepte_updatepicture != 1 && clsDoTraitement.accepte_updatepicture != 2) clsDoTraitement.accepte_updatepicture = 3;
                        clspersonne s = new clspersonne();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("nom")) s.Nom = ((string)obj[i]);
                            else if (dtc.ToString().Equals("postnom")) s.Postnom = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("prenom")) s.Prenom = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("datenaissance")) s.Datenaissance = ((obj[i]) == DBNull.Value) ? null : ((DateTime?)obj[i]);
                            else if (dtc.ToString().Equals("telephone")) s.Telephone = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("sexe")) s.Sexe = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("etatcivil")) s.Etatcivil = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("adresse")) s.Adresse = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdPers = ((int)obj[i]);
                            else if (dtc.ToString().Equals("photo"))
                            {
                                if (obj[i] != DBNull.Value) { s.Photo = (Byte[])obj[i]; }
                                else
                                {
                                    bingImg(pbPhotoPersonne, personne, "Image", "Photo");
                                    s.Photo = personne.Photo;//(obj[i] == DBNull.Value) ? ((Byte[])null) : ((Byte[])obj[i]);
                                }
                            }
                            i++;
                        }
                        new clspersonne().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.pathPhotoLoad = "";
                clsDoTraitement.accepte_updatepicture = 0;

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des informations de la personne =>" + ex.Message, "Affichage informations de la personne", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //this.New();
            //refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clspersonne s = new clspersonne();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("nom")) s.Nom = ((string)obj[i]);
                            else if (dtc.ToString().Equals("postnom")) s.Postnom = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("prenom")) s.Prenom = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("dateNaissance")) s.Datenaissance = ((DateTime)obj[i]);
                            else if (dtc.ToString().Equals("telephone")) s.Telephone = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("sexe")) s.Sexe = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("etatcivil")) s.Etatcivil = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("adresse")) s.Adresse = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdPers = ((int)obj[i]);
                            else if (dtc.ToString().Equals("photo")) s.Photo = (obj[i] == DBNull.Value) ? ((Byte[])null) : ((Byte[])obj[i]);
                            i++;
                        }
                        new clspersonne().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.New();
                        refresh();
                    }
                }
                //Permet l'actualisation des valeur des personne sur le formulair appelant
                clsDoTraitement.EnterFormPersonne = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Nom LIKE '%" + txtSeach.Text + "%' OR Postnom LIKE '%" + txtSeach.Text + "%' OR Prenom LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void lblLoadPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo file = new FileInfo(dlgFile.FileName);
                    dlgFile.Filter = "jpg Files (*.jpg)|*.jpg|png Files ()|*.png";
                    pbPhotoPersonne.Load(dlgFile.FileName);
                    personne.Photo = (new clsDoTraitement()).getFileToByte(dlgFile.FileName);
                    clsDoTraitement.pathPhotoLoad = file.FullName;

                    //Notification qu'une photo a été chargée
                    clsDoTraitement.accepte_updatepicture = 1;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Impossible de charger le fichier", "Photo invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible de charger le fichier, " + ex.Message, "Photo invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void rdLocalPicture_CheckedChanged(object sender, EventArgs e)
        {
            lblLoadPhoto.Enabled = true;
            gpWebCam.Enabled = false;

            cmdArreter_Click(sender, e);
        }

        private void rdWebCamPicture_CheckedChanged(object sender, EventArgs e)
        {
            lblLoadPhoto.Enabled = false;
            gpWebCam.Enabled = true;
        }

        private void cmdCapturer_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureInfo.CaptureFrame();
                cmdEnregistrer.Enabled = true;
                cmdArreter.Enabled = true;
                cmdCapturer.Enabled = false;
            }
            catch (Exception ex)
            {
                this.ErrorMessage(ex);
            }
        }

        private void cmdDeleteItems_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.GetInstance().deleteAllItemToDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec lors de la suppression du contenu du dossier de chemin d'accès : '" + clsDoTraitement.GetInstance().loadParamRepertoire() + "'\n L'Erreur est =>" + ex.Message, "Enregistrement photo capturée", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                Random rd = new Random(34);
                string cheminAcces = clsDoTraitement.GetInstance().loadParamRepertoire() + DateTime.Today.Day.ToString() + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "_" + (rd.Next()).ToString() + ".jpg";
                Console.WriteLine("chemin Acces = " + cheminAcces);
                pbCapture.Image.Save(cheminAcces);
                clsDoTraitement.GetInstance().saveParamTemporaire(cheminAcces);
                MessageBox.Show("Exportation effectué avec succès", "Exportation photo capturée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(clsDoTraitement.GetInstance().getFileToByte(cheminAcces));
                cmdArreter_Click(sender, e);
                cmdCapturer.Enabled = false;
                cmdEffacer.Enabled = false;
                //Notification qu'une photo a été chargée
                clsDoTraitement.accepte_updatepicture = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement du fichier !!, " + ex.Message, "Enregistrement photo capturée", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdRepertoire_Click(object sender, EventArgs e)
        {
            FrmConfigurationRepertoire fr = new FrmConfigurationRepertoire();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void cmdEffacer_Click(object sender, EventArgs e)
        {
            cmdCapturer.Enabled = true;
            pbCapture.Image = null;
            cmdEnregistrer.Enabled = false;
        }

        private void cmdAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Configure();
                cmdArreter.Enabled = true;
                cmdEffacer.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Aucun webCam trouvé !!", "Erreur de webCam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdArreter_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureInfo.DisposeCapture();
                cmdAppliquer.Enabled = true;
                cmdCapturer.Enabled = true;
                cboVideoSource.Enabled = true;
                cboAudioSource.Enabled = true;
                cmdEnregistrer.Enabled = false;
                cmdArreter.Enabled = false;
                pbCapture.Image = null;
                picturePreview.Image = null;
            }
            catch (Exception) { }
        }

        private void FrmPersonne_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CaptureInfo.DisposeCapture();
            }
            catch (Exception) { }

            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }

            this.Dispose();
        }

        private void btnSearchPersonne_Click(object sender, EventArgs e)
        {
            try
            {
                RecherchePersonneFrm fr = new RecherchePersonneFrm();
                fr.setFormPrincipal(principal);
                fr.Icon = principal.Icon;
                fr.ShowDialog();
                
                if (clsDoTraitement.doubleclicRecherchePersonneDg)
                {
                    btnSave.Enabled = true;
                    clsDoTraitement.doubleclicRecherchePersonneDg = false;
                    loadData();
                }
                else btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec lors du chargement des informations de la personne " + ex.Message, "Chargement informations de la personne", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadData()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClspersonneDt(clsDoTraitement.Identifiant_Personne);
                personne = clsMetier.GetInstance().getClspersonne(clsDoTraitement.Identifiant_Personne);

                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                cboSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                cboEtatCiv.Text = personne.Etatcivil;
                txtAdresse.Text = personne.Adresse;

                try
                {
                    if (personne.Photo != null) pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                    else pbPhotoPersonne.Image = null;
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                bindignlst();
                bln = true;
            }
            catch (Exception) { }
        }
    }
}
