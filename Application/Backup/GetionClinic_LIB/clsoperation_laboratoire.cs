
using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB
{
    public class clsoperation_laboratoire
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private int id_malade;
        private int id_examen;
        private string etatpaiement;
        private DateTime? date;
        private string designationComplete;
        private double prix_de_laboratoire;


        //***Listes***
        public List<clsoperation_laboratoire> listes()
        {
            return clsMetier.GetInstance().getAllClsoperation_laboratoire();
        }
        public List<clsoperation_laboratoire> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsoperation_laboratoire(criteria);
        }
        public int inserts()
        {
            return clsMetier.GetInstance().insertClsoperation_laboratoire(this);
        }
        public int update(clsoperation_laboratoire varscls)
        {
            return clsMetier.GetInstance().updateClsoperation_laboratoire(varscls);
        }
        public int delete(clsoperation_laboratoire varscls)
        {
            return clsMetier.GetInstance().deleteClsoperation_laboratoire(varscls);
        }
        //***Le constructeur par defaut***
        public clsoperation_laboratoire()
        {
        }

        //***Accesseur de id***
        public int Id
        {

            get { return id; }
            set { id = value; }
        }
        //***Accesseur de id_malade***
        public int Id_malade
        {

            get { return id_malade; }
            set { id_malade = value; }
        }
        //***Accesseur de date***
        public DateTime? Date
        {

            get { return date; }
            set { date = value; }
        }
        //***Accesseur de Id_examen***
        public int Id_examen
        {
            get { return id_examen; }
            set { id_examen = value; }
        }
        //***Accesseur de Etatpaiement***
        public string Etatpaiement
        {
            get { return etatpaiement; }
            set { etatpaiement = value; }
        }
        //***Accesseur de designationComplete***
        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }
        public override string ToString()
        {
            return DesignationComplete;
        }
        //***Accesseur de prix_laboratoire***
        public double Prix_de_laboratoire
        {
            get { return prix_de_laboratoire; }
            set { prix_de_laboratoire = value; }
        }
    } //***fin class

} //***fin namespace
