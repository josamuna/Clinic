﻿using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class VitamineFrm : Form
    {
        public VitamineFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsvitamine vitamine = new clsvitamine();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtDesignation.DataBindings.Add("Text", vitamine, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDesignation.DataBindings.Clear();
            txtDesignation.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void New()
        {
            vitamine = new clsvitamine();
            bln = false;
            bindingcls();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsvitamine();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    vitamine.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsvitamine s = (clsvitamine)bsrc.Current;
                        new clsvitamine().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des Vitamines sur le formulair des appelant
                clsDoTraitement.EnterForFormVitamine = true;
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
                        clsvitamine d = (clsvitamine)bsrc.Current;
                        new clsvitamine().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                    clsDoTraitement.EnterForFormVitamine = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmVitamine_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvVitamine.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void dgvVitamine_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVitamine.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }
    }
}
