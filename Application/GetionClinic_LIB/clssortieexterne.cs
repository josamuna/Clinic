
using System;
using System.Data;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clssortieexterne 
{
    //***Les variables globales***
    //****private string schaine_conn*****
    private int id;
    private int id_autrefraie;
    private int? id_malade;
    private DateTime? date;
    private int? quantinte;
    private double? montant;
    private string etatpaiement;

    //***Listes***
    public List<clssortieexterne> listes()
    {
        return clsMetier.GetInstance().getAllClssortieexterne();
    }
    public List<clssortieexterne> listes(string criteria)
    {
        return clsMetier.GetInstance().getAllClssortieexterne(criteria);
    }
    public int inserts()
    {
        return clsMetier.GetInstance().insertClssortieexterne(this);
    }
    public int update(clssortieexterne varscls)
    {
        return clsMetier.GetInstance().updateClssortieexterne(varscls);
    }
    public int delete(clssortieexterne varscls)
    {
        return clsMetier.GetInstance().deleteClssortieexterne(varscls);
    }
    //***Le constructeur par defaut***
    public clssortieexterne()
    {
    }

    //***Accesseur de id***
    public int Id
    {

        get { return id; }
        set { id = value; }
    }
    //***Accesseur de id_autrefraie***
    public int Id_autrefraie
    {

        get { return id_autrefraie; }
        set { id_autrefraie = value; }
    }

    //***Accesseur de id_malade***
    public int? Id_malade
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
    //***Accesseur de quantinte***
    public int? Quantinte
    {

        get { return quantinte; }
        set { quantinte = value; }
    }
    //***Accesseur de montant***
    public double? Montant
    {
        get { return montant; }
        set { montant = value; }
    }
    //***Accesseur de etatpaiement***
    public string Etatpaiement
    {
        get { return etatpaiement; }
        set { etatpaiement = value; }
    }
} //***fin class

} //***fin namespace
