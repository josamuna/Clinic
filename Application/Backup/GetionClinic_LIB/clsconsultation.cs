
using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB
{
    public class clsconsultation
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int id_agent;
        private int? id_malade;
        private int? id_tarifconsultation;
        private string etatpaiement;
        private string designationComplete;

        //***Listes***
        public List<clsconsultation> listes()
        {
            return clsMetier.GetInstance().getAllClsconsultation();
        }
        public List<clsconsultation> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsconsultation(criteria);
        }
        public int inserts()
        {
            return clsMetier.GetInstance().insertClsconsultation(this);
        }
        public int update(clsconsultation varscls)
        {
            return clsMetier.GetInstance().updateClsconsultation(varscls);
        }
        public int delete(clsconsultation varscls)
        {
            return clsMetier.GetInstance().deleteClsconsultation(varscls);
        }
        //***Le constructeur par defaut***
        public clsconsultation()
        {
        }

        //***Accesseur de id***
        public int Id
        {

            get { return id; }
            set { id = value; }
        }
        //***Accesseur de date***
        public DateTime? Date
        {

            get { return date; }
            set { date = value; }
        }
        //***Accesseur de id_agent***
        public int Id_agent
        {

            get { return id_agent; }
            set { id_agent = value; }
        }
        //***Accesseur de id_malade***
        public int? Id_malade
        {

            get { return id_malade; }
            set { id_malade = value; }
        }
        //***Accesseur de id_tarifconsultation***
        public int? Id_tarifconsultation
        {

            get { return id_tarifconsultation; }
            set { id_tarifconsultation = value; }
        }
        //***Accesseur de etatpaiement***
        public string Etatpaiement
        {

            get { return etatpaiement; }
            set { etatpaiement = value; }
        }
        public override string ToString()
        {
            return DesignationComplete;
        }

        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }
    } //***fin class

} //***fin namespace
