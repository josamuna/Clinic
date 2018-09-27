using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsprovince 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsprovince> listes(){
 return clsMetier.GetInstance().getAllClsprovince();
}
 public  List<clsprovince>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsprovince(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsprovince(this);
 }
 public  int  update(clsprovince varscls){
 return clsMetier.GetInstance().updateClsprovince(varscls);
 }
 public  int  delete(clsprovince varscls){
 return clsMetier.GetInstance().deleteClsprovince(varscls);
 }
  //***Le constructeur par defaut***
  public    clsprovince() 
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
