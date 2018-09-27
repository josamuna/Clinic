using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossierconsultationpostscolaire
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_tarifconsultationpostnatale;
        private string etatpaiement;
        private string designationComplete;
		
        //***Listes***
        public List<clsdossierconsultationpostscolaire> listes()
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationpostnatale();
        }
        public List<clsdossierconsultationpostscolaire> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationpostnatale(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossierconsultationpostnatale(this);
        }
        public int update(clsdossierconsultationpostscolaire varscls)
        {
            return clsMetier.GetInstance().updateClsdossierconsultationpostnatale(varscls);
        }
        public int delete(clsdossierconsultationpostscolaire varscls)
        {
            return clsMetier.GetInstance().deleteClsdossierconsultationpostnatale(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossierconsultationpostscolaire()
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
        //***Accesseur de id_malade***
        public int? Id_malade
        {

            get { return id_malade; }
            set { id_malade = value; }
        }
        //***Accesseur de id_tarifconsultation***
        public int? Id_tarifconsultationpostnatale
        {

            get { return id_tarifconsultationpostnatale; }
            set { id_tarifconsultationpostnatale = value; }
        }
        //***Accesseur de etatpaiement***
        public string Etatpaiement
        {

            get { return etatpaiement; }
            set { etatpaiement = value; }
        }

        public int? Id_agent
        {
            get { return id_agent; }
            set { id_agent = value; }
        }

        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }

        public override string ToString()
        {
            return DesignationComplete;
        }
    }
}
