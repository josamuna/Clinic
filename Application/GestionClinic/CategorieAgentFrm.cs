﻿using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class CategorieAgentFrm : Form
    {
        public CategorieAgentFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clscategorieagent catAgent = new clscategorieagent();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtDesignation.DataBindings.Add("Text", catAgent, "Designation", true,DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDesignation.DataBindings.Clear();
            txtDesignation.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            catAgent = new clscategorieagent();
            bln = false;
            bindingcls();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClscategorieagent();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    catAgent.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clscategorieagent s = (clscategorieagent)bsrc.Current;
                        new clscategorieagent().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des catégories des agent sur le formulaire appelant
                clsDoTraitement.EnterForFormCategorieAgent = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refresh();
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
                        clscategorieagent d = (clscategorieagent)bsrc.Current;
                        new clscategorieagent().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des catégories des agents sur le formulair appelant
                    clsDoTraitement.EnterForFormCategorieAgent = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void FrmCategorieAgent_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
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

        private void FrmCategorieAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
