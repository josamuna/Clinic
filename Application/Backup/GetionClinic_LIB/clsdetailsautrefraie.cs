using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsdetailsautrefraie 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private string designationComplete;
 private double?  prix ;
 //private int id_de_autrefraie;
 private int? quantinte;
 private double quantite_de_detailsautrefraie;
 private int id_autrefraie;

  //***Listes***
  public List<clsdetailsautrefraie> listes(){
 return clsMetier.GetInstance().getAllClsdetailsautrefraie();
}
 public  List<clsdetailsautrefraie>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsdetailsautrefraie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsdetailsautrefraie(this);
 }
 public  int  update(clsdetailsautrefraie varscls){
 return clsMetier.GetInstance().updateClsdetailsautrefraie(varscls);
 }
 public  int  delete(clsdetailsautrefraie varscls){
 return clsMetier.GetInstance().deleteClsdetailsautrefraie(varscls);
 }
  //***Le constructeur par defaut***
  public    clsdetailsautrefraie() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de designation***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}
 //***Accesseur de designation***
 public string DesignationComplete
 {

     get { return designationComplete; }
     set { designationComplete = value; }
 }
  //***Accesseur de prix***
 public  double ?   Prix {

get { return prix; } 
set { prix = value; }
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
 //***Accesseur de quantinte***
 public int? Quantinte
 {
     get { return quantinte; }
     set { quantinte = value; }
 }
 //***Accesseur de quantite_de_detailsautrefraie***
 public double Quantite_de_detailsautrefraie
 {
     get { return quantite_de_detailsautrefraie; }
     set { quantite_de_detailsautrefraie = value; }
 }
 //***Accesseur de id_autrefraie***
 public int Id_autrefraie
 {
     get { return id_autrefraie; }
     set { id_autrefraie = value; }
 }
} //***fin class

} //***fin namespace
