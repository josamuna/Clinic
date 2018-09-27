using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsservice 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsservice> listes(){
 return clsMetier.GetInstance().getAllClsservice();
}
 public  List<clsservice>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsservice(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsservice(this);
 }
 public  int  update(clsservice varscls){
 return clsMetier.GetInstance().updateClsservice(varscls);
 }
 public  int  delete(clsservice varscls){
 return clsMetier.GetInstance().deleteClsservice(varscls);
 }
  //***Le constructeur par defaut***
  public    clsservice() 
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
