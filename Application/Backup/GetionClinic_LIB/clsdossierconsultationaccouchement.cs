using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossierconsultationaccouchement
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_typeaccouchement;
        private string etatpaiement;
        private string designationComplete;
        private string designationComplete1;

        //***Listes***
        public List<clsdossierconsultationaccouchement> listes()
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationaccouchement();
        }
        public List<clsdossierconsultationaccouchement> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationaccouchement(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossierconsultationaccouchement(this);
        }
        public int update(clsdossierconsultationaccouchement varscls)
        {
            return clsMetier.GetInstance().updateClsdossierconsultationaccouchement(varscls);
        }
        public int delete(clsdossierconsultationaccouchement varscls)
        {
            return clsMetier.GetInstance().deleteClsdossierconsultationaccouchement(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossierconsultationaccouchement()
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
        //***Accesseur de id_typeaccouchement***
        public int? Id_typeaccouchement
        {

            get { return id_typeaccouchement; }
            set { id_typeaccouchement = value; }
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

        public override string ToString()
        {
            return DesignationComplete1.ToString();
        }

        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }

        public string DesignationComplete1
        {
            get { return designationComplete1; }
            set { designationComplete1 = value; }
        }
    }
}
