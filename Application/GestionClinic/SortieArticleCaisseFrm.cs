using System;
using System.Windows.Forms;
using System.Drawing;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class SortieArticleCaisseFrm : Form
    {
        public SortieArticleCaisseFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clssortie sortieArticle = new clssortie();
        clspaiement paiement = new clspaiement();
        clsfacturation facturation = new clsfacturation();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        int stockAlert = 0;
        bool doUpdate = false;

        clssortieexterne sortieArticle1 = new clssortieexterne();
        private BindingSource bsrc1 = new BindingSource();
        //private bool bln1 = false;
        private double montantMituel = 0, montantClient = 0, montantDu = 0, montantDette = 0;

        #region BINDING
        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", sortieArticle, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", sortieArticle, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", sortieArticle, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", sortieArticle, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", sortieArticle, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDate, cboArticle, cboMalade, txtEtatpaiement, txtMontant };
            clearforbinding(tbcontrols);

            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtEtatpaiement, "Etatpaiement", 0);
            setbindingcls(txtMontant, "Montant", 0);
            setbindingcls(cboArticle, "Id_article", 1);
            setbindingcls(cboMalade, "Id_malade", 1);
            //setbindingcls(txtQuantite, "Quantinte", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, cboArticle, txtId_service, cboMalade, txtEtatpaiement, txtMontant, txtSortiemalade, txtQuantite };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtEtatpaiement, "Etatpaiement", 0);
            setbindinglst(txtMontant, "Montant", 0);
            setbindinglst(cboArticle, "Id_article", 1);
            setbindinglst(txtId_service, "Id_service", 0);
            setbindinglst(cboMalade, "Id_malade", 1);
            setbindinglst(txtQuantite, "Quantinte", 0);
            setbindinglst(txtSortiemalade, "Sortiemalade", 0);

            try
            {
                //Recuperation de la valeur de la quantite affiche pour probable modification du stock
                clsDoTraitement.oldValueStockModifie = Convert.ToDouble(txtQuantite.Text);
            }
            catch (Exception) { }
        }

        private void clearforbinding1(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", sortieArticle1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", sortieArticle1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", sortieArticle1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", sortieArticle1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", sortieArticle1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        #endregion END BINDING

        #region NEW ET REFRESH
        private void New()
        {
            sortieArticle = new clssortie();
            bln = false;
            bindingcls();
            txtMontant.Text = "0";
            txtEtatpaiement.Text = "Payé";
            lblMontantAPayer.Text = "";
            lblMontantMituelle.Text = "";
            txtQuantite.Clear();
            if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refresh()
        {
            try
            {
                bindingcls();
                if (!chkAfficheAll.Checked)
                {
                    //On affiche toutes les sorties pour la date du jour : Today
                    if (doUpdate) bsrc.DataSource = clsMetier.GetInstance().getAllClssortie2Caisse(clsMetier.dateMAJSortie.ToString().Substring(0, 10));
                    else bsrc.DataSource = clsMetier.GetInstance().getAllClssortie2Caisse(txtDateSortie.Value.ToString().Substring(0, 10));
                }
                else
                {
                    //On affiche toutes les sorties sans exception
                    bsrc.DataSource = clsMetier.GetInstance().getAllClssortie();
                }

                doUpdate = false;

                cboArticle.DataSource = clsMetier.GetInstance().getAllClsarticle();
                setMembersallcbo(cboArticle, "Desination", "Id");
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
                setMembersallcbo(cboMalade, "Nom_complet", "Id");

                if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
                if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void saveUpdate()
        {
            sortieArticle.Quantinte = Convert.ToInt32(txtQuantite.Text);
            sortieArticle.Id_service = null;
            sortieArticle.Sortiemalade = true;
            if (!bln)
            {
                sortieArticle.inserts();

                //Insertion du paiement
                getAttributPaiementSortie();
                paiement.inserts();

                //Insertion de la facturation
                getAttributFacturationSortie();
                facturation.inserts();
                MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bsrc.DataSource != null)
                {
                    clssortie s = (clssortie)bsrc.Current;
                    s.Quantinte = Convert.ToInt32(txtQuantite.Text);

                    new clssortie().update(s);

                    //Modification du paiement
                    getAttributPaiementSortieUpdate();
                    paiement.update(paiement);

                    //Modification de la facturation
                    getAttributFacturationSortieUpdate();
                    facturation.update(facturation);
                    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            doUpdate = true;
            this.New();
            refresh();
        }

        private void saveUpdate1()
        {
            //sortieArticle1.Quantinte = Convert.ToInt32(txtQuantite1.Text);
            //if (!bln1)
            //{
            //    sortieArticle1.inserts();

            //    //Insertion du paiement
            //    getAttributPaiementSortieExterneUpdate();
            //    paiement.update(paiement);

            //    //Insertion de la facturation
            //    getAttributFacturationSortieExterne();
            //    facturation.inserts();
            //    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    if (bsrc1.DataSource != null)
            //    {
            //        clssortieexterne s = (clssortieexterne)bsrc1.Current;
            //        s.Quantinte = Convert.ToInt32(txtQuantite1.Text);
            //        new clssortieexterne().update(s);

            //        //Modification du paiement
            //        getAttributPaiementSortieExterneUpdate();
            //        paiement.update(paiement);

            //        //Modification de la facturation
            //        getAttributFacturationSortieExterneUpdate();
            //        facturation.update(facturation);
            //        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //this.New1();
            //refresh1();
        }

        private void getAttributPaiementSortie()
        {
            if (cboMalade.Text.Equals("")) paiement.Id_malade = 0;
            else paiement.Id_malade = (int)sortieArticle.Id_malade;
            paiement.Id_accouchement = null;
            paiement.Id_consultation = null;
            paiement.Id_dossierconsultationpostnatal = null;
            paiement.Id_dossierconsultationprenatale = null;
            paiement.Id_hospitalisation = null;
            paiement.Id_operation_laboratoire = null;
            paiement.Id_autrefraie = null;
            paiement.Id_subit = null;
            paiement.Id_sortie = clsDoTraitement.id_sortie_medicaments;
            paiement.Id_dossierpreconsultation = null;
            paiement.Id_consultationgyn = null;

            //Recalculage de la dette pour le paiement
            if (txtCategorieMalade.Text.Equals("Abonné"))
            {
                if (Convert.ToDouble(txtMontant.Text) > montantClient) throw new Exception("Le client ne peut payer plus que ce qu'il doit");
                else if (Convert.ToDouble(txtMontant.Text) == montantClient)
                {
                    montantDette = 0;
                    paiement.Dette = (double)montantDette;
                }
                else if (Convert.ToDouble(txtMontant.Text) < montantClient)
                {
                    montantDette = Math.Round(montantClient - Convert.ToDouble(txtMontant.Text), 2);
                    paiement.Dette = (double)montantDette;
                }
                paiement.Montantmituelle = montantMituel;
            }
            else
            {
                paiement.Dette = 0;
                paiement.Montantmituelle = 0;
            }

            paiement.Montantdu = montantDu;
            paiement.Date = (DateTime)DateTime.Today;
            paiement.Montantpaye = Convert.ToDouble(txtMontant.Text);
        }

        private void getAttributPaiementSortieUpdate()
        {
            paiement = clsMetier.GetInstance().getClspaiement2(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id_malade);
            if (cboMalade.Text.Equals("")) paiement.Id_malade = 0;
            else paiement.Id_malade = ((clsmalade)cboMalade.SelectedItem).Id;
            //paiement.Id_malade = (int)sortieArticle.Id_malade;
            //paiement.Id_sortie = (int)sortieArticle.Id;

            //Recalculage de la dette pour le paiement
            if (txtCategorieMalade.Text.Equals("Abonné"))
            {
                if (Convert.ToDouble(txtMontant.Text) > montantClient) throw new Exception("Le client ne peut payer plus que ce qu'il doit");
                else if (Convert.ToDouble(txtMontant.Text) == montantClient)
                {
                    montantDette = 0;
                    paiement.Dette = (double)montantDette;
                }
                else if (Convert.ToDouble(txtMontant.Text) < montantClient)
                {
                    montantDette = Math.Round(montantClient - Convert.ToDouble(txtMontant.Text), 2);
                    paiement.Dette = (double)montantDette;
                }
                paiement.Montantmituelle = montantMituel;
            }
            else
            {
                paiement.Dette = 0;
                paiement.Montantmituelle = 0;
            }

            paiement.Montantdu = montantDu;
            //paiement.Date = (DateTime)DateTime.Today;
            paiement.Montantpaye = Convert.ToDouble(txtMontant.Text);
        }

        private void getAttributFacturationSortie()
        {
            int idFactureTemp = clsMetier.GetInstance().generateIdFacture();
            if (idFactureTemp == 1) facturation.Numero_facture = 1;
            else if (idFactureTemp > 1) facturation.Numero_facture = clsMetier.GetInstance().generateIdFacture2();

            if (cboMalade.Text.Equals("")) facturation.Id_malade = 0;
            else facturation.Id_malade = (int)sortieArticle.Id_malade;

            facturation.Id_paiement = clsMetier.id_du_paiement;
            facturation.Designation_service = "Article";
            facturation.Designation = cboArticle.Text;
            facturation.Id_article = clsMetier.id_Sortie_art;
            facturation.Id_article_f = ((clsarticle)cboArticle.SelectedItem).Id;
            facturation.Pu = Math.Round((Convert.ToDouble(txtPrix.Text)), 2);
            facturation.Quantite = Convert.ToDouble(txtQuantite.Text);
            facturation.Montantpaye = Convert.ToDouble(txtMontant.Text);
            facturation.Date = (DateTime)DateTime.Today;
            facturation.Ismedicament = true;
            facturation.Isexamen = false;
            facturation.Ispaiementmalade = true;

            //Recalculage de la dette pour la facturation
            if (txtCategorieMalade.Text.Equals("Abonné"))
            {
                if (Convert.ToDouble(txtMontant.Text) == montantClient)
                {
                    montantDette = 0;
                    facturation.Dette = (double)montantDette;
                }
                else if (Convert.ToDouble(txtMontant.Text) < montantClient)
                {
                    montantDette = Math.Round(montantClient - Convert.ToDouble(txtMontant.Text), 2);
                    facturation.Dette = (double)montantDette;
                }
                facturation.Montantmituelle = montantMituel;
            }
            else
            {
                facturation.Dette = 0;
                facturation.Montantmituelle = 0;
            }
            facturation.Avance = 0;
        }

        private void getAttributFacturationSortieUpdate()
        {
            facturation = clsMetier.GetInstance().getClsfacturation1(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id_malade);
            //int idPaiement = facturation.Id_paiement;
            if (cboMalade.Text.Equals("")) facturation.Id_malade = 0;
            else paiement.Id_malade = ((clsmalade)cboMalade.SelectedItem).Id;

            facturation.Id_malade = ((clsmalade)cboMalade.SelectedItem).Id;// (int)sortieArticle.Id_malade;
            facturation.Designation_service = "Article";
            facturation.Designation = cboArticle.Text;
            facturation.Id_article = ((clsarticle)cboArticle.SelectedItem).Id;
            facturation.Id_paiement = clsMetier.GetInstance().getClsfacturationIdpaiement(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id, cboArticle.Text);
            facturation.Pu = Math.Round((Convert.ToDouble(txtPrix.Text)), 2);
            facturation.Quantite = Convert.ToDouble(txtQuantite.Text);
            facturation.Montantpaye = Convert.ToDouble(txtMontant.Text);
            facturation.Date = (DateTime)DateTime.Today;
            facturation.Ismedicament = true;
            facturation.Isexamen = false;

            //Recalculage de la dette pour la facturation
            if (txtCategorieMalade.Text.Equals("Abonné"))
            {
                if (Convert.ToDouble(txtMontant.Text) == montantClient)
                {
                    montantDette = 0;
                    facturation.Dette = (double)montantDette;
                }
                else if (Convert.ToDouble(txtMontant.Text) < montantClient)
                {
                    montantDette = Math.Round(montantClient - Convert.ToDouble(txtMontant.Text), 2);
                    facturation.Dette = (double)montantDette;
                }
                facturation.Montantmituelle = montantMituel;
            }
            else
            {
                facturation.Dette = 0;
                facturation.Montantmituelle = 0;
            }
        }

        private void FrmSortieArticleCaisse_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc, bsrc1 };
                DataGridView[] dg = { dgv };
                ComboBox[] cbo = { cboArticle, cboMalade };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void FrmSortieArticleCaisse_Load(object sender, EventArgs e)
        {
            chkAfficheAll.Checked = false;
            txtDateSortie.Enabled = true;

            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();
                //cboService.SelectedIndex = -1;
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes des sorties", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                try
                {
                    New();
                    cboMalade.SelectedIndex = 0;
                }
                catch (Exception) { btnSave.Enabled = false; }
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                MessageBox.Show("Il n'a rien à afficher", "Message clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                try
                {
                    if (Convert.ToDouble(txtMontant.Text) > 0)
                    {
                        if (Convert.ToDouble(txtMontant.Text) > Convert.ToDouble(lblMontantAPayer.Text)) throw new Exception("Le client veut payer plus que ce qu'il doit");
                        else if (Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text) && txtCategorieMalade.Text.Equals("Non abonné")) throw new Exception("Le client non abonné ne peut payer moins que ce qu'il doit");
                        else if (Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text) && txtCategorieMalade.Text.Equals("Abonné"))
                        {
                            DialogResult msg = MessageBox.Show("Etes-vous sûr que le client veut payer une partie de ce qu'il doit quand bien même il est abonné ?", "Achat pour abonné", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (msg == DialogResult.Yes)
                            {
                                //On effectue la vente pour l'abonné avec une dette partielle
                                saveUpdate();
                            }
                            else MessageBox.Show("Vente non effectuée", "Achat pour abonné", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Vente normale et valide pour un non abonné
                            saveUpdate();
                        }
                    }
                    else if (txtCategorieMalade.Text.Equals("Abonné") || txtCategorieMalade.Text == "")
                    {
                        if (Convert.ToDouble(txtMontant.Text) == 0)
                        {
                            //On effectue la vente pour l'abonné avec une dette totale ou pour le service
                            saveUpdate();
                        }
                    }
                    else throw new Exception("Le montant est invalide");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            montantMituel = 0;
            montantClient = 0;
            montantDu = 0;
            montantDette = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                try
                {
                    DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (bsrc.DataSource != null)
                        {
                            clssortie d = (clssortie)bsrc.Current;
                            new clssortie().delete(d);
                            MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.New();
                            refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                refresh();
            }
        }

        private void lblAddArticle_Click(object sender, EventArgs e)
        {
            ArticleFrm frm = new ArticleFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void cboArticle_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormArticle)
            {
                try
                {
                    cboArticle.DataSource = clsMetier.GetInstance().getAllClsarticle();
                }
                catch (Exception) { }
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();

                    //
                    try
                    {
                        //Recuperation de la valeur en stock du produit sélectionné dans le combobox des articles
                        txtStock.Text = ((clsarticle)cboArticle.SelectedItem).Stock.ToString();
                        txtPrix.Text = Math.Round((Convert.ToDouble(((clsarticle)cboArticle.SelectedItem).Pu)), 2).ToString(); ;
                        stockAlert = ((clsarticle)cboArticle.SelectedItem).Stock_alert;
                    }
                    catch (Exception) { }

                    lblArticleSorti.Text = cboArticle.Text;
                    try
                    {
                        if (Convert.ToDouble(txtStock.Text) == 0)
                        {
                            lblTexteStock.Text = "Le produit sélectioné est en rupture de stock";
                            ((Control)lblTexteStock).ForeColor = Color.FromArgb(255, 0, 0);
                        }
                        else if (Convert.ToDouble(txtStock.Text) >= 0 && Convert.ToDouble(txtStock.Text) <= stockAlert)
                        {
                            lblTexteStock.Text = "Le produit sélectioné a atteint le stock d'alert";
                            ((Control)lblTexteStock).ForeColor = Color.FromArgb(255, 121, 121);
                        }
                        else if (Convert.ToDouble(txtStock.Text) > stockAlert)
                        {
                            lblTexteStock.Text = "Le produit sélectioné est disponible en stock";
                            ((Control)lblTexteStock).ForeColor = Color.FromArgb(0, 153, 0);
                        }
                    }
                    catch (Exception) { }

                    txtQuantite.Text = ((clssortie)dgv.SelectedRows[0].DataBoundItem).Quantinte.ToString();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void cboArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de la valeur en stock du produit sélectionné dans le combobox des articles
                txtStock.Text = ((clsarticle)cboArticle.SelectedItem).Stock.ToString();
                txtPrix.Text = Math.Round((Convert.ToDouble(((clsarticle)cboArticle.SelectedItem).Pu)), 2).ToString(); ;
                stockAlert = ((clsarticle)cboArticle.SelectedItem).Stock_alert;
            }
            catch (Exception) { }

            try
            {
                if (Convert.ToDouble(txtStock.Text) == 0)
                {
                    lblTexteStock.Text = "Le produit sélectioné est en rupture de stock";
                    ((Control)lblTexteStock).ForeColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtStock.Text) >= 0 && Convert.ToDouble(txtStock.Text) <= stockAlert)
                {
                    lblTexteStock.Text = "Le produit sélectioné a atteint le stock d'alert";
                    ((Control)lblTexteStock).ForeColor = Color.FromArgb(255, 121, 121);
                }
                else if (Convert.ToDouble(txtStock.Text) > stockAlert)
                {
                    lblTexteStock.Text = "Le produit sélectioné est disponible en stock";
                    ((Control)lblTexteStock).ForeColor = Color.FromArgb(0, 153, 0);
                }
            }
            catch (Exception) { }
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtStock.Text) == 0) lblTexteStock.Text = "Le produit sélectioné est en rupture de stock";
                if (Convert.ToDouble(txtStock.Text) >= 0 && Convert.ToDouble(txtStock.Text) <= stockAlert) lblTexteStock.Text = "Le produit sélectioné a atteint le stock d'alert";//10
                else if (Convert.ToDouble(txtStock.Text) > stockAlert) lblTexteStock.Text = "Le produit sélectioné est disponible en stock";//15
            }
            catch (Exception) { }
        }

        private void txtQuantite_TextChanged(object sender, EventArgs e)
        {
            bool okService = false;
            try
            {
                if (txtCategorieMalade.Text.Equals("Abonné"))
                {
                    montantDu = Math.Round(Convert.ToDouble(txtPrix.Text) * Convert.ToDouble(txtQuantite.Text) * clsMetier.GetInstance().getClscategoriemalade1(sortieArticle.Id_malade).Taux, 2);
                    montantMituel = Math.Round(montantDu * (clsMetier.GetInstance().getClsetablissementpriseencharge(sortieArticle.Id_malade).Taux), 2);
                    montantClient = Math.Round(montantDu - montantMituel, 2);
                    lblMontantAPayer.Text = montantClient.ToString();
                    txtMontant.Text = montantClient.ToString();
                    lblMontantMituelle.Text = montantMituel.ToString();
                }
                else if (txtCategorieMalade.Text.Equals("Non abonné"))
                {
                    montantDu = Math.Round(Convert.ToDouble(txtPrix.Text) * Convert.ToDouble(txtQuantite.Text) * clsMetier.GetInstance().getClscategoriemalade1(sortieArticle.Id_malade).Taux, 2);
                    //montantDu = Math.Round(Convert.ToDouble(txtPrix.Text) * Convert.ToDouble(txtQuantite.Text) * clsMetier.GetInstance().getClscategoriemalade1(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id_malade).Taux, 2);
                    lblMontantAPayer.Text = montantDu.ToString();
                    txtMontant.Text = lblMontantAPayer.Text;
                    lblMontantMituelle.Text = "";
                }
                else
                {
                    montantDu = Math.Round((Convert.ToDouble(txtPrix.Text) * Convert.ToDouble(txtQuantite.Text)), 2);
                    lblMontantAPayer.Text = montantDu.ToString();
                    txtMontant.Text = lblMontantAPayer.Text;
                    lblMontantMituelle.Text = "";
                    okService = true;
                }
            }
            catch (Exception) { }

            try
            {
                if (!okService)
                {
                    if (Convert.ToDouble(txtMontant.Text) == montantClient) txtEtatpaiement.Text = "Payé";
                    //else if (Convert.ToDouble(txtMontant.Text) != montantClient) txtEtatpaiement.Text = "Non payé";
                    else if (Convert.ToDouble(txtMontant.Text) != montantClient) txtEtatpaiement.Text = "Payé";
                    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Abonné") && Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Payé";
                    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Non abonné") && Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Payé";
                    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Non abonné") && Convert.ToDouble(txtMontant.Text) == Convert.ToDouble(lblMontantAPayer.Text) || Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Abonné") && Convert.ToDouble(txtMontant.Text) == Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Payé";
                }
                else txtEtatpaiement.Text = "Non payé";
            }
            catch (Exception) { }
        }

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCategorieMalade.Text = clsMetier.GetInstance().getClscategoriemalade(((clsmalade)cboMalade.SelectedItem).Id_categoriemalade).Designation;
                lblNumeroMalade.Text = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade.SelectedItem).Id).Numero;
            }
            catch (Exception) { txtCategorieMalade.Clear(); lblNumeroMalade.Text = ""; }
        }

        private void txtMontant_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //if (Convert.ToDouble(txtMontant.Text) == montantClient) txtEtatpaiement.Text = "Payé";
            //else if (Convert.ToDouble(txtMontant.Text) != montantClient) txtEtatpaiement.Text = "Non payé";
            //    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Abonné") && Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Non payé";
            //    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Non abonné") && Convert.ToDouble(txtMontant.Text) < Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Non payé";
            //    else if (Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Non abonné") && Convert.ToDouble(txtMontant.Text) == Convert.ToDouble(lblMontantAPayer.Text) || Convert.ToDouble(txtMontant.Text) > 0 && txtCategorieMalade.Text.Equals("Abonné") && Convert.ToDouble(txtMontant.Text) == Convert.ToDouble(lblMontantAPayer.Text)) txtEtatpaiement.Text = "Payé";
            //}
            //catch (Exception) { }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0)
                {
                    lblArticleSorti.Text = cboArticle.Text;
                    //Recuperation du nom du aptitude pour la ligne en cours
                    lblNomMalade.Text = clsMetier.GetInstance().getClsmalade(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id_malade).Nom_complet;
                }
            }
            catch (Exception) { lblArticleSorti.Text = ""; }
        }

        private void chkAfficheAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfficheAll.Checked) txtDateSortie.Enabled = false;
            else txtDateSortie.Enabled = true;
        }
    }
}
