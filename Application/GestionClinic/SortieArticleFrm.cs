using System;
using System.Windows.Forms;
using GestionClinic_LIB;
using System.Drawing;

namespace GestionClinic_WIN
{
    public partial class SortieArticleFrm : Form
    {
        public SortieArticleFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clssortie sortieArticle = new clssortie();
        clssortiecancel sortieArticle2 = new clssortiecancel();
        private BindingSource bsrc = new BindingSource();
        private BindingSource bsrc2 = new BindingSource();
        private BindingSource bsrc3 = new BindingSource();

        private bool bln = false;
        private int niveauUser = -1;
        int stockAlert = 0;
        int stockAlert2 = 0;
        bool isPharmacien = false;
        bool doUpdate = false;

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
            Control[] tbcontrols = { txtDate, cboArticle, cboService, cboMalade, txtQuantite, txtEtatpaiement, chkChoix };
            clearforbinding(tbcontrols);

            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtEtatpaiement, "Etatpaiement", 0);
            setbindingcls(cboArticle, "Id_article", 1);
            setbindingcls(cboService, "Id_service", 1);
            setbindingcls(cboMalade, "Id_malade", 1);
            setbindingcls(txtQuantite, "Quantinte", 0);
            setbindingcls(chkChoix, "Sortiemalade", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, cboArticle, cboService, cboMalade, txtQuantite, txtEtatpaiement, chkChoix, txtMontant };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtEtatpaiement, "Etatpaiement", 0);
            setbindinglst(cboArticle, "Id_article", 1);
            setbindinglst(cboService, "Id_service", 1);
            setbindinglst(cboMalade, "Id_malade", 1);
            setbindinglst(txtQuantite, "Quantinte", 0);
            setbindinglst(chkChoix, "Sortiemalade", 0);
            setbindinglst(txtMontant, "Montant", 0);

            try
            {
                //Recuperation de la valeur de la quantite affiche pour probable modification du stock
                clsDoTraitement.oldValueStockModifie = Convert.ToDouble(txtQuantite.Text);
            }
            catch (Exception) { }
        }

        private void clearforbinding2(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls2(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", sortieArticle2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", sortieArticle2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", sortieArticle2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", sortieArticle2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst2(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls2()
        {
            Control[] tbcontrols = { txtDate2, cboArticle2, txtService2, cboMalade2, txtQuantite2, txtEtatpaiement2, txtChoix2, txtId_sortie2 };
            clearforbinding2(tbcontrols);

            setbindingcls2(txtDate2, "Date", 0);
            setbindingcls2(txtEtatpaiement2, "Etatpaiement", 0);
            setbindingcls2(cboArticle2, "Id_article", 1);
            setbindingcls2(txtService2, "Id_service", 0);
            setbindingcls2(cboMalade2, "Id_malade", 1);
            setbindingcls2(txtQuantite2, "Quantinte", 0);
            setbindingcls2(txtChoix2, "Sortiemalade", 0);
            setbindingcls2(txtId_sortie2, "Id_sortie", 0);
            //setbindingcls2(txtStock2, "Stock_in", 0);
        }

        private void bindignlst2()
        {
            //btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate2, cboArticle2, txtService2, cboMalade2, txtQuantite2, txtEtatpaiement2, txtChoix2, txtMontant2, txtId_sortie2 };
            clearforbinding2(tbcontrols);

            setbindinglst2(txtDate2, "Date", 0);
            setbindinglst2(txtEtatpaiement2, "Etatpaiement", 0);
            setbindinglst2(cboArticle2, "Id_article", 1);
            setbindinglst2(txtService2, "Id_service", 1);
            setbindinglst2(cboMalade2, "Id_malade", 1);
            setbindinglst2(txtQuantite2, "Quantinte", 0);
            setbindinglst2(txtChoix2, "Sortiemalade", 0);
            setbindinglst2(txtMontant2, "Montant", 0);
            setbindinglst2(txtId_sortie2, "Id_sortie", 0);
        }
        #endregion END BINDING

        #region NEW ET REFRESH

        private void New()
        {
            sortieArticle = new clssortie();
            bln = false;
            bindingcls();
            txtEtatpaiement.Text = "Non payé";
            if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
            if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
            //btnSave.Enabled = true;
        }

        private void refresh()
        {
            try
            {
                bindingcls();
                if (!chkAfficheAll.Checked)
                {
                    //On affiche toutes les sorties pour la date du jour : Today
                    if (doUpdate) bsrc.DataSource = clsMetier.GetInstance().getAllClssortie2(clsMetier.dateMAJSortie.ToString().Substring(0, 10));
                    else bsrc.DataSource = clsMetier.GetInstance().getAllClssortie2(txtDateSortie.Value.ToString().Substring(0, 10));
                }
                else
                {
                    //On affiche toutes les sorties sans exception
                    bsrc.DataSource = clsMetier.GetInstance().getAllClssortie();
                }

                doUpdate = false;
                cboArticle.DataSource = clsMetier.GetInstance().getAllClsarticle();
                setMembersallcbo(cboArticle, "Desination", "Id");
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "id");
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
                setMembersallcbo(cboMalade, "Nom_complet", "Id");

                if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
                if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
                chkChoix.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refresh2()
        {
            try
            {
                cboArticle2.DataSource = clsMetier.GetInstance().getAllClsarticle();
                setMembersallcbo(cboArticle2, "Desination", "Id");
                cboMalade2.DataSource = clsMetier.GetInstance().getAllClsmalade();
                setMembersallcbo(cboMalade2, "Nom_complet", "Id");

                if (cboArticle2.Items.Count > 0) cboArticle2.SelectedIndex = 0;
                if (cboMalade2.Items.Count > 0) cboMalade2.SelectedIndex = 0;

                bsrc2.DataSource = clsMetier.GetInstance().getAllClssortiecancelforNull();
                dgv2.DataSource = bsrc2;
                txtQuantiteRetour2.Clear();
                txtQuantiteRetour2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


        public void enabledItem(bool etat)
        {
            btnDelete.Enabled = etat;
            btnSave.Enabled = etat;
            btnAdd.Enabled = etat;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void enabledPharmacien(bool validate)
        {
            gp1.Enabled = validate;
            gp2.Enabled = validate;
            isPharmacien = validate;
        }

        private void FrmSortieArticle_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc, bsrc2 };
                DataGridView[] dg = { dgv, dgv2 };
                ComboBox[] cbo = { cboArticle, cboArticle2 };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                try
                {
                    New();
                    foreach (string str_groupe in clsDoTraitement.valueUser)
                    {
                        if (str_groupe.Equals("Service"))
                        {
                            chkChoix.Checked = false;
                            chkChoix_CheckedChanged(sender, e);
                            if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            chkChoix.Checked = true;
                            chkChoix_CheckedChanged(sender, e);
                        }
                    }
                }
                catch (Exception) { btnSave.Enabled = false; }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                try
                {
                    if (!bln)
                    {
                        //Affectation du montant
                        if (!cboService.Text.Equals("") && chkChoix.Checked == false) sortieArticle.Montant = Math.Round(((double)((clsarticle)cboArticle.SelectedItem).Pu) * Convert.ToDouble(sortieArticle.Quantinte), 2);
                        else if (!cboMalade.Text.Equals("") && chkChoix.Checked == true) sortieArticle.Montant = 0;
                        sortieArticle.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (bsrc.DataSource != null)
                        {
                            clssortie s = (clssortie)bsrc.Current;
                            new clssortie().update(s);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    doUpdate = true;
                    this.New();
                    refresh();
                    chkChoix.Checked = true;
                    chkChoix_CheckedChanged(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Il n'a rien à afficher", "Message clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
                //Sortie externe
                //try
                //{
                //    DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (result == DialogResult.Yes)
                //    {
                //        if (bsrc1.DataSource != null)
                //        {
                //            clssortieexterne d = (clssortieexterne)bsrc1.Current;
                //            new clssortieexterne().delete(d);
                //            MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            this.New1();
                //            refresh1();
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //Sortie simple
                refresh();
                chkChoix_CheckedChanged(sender, e);
                cboService.SelectedIndex = -1;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Il n'a rien à afficher", "Message clinic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
                //Sortie externe
                //refresh1();
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
                    bln = true;

                    //if (niveauUser == 1) this.enabledItem(false);
                    //else this.enabledItem(true);
                    lblArticleSorti.Text = cboArticle.Text;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); lblArticleSorti.Text = ""; }
        }

        private void chkChoix_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChoix.Checked)
            {
                cboMalade.Enabled = true;
                cboService.SelectedIndex = -1;
                cboService.Enabled = false;
            }
            else if (chkChoix.Checked == false)
            {
                cboService.Enabled = true;
                cboMalade.SelectedIndex = -1;
                cboMalade.Enabled = false;
            }
        }

        private void cboArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de la valeur en stock du produit sélectionné dans le combobox des articles
                txtStock.Text = ((clsarticle)cboArticle.SelectedItem).Stock.ToString();
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

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCategorieMalade.Text = clsMetier.GetInstance().getClscategoriemalade(((clsmalade)cboMalade.SelectedItem).Id_categoriemalade).Designation;
                lblNumeroMalade.Text = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade.SelectedItem).Id).Numero;
            }
            catch (Exception) { txtCategorieMalade.Clear(); lblNumeroMalade.Text = ""; }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (niveauUser == 3) this.enabledItem(false);
            else this.enabledItem(true);

            try
            {
                if (dgv.RowCount > 0)
                {
                    lblArticleSorti.Text = cboArticle.Text;
                    //Recuperation du nom du malade pour la ligne en cours
                    lblNomMalade.Text = clsMetier.GetInstance().getClsmalade(((clssortie)dgv.SelectedRows[0].DataBoundItem).Id_malade).Nom_complet;
                }
            }
            catch (Exception) { lblArticleSorti.Text = ""; }
        }

        private void FrmSortieArticle_Load(object sender, EventArgs e)
        {
            chkAfficheAll.Checked = false;
            txtDateSortie.Enabled = true;
            chkAfficheAllService.Checked = false;

            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();

                bindingcls2();
                refresh2();

                //bool ok1 = true, ok2 = true, ok3 = true, ok4 = true, ok5 = true, ok6 = true;
                //foreach (string str_groupe in clsDoTraitement.valueUser)
                //{
                //    if (str_groupe.Equals("Administrateur"))
                //    {
                //        this.enabledItem(true);
                //        break;
                //    }
                //    else if (str_groupe.Equals("Médecin") && ok1)
                //    {
                //        this.enabledItem(false);
                //        ok1 = false;
                //    }
                //    else if (str_groupe.Equals("Infirmier") && ok2)
                //    {
                //        this.enabledItem(false);
                //        ok2 = false;
                //    }
                //    else if (str_groupe.Equals("Laborantin") && ok3)
                //    {
                //        this.enabledItem(false);
                //        ok2 = false;
                //    }
                //    else if (str_groupe.Equals("Pharmacien"))
                //    {
                //        this.enabledItem(true);
                //        break;
                //    }
                //    else if (str_groupe.Equals("Caissier") && ok4)
                //    {
                //        this.enabledItem(false);
                //        ok4 = false;
                //    }
                //    else if (str_groupe.Equals("Médecin gynéco.") && ok5)
                //    {
                //        this.enabledItem(false);
                //        ok5 = false;
                //    }
                //    else if (str_groupe.Equals("Service") && ok6)
                //    {
                //        this.enabledItem(false);
                //        ok6 = false;
                //    }
                //}
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes des sorties, rassurez vous que vous êtes connecté en tant qu'agent", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            chkChoix_CheckedChanged(sender, e);
            cboService.SelectedIndex = -1;
            chkChoix.Checked = true;
            //btnDelete.Enabled = false;
            //btnSave.Enabled = false;
        }

        private void cmdAfficherData_Click(object sender, EventArgs e)
        {
            try
            {
                //Réinitialisation de la valeur du stock contenu dans le chanp concerné
                txtStock2.Clear();

                bindingcls2();
                bsrc2.DataSource = clsMetier.GetInstance().getAllClssortiecancel(((clsmalade)cboMalade2.SelectedItem).Id, txtDate2.Text.Substring(0, 10));
                dgv2.DataSource = bsrc2;
            }
            catch (Exception) { MessageBox.Show("Erreur lors de l'affichage des informations relatives à une sortie d'un malade", "Erreur d'affichage information de la sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                try
                {
                    //Sortie simple
                    refresh();
                    chkChoix_CheckedChanged(sender, e);
                    cboService.SelectedIndex = -1;
                }
                catch (Exception) { }
                btnRefreh.Enabled = true;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                cmdValiderRetourStk.Enabled = false;
                cboArticle2.Enabled = false;
                txtQuantite2.Enabled = false;
                //Si l'utilisateur est un pharmacien on active l'ongle de remise des articles
                bool ok1 = true, ok2 = true, ok3 = true, ok4 = true, ok5 = true, ok6 = true;
                foreach (string str_groupe in clsDoTraitement.valueUser)
                {
                    if (str_groupe.Equals("Administrateur"))
                    {
                        this.enabledPharmacien(true);
                        break;
                    }
                    else if (str_groupe.Equals("Médecin") && ok1)
                    {
                        this.enabledPharmacien(false);
                        ok1 = false;
                    }
                    else if (str_groupe.Equals("Infirmier") && ok2)
                    {
                        this.enabledPharmacien(false);
                        ok2 = false;
                    }
                    else if (str_groupe.Equals("Laborantin") && ok3)
                    {
                        this.enabledPharmacien(false);
                        ok2 = false;
                    }
                    else if (str_groupe.Equals("Pharmacien"))
                    {
                        this.enabledPharmacien(true);
                        break;
                    }
                    else if (str_groupe.Equals("Caissier") && ok4)
                    {
                        this.enabledPharmacien(false);
                        ok4 = false;
                    }
                    else if (str_groupe.Equals("Médecin gynéco.") && ok5)
                    {
                        this.enabledPharmacien(false);
                        ok5 = false;
                    }
                    else if (str_groupe.Equals("Service") && ok6)
                    {
                        this.enabledPharmacien(false);
                        ok6 = false;
                    }
                }

                if (cboMalade2.Items.Count > 0) cboMalade2.SelectedIndex = 0;

                //try
                //{
                //    bindingcls2();

                //    refresh2();

                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnRefreh.Enabled = false;
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Erreur lors de l'affichage des des informations relatives à une sortie d'un malade", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                chkAfficheAllService.Checked = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnRefreh.Enabled = false;
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            refresh2();
        }

        private void cboArticle2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de la valeur en stock du produit sélectionné dans le combobox des articles
                txtStock2.Text = ((clsarticle)cboArticle2.SelectedItem).Stock.ToString();
                stockAlert2 = ((clsarticle)cboArticle2.SelectedItem).Stock_alert;
            }
            catch (Exception) { }

            try
            {
                if (Convert.ToDouble(txtStock2.Text) == 0)
                {
                    lblTexteStock2.Text = "Le produit sélectioné est en rupture de stock";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtStock2.Text) >= 0 && Convert.ToDouble(txtStock2.Text) <= stockAlert2)
                {
                    lblTexteStock2.Text = "Le produit sélectioné a atteint le stock d'alert";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(255, 121, 121);
                }
                else if (Convert.ToDouble(txtStock2.Text) > stockAlert2)
                {
                    lblTexteStock2.Text = "Le produit sélectioné est disponible en stock";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(0, 153, 0);
                }
            }
            catch (Exception) { }
        }

        private void cboMalade2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCategorieMalade2.Text = clsMetier.GetInstance().getClscategoriemalade(((clsmalade)cboMalade2.SelectedItem).Id_categoriemalade).Designation;
                lblNumeroMalade2.Text = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade2.SelectedItem).Id).Numero;
            }
            catch (Exception) { txtCategorieMalade2.Clear(); lblNumeroMalade2.Text = ""; }
        }

        private void txtStock2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtStock2.Text) == 0)
                {
                    lblTexteStock2.Text = "Le produit sélectioné est en rupture de stock";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtStock2.Text) >= 0 && Convert.ToDouble(txtStock2.Text) <= stockAlert2)
                {
                    lblTexteStock2.Text = "Le produit sélectioné a atteint le stock d'alert";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(255, 121, 121);
                }
                else if (Convert.ToDouble(txtStock2.Text) > stockAlert2)
                {
                    lblTexteStock2.Text = "Le produit sélectioné est disponible en stock";
                    ((Control)lblTexteStock2).ForeColor = Color.FromArgb(0, 153, 0);
                }
            }
            catch (Exception) { }
        }

        private void cmdValiderRetourStk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuantiteRetour2.Text)) clsDoTraitement.quantinteretour = null;
                else clsDoTraitement.quantinteretour = Convert.ToInt32(txtQuantiteRetour2.Text.Trim());
                clsMetier.GetInstance().validateRetourArticle(((clssortiecancel)(dgv2.SelectedRows[0].DataBoundItem)).Id_sortie);

                //Réinitialisation de la variable contenant la quantité à retourner
                clsDoTraitement.quantinteretour = null;
                //Réinitialisation de la valeur du stock contenu dans le chanp concerné
                txtStock2.Clear();

                MessageBox.Show("Retour en stock effectué avec succès", "Retour en stock", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualisation de l'affichage du DataGrid de sortiecancel
                try
                {
                    bindingcls2();
                    bsrc2.DataSource = clsMetier.GetInstance().getAllClssortiecancel(((clsmalade)cboMalade2.SelectedItem).Id, txtDate2.Text.Substring(0, 10));
                    dgv2.DataSource = bsrc2;
                }
                catch (Exception ex) { MessageBox.Show("Erreur lors de l'affichage des informations relatives à une sortie d'un malade, " + ex.Message, "Erreur d'affichage information de la sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                //Actualisation affichage stock et messages y relatif
                cboArticle2_SelectedIndexChanged(sender, e);

                txtQuantiteRetour2.Clear();
            }
            catch (Exception ex1)
            {
                clsDoTraitement.quantinteretour = null;
                MessageBox.Show("Erreur lors de la validation du retour en stock, " + ex1.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    bindignlst2();
                    txtStock2.Text = dgv2["colstock_in2", dgv2.CurrentRow.Index].Value.ToString();
                    cmdValiderRetourStk.Enabled = true;
                    txtQuantiteRetour2.Focus();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); lblArticleSorti.Text = ""; }
        }

        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                cmdValiderRetourStk.Enabled = true;
                txtQuantiteRetour2.Focus();
            }
        }

        private void chkAfficheAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfficheAll.Checked) txtDateSortie.Enabled = false;
            else txtDateSortie.Enabled = true;
        }

        private void chkAfficheAllService_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfficheAllService.Checked) txtDateService.Enabled = false;
            else txtDateService.Enabled = true;
        }

        private void btnAfficheService_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkAfficheAllService.Checked)
                {
                    //On affiche toutes les sorties des services pour la date du jour : Today
                    bsrc3.DataSource = clsMetier.GetInstance().getAllClssortie_Service(txtDateService.Value.ToString().Substring(0, 10));
                    dgvService.DataSource = bsrc3;
                }
                else
                {
                    //On affiche toutes les sorties des services sans exception
                    bsrc3.DataSource = clsMetier.GetInstance().getAllClssortie_Service();
                    dgvService.DataSource = bsrc3;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'affichage des sorties pour les services", "Sorties pour service", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
