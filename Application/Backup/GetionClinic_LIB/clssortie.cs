
using System;
using System.Data;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clssortie 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private int   id_article ;
 private int? id_service;
 private int? id_malade;
 private DateTime?  date ;
 private int?  quantinte ;
 private double? montant;
 private string etatpaiement;
 private bool sortiemalade;
 private int stock_in;
 private string designation;

  //***Listes***
  public List<clssortie> listes(){
 return clsMetier.GetInstance().getAllClssortie();
}
 public  List<clssortie>   listes(string criteria){
 return clsMetier.GetInstance().getAllClssortie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClssortie(this);
 }
 public int insertion(){
     return clsMetier.GetInstance().insertClssortieFiche(this);
 }
 public  int  update(clssortie varscls){
 return clsMetier.GetInstance().updateClssortie(varscls);
 }
 public int updatage(clssortie varscls){
     return clsMetier.GetInstance().updateClssortieFiche(varscls);
 }
 public  int  delete(clssortie varscls){
 return clsMetier.GetInstance().deleteClssortie(varscls);
 }
  //***Le constructeur par defaut***
  public    clssortie() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_article***
 public  int   Id_article {

get { return id_article; } 
set { id_article = value; }
}
  //***Accesseur de id_service***
 public  int ?   Id_service {

get { return id_service; } 
set { id_service = value; }
}
 //***Accesseur de id_malade***
 public int? Id_malade
 {
     get { return id_malade; }
     set { id_malade = value; }
 }
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de quantinte***
 public  int ?   Quantinte {

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
 //***Accesseur de sortiemalade***
 public bool Sortiemalade
 {
     get { return sortiemalade; }
     set { sortiemalade = value; }
 }
 //***Accesseur de stock_in***
 public int Stock_in
 {
     get { return stock_in; }
     set { stock_in = value; }
 }
 //***Accesseur de designation***
 public string Designation
 {
     get { return designation; }
     set { designation = value; }
 }
 //***Accesseur de total_montant***
} //***fin class

} //***fin namespace
