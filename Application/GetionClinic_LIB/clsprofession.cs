using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsprofession 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsprofession> listes(){
 return clsMetier.GetInstance().getAllClsprofession();
}
 public  List<clsprofession>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsprofession(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsprofession(this);
 }
 public  int  update(clsprofession varscls){
 return clsMetier.GetInstance().updateClsprofession(varscls);
 }
 public  int  delete(clsprofession varscls){
 return clsMetier.GetInstance().deleteClsprofession(varscls);
 }
  //***Le constructeur par defaut***
  public    clsprofession() 
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
