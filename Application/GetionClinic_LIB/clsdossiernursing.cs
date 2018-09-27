using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossiernursing
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_tarifnursing;
        private string etatpaiement;
        private string designationComplete;

        //***Listes***
        public List<clsdossiernursing> listes()
        {
            return clsMetier.GetInstance().getAllClsdossiernursing();
        }
        public List<clsdossiernursing> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossiernursing(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossiernursing(this);
        }
        public int update(clsdossiernursing varscls)
        {
            return clsMetier.GetInstance().updateClsdossiernursing(varscls);
        }
        public int delete(clsdossiernursing varscls)
        {
            return clsMetier.GetInstance().deleteClsdossiernursing(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossiernursing()
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
        //***Accesseur de id_tarifnursing***
        public int? Id_tarifnursing
        {

            get { return id_tarifnursing; }
            set { id_tarifnursing = value; }
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
