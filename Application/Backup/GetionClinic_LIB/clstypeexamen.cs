using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstypeexamen 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clstypeexamen> listes(){
 return clsMetier.GetInstance().getAllClstypeexamen();
}
 public  List<clstypeexamen>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstypeexamen(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstypeexamen(this);
 }
 public  int  update(clstypeexamen varscls){
 return clsMetier.GetInstance().updateClstypeexamen(varscls);
 }
 public  int  delete(clstypeexamen varscls){
 return clsMetier.GetInstance().deleteClstypeexamen(varscls);
 }
  //***Le constructeur par defaut***
  public    clstypeexamen() 
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
