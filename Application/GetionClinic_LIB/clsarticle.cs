using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsarticle 
{
  //***Les variables globales***
 private int   id ;
 private string   desination ;
 private string designationComplete;
 private double?  pu ;
 private string   caracteristique ;
 private double?   stock ;
 private int id_de_sortie;
 private double quantite_de_sortie;
 private int stock_alert;
 private bool fiche_supplementaire;

  //***Listes***
  public List<clsarticle> listes(){
 return clsMetier.GetInstance().getAllClsarticle();
}
 public  List<clsarticle>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsarticle(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsarticle(this);
 }
 public  int  update(clsarticle varscls){
 return clsMetier.GetInstance().updateClsarticle(varscls);
 }
 public  int  delete(clsarticle varscls){
 return clsMetier.GetInstance().deleteClsarticle(varscls);
 }
  //***Le constructeur par defaut***
  public    clsarticle() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de desination***
 public  string   Desination {

get { return desination; } 
set { desination = value; }
}

 //***Accesseur de designation***
 public string DesignationComplete
 {

     get { return designationComplete; }
     set { designationComplete = value; }
 }
  //***Accesseur de pu***
 public  double ?   Pu {

get { return pu; } 
set { pu = value; }
}
  //***Accesseur de caracteristique***
 public  string   Caracteristique {

get { return caracteristique; } 
set { caracteristique = value; }
}
  //***Accesseur de stock***
 public  double?   Stock {

get { return stock; } 
set { stock = value; }
}
 public override string ToString()
 {
     return DesignationComplete;
 }
 //***Accesseur de id_de_autrefraie***
 public int Id_de_sortie
 {
     get { return id_de_sortie; }
     set { id_de_sortie = value; }
 }
 //***Accesseur de montant_de_sortie***
 public double Quantite_de_sortie
 {
     get { return quantite_de_sortie; }
     set { quantite_de_sortie = value; }
 }
 //***Accesseur de nom_classe***
 public string Nom_classe
 {
     get { return "clsarticle"; }
 }
 //***Accesseur de stock_alert***
 public int Stock_alert
 {
     get { return stock_alert; }
     set { stock_alert = value; }
 }
 //***Accesseur de stock_alert***
 public bool Fiche_supplementaire
 {
     get { return fiche_supplementaire; }
     set { fiche_supplementaire = value; }
 }
} //***fin class

} //***fin namespace
