using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsautrefraie 
{
  //***Les variables globales***
 private int   id ;
 private string designationComplete;
 //private int id_de_autrefraie;
 //private double quantite_de_detailsautrefraie;
 private int? id_etablissementexterne;
 private int? id_malade;
 private string numerofacture;
 private DateTime? datepaiement;
 private DateTime? dateenregistrement;
 private double? montant;
 private string etatpaiement;

  //***Listes***
  public List<clsautrefraie> listes(){
 return clsMetier.GetInstance().getAllClsautrefraie();
}
 public  List<clsautrefraie>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsautrefraie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsautrefraie(this);
 }
 public  int  update(clsautrefraie varscls){
 return clsMetier.GetInstance().updateClsautrefraie(varscls);
 }
 public  int  delete(clsautrefraie varscls){
 return clsMetier.GetInstance().deleteClsautrefraie(varscls);
 }
  //***Le constructeur par defaut***
  public    clsautrefraie() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
 //***Accesseur de designation***
 public string DesignationComplete
 {

     get { return designationComplete; }
     set { designationComplete = value; }
 }

 public override string ToString()
 {
     return DesignationComplete;
 }
 //***Accesseur de id_de_autrefraie***
 //public int Id_de_autrefraie
 //{
 //    get { return id_de_autrefraie; }
 //    set { id_de_autrefraie = value; }
 //}
 //***Accesseur de quantite_de_detailsautrefraie***
 //public double Quantite_de_detailsautrefraie
 //{
 //    get { return quantite_de_detailsautrefraie; }
 //    set { quantite_de_detailsautrefraie = value; }
 //}
 //***Accesseur de id_etablissementexterne***
 public int? Id_etablissementexterne
 {
     get { return id_etablissementexterne; }
     set { id_etablissementexterne = value; }
 }
 //***Accesseur de id_malade***
 public int? Id_malade
 {
     get { return id_malade; }
     set { id_malade = value; }
 }
 //***Accesseur de numerofacture***
 public string Numerofacture
 {
     get { return numerofacture; }
     set { numerofacture = value; }
 }
 //***Accesseur de datepaiement***
 public DateTime? Datepaiement
 {
     get { return datepaiement; }
     set { datepaiement = value; }
 }
 //***Accesseur de dateenregistrement***
 public DateTime? Dateenregistrement
 {
     get { return dateenregistrement; }
     set { dateenregistrement = value; }
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
