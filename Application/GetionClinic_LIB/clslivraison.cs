using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clslivraison 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  date ;
 private int?  quantinte ;
 private double?  puachat ;
 private DateTime?  dateexpiration ;
 private int   id_fournisseur ;
 private int   id_article ;
 private int id_conditionnement;
 private int stock_out;
 private string designation;

  //***Listes***
  public List<clslivraison> listes(){
 return clsMetier.GetInstance().getAllClslivraison();
}
 public  List<clslivraison>   listes(string criteria){
 return clsMetier.GetInstance().getAllClslivraison(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClslivraison(this);
 }
 public  int  update(clslivraison varscls){
 return clsMetier.GetInstance().updateClslivraison(varscls);
 }
 public  int  delete(clslivraison varscls){
 return clsMetier.GetInstance().deleteClslivraison(varscls);
 }
  //***Le constructeur par defaut***
  public    clslivraison() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
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
  //***Accesseur de puachat***
 public  double ?   Puachat {

get { return puachat; } 
set { puachat = value; }
}
  //***Accesseur de dateexpiration***
 public  DateTime ?   Dateexpiration {

get { return dateexpiration; } 
set { dateexpiration = value; }
}
  //***Accesseur de id_fournisseur***
 public  int   Id_fournisseur {

get { return id_fournisseur; } 
set { id_fournisseur = value; }
}
  //***Accesseur de id_article***
 public  int   Id_article {

get { return id_article; } 
set { id_article = value; }
}
  //***Accesseur de conditionnement***
 public  int   Id_conditionnement {

get { return id_conditionnement; } 
set { id_conditionnement = value; }
}
 //***Accesseur de stock_out***
 public int Stock_out
 {
     get { return stock_out; }
     set { stock_out = value; }
 }
 //***Accesseur de designation***
 public string Designation
 {
     get { return designation; }
     set { designation = value; }
 }
} //***fin class

} //***fin namespace
