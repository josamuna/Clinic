using System;
using System.Collections.Generic;

namespace GestionClinic_LIB
{
    public class clsconsultation_fiche
    {
        //***Les variables globales***
        private int id;
        private int? id_malade;
        private int? id_rendezvous;
        private int? id_suivicroissance;
        private int? id_vaccination;
        private DateTime? date_consultaion;
        private bool? dort_sous_moust;
        //***Listes***
        public List<clsconsultation_fiche> listes()
        {
            return clsMetier.GetInstance().getAllClsconsultation_fiche();
        }
        public List<clsconsultation_fiche> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsconsultation_fiche(criteria);
        }
        public int inserts()
        {
            return clsMetier.GetInstance().insertClsconsultation_fiche(this);
        }
        public int update(clsconsultation_fiche varscls)
        {
            return clsMetier.GetInstance().updateClsconsultation_fiche(varscls);
        }
        public int delete(clsconsultation_fiche varscls)
        {
            return clsMetier.GetInstance().deleteClsconsultation_fiche(varscls);
        }
        //***Le constructeur par defaut***
        public clsconsultation_fiche()
        {
        }

        //***Accesseur de id***
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        //***Accesseur de id_malade***
        public int? Id_malade
        {
            get { return id_malade; }
            set { id_malade = value; }
        }
        //***Accesseur de id_rendezvous***
        public int? Id_rendezvous
        {
            get { return id_rendezvous; }
            set { id_rendezvous = value; }
        }
        //***Accesseur de id_suivicroissance***
        public int? Id_suivicroissance
        {
            get { return id_suivicroissance; }
            set { id_suivicroissance = value; }
        }
        //***Accesseur de id_vaccination***
        public int? Id_vaccination
        {

            get { return id_vaccination; }
            set { id_vaccination = value; }
        }
        //***Accesseur de date_consultaion***
        public DateTime? Date_consultaion
        {

            get { return date_consultaion; }
            set { date_consultaion = value; }
        }
        //***Accesseur de dort_sous_moust***
        public bool? Dort_sous_moust
        {
            get { return dort_sous_moust; }
            set { dort_sous_moust = value; }
        }

    } //***fin class

} //***fin namespace
