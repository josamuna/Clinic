using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clscollectivitequartier 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clscollectivitequartier> listes(){
 return clsMetier.GetInstance().getAllClscollectivitequartier();
}
 public  List<clscollectivitequartier>   listes(string criteria){
 return clsMetier.GetInstance().getAllClscollectivitequartier(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClscollectivitequartier(this);
 }
 public  int  update(clscollectivitequartier varscls){
 return clsMetier.GetInstance().updateClscollectivitequartier(varscls);
 }
 public  int  delete(clscollectivitequartier varscls){
 return clsMetier.GetInstance().deleteClscollectivitequartier(varscls);
 }
  //***Le constructeur par defaut***
  public    clscollectivitequartier() 
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

} //***fin class

} //***fin namespace
