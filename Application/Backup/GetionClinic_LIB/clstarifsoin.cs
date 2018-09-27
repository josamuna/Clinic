using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifsoin 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;
 private int id_de_dossiersoin;

  //***Listes***
  public List<clstarifsoin> listes(){
 return clsMetier.GetInstance().getAllClstarifsoin();
}
 public  List<clstarifsoin>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifsoin(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifsoin(this);
 }
 public  int  update(clstarifsoin varscls){
 return clsMetier.GetInstance().updateClstarifsoin(varscls);
 }
 public  int  delete(clstarifsoin varscls){
 return clsMetier.GetInstance().deleteClstarifsoin(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifsoin() 
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
  //***Accesseur de montant***
 public  double ?   Montant {

get { return montant; } 
set { montant = value; }
}
 public string DesignationComplete
 {
     get { return designationComplete; }
     set { designationComplete = value; }
 }
 //***Accesseur de id_de_dossiersoin***
 public int Id_de_dossiersoin
 {
     get { return id_de_dossiersoin; }
     set { id_de_dossiersoin = value; }
 }
 public override string ToString()
 {
     return DesignationComplete;
 }
} //***fin class

} //***fin namespace
