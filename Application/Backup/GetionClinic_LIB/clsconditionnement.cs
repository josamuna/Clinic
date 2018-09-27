using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsconditionnement 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsconditionnement> listes(){
 return clsMetier.GetInstance().getAllClsconditionnement();
}
 public  List<clsconditionnement>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsconditionnement(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsconditionnement(this);
 }
 public  int  update(clsconditionnement varscls){
 return clsMetier.GetInstance().updateClsconditionnement(varscls);
 }
 public  int  delete(clsconditionnement varscls){
 return clsMetier.GetInstance().deleteClsconditionnement(varscls);
 }
  //***Le constructeur par defaut***
  public    clsconditionnement() 
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
