using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsdistrictville 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsdistrictville> listes(){
 return clsMetier.GetInstance().getAllClsdistrictville();
}
 public  List<clsdistrictville>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsdistrictville(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsdistrictville(this);
 }
 public  int  update(clsdistrictville varscls){
 return clsMetier.GetInstance().updateClsdistrictville(varscls);
 }
 public  int  delete(clsdistrictville varscls){
 return clsMetier.GetInstance().deleteClsdistrictville(varscls);
 }
  //***Le constructeur par defaut***
  public    clsdistrictville() 
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
